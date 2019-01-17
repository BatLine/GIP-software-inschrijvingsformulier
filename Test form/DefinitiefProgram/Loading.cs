using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace DefinitiefProgram
{
    public partial class Loading : Form
    {
        public string strStatusText="Even geduld";
        int plus = 2, intPunten=0;

        public Loading()
        {
            InitializeComponent();

            panel2.Left = 0;
            panel1.ForeColor = ColorFromHex("#33373B");
            this.BackColor = ColorFromHex("#33373B");
        }

        public static Color ColorFromHex(string Hex)
        {
            return Color.FromArgb(checked((int)long.Parse(string.Format("FFFFFFFFFF{0}", Hex.Substring(1)), NumberStyles.HexNumber)));
        }

        private void Loading_Load(object sender, EventArgs e)
        {

        }

        void move()
        {
            panel2.Left = panel2.Left + plus;

            if (panel2.Left > 283)
            {
                plus = -2;
            }
            if (panel2.Left < 0)
            {
                plus = 2;
            }
        }

        private void Progress_Tick(object sender, EventArgs e)
        {
            move();
        }

        private void tmrPunt_Tick(object sender, EventArgs e)
        {
            switch (intPunten)
            {
                case 0:
                    lblPunt.Text = " .";
                    intPunten = 1;
                    break;
                case 1:
                    lblPunt.Text = " ..";
                    intPunten = 2;
                    break;
                case 2:
                    lblPunt.Text = " ...";
                    intPunten = 3;
                    break;
                case 3:
                    lblPunt.Text = "";
                    intPunten = 0;
                    break;
                default:
                    break;
            }
        }
    }
}
