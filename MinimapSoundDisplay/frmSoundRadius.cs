using System.Drawing;
using System.Windows.Forms;

namespace MinimapSoundDisplay
{
    public partial class frmSoundRadius : Form
    {
        public frmSoundRadius()
        {
            InitializeComponent();
            this.TransparencyKey = BackColor;
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            // New Ellpise
            Graphics g = e.Graphics;
            Pen black = new Pen(Color.LightGray);
            g.DrawEllipse(black, 0, 0, 360, 360);
            g.FillRectangle(Brushes.White, 180, 180, 4, 4);
            g.Dispose();

        }

        // Disables x button, could accidentaly be clicked
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        /* This is just a temporary solution to a very frustrating problem.
         * I want to create a draggable bitmap, shape, or picturebox that is
         * slight opaque, however over 10 hours I could make literally no progress
         * doing this. It would look prettier and would make the program feel better
         * Thanks if you manage to do it, I think it may just not possible in VS
         */
    }
}
