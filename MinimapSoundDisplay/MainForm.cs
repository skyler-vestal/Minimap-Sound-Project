using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using KUtility;

namespace MinimapSoundDisplay
{
    public partial class MainForm : Form
    {
        // Get the startup path
        private string startupPath = AppDomain.CurrentDomain.BaseDirectory;

        public MainForm()
        {
            InitializeComponent();

            if (Properties.Settings.Default.csgoPath == "")
            {
                changeCsgoDir();
            }

            loadMaps();
        }

        public void loadMaps()
        {
            cBox.Items.Clear();

            // Path to the folder the radar files are stored in
            string radarDir = Properties.Settings.Default.csgoPath + @"\csgo\resource\overviews";

            DirectoryInfo radarDirInfo = new DirectoryInfo(radarDir);

            // Create the caching directory
            if (!Directory.Exists(startupPath + "\\cache"))
            {
                Directory.CreateDirectory(startupPath + "\\cache");
            }

            // Iterate over all dds files in the overviews directory
            foreach (var file in radarDirInfo.GetFiles("*.dds"))
            {
                // If file is not the spectate radar file
                if (!file.Name.Contains("_spectate.dds"))
                {
                    // Build the cache file path
                    string cacheFilename = startupPath + "\\cache\\" + file.Name.Replace("_radar.dds", ".png");

                    // If the cache file doesn't exist
                    if (!File.Exists(cacheFilename))
                    {
                        // TODO: Fix the buffersize exception instead of ignoring it
                        try
                        {
                            // Read and convert the dds image
                            // TODO: Add support for custom radars
                            Bitmap converted = new DDSImage(File.ReadAllBytes(file.FullName)).images[0];

                            // Save the cache file
                            converted.Save(cacheFilename);

                            // Add the image to the map list
                            cBox.Items.Add(new Map(file.Name.Replace("_radar.dds", ""), converted));
                        }
                        catch
                        {
                        }
                    }
                    else // If the cache file already exists
                    {
                        // Read the cached file and add it to the list
                        cBox.Items.Add(new Map(Path.GetFileName(cacheFilename.Replace(".png", "")), new Bitmap(Bitmap.FromFile(cacheFilename))));
                    }
                }
            }
        }

        private void changeCsgoDir()
        {
            FolderBrowserDialog csbrowser = new FolderBrowserDialog()
            {
                Description = "Select your CS:GO installation directory"
            };

            DialogResult result = csbrowser.ShowDialog();

            if (csbrowser.SelectedPath != "" && result != DialogResult.Abort && result != DialogResult.Cancel)
            {
                // Update the path
                Properties.Settings.Default.csgoPath = csbrowser.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }

        private void btnClearCache_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(startupPath + "\\cache"))
            {
                try
                {
                    Directory.Delete(startupPath + "\\cache", true);
                }
                catch
                {
                }
            }

            this.Enabled = false;
            loadMaps();
            this.Enabled = true;
        }

        #region Map Combobox
        private void cBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Map map = (Map)cBox.SelectedItem;
            mapPictureBox.Image = map.Image;
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

        private void btnChangeCsgoDir_Click(object sender, EventArgs e)
        {
            changeCsgoDir();
        }
    }
}