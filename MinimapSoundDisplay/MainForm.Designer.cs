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
            this.mapPictureBox = new System.Windows.Forms.PictureBox();
            this.mapPanDummy = new System.Windows.Forms.Panel();
            this.descLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cBox = new System.Windows.Forms.ComboBox();
            this.mapLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mapPictureBox)).BeginInit();
            this.mapPanDummy.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapPictureBox
            // 
            this.mapPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mapPictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.mapPictureBox.ErrorImage = null;
            this.mapPictureBox.InitialImage = null;
            this.mapPictureBox.Location = new System.Drawing.Point(0, 0);
            this.mapPictureBox.Name = "mapPictureBox";
            this.mapPictureBox.Size = new System.Drawing.Size(0, 0);
            this.mapPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.mapPictureBox.TabIndex = 0;
            this.mapPictureBox.TabStop = false;
            this.mapPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.mapPictureBox_Paint);
            this.mapPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mapPictureBox_MouseDown);
            this.mapPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mapPictureBox_MouseMove);
            this.mapPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mapPictureBox_MouseUp);
            // 
            // mapPanDummy
            // 
            this.mapPanDummy.AutoScroll = true;
            this.mapPanDummy.Controls.Add(this.mapPictureBox);
            this.mapPanDummy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapPanDummy.Location = new System.Drawing.Point(0, 0);
            this.mapPanDummy.Name = "mapPanDummy";
            this.mapPanDummy.Size = new System.Drawing.Size(684, 561);
            this.mapPanDummy.TabIndex = 2;
            // 
            // descLabel
            // 
            this.descLabel.AutoSize = true;
            this.descLabel.Location = new System.Drawing.Point(526, 6);
            this.descLabel.Name = "descLabel";
            this.descLabel.Size = new System.Drawing.Size(155, 13);
            this.descLabel.TabIndex = 3;
            this.descLabel.Text = "Click && drag to pan the map.";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mapLabel);
            this.panel1.Controls.Add(this.cBox);
            this.panel1.Controls.Add(this.descLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 534);
            this.panel1.MaximumSize = new System.Drawing.Size(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 27);
            this.panel1.TabIndex = 4;
            // 
            // cBox
            // 
            this.cBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cBox.FormattingEnabled = true;
            this.cBox.Location = new System.Drawing.Point(87, 3);
            this.cBox.MaximumSize = new System.Drawing.Size(145, 0);
            this.cBox.Name = "cBox";
            this.cBox.Size = new System.Drawing.Size(145, 21);
            this.cBox.Sorted = true;
            this.cBox.TabIndex = 4;
            this.cBox.Text = "Nothing";
            this.cBox.SelectedIndexChanged += new System.EventHandler(this.cBox_SelectedIndexChanged);
            // 
            // mapLabel
            // 
            this.mapLabel.AutoSize = true;
            this.mapLabel.Location = new System.Drawing.Point(3, 6);
            this.mapLabel.Name = "mapLabel";
            this.mapLabel.Size = new System.Drawing.Size(78, 13);
            this.mapLabel.TabIndex = 5;
            this.mapLabel.Text = "Current Map: ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mapPanDummy);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minimap Sound Display";
            ((System.ComponentModel.ISupportInitialize)(this.mapPictureBox)).EndInit();
            this.mapPanDummy.ResumeLayout(false);
            this.mapPanDummy.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox mapPictureBox;
        private System.Windows.Forms.Panel mapPanDummy;
        private System.Windows.Forms.Label descLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label mapLabel;
        private System.Windows.Forms.ComboBox cBox;
    }
}

