namespace VeiculosApp
{
    
    using System.Drawing;
    // Adicionado para estilos do Grid e Padding
    using System.Windows.Forms;

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

            // --- [ESTILO MODERNO LIMPO] ---
            // Definindo nossas cores
            var azulPrincipal = Color.FromArgb(0, 120, 212);
            var azulMouseOver = Color.FromArgb(0, 90, 158);
            var cinzaFundoClaro = Color.FromArgb(245, 245, 245); // Fundo para linhas alternadas
            var textoEscuro = Color.FromArgb(30, 30, 30);
            var textoClaro = Color.White;
            var fundoBranco = Color.White;
            var fundoForm = Color.FromArgb(245, 245, 245); // Fundo geral CINZA bem claro
            // --- [FIM ESTILO] ---

            // ===== raiz =====
            root = new System.Windows.Forms.TableLayoutPanel();
            root.Dock = System.Windows.Forms.DockStyle.Fill;
            root.Padding = new System.Windows.Forms.Padding(12);
            root.ColumnCount = 2;
            root.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 320F)); // campos
            root.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F)); // foto
            root.RowCount = 4;
            root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 210F)); // campos/foto
            root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));  // label lista (aumentado)
            root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));  // listbox
            root.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));  // rodapé
            // --- [ESTILO MODERNO] ---
            root.BackColor = fundoForm; 

            // ===== esquerda: campos (Card 1) =====
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
            // --- [ESTILO MODERNO] ---
            formLeft.BackColor = fundoBranco;
            formLeft.Padding = new System.Windows.Forms.Padding(12); // Padding interno
            formLeft.Margin = new System.Windows.Forms.Padding(0, 0, 6, 6); // Margem para separar dos outros

            lblMarca = new System.Windows.Forms.Label { Text = "Marca", Dock = System.Windows.Forms.DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleLeft, ForeColor = textoEscuro };
            lblModelo = new System.Windows.Forms.Label { Text = "Modelo", Dock = System.Windows.Forms.DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleLeft, ForeColor = textoEscuro };
            lblAno = new System.Windows.Forms.Label { Text = "Ano", Dock = System.Windows.Forms.DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleLeft, ForeColor = textoEscuro };
            lblPreco = new System.Windows.Forms.Label { Text = "Preço", Dock = System.Windows.Forms.DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleLeft, ForeColor = textoEscuro };

            txtMarca = new System.Windows.Forms.TextBox { Dock = System.Windows.Forms.DockStyle.Fill, BorderStyle = BorderStyle.FixedSingle };
            txtModelo = new System.Windows.Forms.TextBox { Dock = System.Windows.Forms.DockStyle.Fill, BorderStyle = BorderStyle.FixedSingle };
            numAno = new System.Windows.Forms.NumericUpDown { Dock = System.Windows.Forms.DockStyle.Left, Minimum = 1900, Maximum = 2100, Width = 120, BorderStyle = BorderStyle.FixedSingle };
            numPreco = new System.Windows.Forms.NumericUpDown { Dock = System.Windows.Forms.DockStyle.Left, DecimalPlaces = 2, Maximum = 100000000m, Width = 120, ThousandsSeparator = true, BorderStyle = BorderStyle.FixedSingle };

            formLeft.Controls.Add(lblMarca, 0, 0);
            formLeft.Controls.Add(txtMarca, 1, 0);
            formLeft.Controls.Add(lblModelo, 0, 1);
            formLeft.Controls.Add(txtModelo, 1, 1);
            formLeft.Controls.Add(lblAno, 0, 2);
            formLeft.Controls.Add(numAno, 1, 2);
            formLeft.Controls.Add(lblPreco, 0, 3);
            formLeft.Controls.Add(numPreco, 1, 3);

            // ===== direita: foto grande (Card 1) =====
            picFoto = new System.Windows.Forms.PictureBox
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom,
               
                BackColor = fundoBranco,
                Margin = new System.Windows.Forms.Padding(6, 0, 0, 6) // Margem para separar
            };

            // ===== label lista =====
            lblLista = new System.Windows.Forms.Label
            {
                Text = "Fotos do veículo (ordem de exibição):",
                Dock = System.Windows.Forms.DockStyle.Fill,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                // --- [ESTILO MODERNO] ---
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = textoEscuro,
                Margin = new System.Windows.Forms.Padding(0, 6, 0, 0) // Espaço acima
            };

            // ===== listbox (Card 2) =====
            lstImagens = new System.Windows.Forms.ListBox
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                // --- [ESTILO MODERNO] ---
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new System.Windows.Forms.Padding(0, 0, 6, 0),
                BackColor = fundoBranco
            };

            // ===== botões lista (Card 2) =====
            flowBtns = new System.Windows.Forms.FlowLayoutPanel
            {
                Dock = System.Windows.Forms.DockStyle.Fill, // Mudado para Fill
                FlowDirection = System.Windows.Forms.FlowDirection.TopDown, // Botões um em cima do outro
                AutoSize = false,
                Padding = new System.Windows.Forms.Padding(6, 0, 0, 0),
               
                BackColor = fundoForm, 
                Margin = new System.Windows.Forms.Padding(6, 0, 0, 0)
            };
            btnAddFotos = new System.Windows.Forms.Button { Text = "+ Adicionar fotos…", Height = 32, Width = 150 };
            btnRemoverFoto = new System.Windows.Forms.Button { Text = "✕ Remover seleção", Height = 32, Width = 150 };

            // --- [ESTILO MODERNO BTN ADICIONAR] ---
            btnAddFotos.FlatStyle = FlatStyle.Flat;
            btnAddFotos.FlatAppearance.BorderSize = 0;
            btnAddFotos.BackColor = azulPrincipal;
            btnAddFotos.ForeColor = textoClaro;
            btnAddFotos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddFotos.FlatAppearance.MouseOverBackColor = azulMouseOver;

            // --- [ESTILO MODERNO BTN REMOVER] ---
            btnRemoverFoto.FlatStyle = FlatStyle.Flat;
            btnRemoverFoto.FlatAppearance.BorderSize = 1;
            btnRemoverFoto.FlatAppearance.BorderColor = Color.Gray;
            btnRemoverFoto.BackColor = fundoBranco;
            btnRemoverFoto.ForeColor = textoEscuro;
            btnRemoverFoto.Font = new Font("Segoe UI", 9F); // Normal, não bold

            flowBtns.Controls.Add(btnAddFotos);
            flowBtns.Controls.Add(btnRemoverFoto);

            // ===== rodapé (Salvar/Cancelar) =====
            footer = new System.Windows.Forms.FlowLayoutPanel
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft,
                // --- [ESTILO MODERNO] ---
                BackColor = fundoForm
            };
            btnSalvar = new System.Windows.Forms.Button { Text = "Salvar", Width = 110, Height = 32, DialogResult = System.Windows.Forms.DialogResult.OK };
            btnCancelar = new System.Windows.Forms.Button { Text = "Cancelar", Width = 110, Height = 32, DialogResult = System.Windows.Forms.DialogResult.Cancel };

            // --- [ESTILO MODERNO BTN SALVAR] ---
            btnSalvar.FlatStyle = FlatStyle.Flat;
            btnSalvar.FlatAppearance.BorderSize = 0;
            btnSalvar.BackColor = azulPrincipal;
            btnSalvar.ForeColor = textoClaro;
            btnSalvar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSalvar.FlatAppearance.MouseOverBackColor = azulMouseOver;

            // --- [ESTILO MODERNO BTN CANCELAR] ---
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.FlatAppearance.BorderSize = 1;
            btnCancelar.FlatAppearance.BorderColor = azulPrincipal;
            btnCancelar.BackColor = fundoBranco;
            btnCancelar.ForeColor = azulPrincipal;
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

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

            // ===== Form =====
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font; // Mantendo Font para sua solução
            this.ClientSize = new System.Drawing.Size(740, 480); // Aumentei a altura
            this.Controls.Add(root);
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.Name = "VeiculoForm";
            this.Text = "Editar Veículo";
            // --- [ESTILO MODERNO] ---
            this.BackColor = fundoForm;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
        }
    }
}
