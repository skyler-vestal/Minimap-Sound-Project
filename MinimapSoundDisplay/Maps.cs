namespace MinimapSoundDisplay
{
    public class Map
    {
        public string Name { get; set; }
        public System.Drawing.Bitmap Image { get; set; }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
