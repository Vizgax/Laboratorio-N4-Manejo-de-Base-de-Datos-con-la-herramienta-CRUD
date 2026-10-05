

namespace Lab3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            DGV_BD = new DataGridView();
            ID_Col = new DataGridViewTextBoxColumn();
            Nom_Col = new DataGridViewTextBoxColumn();
            Prec_Col = new DataGridViewTextBoxColumn();
            Cant_Col = new DataGridViewTextBoxColumn();
            Img_Col = new DataGridViewImageColumn();
            imageList1 = new ImageList(components);
            BTN_Save = new Button();
            BTN_Mod = new Button();
            BTN_Elim = new Button();
            BTN_Clean = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            TB_Entrada = new TextBox();
            panel2 = new Panel();
            BTN_Salir = new Button();
            TB_Nom = new TextBox();
            TB_Prec = new TextBox();
            TB_Cant = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            TB_ID = new TextBox();
            BTN_AgIMG = new Button();
            PB_IMG = new PictureBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)DGV_BD).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PB_IMG).BeginInit();
            SuspendLayout();
            // 
            // DGV_BD
            // 
            DGV_BD.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_BD.Columns.AddRange(new DataGridViewColumn[] { ID_Col, Nom_Col, Prec_Col, Cant_Col, Img_Col });
            DGV_BD.Location = new Point(12, 366);
            DGV_BD.Name = "DGV_BD";
            DGV_BD.Size = new Size(776, 166);
            DGV_BD.TabIndex = 0;
            DGV_BD.CellClick += DGV_BD_CellClick;
            // 
            // ID_Col
            // 
            ID_Col.HeaderText = "ID";
            ID_Col.Name = "ID_Col";
            // 
            // Nom_Col
            // 
            Nom_Col.HeaderText = "Nombre";
            Nom_Col.Name = "Nom_Col";
            // 
            // Prec_Col
            // 
            Prec_Col.HeaderText = "Precio";
            Prec_Col.Name = "Prec_Col";
            // 
            // Cant_Col
            // 
            Cant_Col.HeaderText = "Cantidad";
            Cant_Col.Name = "Cant_Col";
            // 
            // Img_Col
            // 
            Img_Col.HeaderText = "Imagen";
            Img_Col.Name = "Img_Col";
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "guardar.png");
            imageList1.Images.SetKeyName(1, "lapiz.png");
            imageList1.Images.SetKeyName(2, "bote-de-basura.png");
            imageList1.Images.SetKeyName(3, "limpiar.png");
            imageList1.Images.SetKeyName(4, "lupa.png");
            imageList1.Images.SetKeyName(5, "eliminar.png");
            imageList1.Images.SetKeyName(6, "agregar.png");
            // 
            // BTN_Save
            // 
            BTN_Save.ImageAlign = ContentAlignment.MiddleRight;
            BTN_Save.ImageIndex = 0;
            BTN_Save.ImageList = imageList1;
            BTN_Save.Location = new Point(12, 538);
            BTN_Save.Name = "BTN_Save";
            BTN_Save.Size = new Size(161, 47);
            BTN_Save.TabIndex = 1;
            BTN_Save.Text = "Guardar";
            BTN_Save.UseVisualStyleBackColor = true;
            BTN_Save.Click += BTN_Save_Click;
            // 
            // BTN_Mod
            // 
            BTN_Mod.ImageAlign = ContentAlignment.MiddleRight;
            BTN_Mod.ImageIndex = 1;
            BTN_Mod.ImageList = imageList1;
            BTN_Mod.Location = new Point(208, 538);
            BTN_Mod.Name = "BTN_Mod";
            BTN_Mod.Size = new Size(162, 47);
            BTN_Mod.TabIndex = 2;
            BTN_Mod.Text = "Modificar";
            BTN_Mod.UseVisualStyleBackColor = true;
            BTN_Mod.Click += BTN_Mod_Click;
            // 
            // BTN_Elim
            // 
            BTN_Elim.ImageAlign = ContentAlignment.MiddleRight;
            BTN_Elim.ImageIndex = 2;
            BTN_Elim.ImageList = imageList1;
            BTN_Elim.Location = new Point(420, 538);
            BTN_Elim.Name = "BTN_Elim";
            BTN_Elim.Size = new Size(166, 47);
            BTN_Elim.TabIndex = 3;
            BTN_Elim.Text = "Eliminar";
            BTN_Elim.UseVisualStyleBackColor = true;
            BTN_Elim.Click += BTN_Elim_Click;
            // 
            // BTN_Clean
            // 
            BTN_Clean.ImageAlign = ContentAlignment.MiddleRight;
            BTN_Clean.ImageIndex = 3;
            BTN_Clean.ImageList = imageList1;
            BTN_Clean.Location = new Point(626, 538);
            BTN_Clean.Name = "BTN_Clean";
            BTN_Clean.Size = new Size(162, 47);
            BTN_Clean.TabIndex = 4;
            BTN_Clean.Text = "Limpiar";
            BTN_Clean.UseVisualStyleBackColor = true;
            BTN_Clean.Click += BTN_Clean_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(128, 128, 255);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(TB_Entrada);
            panel1.Location = new Point(12, 240);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 109);
            panel1.TabIndex = 5;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(564, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(127, 103);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // TB_Entrada
            // 
            TB_Entrada.Location = new Point(32, 43);
            TB_Entrada.Name = "TB_Entrada";
            TB_Entrada.Size = new Size(491, 23);
            TB_Entrada.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(128, 128, 255);
            panel2.Controls.Add(BTN_Salir);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 62);
            panel2.TabIndex = 6;
            // 
            // BTN_Salir
            // 
            BTN_Salir.ImageIndex = 5;
            BTN_Salir.ImageList = imageList1;
            BTN_Salir.Location = new Point(718, 7);
            BTN_Salir.Name = "BTN_Salir";
            BTN_Salir.Size = new Size(75, 47);
            BTN_Salir.TabIndex = 0;
            BTN_Salir.UseVisualStyleBackColor = true;
            BTN_Salir.Click += BTN_Salir_Click;
            // 
            // TB_Nom
            // 
            TB_Nom.Location = new Point(151, 109);
            TB_Nom.Name = "TB_Nom";
            TB_Nom.Size = new Size(219, 23);
            TB_Nom.TabIndex = 7;
            // 
            // TB_Prec
            // 
            TB_Prec.Location = new Point(151, 157);
            TB_Prec.Name = "TB_Prec";
            TB_Prec.Size = new Size(219, 23);
            TB_Prec.TabIndex = 8;
            // 
            // TB_Cant
            // 
            TB_Cant.Location = new Point(151, 210);
            TB_Cant.Name = "TB_Cant";
            TB_Cant.Size = new Size(219, 23);
            TB_Cant.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(71, 112);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 10;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(71, 160);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 11;
            label2.Text = "Precio";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(71, 213);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 12;
            label3.Text = "Cantidad";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(71, 71);
            label4.Name = "label4";
            label4.Size = new Size(18, 15);
            label4.TabIndex = 14;
            label4.Text = "ID";
            // 
            // TB_ID
            // 
            TB_ID.Location = new Point(151, 68);
            TB_ID.Name = "TB_ID";
            TB_ID.Size = new Size(219, 23);
            TB_ID.TabIndex = 13;
            // 
            // BTN_AgIMG
            // 
            BTN_AgIMG.ImageIndex = 6;
            BTN_AgIMG.ImageList = imageList1;
            BTN_AgIMG.Location = new Point(453, 144);
            BTN_AgIMG.Name = "BTN_AgIMG";
            BTN_AgIMG.Size = new Size(56, 46);
            BTN_AgIMG.TabIndex = 15;
            BTN_AgIMG.UseVisualStyleBackColor = true;
            BTN_AgIMG.Click += BTN_AgIMG_Click;
            // 
            // PB_IMG
            // 
            PB_IMG.Location = new Point(557, 71);
            PB_IMG.Name = "PB_IMG";
            PB_IMG.Size = new Size(231, 162);
            PB_IMG.TabIndex = 16;
            PB_IMG.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(434, 126);
            label5.Name = "label5";
            label5.Size = new Size(92, 15);
            label5.TabIndex = 17;
            label5.Text = "Agregar imagen";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 192, 255);
            ClientSize = new Size(800, 593);
            Controls.Add(label5);
            Controls.Add(PB_IMG);
            Controls.Add(BTN_AgIMG);
            Controls.Add(label4);
            Controls.Add(TB_ID);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TB_Cant);
            Controls.Add(TB_Prec);
            Controls.Add(TB_Nom);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(BTN_Clean);
            Controls.Add(BTN_Elim);
            Controls.Add(BTN_Mod);
            Controls.Add(BTN_Save);
            Controls.Add(DGV_BD);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tabla";
            ((System.ComponentModel.ISupportInitialize)DGV_BD).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PB_IMG).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DGV_BD;
        private DataGridViewTextBoxColumn ID_Col;
        private DataGridViewTextBoxColumn Nom_Col;
        private DataGridViewTextBoxColumn Prec_Col;
        private DataGridViewTextBoxColumn Cant_Col;
        private DataGridViewImageColumn Img_Col;
        private ImageList imageList1;
        private Button BTN_Save;
        private Button BTN_Mod;
        private Button BTN_Elim;
        private Button BTN_Clean;
        private Panel panel1;
        private TextBox TB_Entrada;
        private PictureBox pictureBox1;
        private Panel panel2;
        private TextBox TB_Nom;
        private TextBox TB_Prec;
        private TextBox TB_Cant;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button BTN_Salir;
        private Label label4;
        private TextBox TB_ID;
        private Button BTN_AgIMG;
        private PictureBox PB_IMG;
        private Label label5;
    }
}
