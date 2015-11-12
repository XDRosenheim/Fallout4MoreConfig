using System;
using System.Diagnostics;
using System.Drawing;
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
        /// This is going to be moved to its own class later.
        /// WE ARE NOT EVEN IN AN ALPHA STAGE FOLKS!
        /// </summary>
        /// <param name="file">Full path to file, including filename.</param>
        /// <param name="command">The command used for the setting.</param>
        /// <returns>An object</returns>
        public object GetLineValue( string file, string command ) {
            using(StreamReader inputReader = new StreamReader( fallout4PrefsLocation )) {
                while(!inputReader.EndOfStream) {
                    var line = inputReader.ReadLine();
                    if(line.StartsWith( command )) {
                        try {
                            object[] splitLine = line.Split( new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries );
                            return splitLine[1];
                        } catch(Exception e) {
                            // TODO - Copy error to clipboard button.
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
            SavingAutoSaveTextBox.Text = Convert.ToInt32( GetLineValue( fallout4PrefsLocation, "fAutosaveEveryXMins" ) ).ToString();

            /// HUD
            // Opacity
            HUDOpacityResult.Text = Convert.ToString( Convert.ToInt32( Convert.ToDecimal( GetLineValue( fallout4PrefsLocation, "fHUDOpacity" ) ) * 100 ) ) + "%";
            HUDOpacityTrackBar.Value = Convert.ToInt32( Convert.ToDecimal( GetLineValue( fallout4PrefsLocation, "fHUDOpacity" ) ) * 100 );
            // Color
            var HUDColorRed = GetLineValue( fallout4PrefsLocation, "iHUDColorR" );
            var HUDColorGreen = GetLineValue( fallout4PrefsLocation, "iHUDColorG" );
            var HUDColorBlue = GetLineValue( fallout4PrefsLocation, "iHUDColorB" );
            HUDColorRedTrackBar.Value = Convert.ToInt16(HUDColorRed);
            HUDColorRedTextBox.Text = HUDColorRed.ToString();
            HUDColorGreenTrackBar.Value = Convert.ToInt16( HUDColorGreen );
            HUDColorGreenTextBox.Text = HUDColorGreen.ToString();
            HUDColorBlueTrackBar.Value = Convert.ToInt16( HUDColorBlue );
            HUDColorBlueTextBox.Text = HUDColorBlue.ToString();
            // Preview
            HUDColorPreviewBox.BackColor = Color.FromArgb( 
                Convert.ToInt16(HUDColorRed),
                Convert.ToInt16(HUDColorGreen),
                Convert.ToInt16(HUDColorBlue)
                );

            /// Pip-Boy
            // Color
            var PipBoyColorRed = GetLineValue( fallout4PrefsLocation, "fPipboyEffectColorR" );
            var PipBoyColorGreen = GetLineValue( fallout4PrefsLocation, "fPipboyEffectColorG" );
            var PipBoyColorBlue = GetLineValue( fallout4PrefsLocation, "fPipboyEffectColorB" );
            PipBoyColorRedTrackBar.Value = Convert.ToInt32( Convert.ToDecimal( GetLineValue( fallout4PrefsLocation, "fPipboyEffectColorR" ) ) * 100 );
            PipBoyColorRedTextBox.Text = PipBoyColorRed.ToString();
            PipBoyColorGreenTrackBar.Value = Convert.ToInt32( Convert.ToDecimal( GetLineValue( fallout4PrefsLocation, "fPipboyEffectColorG" ) ) * 100 );
            PipBoyColorGreenTextBox.Text = PipBoyColorGreen.ToString();
            PipBoyColorBlueTrackBar.Value = Convert.ToInt32( Convert.ToDecimal( GetLineValue( fallout4PrefsLocation, "fPipboyEffectColorB" ) ) * 100 );
            PipBoyColorBlueTextBox.Text = PipBoyColorBlue.ToString();
        }
        

        // The buttons
        private void btnSave_Click( object sender, EventArgs e ) {
            // ATTENTION !!
            // THE FOLLOWING IS A MESS !!
            // IT READS THE WHOLE FILE TO MEMORY !!
            // PLEASE CONTACT ME ON GITHUB IF YOU HAVE A SOLUTION !!
            // http://github.com/XDRosenheim/Fallout4MoreConfig
            // But, hey, it works...

            string text = File.ReadAllText( fallout4PrefsLocation );
            // HUD - opacity
            string pattern = @"fHUDOpacity=([0-9\.]+)";
            string replacement = "fHUDOpacity=" + Math.Round( Convert.ToDouble( HUDOpacityTrackBar.Value ) / 100, 4 );
            Regex rgx = new Regex( pattern );
            text = rgx.Replace( text, replacement );
            // Settings - Autosave
            pattern = @"fAutosaveEveryXMins=([0-9\.]+)";
            replacement = "fAutosaveEveryXMins=" + Math.Round( Convert.ToDouble( SavingAutoSaveTextBox.Text ), 4 );
            rgx = new Regex( pattern );
            text = rgx.Replace( text, replacement );
            // Write to file
            File.WriteAllText( fallout4PrefsLocation, text );
        }
        private void btnDefault_Click( object sender, EventArgs e ) {

        }
        private void btnOMFGQUIT_Click( object sender, EventArgs e ) { 
            Application.Exit(); 
        }
        private void button4_Click( object sender, EventArgs e ) {
            Process.Start( "http://github.com/XDRosenheim/Fallout4MoreConfig" );
        }

        // Scrollers - Track bars - Sliders - Whatever
        private void trackHudOpacity_Scroll( object sender, EventArgs e ) {
            HUDOpacityResult.Text = HUDOpacityTrackBar.Value.ToString() + "%";
        }
        private void HUDColorRedTrackBar_Scroll( object sender, EventArgs e ) {
            HUDColorRedTextBox.Text = HUDColorRedTrackBar.Value.ToString();
            HUDColorPreviewBox.BackColor = Color.FromArgb( HUDColorRedTrackBar.Value, HUDColorGreenTrackBar.Value, HUDColorBlueTrackBar.Value );
        }
        private void HUDColorGreenTrackBar_Scroll( object sender, EventArgs e ) {
            HUDColorGreenTextBox.Text = HUDColorGreenTrackBar.Value.ToString();
            HUDColorPreviewBox.BackColor = Color.FromArgb( HUDColorRedTrackBar.Value, HUDColorGreenTrackBar.Value, HUDColorBlueTrackBar.Value );
        }
        private void HUDColorBlueTrackBar_Scroll( object sender, EventArgs e ) {
            HUDColorBlueTextBox.Text = HUDColorBlueTrackBar.Value.ToString();
            HUDColorPreviewBox.BackColor = Color.FromArgb( HUDColorRedTrackBar.Value, HUDColorGreenTrackBar.Value, HUDColorBlueTrackBar.Value );
        }

        
    }
}
