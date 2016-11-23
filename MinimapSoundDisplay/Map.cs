namespace MinimapSoundDisplay
{
    public class Map
    {
        public string Name { get; set; }
        public System.Drawing.Bitmap Image { get; set; }

        public Map(string Name, System.Drawing.Bitmap Image)
        {
            this.Name = Name;
            this.Image = Image;
        }

        
        public override string ToString()
        {
            return this.Name;
        }
    }
}
