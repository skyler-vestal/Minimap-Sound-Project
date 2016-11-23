using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MinimapSoundDisplay.Properties;

namespace MinimapSoundDisplay
{
    public partial class MainForm : Form
    {
        private const int BorderWidth = 16;
        private const int BorderMargin = 9;

        private const int EllipseWidth = 364;
        private const int PointWidth = 4;

        private readonly int _labelMargin;
        private readonly int _comboBoxMargin;
        private readonly int _comboBoxWidth;

        private Point _cursorClickPoint = new Point(-1, -1);

        // Initialize
        public MainForm()
        {
            InitializeComponent();
            InitalizeMapList();

            _labelMargin = mapSelectLabel.Location.X;
            _comboBoxMargin = mapComboBox.Location.X;
            _comboBoxWidth = mapComboBox.Size.Width;
        }
        private void InitalizeMapList()
        {

            // Adds map with name you choose, assign the name to one of the resource images
            // If someone could add an option to input their own that would be awesome, would be easily I believe
            mapComboBox.Items.Add(new Map("Cache", Resources.de_cache_radar));
            mapComboBox.Items.Add(new Map("Cobblestone", Resources.de_cbble_radar));
            mapComboBox.Items.Add(new Map("Dust2", Resources.de_dust2_radar));
            mapComboBox.Items.Add(new Map("Inferno", Resources.de_inferno_radar));
            mapComboBox.Items.Add(new Map("Mirage", Resources.de_mirage_radar));
            mapComboBox.Items.Add(new Map("Nuke", Resources.de_nuke_radar));
            mapComboBox.Items.Add(new Map("Overpass", Resources.de_overpass_radar));
            mapComboBox.Items.Add(new Map("Train", Resources.de_train_radar));
        }

        // Events
        private void mapComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mapComboBox.SelectedIndex < 0)
                return;

            // Remove old cursorClickPoint
            _cursorClickPoint = new Point(-1, -1);
            Refresh(); // Paint event

            var mapObject = (Map)mapComboBox.SelectedItem;

            var imageWidth = mapObject.Image.Width;
            var imageHeight = mapObject.Image.Height;

            // Change mapImage image and size
            mapImage.Image = mapObject.Image;
            mapImage.Size = new Size(imageWidth, imageHeight);

            // Change form size
            Width = imageWidth + _comboBoxMargin + _comboBoxWidth + BorderMargin + BorderWidth;
            Height = imageHeight;

            // Change controls location
            mapSelectLabel.Location = new Point(imageWidth + _labelMargin, mapSelectLabel.Location.Y);
            mapComboBox.Location = new Point(imageWidth + _comboBoxMargin, mapComboBox.Location.Y);

            // Clean memory
            GC.Collect();
        }
        private void mapImage_MouseClick(object sender, MouseEventArgs e)
        {
            _cursorClickPoint = PointToClient(Cursor.Position);
            Refresh(); // Paint event
        }
        private void mapImage_Paint(object sender, PaintEventArgs e)
        {
            if (_cursorClickPoint == new Point(-1, -1))
                return;

            // Anti aliasing
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            // Ellipse
            {
                var ellipsePen = new Pen(Color.White, 2f);

                var x = _cursorClickPoint.X - EllipseWidth / 2;
                var y = _cursorClickPoint.Y - EllipseWidth / 2;

                e.Graphics.DrawEllipse(ellipsePen, x, y, EllipseWidth, EllipseWidth);
            }

            // Point
            {
                var pointBrush = new SolidBrush(Color.White);

                var x = _cursorClickPoint.X - PointWidth / 2;
                var y = _cursorClickPoint.Y - PointWidth / 2;

                e.Graphics.FillEllipse(pointBrush, x, y, PointWidth, PointWidth);
            }
        }
    }
}
