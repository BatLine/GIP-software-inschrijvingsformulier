using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DefinitiefProgram
{
    public partial class LoadingCircle : Form
    {
        public LoadingCircle()
        { InitializeComponent(); }

        private void LoadingCircle_Load(object sender, EventArgs e)
        {
            //circle.Value = 0;
            circle.MaxValue = 100;
        }

        public void setValue(int v)
        { circle.Value = v; }
        public void addOneValue()
        { circle.Value += 1; }
        public void setMaxValue(int v)
        { circle.MaxValue = v; }
    }
}
