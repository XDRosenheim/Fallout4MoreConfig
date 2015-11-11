using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fallout4MoreConfig
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //TODO Get values from config files
            HUDOpacityValue.Text = "GET VALUE FROM FILE"; 
        }

        private void trackHudOpacity_Scroll(object sender, EventArgs e) { 
            HUDOpacityValue.Text = trackHudOpacity.Value.ToString() + "%"; 
        }
    }
}
