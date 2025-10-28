namespace VeiculosApp
{
    partial class VeiculoForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TableLayoutPanel root;      // 2 colunas: campos | foto
        private System.Windows.Forms.TableLayoutPanel formLeft;  // campos (labels/inputs)
        private System.Windows.Forms.Label lblMarca, lblModelo, lblAno, lblPreco;
        private System.Windows.Forms.TextBox txtMarca, txtModelo;
        private System.Windows.Forms.NumericUpDown numAno, numPreco;

        private System.Windows.Forms.PictureBox picFoto;         // preview grande (direita)

        private System.Windows.Forms.Label lblLista;
        private System.Windows.Forms.ListBox lstImagens;
        private System.Windows.Forms.FlowLayoutPanel flowBtns;   // Add/Remover
        private System.Windows.Forms.Button btnAddFotos, btnRemoverFoto;

        private System.Windows.Forms.FlowLayoutPanel footer;     // rodapé
        private System.Windows.Forms.Button btnSalvar, btnCancelar;

        private System.Windows.Forms.OpenFileDialog dlgAbrirImagem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // ===== raiz =====
            root = new System.Windows.Forms.TableLayoutPanel();
            root.Dock = System.Windows.Forms.DockStyle.Fill;
            root.Padding = new System.Windows.Forms.Padding(12);
            root.ColumnCount = 2;
            root.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 320F)); // campos
            root.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F)); // foto
            root.RowCount = 4;
            root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 210F)); // campos/foto
            root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));  // label lista
            root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));  // listbox
            root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));  // rodapé

            // ===== esquerda: campos =====
            formLeft = new System.Windows.Forms.TableLayoutPanel();
            formLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            formLeft.ColumnCount = 2;
            formLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F)); // labels
            formLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F)); // inputs
            formLeft.RowCount = 4;
            formLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            formLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            formLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            formLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));

            lblMarca = new System.Windows.Forms.Label { Text = "Marca", Dock = System.Windows.Forms.DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
            lblModelo = new System.Windows.Forms.Label { Text = "Modelo", Dock = System.Windows.Forms.DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
            lblAno = new System.Windows.Forms.Label { Text = "Ano", Dock = System.Windows.Forms.DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
            lblPreco = new System.Windows.Forms.Label { Text = "Preço", Dock = System.Windows.Forms.DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleLeft };

            txtMarca = new System.Windows.Forms.TextBox { Dock = System.Windows.Forms.DockStyle.Fill };
            txtModelo = new System.Windows.Forms.TextBox { Dock = System.Windows.Forms.DockStyle.Fill };
            numAno = new System.Windows.Forms.NumericUpDown { Dock = System.Windows.Forms.DockStyle.Left, Minimum = 1900, Maximum = 2100, Width = 120 };
            numPreco = new System.Windows.Forms.NumericUpDown { Dock = System.Windows.Forms.DockStyle.Left, DecimalPlaces = 2, Maximum = 100000000m, Width = 120 };

            formLeft.Controls.Add(lblMarca, 0, 0);
            formLeft.Controls.Add(txtMarca, 1, 0);
            formLeft.Controls.Add(lblModelo, 0, 1);
            formLeft.Controls.Add(txtModelo, 1, 1);
            formLeft.Controls.Add(lblAno, 0, 2);
            formLeft.Controls.Add(numAno, 1, 2);
            formLeft.Controls.Add(lblPreco, 0, 3);
            formLeft.Controls.Add(numPreco, 1, 3);

            // ===== direita: foto grande =====
            picFoto = new System.Windows.Forms.PictureBox
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            };

            // ===== label lista =====
            lblLista = new System.Windows.Forms.Label
            {
                Text = "Fotos do veículo (ordem de exibição):",
                Dock = System.Windows.Forms.DockStyle.Fill,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };

            // ===== listbox + botões =====
            lstImagens = new System.Windows.Forms.ListBox { Dock = System.Windows.Forms.DockStyle.Fill };
            flowBtns = new System.Windows.Forms.FlowLayoutPanel
            {
                Dock = System.Windows.Forms.DockStyle.Right,
                FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft,
                AutoSize = true,
                Padding = new System.Windows.Forms.Padding(0, 6, 0, 0)
            };
            btnAddFotos = new System.Windows.Forms.Button { Text = "Adicionar fotos…", AutoSize = true };
            btnRemoverFoto = new System.Windows.Forms.Button { Text = "Remover seleção", AutoSize = true };
            flowBtns.Controls.Add(btnRemoverFoto);
            flowBtns.Controls.Add(btnAddFotos);

            // ===== rodapé (Salvar/Cancelar) =====
            footer = new System.Windows.Forms.FlowLayoutPanel
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
            };
            btnSalvar = new System.Windows.Forms.Button { Text = "Salvar", Width = 100, DialogResult = System.Windows.Forms.DialogResult.OK };
            btnCancelar = new System.Windows.Forms.Button { Text = "Cancelar", Width = 100, DialogResult = System.Windows.Forms.DialogResult.Cancel };
            footer.Controls.Add(btnSalvar);
            footer.Controls.Add(btnCancelar);

            // ===== OpenFileDialog (multi) =====
            dlgAbrirImagem = new System.Windows.Forms.OpenFileDialog
            {
                Filter = "Imagens|*.jpg;*.jpeg;*.png;*.bmp",
                Multiselect = true
            };

            // ===== montar root =====
            root.Controls.Add(formLeft, 0, 0);
            root.Controls.Add(picFoto, 1, 0);

            // linha 1: label lista (ocupa 2 colunas)
            root.Controls.Add(lblLista, 0, 1);
            root.SetColumnSpan(lblLista, 2);

            // linha 2: ListBox (coluna 0) + botões (coluna 1)
            root.Controls.Add(lstImagens, 0, 2);
            root.Controls.Add(flowBtns, 1, 2);

            // linha 3: rodapé (ocupa 2 colunas)
            root.Controls.Add(footer, 0, 3);
            root.SetColumnSpan(footer, 2);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 440);
            this.Controls.Add(root);
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.Name = "VeiculoForm";
            this.Text = "Veículo";
        }
    }
}
