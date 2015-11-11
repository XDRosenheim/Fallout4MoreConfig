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
            Application.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
            InitializeComponent();
            // TODO Get values from config files
            HUDOpacityValue.Text = "GET VALUE FROM FILE";
        }

        private void trackHudOpacity_Scroll(object sender, EventArgs e) { 
            HUDOpacityValue.Text = trackHudOpacity.Value.ToString() + "%"; 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            /// ATTENTION !!
            /// THE FOLLOWING IS A MESS !!
            /// IT READ THE WHOLE FILE TO MEMORY !!
            /// PLEASE CONTACT ME ON GITHUB IF YOU HAVE A SOLUTION !!
            /// But it works...

            // File path
            string fallout4PrefsLocation = Environment.ExpandEnvironmentVariables("%HOMEPATH%") 
                + "\\Documents\\My Games\\fallout4\\Fallout4Prefs.ini";
            string text = File.ReadAllText(fallout4PrefsLocation);
            // HUD - opacity
            string pattern = @"fHUDOpacity=([A-Za-z0-9\-\.]+)";
            string replacement = "fHUDOpacity=" + Math.Round(Convert.ToDouble(trackHudOpacity.Value) / 100, 4);
            Regex rgx = new Regex(pattern);
            string result = rgx.Replace(text, replacement);
            
            // Write to file
            File.WriteAllText(fallout4PrefsLocation, result);
        }

        private void btnOMFGQUIT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
