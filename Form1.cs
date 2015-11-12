using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Fallout4MoreConfig {
    public partial class Form1 : Form {
        public string fallout4Location = Environment.ExpandEnvironmentVariables( "%HOMEPATH%" )
                + @"\Documents\My Games\fallout4\Fallout4.ini";
        public string fallout4PrefsLocation = Environment.ExpandEnvironmentVariables( "%HOMEPATH%" )
                + @"\Documents\My Games\fallout4\Fallout4Prefs.ini";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file">Full path to file, including filename.</param>
        /// <param name="lineStartsWith"></param>
        /// <returns></returns>
        public string GetLineValue( string file, string lineStartsWith ) {
            using(StreamReader inputReader = new StreamReader( fallout4PrefsLocation )) {
                while(!inputReader.EndOfStream) {
                    var line = inputReader.ReadLine();
                    if(line.StartsWith( lineStartsWith )) {
                        try {
                            string[] splitLine = line.Split( new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries );
                            return splitLine[1];
                        } catch(Exception e) {
                            MessageBox.Show( "Please report the following code on github: \n" + e.ToString(),
                                "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error );
                            Application.Exit();
                        }
                    }
                }
            }
            return "%ERROR%";
        }
        public Form1() {
            // Some (most) coutries uses comma (,) as decimal mark, but some countries just has to fuck everything up.
            // And Bethesda uses the a point (.) in their config file...
            // This fixes it.
            Application.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture( "en-US" );

            InitializeComponent();
            //// Get values from current config

            /// Settings
            // Auto-Save
            SettingsTextBoxAutoSave.Text = Convert.ToInt32( Convert.ToDecimal( GetLineValue( fallout4PrefsLocation, "fAutosaveEveryXMins" ) ) ).ToString();

            /// HUD
            // Opacity
            HUDOpacityResult.Text = Convert.ToString( Convert.ToInt32( Convert.ToDecimal( GetLineValue( fallout4PrefsLocation, "fHUDOpacity" ) ) * 100 ) ) + "%";
            HUDOpacityTrackBar.Value = Convert.ToInt32( Convert.ToDecimal( GetLineValue( fallout4PrefsLocation, "fHUDOpacity" ) ) * 100 );
        }
        private void trackHudOpacity_Scroll( object sender, EventArgs e ) {
            HUDOpacityResult.Text = HUDOpacityTrackBar.Value.ToString() + "%";
        }
        private void btnSave_Click( object sender, EventArgs e ) {
            /// ATTENTION !!
            /// THE FOLLOWING IS A MESS !!
            /// IT READS THE WHOLE FILE TO MEMORY !!
            /// PLEASE CONTACT ME ON GITHUB IF YOU HAVE A SOLUTION !!
            /// 
            /// But, hey, it works...

            string text = File.ReadAllText( fallout4PrefsLocation );
            // HUD - opacity
            string pattern = @"fHUDOpacity=([0-9\.]+)";
            string replacement = "fHUDOpacity=" + Math.Round( Convert.ToDouble( HUDOpacityTrackBar.Value ) / 100, 4 );
            Regex rgx = new Regex( pattern );
            text = rgx.Replace( text, replacement );
            // Settings - Autosave
            pattern = @"fAutosaveEveryXMins=([0-9\.]+)";
            replacement = "fAutosaveEveryXMins=" + Math.Round( Convert.ToDouble( SettingsTextBoxAutoSave.Text ), 4 );
            rgx = new Regex( pattern );
            text = rgx.Replace( text, replacement );
            // Write to file
            File.WriteAllText( fallout4PrefsLocation, text );
        }
        private void btnOMFGQUIT_Click( object sender, EventArgs e ) { Application.Exit(); }
    }
}
