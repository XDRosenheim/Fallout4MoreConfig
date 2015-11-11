using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Fallout4MoreConfig
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // TODO Get values from config files
            HUDOpacityValue.Text = "GET VALUE FROM FILE";
        }

        private void trackHudOpacity_Scroll(object sender, EventArgs e) { 
            HUDOpacityValue.Text = trackHudOpacity.Value.ToString() + "%"; 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ///
            /// TODO Save to file(s)
            /// 
            
            // HUD - opacity
            string path = Environment.ExpandEnvironmentVariables("%HOMEPATH%") + "\\Documents\\My Games\\fallout4\\Fallout4Prefs.ini";
            string text = File.ReadAllText(path);
            string pattern = @"fHUDOpacity=([A-Za-z0-9\-]+)";
            string replacement = "fHUDOpacity=" + (trackHudOpacity.Value / 100);
            Regex rgx = new Regex(pattern);
            string result = rgx.Replace(text, replacement);
            File.WriteAllText(path, result);
        }

        private void btnOMFGQUIT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
