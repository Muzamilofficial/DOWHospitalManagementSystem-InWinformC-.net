using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Hospital_Management_Server__DOW_Hospital_
{
    public class PictureBorderClass :PictureBox
    {
        protected override void OnPaint(PaintEventArgs pe)
        {
            GraphicsPath gp=new GraphicsPath();
            gp.AddEllipse(0,0,ClientSize.Width,ClientSize.Height);
            this.Region=new System.Drawing.Region(gp);
            base.OnPaint(pe);
        }
    }
}
