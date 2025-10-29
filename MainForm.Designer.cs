namespace VeiculosApp
{
    using System.Drawing;
    // Adicionado para estilos do Grid e Padding
    using System.Windows.Forms;

    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // ESQUERDA
        private System.Windows.Forms.SplitContainer splitLeftRight;
        private System.Windows.Forms.TableLayoutPanel tlpLeft;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnExcluir;

        // DIREITA
        private System.Windows.Forms.SplitContainer splitRight; // Orientation = Horizontal

        // TOPO (DETALHES)
        private System.Windows.Forms.TableLayoutPanel tlpDetail;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.Label lblAno;
        private System.Windows.Forms.Label lblPreco;
        private System.Windows.Forms.Label lblMarcaVal;
        private System.Windows.Forms.Label lblModeloVal;
        private System.Windows.Forms.Label lblAnoVal;
        private System.Windows.Forms.Label lblPrecoVal;

        // NAV DE FOTOS (centralizada)
        private System.Windows.Forms.TableLayoutPanel navTlp;
        private System.Windows.Forms.FlowLayoutPanel navFlow;
        private System.Windows.Forms.Button btnFotoAnterior;
        private System.Windows.Forms.Button btnFotoProxima;
        private System.Windows.Forms.Label lblFotoIndex;

        // BASE (BUSCA + GRID)
        private System.Windows.Forms.Panel pnlBottomTop;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // O Designer espera que as inicializações de componentes venham primeiro.
            splitLeftRight = new SplitContainer();
            tlpLeft = new TableLayoutPanel();
            btnNovo = new Button();
            btnEditar = new Button();
            btnExcluir = new Button();

            splitRight = new SplitContainer();

            tlpDetail = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            lblMarca = new Label();
            lblMarcaVal = new Label();
            lblModelo = new Label();
            lblModeloVal = new Label();
            lblAno = new Label();
            lblAnoVal = new Label();
            lblPreco = new Label();
            lblPrecoVal = new Label();

            navTlp = new TableLayoutPanel();
            navFlow = new FlowLayoutPanel();
            btnFotoAnterior = new Button();
            lblFotoIndex = new Label();
            btnFotoProxima = new Button();

            dataGridView1 = new DataGridView();
            pnlBottomTop = new Panel();
            textBox1 = new TextBox();
            lblBuscar = new Label();

            // --- [ESTILO MODERNO LIMPO] ---
            // Definindo nossas cores
            var azulPrincipal = Color.FromArgb(0, 120, 212);
            var azulMouseOver = Color.FromArgb(0, 90, 158);
            var cinzaFundoClaro = Color.FromArgb(245, 245, 245); // Fundo para linhas alternadas
            var azulSelecaoGrid = Color.FromArgb(204, 232, 255); // Seleção de grid bem clara
            var textoEscuro = Color.FromArgb(30, 30, 30);
            var textoClaro = Color.White;
            var fundoBranco = Color.White;
            var fundoForm = Color.FromArgb(245, 245, 245); // Fundo geral CINZA bem claro

            // Definindo estilos da tabela
            var estiloCabecalhoGrid = new DataGridViewCellStyle();
            estiloCabecalhoGrid.BackColor = azulPrincipal;
            estiloCabecalhoGrid.ForeColor = textoClaro;
            estiloCabecalhoGrid.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            estiloCabecalhoGrid.Alignment = DataGridViewContentAlignment.MiddleLeft;
            estiloCabecalhoGrid.Padding = new Padding(5);
            // --- [CORREÇÃO] --- Impede que o fundo mude ao selecionar o cabeçalho
            estiloCabecalhoGrid.SelectionBackColor = azulPrincipal;

            var estiloLinhaPadrao = new DataGridViewCellStyle();
            estiloLinhaPadrao.BackColor = fundoBranco;
            estiloLinhaPadrao.ForeColor = textoEscuro;
            estiloLinhaPadrao.SelectionBackColor = azulSelecaoGrid;
            estiloLinhaPadrao.SelectionForeColor = textoEscuro; // Texto escuro na seleção clara
            estiloLinhaPadrao.Padding = new Padding(5, 0, 5, 0);
            estiloLinhaPadrao.Alignment = DataGridViewContentAlignment.MiddleLeft;

            var estiloLinhaAlternada = new DataGridViewCellStyle();
            estiloLinhaAlternada.BackColor = cinzaFundoClaro; // Linha alternada cinza claro
            estiloLinhaAlternada.ForeColor = textoEscuro;
            estiloLinhaAlternada.SelectionBackColor = azulSelecaoGrid;
            estiloLinhaAlternada.SelectionForeColor = textoEscuro; // Texto escuro na seleção clara
            estiloLinhaAlternada.Padding = new Padding(5, 0, 5, 0);
            estiloLinhaAlternada.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // --- [FIM ESTILO] ---

            ((System.ComponentModel.ISupportInitialize)splitLeftRight).BeginInit();
            splitLeftRight.Panel1.SuspendLayout();
            splitLeftRight.Panel2.SuspendLayout();
            splitLeftRight.SuspendLayout();

            tlpLeft.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)splitRight).BeginInit();
            splitRight.Panel1.SuspendLayout();
            splitRight.Panel2.SuspendLayout();
            splitRight.SuspendLayout();

            tlpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();

            navTlp.SuspendLayout();
            navFlow.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            pnlBottomTop.SuspendLayout();
            SuspendLayout();

            // ========== FORM ==========
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font; // Mantendo em Font para sua solução de compatibilidade
            ClientSize = new Size(980, 560);
            Name = "MainForm";
            Text = "Gerenciador de Veículos";
            // --- [ESTILO MODERNO] ---
            BackColor = fundoForm; // Fundo geral do Form (cinza-claro)

            // ========== SPLIT ESQ/DIR ==========
            splitLeftRight.Dock = DockStyle.Fill;
            splitLeftRight.FixedPanel = FixedPanel.Panel1;
            splitLeftRight.Location = new Point(0, 0);
            splitLeftRight.Name = "splitLeftRight";
            splitLeftRight.Size = new Size(980, 560);
            splitLeftRight.SplitterDistance = 140;
            splitLeftRight.TabIndex = 0;
            // --- [ESTILO MODERNO] ---
            splitLeftRight.BackColor = Color.Transparent; // Deixa o splitter transparente
            splitLeftRight.Panel1.BackColor = Color.Transparent; // Painel esquerdo transparente (mostra fundo do form)
            splitLeftRight.Panel2.BackColor = fundoBranco; // Painel direito (conteúdo) branco

            // ----- ESQUERDA
            tlpLeft.ColumnCount = 1;
            tlpLeft.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpLeft.Controls.Add(btnNovo, 0, 0);
            tlpLeft.Controls.Add(btnEditar, 0, 1);
            tlpLeft.Controls.Add(btnExcluir, 0, 2);
            tlpLeft.Dock = DockStyle.Fill;
            tlpLeft.Padding = new Padding(8);
            tlpLeft.RowCount = 6;
            tlpLeft.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tlpLeft.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tlpLeft.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tlpLeft.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpLeft.RowStyles.Add(new RowStyle(SizeType.Absolute, 1F));
            tlpLeft.RowStyles.Add(new RowStyle(SizeType.Absolute, 1F));
            // --- [ESTILO MODERNO] ---
            tlpLeft.BackColor = Color.Transparent; // Painel dos botões transparente

            btnNovo.Text = "   +   Novo";
            btnNovo.Dock = DockStyle.Fill;
            btnNovo.Margin = new Padding(0, 0, 0, 6);
            // --- [ESTILO MODERNO] ---
            btnNovo.FlatStyle = FlatStyle.Flat;
            btnNovo.FlatAppearance.BorderSize = 0;
            btnNovo.BackColor = azulPrincipal;
            btnNovo.ForeColor = textoClaro;
            btnNovo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNovo.FlatAppearance.MouseOverBackColor = azulMouseOver;
            btnNovo.TextAlign = ContentAlignment.MiddleLeft; // Alinha texto (e ícone) à esquerda


            btnEditar.Text = "   ✎   Editar";
            btnEditar.Dock = DockStyle.Fill;
            btnEditar.Margin = new Padding(0, 0, 0, 6);
            // --- [ESTILO MODERNO] ---
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.BackColor = azulPrincipal;
            btnEditar.ForeColor = textoClaro;
            btnEditar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEditar.FlatAppearance.MouseOverBackColor = azulMouseOver;
            btnEditar.TextAlign = ContentAlignment.MiddleLeft;

            btnExcluir.Text = "   ✕   Excluir";
            btnExcluir.Dock = DockStyle.Fill;
            // --- [ESTILO MODERNO] ---
            btnExcluir.FlatStyle = FlatStyle.Flat;
            btnExcluir.FlatAppearance.BorderSize = 0;
            btnExcluir.BackColor = azulPrincipal;
            btnExcluir.ForeColor = textoClaro;
            btnExcluir.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExcluir.FlatAppearance.MouseOverBackColor = azulMouseOver;
            btnExcluir.TextAlign = ContentAlignment.MiddleLeft;


            splitLeftRight.Panel1.Controls.Add(tlpLeft);

            // ----- DIREITA (split vertical)
            splitRight.Dock = DockStyle.Fill;
            splitRight.Orientation = Orientation.Horizontal; // topo detalhes / baixo grid
            splitRight.SplitterDistance = 360;
            splitLeftRight.Panel2.Controls.Add(splitRight);
            // --- [ESTILO MODERNO] ---
            splitRight.BackColor = fundoBranco; // Fundo do painel direito
            splitRight.Panel1.BackColor = fundoBranco; // Fundo do painel de detalhes
            splitRight.Panel2.BackColor = fundoBranco; // Fundo do painel do grid

            // ========== TOPO: DETALHES + FOTO ==========
            tlpDetail.ColumnCount = 2;
            tlpDetail.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            tlpDetail.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpDetail.Dock = DockStyle.Fill;
            tlpDetail.Padding = new Padding(12, 12, 12, 8);
            tlpDetail.RowCount = 5;
            tlpDetail.RowStyles.Add(new RowStyle(SizeType.Absolute, 220F)); // foto
            tlpDetail.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tlpDetail.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tlpDetail.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tlpDetail.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            // --- [ESTILO MODERNO] ---
            tlpDetail.BackColor = fundoBranco; // Fundo do painel de detalhes

            // Foto
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            tlpDetail.SetColumnSpan(pictureBox1, 2);
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            // --- [ESTILO MODERNO] ---
            pictureBox1.BackColor = Color.FromArgb(250, 250, 250); // Fundo levemente cinza para a foto

            // Labels estáticos
            lblMarca.Text = "Marca:";
            lblModelo.Text = "Modelo:";
            lblAno.Text = "Ano:";
            lblPreco.Text = "Preço:";
            lblMarca.TextAlign = ContentAlignment.MiddleRight;
            lblModelo.TextAlign = ContentAlignment.MiddleRight;
            lblAno.TextAlign = ContentAlignment.MiddleRight;
            lblPreco.TextAlign = ContentAlignment.MiddleRight;
            // --- [ESTILO MODERNO] ---
            lblMarca.BackColor = fundoBranco;
            lblModelo.BackColor = fundoBranco;
            lblAno.BackColor = fundoBranco;
            lblPreco.BackColor = fundoBranco;
            lblMarca.ForeColor = textoEscuro;
            lblModelo.ForeColor = textoEscuro;
            lblAno.ForeColor = textoEscuro;
            lblPreco.ForeColor = textoEscuro;

            // --- [CORREÇÃO DESIGNER] --- (Para o designer não quebrar)
            lblMarca.Dock = DockStyle.Fill;
            lblModelo.Dock = DockStyle.Fill;
            lblAno.Dock = DockStyle.Fill;
            lblPreco.Dock = DockStyle.Fill;

            // Valores
            lblMarcaVal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblModeloVal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAnoVal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPrecoVal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            // --- [NOVA CORREÇÃO DE ALINHAMENTO] ---
            lblMarcaVal.TextAlign = ContentAlignment.MiddleLeft;
            lblModeloVal.TextAlign = ContentAlignment.MiddleLeft;
            lblAnoVal.TextAlign = ContentAlignment.MiddleLeft;
            lblPrecoVal.TextAlign = ContentAlignment.MiddleLeft;

            // --- [ESTILO MODERNO] ---
            lblMarcaVal.BackColor = fundoBranco;
            lblModeloVal.BackColor = fundoBranco;
            lblAnoVal.BackColor = fundoBranco;
            lblPrecoVal.BackColor = fundoBranco;
            lblMarcaVal.ForeColor = azulPrincipal; // Cor de destaque
            lblModeloVal.ForeColor = azulPrincipal; // Cor de destaque
            lblAnoVal.ForeColor = azulPrincipal; // Cor de destaque
            lblPrecoVal.ForeColor = azulPrincipal; // Cor de destaque


            // --- [CORREÇÃO DESIGNER] --- (Para o designer não quebrar)
            lblMarcaVal.Dock = DockStyle.Fill;
            lblModeloVal.Dock = DockStyle.Fill;
            lblAnoVal.Dock = DockStyle.Fill;
            lblPrecoVal.Dock = DockStyle.Fill;

            // Monta detahes
            tlpDetail.Controls.Add(pictureBox1, 0, 0);
            tlpDetail.Controls.Add(lblMarca, 0, 1);
            tlpDetail.Controls.Add(lblMarcaVal, 1, 1);
            tlpDetail.Controls.Add(lblModelo, 0, 2);
            tlpDetail.Controls.Add(lblModeloVal, 1, 2);
            tlpDetail.Controls.Add(lblAno, 0, 3);
            tlpDetail.Controls.Add(lblAnoVal, 1, 3);
            tlpDetail.Controls.Add(lblPreco, 0, 4);
            tlpDetail.Controls.Add(lblPrecoVal, 1, 4);

            // ===== Navegação de fotos (centralizada, estável)
            navTlp.Dock = DockStyle.Bottom;
            navTlp.Height = 40;
            navTlp.Padding = new Padding(0, 4, 0, 6);
            navTlp.RowCount = 1;
            navTlp.ColumnCount = 3;
            navTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F)); // filler esq
            navTlp.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize)); // centro
            navTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F)); // filler dir
            // --- [ESTILO MODERNO] ---
            navTlp.BackColor = fundoBranco;

            navFlow.AutoSize = true;
            navFlow.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            navFlow.FlowDirection = FlowDirection.LeftToRight;
            navFlow.WrapContents = false;
            navFlow.Anchor = AnchorStyles.None;
            // --- [ESTILO MODERNO] ---
            navFlow.BackColor = fundoBranco;


            btnFotoAnterior.Text = "◀";
            btnFotoAnterior.Width = 36;
            btnFotoAnterior.Height = 28;
            btnFotoAnterior.Margin = new Padding(0, 0, 8, 0);
            // --- [ESTILO MODERNO] ---
            btnFotoAnterior.FlatStyle = FlatStyle.Flat;
            btnFotoAnterior.BackColor = cinzaFundoClaro; // Fundo mais claro
            btnFotoAnterior.ForeColor = azulPrincipal;


            lblFotoIndex.AutoSize = true;
            lblFotoIndex.Text = "0/0";
            lblFotoIndex.Margin = new Padding(0, 5, 8, 0);

            btnFotoProxima.Text = "▶";
            btnFotoProxima.Width = 36;
            btnFotoProxima.Height = 28;
            btnFotoProxima.Margin = new Padding(0);
            // --- [ESTILO MODERNO] ---
            btnFotoProxima.FlatStyle = FlatStyle.Flat;
            btnFotoProxima.BackColor = cinzaFundoClaro; // Fundo mais claro
            btnFotoProxima.ForeColor = azulPrincipal;

            navFlow.Controls.Add(btnFotoAnterior);
            navFlow.Controls.Add(lblFotoIndex);
            navFlow.Controls.Add(btnFotoProxima);

            navTlp.Controls.Add(navFlow, 1, 0);

            // Adiciona ao topo (Panel1 do splitRight)
            splitRight.Panel1.Controls.Add(tlpDetail);
            splitRight.Panel1.Controls.Add(navTlp);

            // ========== BASE: BUSCA + GRID ==========
            pnlBottomTop.Dock = DockStyle.Top;
            pnlBottomTop.Padding = new Padding(8, 8, 8, 6);
            pnlBottomTop.Height = 38;
            // --- [ESTILO MODERNO] ---
            pnlBottomTop.BackColor = fundoBranco;

            lblBuscar.Text = "Buscar:";
            lblBuscar.AutoSize = true;
            lblBuscar.Dock = DockStyle.Left;
            // --- [ESTILO MODERNO] ---
            lblBuscar.BackColor = Color.Transparent;


            textBox1.Dock = DockStyle.Fill;
            textBox1.Margin = new Padding(8, 0, 0, 0);
            textBox1.PlaceholderText = "marca / modelo / ano";
            // --- [ESTILO MODERNO] ---
            textBox1.BorderStyle = BorderStyle.FixedSingle; // Borda sutil


            pnlBottomTop.Controls.Add(textBox1);
            pnlBottomTop.Controls.Add(lblBuscar);

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // --- [ESTILO MODERNO] ---
            dataGridView1.BackgroundColor = fundoBranco;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.GridColor = cinzaFundoClaro; // Cor da grade mais clara
            dataGridView1.EnableHeadersVisualStyles = false; // Essencial para estilizar cabeçalho
            dataGridView1.RowTemplate.Height = 32; // Mais espaçamento
            dataGridView1.ColumnHeadersHeight = 40; // Cabeçalho mais alto
            dataGridView1.ColumnHeadersDefaultCellStyle = estiloCabecalhoGrid;
            dataGridView1.DefaultCellStyle = estiloLinhaPadrao;
            dataGridView1.AlternatingRowsDefaultCellStyle = estiloLinhaAlternada;


            splitRight.Panel2.Controls.Add(dataGridView1);
            splitRight.Panel2.Controls.Add(pnlBottomTop);

            // ========== ADD ROOT ==========
            Controls.Add(splitLeftRight);

            splitLeftRight.Panel1.ResumeLayout(false);
            splitLeftRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitLeftRight).EndInit();
            splitLeftRight.ResumeLayout(false);

            tlpLeft.ResumeLayout(false);

            splitRight.Panel1.ResumeLayout(false);
            splitRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitRight).EndInit();
            splitRight.ResumeLayout(false);

            tlpDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();

            navTlp.ResumeLayout(false);
            navTlp.PerformLayout();
            navFlow.ResumeLayout(false);
            navFlow.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            pnlBottomTop.ResumeLayout(false);
            pnlBottomTop.PerformLayout();

            ResumeLayout(false);
        }
    }
}

