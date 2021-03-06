namespace SimpleVectorGraphicsEditor
{
    partial class FillProps
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbTrasparent = new System.Windows.Forms.Label();
            this.tbTrasparent = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.cbColor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dlgSelectColor = new System.Windows.Forms.ColorDialog();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTrasparent)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(178, 204);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOk.Location = new System.Drawing.Point(104, 204);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(68, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "Ввод";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pbPreview);
            this.groupBox2.Location = new System.Drawing.Point(12, 99);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(241, 91);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Образец ";
            // 
            // pbPreview
            // 
            this.pbPreview.BackgroundImage = global::SimpleVectorGraphicsEditor.Properties.Resources.transparent;
            this.pbPreview.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbPreview.Location = new System.Drawing.Point(9, 20);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(224, 64);
            this.pbPreview.TabIndex = 0;
            this.pbPreview.TabStop = false;
            this.pbPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.pbPreview_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbTrasparent);
            this.groupBox1.Controls.Add(this.tbTrasparent);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbColor);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 81);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Фон ";
            // 
            // lbTrasparent
            // 
            this.lbTrasparent.AutoSize = true;
            this.lbTrasparent.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbTrasparent.Location = new System.Drawing.Point(210, 51);
            this.lbTrasparent.Name = "lbTrasparent";
            this.lbTrasparent.Size = new System.Drawing.Size(23, 15);
            this.lbTrasparent.TabIndex = 5;
            this.lbTrasparent.Text = "0%";
            this.lbTrasparent.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbTrasparent
            // 
            this.tbTrasparent.AutoSize = false;
            this.tbTrasparent.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbTrasparent.LargeChange = 10;
            this.tbTrasparent.Location = new System.Drawing.Point(92, 47);
            this.tbTrasparent.Maximum = 255;
            this.tbTrasparent.Name = "tbTrasparent";
            this.tbTrasparent.Size = new System.Drawing.Size(100, 30);
            this.tbTrasparent.TabIndex = 4;
            this.tbTrasparent.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbTrasparent.Scroll += new System.EventHandler(this.tbTrasparent_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(4, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Прозрачность:";
            // 
            // cbColor
            // 
            this.cbColor.BackColor = System.Drawing.SystemColors.Window;
            this.cbColor.DisplayMember = "Color";
            this.cbColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbColor.FormattingEnabled = true;
            this.cbColor.Location = new System.Drawing.Point(104, 17);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(131, 24);
            this.cbColor.TabIndex = 0;
            this.cbColor.ValueMember = "Color";
            this.cbColor.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbColor_DrawItem);
            this.cbColor.SelectedIndexChanged += new System.EventHandler(this.cbColor_SelectedIndexChanged);
            this.cbColor.SelectionChangeCommitted += new System.EventHandler(this.cbColor_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Цвет:";
            // 
            // dlgSelectColor
            // 
            this.dlgSelectColor.Color = System.Drawing.Color.White;
            this.dlgSelectColor.FullOpen = true;
            // 
            // FillProps
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(265, 244);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FillProps";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Свойства фона фигуры";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTrasparent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbTrasparent;
        private System.Windows.Forms.TrackBar tbTrasparent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorDialog dlgSelectColor;
    }
}