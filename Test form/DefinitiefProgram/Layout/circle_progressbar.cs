using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;

namespace DefinitiefProgram.Layout
{
    public partial class circle_progressbar : UserControl
    {
        int dir = 1;
        List<Color> colors = new List<Color>();
        int cur_color = 0;
        int loop = 0;

        public circle_progressbar()
        {
            InitializeComponent();
            colors.Add(Color.FromArgb(0, 158, 71));
            colors.Add(Color.FromArgb(112, 191, 83));
            colors.Add(Color.FromArgb(216, 155, 40));
            colors.Add(Color.FromArgb(217, 102, 41));
            colors.Add(Color.FromArgb(217, 102, 41));
            colors.Add(Color.FromArgb(235, 83, 104));
            colors.Add(Color.FromArgb(223, 128, 255));
            colors.Add(Color.FromArgb(112, 48, 160));
            colors.Add(Color.FromArgb(107, 122, 187));
            colors.Add(Color.FromArgb(95, 136, 176));
            colors.Add(Color.FromArgb(70, 175, 227));
            colors.Add(Color.FromArgb(0, 158, 71));

            List<Color> tempColors = new List<Color>();
            for (int intTeller = colors.Count-1; intTeller >= 0; intTeller--)
            { tempColors.Add(colors[intTeller]); }
            foreach (Color c in tempColors)
            { colors.Add(c); }

            circle.ProgressColor = colors[cur_color];
        }

        private void stretch_Tick(object sender, EventArgs e)
        {
            if (circle.Value == 160)
            {
                dir = -1;
                circle.animationIterval = 4;
            }
            else if (circle.Value == 20)
            {
                dir = +1;
                circle.animationIterval = 2;
            }
            circle.Value += dir;
        }

        private void fader_Tick(object sender, EventArgs e)
        {
            if (cur_color<colors.Count-1)
            {
                circle.ProgressColor = BunifuColorTransition.getColorScale(loop, colors[cur_color], colors[cur_color + 1]);
                if (loop<100)
                {
                    loop++;
                }
                else
                {
                    loop = 0;
                    cur_color++;
                }
            }
            else { cur_color = 0; }
        }
    }
}
