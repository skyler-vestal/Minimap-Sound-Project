using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using KUtility;

namespace MinimapSoundDisplay
{
    public partial class frmMap : Form
    {
        // Path to the CS:GO directory - the @ is to suppress errors because of backslashes
        private string csDir = "";

        // Get the startup path
        private string startupPath = AppDomain.CurrentDomain.BaseDirectory;

        public frmMap()
        {
            InitializeComponent();
        }


        private void frmMap_Load(object sender, EventArgs e)
        {
            csDir = Properties.Settings.Default.csgoPath;

            if (csDir == "")
            {
                changeCsgoDir();
            }

            MapList();

            // Loads Form2 when launching this form
            // The (this) makes form2 launch and stay on top of form1
            frmSoundRadius form2 = new frmSoundRadius();
            form2.Show(this);
        }

        private void changeCsgoDir()
        {
            FolderBrowserDialog csbrowser = new FolderBrowserDialog() {
                Description = "Select your CS:GO installation directory"
            };

            DialogResult result = csbrowser.ShowDialog();

            if (csbrowser.SelectedPath != "" && result != DialogResult.Abort && result != DialogResult.Cancel)
            {
                csDir = csbrowser.SelectedPath;

                // Update the path
                Properties.Settings.Default.csgoPath = csbrowser.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }

        public void MapList()
        {
            cBox.Items.Clear();

            // Path to the folder the radar files are stored in
            string radarDir = csDir + @"\csgo\resource\overviews";

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


        private void cBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBox.SelectedIndex > -1)
            {
                // When the combobox changes, this will change the bitmap to the select map on the list
                // I don't believe the = null does anything, if someone can fix this to fix horrible memory
                // stacking that would be rad :) thanks

                // TODO: Dispose the image properly
                // EDIT: The method below works, but makes the disposed image unusable
                /*if (pictureBox.Image != null)
                {
                    pictureBox.Image.Dispose();
                }*/

                pictureBox.BackgroundImage = null;
                var imageName = (Map)cBox.SelectedItem;
                pictureBox.BackgroundImage = imageName.Image;
            }
        }

        private void btnChangeCsgoDir_Click(object sender, EventArgs e)
        {
            changeCsgoDir();
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
            MapList();
            this.Enabled = true;
        }
    }
}
