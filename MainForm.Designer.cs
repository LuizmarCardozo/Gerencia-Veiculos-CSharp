namespace VeiculosApp
{
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
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 560);
            Name = "MainForm";
            Text = "Gerenciador de Veículos";

            // ========== SPLIT ESQ/DIR ==========
            splitLeftRight.Dock = DockStyle.Fill;
            splitLeftRight.FixedPanel = FixedPanel.Panel1;
            splitLeftRight.Location = new Point(0, 0);
            splitLeftRight.Name = "splitLeftRight";
            splitLeftRight.Size = new Size(980, 560);
            splitLeftRight.SplitterDistance = 140;
            splitLeftRight.TabIndex = 0;

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

            btnNovo.Text = "Novo";
            btnNovo.Dock = DockStyle.Fill;
            btnNovo.Margin = new Padding(0, 0, 0, 6);

            btnEditar.Text = "Editar";
            btnEditar.Dock = DockStyle.Fill;
            btnEditar.Margin = new Padding(0, 0, 0, 6);

            btnExcluir.Text = "Excluir";
            btnExcluir.Dock = DockStyle.Fill;

            splitLeftRight.Panel1.Controls.Add(tlpLeft);

            // ----- DIREITA (split vertical)
            splitRight.Dock = DockStyle.Fill;
            splitRight.Orientation = Orientation.Horizontal; // topo detalhes / baixo grid
            splitRight.SplitterDistance = 360;
            splitLeftRight.Panel2.Controls.Add(splitRight);

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

            // Foto
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            tlpDetail.SetColumnSpan(pictureBox1, 2);
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            // Labels estáticos
            lblMarca.Text = "Marca:";
            lblModelo.Text = "Modelo:";
            lblAno.Text = "Ano:";
            lblPreco.Text = "Preço:";
            lblMarca.TextAlign = ContentAlignment.MiddleRight;
            lblModelo.TextAlign = ContentAlignment.MiddleRight;
            lblAno.TextAlign = ContentAlignment.MiddleRight;
            lblPreco.TextAlign = ContentAlignment.MiddleRight;
            lblMarca.Dock = lblModelo.Dock = lblAno.Dock = lblPreco.Dock = DockStyle.Fill;

            // Valores
            lblMarcaVal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblModeloVal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAnoVal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPrecoVal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMarcaVal.Dock = lblModeloVal.Dock = lblAnoVal.Dock = lblPrecoVal.Dock = DockStyle.Fill;

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
            navTlp.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));     // centro
            navTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F)); // filler dir

            navFlow.AutoSize = true;
            navFlow.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            navFlow.FlowDirection = FlowDirection.LeftToRight;
            navFlow.WrapContents = false;
            navFlow.Anchor = AnchorStyles.None;

            btnFotoAnterior.Text = "◀";
            btnFotoAnterior.Width = 36;
            btnFotoAnterior.Height = 28;
            btnFotoAnterior.Margin = new Padding(0, 0, 8, 0);

            lblFotoIndex.AutoSize = true;
            lblFotoIndex.Text = "0/0";
            lblFotoIndex.Margin = new Padding(0, 5, 8, 0);

            btnFotoProxima.Text = "▶";
            btnFotoProxima.Width = 36;
            btnFotoProxima.Height = 28;
            btnFotoProxima.Margin = new Padding(0);

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

            lblBuscar.Text = "Buscar:";
            lblBuscar.AutoSize = true;
            lblBuscar.Dock = DockStyle.Left;

            textBox1.Dock = DockStyle.Fill;
            textBox1.Margin = new Padding(8, 0, 0, 0);
            textBox1.PlaceholderText = "marca / modelo / ano";

            pnlBottomTop.Controls.Add(textBox1);
            pnlBottomTop.Controls.Add(lblBuscar);

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

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
