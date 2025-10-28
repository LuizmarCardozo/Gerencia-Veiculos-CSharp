using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using VeiculosApp.Data;
using VeiculosApp.Models;

namespace VeiculosApp
{
    public partial class MainForm : Form
    {
        private readonly VeiculoRepository _repo = new();
        private BindingList<Veiculo> _dados = new();
        private BindingList<Veiculo> _view = new();

        // Navegação de fotos
        private int _fotoIndex = 0;

        public MainForm()
        {
            InitializeComponent();
            CarregarDados();
            ConfigurarBindings();

            // Botões
            btnNovo.Click += btnNovo_Click;
            btnEditar.Click += btnEditar_Click;
            btnExcluir.Click += btnExcluir_Click;

            // Navegação de fotos
            btnFotoAnterior.Click += (s, e) => TrocarFoto(-1);
            btnFotoProxima.Click += (s, e) => TrocarFoto(+1);
        }

        private void CarregarDados()
        {
            var lista = _repo.CarregarTodos();
            _dados = new BindingList<Veiculo>(lista);
            _view = new BindingList<Veiculo>(_dados.ToList());
        }

        private void ConfigurarBindings()
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = _view;

            // Aparência / comportamento
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;

            // Esconde/renomeia colunas sempre que o binding completar
            dataGridView1.DataBindingComplete += (s, e) =>
            {
                if (dataGridView1.Columns["Id"] != null)
                    dataGridView1.Columns["Id"].Visible = false;
                if (dataGridView1.Columns["Imagens"] != null)
                    dataGridView1.Columns["Imagens"].Visible = false;
                if (dataGridView1.Columns["CaminhoImagem"] != null)
                    dataGridView1.Columns["CaminhoImagem"].Visible = false;

                if (dataGridView1.Columns["PrimeiraImagem"] != null)
                    dataGridView1.Columns["PrimeiraImagem"].HeaderText = "Imagem (1ª)";
                if (dataGridView1.Columns["Fotos"] != null)
                    dataGridView1.Columns["Fotos"].HeaderText = "Fotos";
                if (dataGridView1.Columns["Preco"] != null)
                    dataGridView1.Columns["Preco"].DefaultCellStyle.Format = "C2";
            };

            // Eventos de UI
            dataGridView1.SelectionChanged += Grid_SelectionChanged;
            textBox1.TextChanged += TxtBusca_TextChanged;

            AtualizarPreview();
        }

        private void TxtBusca_TextChanged(object? sender, EventArgs e)
        {
            var q = (textBox1.Text ?? string.Empty).Trim().ToLowerInvariant();

            var filtrado = string.IsNullOrWhiteSpace(q)
                ? _dados.ToList()
                : _dados.Where(v =>
                        (v.Marca ?? string.Empty).ToLower().Contains(q) ||
                        (v.Modelo ?? string.Empty).ToLower().Contains(q) ||
                        v.Ano.ToString().Contains(q))
                    .ToList();

            _view = new BindingList<Veiculo>(filtrado);
            dataGridView1.DataSource = _view; // DataBindingComplete ajusta cabeçalhos/visibilidade
            AtualizarPreview();
        }

        private Veiculo? Selecionado() => dataGridView1.CurrentRow?.DataBoundItem as Veiculo;

        private void Grid_SelectionChanged(object? sender, EventArgs e) => AtualizarPreview();

        private void AtualizarPreview()
        {
            var v = Selecionado();
            if (v is null)
            {
                pictureBox1.Image = null;
                lblMarcaVal.Text = lblModeloVal.Text = lblAnoVal.Text = lblPrecoVal.Text = "";
                lblFotoIndex.Text = "0/0";
                return;
            }

            _fotoIndex = 0;
            AtualizarFotoEVersao(v);

            lblMarcaVal.Text = v.Marca ?? "";
            lblModeloVal.Text = v.Modelo ?? "";
            lblAnoVal.Text = v.Ano.ToString();
            lblPrecoVal.Text = v.Preco.ToString("C2");
        }

        private void AtualizarFotoEVersao(Veiculo v)
        {
            if (v.Imagens == null || v.Imagens.Count == 0)
            {
                pictureBox1.Image = null;
                lblFotoIndex.Text = "0/0";
                return;
            }
            if (_fotoIndex < 0 || _fotoIndex >= v.Imagens.Count) _fotoIndex = 0;

            var rel = v.Imagens[_fotoIndex];
            var abs = _repo.CaminhoAbsolutoDaImagem(rel);
            pictureBox1.ImageLocation = System.IO.File.Exists(abs) ? abs : null;
            lblFotoIndex.Text = $"{_fotoIndex + 1}/{v.Imagens.Count}";
        }

        private void TrocarFoto(int delta)
        {
            var v = Selecionado();
            if (v == null || v.Imagens == null || v.Imagens.Count == 0) return;
            _fotoIndex += delta;
            if (_fotoIndex < 0) _fotoIndex = v.Imagens.Count - 1;
            if (_fotoIndex >= v.Imagens.Count) _fotoIndex = 0;
            AtualizarFotoEVersao(v);
        }

        private void btnNovo_Click(object? sender, EventArgs e)
        {
            using var dlg = new VeiculoForm();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _dados.Add(dlg.Veiculo);
                Persistir();
                TxtBusca_TextChanged(null, EventArgs.Empty);
            }
        }

        private void btnEditar_Click(object? sender, EventArgs e)
        {
            var v = Selecionado();
            if (v == null) return;

            var temp = new Veiculo
            {
                Id = v.Id,
                Marca = v.Marca,
                Modelo = v.Modelo,
                Ano = v.Ano,
                Preco = v.Preco,
                Imagens = v.Imagens?.ToList() ?? new()
            };

            using var dlg = new VeiculoForm(temp);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                v.Marca = temp.Marca;
                v.Modelo = temp.Modelo;
                v.Ano = temp.Ano;
                v.Preco = temp.Preco;
                v.Imagens = temp.Imagens;
                dataGridView1.Refresh();
                Persistir();
                AtualizarPreview();
            }
        }

        private void btnExcluir_Click(object? sender, EventArgs e)
        {
            var v = Selecionado();
            if (v == null) return;

            if (MessageBox.Show($"Excluir '{v.Marca} {v.Modelo}'?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _dados.Remove(v);
                Persistir();
                TxtBusca_TextChanged(null, EventArgs.Empty);
            }
        }

        private void Persistir() => _repo.SalvarTodos(_dados.ToList());
    }
}
