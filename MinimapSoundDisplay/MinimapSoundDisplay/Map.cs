using System.Drawing;

namespace MinimapSoundDisplay
{
    public class Map
    {
        public Bitmap Image { get; set; }
        public string Name { get; set; }

        public Map(string name, Bitmap image)
        {
            Name = name;
            Image = image;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
