using System;
using System.Linq;
using System.Windows.Forms;
using VeiculosApp.Data;
using VeiculosApp.Models;

namespace VeiculosApp
{
    public partial class VeiculoForm : Form
    {
        private readonly VeiculoRepository _repo = new();
        public Veiculo Veiculo { get; private set; }
        private int _selIndex = -1;

        public VeiculoForm(Veiculo? veiculo = null)
        {
            InitializeComponent();
            Veiculo = veiculo ?? new Veiculo();
            WireEvents();
            PreencherCampos();
        }

        private void WireEvents()
        {
            btnAddFotos.Click += btnAddFotos_Click;
            btnRemoverFoto.Click += btnRemoverFoto_Click;
            lstImagens.SelectedIndexChanged += lstImagens_SelectedIndexChanged;
            // DELETE remove imagens
            lstImagens.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Delete) { btnRemoverFoto.PerformClick(); e.Handled = true; }
            };

            btnSalvar.Click += btnSalvar_Click;
            btnCancelar.Click += btnCancelar_Click;
        }

        private void PreencherCampos()
        {
            txtMarca.Text = Veiculo.Marca ?? string.Empty;
            txtModelo.Text = Veiculo.Modelo ?? string.Empty;

            numAno.Value = Veiculo.Ano > 0 ? Veiculo.Ano : DateTime.Now.Year;
            numPreco.Value = Veiculo.Preco > 0 ? Veiculo.Preco : 0m;

            // Carregar lista (migrar legado se houver)
            lstImagens.Items.Clear();
            if (Veiculo.Imagens != null && Veiculo.Imagens.Count > 0)
            {
                foreach (var rel in Veiculo.Imagens) lstImagens.Items.Add(rel);
            }
            else if (!string.IsNullOrWhiteSpace(Veiculo.CaminhoImagem))
            {
                Veiculo.Imagens = new System.Collections.Generic.List<string> { Veiculo.CaminhoImagem };
                lstImagens.Items.Add(Veiculo.CaminhoImagem);
                Veiculo.CaminhoImagem = null;
            }

            if (lstImagens.Items.Count > 0)
                lstImagens.SelectedIndex = 0;
            else
                picFoto.Image = null;

            AtualizarPreview();
        }

        private void lstImagens_SelectedIndexChanged(object? sender, EventArgs e)
        {
            _selIndex = lstImagens.SelectedIndex;
            AtualizarPreview();
        }

        // Preview NÃO modifica a lista; só mostra a imagem
        private void AtualizarPreview()
        {
            if (_selIndex < 0 || _selIndex >= lstImagens.Items.Count)
            {
                picFoto.Image = null;
                return;
            }

            var item = lstImagens.Items[_selIndex]!.ToString()!;
            // Se for relativo (Images/...), converte p/ absoluto; se já for absoluto, usa como está
            var abs = (item.StartsWith("Images\\") || item.StartsWith("Images/"))
                ? _repo.CaminhoAbsolutoDaImagem(item)
                : item;

            if (System.IO.File.Exists(abs))
                picFoto.ImageLocation = abs;
            else
                picFoto.Image = null;
        }

        private void btnAddFotos_Click(object? sender, EventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                Filter = "Imagens|*.jpg;*.jpeg;*.png;*.bmp",
                Multiselect = true
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                foreach (var path in dlg.FileNames) lstImagens.Items.Add(path);
                if (lstImagens.Items.Count > 0)
                    lstImagens.SelectedIndex = lstImagens.Items.Count - 1;
            }
        }

        private void btnRemoverFoto_Click(object? sender, EventArgs e)
        {
            var idx = lstImagens.SelectedIndex;
            if (idx < 0 || lstImagens.Items.Count == 0) return;

            lstImagens.Items.RemoveAt(idx);
            if (lstImagens.Items.Count > 0)
                lstImagens.SelectedIndex = Math.Min(idx, lstImagens.Items.Count - 1);
            else
                picFoto.Image = null;
        }

        private void btnSalvar_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMarca.Text)) { MessageBox.Show("Informe a Marca."); return; }
            if (string.IsNullOrWhiteSpace(txtModelo.Text)) { MessageBox.Show("Informe o Modelo."); return; }

            Veiculo.Marca = txtMarca.Text.Trim();
            Veiculo.Modelo = txtModelo.Text.Trim();
            Veiculo.Ano = (int)numAno.Value;
            Veiculo.Preco = numPreco.Value;

            // Normaliza: copia arquivos absolutos para Images/ e guarda relativo
            var finais = lstImagens.Items.Cast<object>()
                          .Select(o => o?.ToString() ?? "")
                          .Where(s => !string.IsNullOrWhiteSpace(s))
                          .Select(s =>
                              (s.StartsWith("Images\\") || s.StartsWith("Images/"))
                              ? s
                              : _repo.CopiarImagemParaRepositorio(s))
                          .Where(s => !string.IsNullOrWhiteSpace(s))
                          .ToList();

            Veiculo.Imagens = finais;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
