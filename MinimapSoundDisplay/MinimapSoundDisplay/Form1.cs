using System;
using System.IO;
using System.Windows.Forms;

namespace MinimapSoundDisplay
{
    public partial class Form1 : Form
    {
        public Form1()
        {
          InitializeComponent();

          MapList();
          Form1_Load();
        }
     

        private void Form1_Load()
        {
            // Loads Form2 when launching this form
            // The (this) makes form2 launch and stay on top of form1
            Form2 form2 = new Form2();
            form2.Show(this);
        }

        public void MapList()
        {
            
            // Adds map with name you choose, assign the name to one of the resource images
            // If someone could add an option to input their own that would be awesome, would be easily I believe
            cBox.Items.Add(
                new Map() {Name= "Cache" ,
                    Image = MinimapSoundDisplay.Properties.Resources.de_cache_radar
                });
            cBox.Items.Add(
                new Map()
                {
                    Name = "Cobblestone",
                    Image = MinimapSoundDisplay.Properties.Resources.de_cbble_radar
                    //System.IO.Path.Combine(apppath, "de_cbble_radar.png")
                });
            cBox.Items.Add(
                new Map()
                {
                    Name = "Dust2",
                    Image = MinimapSoundDisplay.Properties.Resources.de_dust2_radar
                });
            cBox.Items.Add(
                new Map()
                {
                    Name = "Inferno",
                    Image = MinimapSoundDisplay.Properties.Resources.de_inferno_radar
                });
            cBox.Items.Add(
                new Map()
                {
                    Name = "Mirage",
                    Image = MinimapSoundDisplay.Properties.Resources.de_mirage_radar
                });
            cBox.Items.Add(
                new Map()
                {
                    Name = "Nuke",
                    Image = MinimapSoundDisplay.Properties.Resources.de_nuke_radar
                });
            cBox.Items.Add(
                new Map()
                {
                    Name = "Overpass",
                    Image = MinimapSoundDisplay.Properties.Resources.de_overpass_radar
                });
            cBox.Items.Add(
                new Map()
                {
                    Name = "Train",
                    Image = MinimapSoundDisplay.Properties.Resources.de_train_radar
                });
        }

        
        private void cBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBox.SelectedIndex > -1)
            {
                // When the combobox changes, this will change the bitmap to the select map on the list
                // I don't believe the = null does anything, if someone can fix this to fix horrible memory
                // stacking that would be rad :) thanks
                var imageName = ((Map)cBox.SelectedItem);
                pictureBox.Image = null;
                pictureBox.Image = imageName.Image;
            }
        }
    }
}
