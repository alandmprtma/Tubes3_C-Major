using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GUI
{
    public class ToggleButton : CheckBox
    {
        private Color OnToggleColor = Color.WhiteSmoke;
        private Color OffBackColor = Color.DarkSlateGray;
        private Color onBackColor = Color.MediumSlateBlue;
        private Color OffToggleColor = Color.Gainsboro;

        public ToggleButton()
        {
            this.MinimumSize = new Size(45, 22);

        }
        private GraphicsPath GetFigurePath()
        {
            int arcSize = this.Height - 1;
            Rectangle leftArc = new Rectangle(0, 0, arcSize, arcSize);
            Rectangle rightArc = new Rectangle(this.Width-arcSize-2, 0, arcSize, arcSize);

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);
            path.CloseFigure();

            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            int toggleSize = this.Height - 5;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(this.Parent.BackColor);

            if (this.Checked)
            {
                pevent.Graphics.FillPath(new SolidBrush(onBackColor), GetFigurePath());

                pevent.Graphics.FillEllipse(new SolidBrush(OnToggleColor), new Rectangle(this.Width - this.Height + 1, 2, toggleSize, toggleSize));

            }
            else
            {
                pevent.Graphics.FillPath(new SolidBrush(OffBackColor), GetFigurePath());

                pevent.Graphics.FillEllipse(new SolidBrush(OffToggleColor), new Rectangle(2, 2, toggleSize, toggleSize));
            }


        }
    }
}
