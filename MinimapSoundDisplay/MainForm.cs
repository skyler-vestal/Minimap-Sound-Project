using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MinimapSoundDisplay
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            foreach (string mapFile in Directory.GetFiles("Maps", "*.png", SearchOption.TopDirectoryOnly))
                cBox.Items.Add(Path.GetFileNameWithoutExtension(mapFile));
        }

        #region Map Combobox
        private void cBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string newMapFile = Path.GetFullPath(Path.Combine("Maps", cBox.SelectedItem.ToString()) + ".png");
            if (File.Exists(newMapFile))
                mapPictureBox.Image = Image.FromFile(newMapFile);
        }
        #endregion
        #region Map Handling
        internal bool isMapPanning = false;
        internal Point panStartPoint = Point.Empty;
        internal Point cursorPoint = Point.Empty;

        private void mapPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                panStartPoint = new Point(e.X, e.Y);
                isMapPanning = true;
            }
        }

        private void mapPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right && isMapPanning)
            {
                int newX = (panStartPoint.X - e.X) - mapPanDummy.AutoScrollPosition.X;
                int newY = (panStartPoint.Y - e.Y) - mapPanDummy.AutoScrollPosition.Y;

                mapPanDummy.AutoScrollPosition = new Point(newX, newY);
            }
            else
            {
                cursorPoint = new Point(e.X, e.Y);
                mapPictureBox.Invalidate();
            }
        }
        private void mapPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            isMapPanning = false;
        }

        private void mapPictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(110, Color.White)), cursorPoint.X - 180, cursorPoint.Y - 180, 360, 360);
        }
        #endregion
    }
}