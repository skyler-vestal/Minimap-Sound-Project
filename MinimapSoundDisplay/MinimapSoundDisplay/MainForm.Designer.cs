namespace MinimapSoundDisplay
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mapComboBox = new System.Windows.Forms.ComboBox();
            this.mapSelectLabel = new System.Windows.Forms.Label();
            this.mapImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.mapImage)).BeginInit();
            this.SuspendLayout();
            // 
            // mapComboBox
            // 
            this.mapComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapComboBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapComboBox.FormattingEnabled = true;
            this.mapComboBox.Location = new System.Drawing.Point(15, 30);
            this.mapComboBox.Name = "mapComboBox";
            this.mapComboBox.Size = new System.Drawing.Size(159, 26);
            this.mapComboBox.TabIndex = 1;
            this.mapComboBox.SelectedIndexChanged += new System.EventHandler(this.mapComboBox_SelectedIndexChanged);
            // 
            // mapSelectLabel
            // 
            this.mapSelectLabel.AutoSize = true;
            this.mapSelectLabel.BackColor = System.Drawing.Color.Transparent;
            this.mapSelectLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapSelectLabel.Location = new System.Drawing.Point(70, 9);
            this.mapSelectLabel.Name = "mapSelectLabel";
            this.mapSelectLabel.Size = new System.Drawing.Size(104, 18);
            this.mapSelectLabel.TabIndex = 2;
            this.mapSelectLabel.Text = "Select Map:";
            // 
            // mapImage
            // 
            this.mapImage.BackColor = System.Drawing.Color.Transparent;
            this.mapImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mapImage.Cursor = System.Windows.Forms.Cursors.Cross;
            this.mapImage.Location = new System.Drawing.Point(0, 0);
            this.mapImage.Name = "mapImage";
            this.mapImage.Size = new System.Drawing.Size(10, 10);
            this.mapImage.TabIndex = 0;
            this.mapImage.TabStop = false;
            this.mapImage.Paint += new System.Windows.Forms.PaintEventHandler(this.mapImage_Paint);
            this.mapImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mapImage_MouseClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(183, 66);
            this.Controls.Add(this.mapSelectLabel);
            this.Controls.Add(this.mapComboBox);
            this.Controls.Add(this.mapImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.mapImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mapImage;
        private System.Windows.Forms.ComboBox mapComboBox;
        private System.Windows.Forms.Label mapSelectLabel;
    }
}

