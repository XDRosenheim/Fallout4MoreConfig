using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Fallout4MoreConfig.Properties;

namespace Fallout4MoreConfig {
    public partial class Form1 : Form {
        public string Fallout4Location = Environment.ExpandEnvironmentVariables( "%HOMEPATH%" )
                + @"\Documents\My Games\fallout4\Fallout4.ini";
        public string Fallout4PrefsLocation = Environment.ExpandEnvironmentVariables( "%HOMEPATH%" )
                + @"\Documents\My Games\fallout4\Fallout4Prefs.ini";

        private readonly Extras _extras = new Extras();

        public void GetAllValues() {
            // Get values from current config
            #region Saving
            #region Auto-Save
            SavingAutoSaveTextBox.Text = Convert.ToInt32( _extras.GetLineValue( Fallout4PrefsLocation, "fAutosaveEveryXMins" ) ).ToString();
            #endregion
            #region Quick-Save
            SavingQuickPause.Checked = Convert.ToInt16( _extras.GetLineValue( Fallout4PrefsLocation, "bSaveOnPause" ) ) == 1;
            SavingQuickTravel.Checked = Convert.ToInt16( _extras.GetLineValue( Fallout4PrefsLocation, "bSaveOnTravel" ) ) == 1;
            SavingQuickWaiting.Checked = Convert.ToInt16( _extras.GetLineValue( Fallout4PrefsLocation, "bSaveOnWait" ) ) == 1;
            SavingQuickSleeping.Checked = Convert.ToInt16( _extras.GetLineValue( Fallout4PrefsLocation, "bSaveOnRest" ) ) == 1;
            #endregion
            #endregion
            #region HUD
            #region Opacity
            HUDOpacityResult.Text = Convert.ToString( Convert.ToInt32( Convert.ToDecimal( _extras.GetLineValue( Fallout4PrefsLocation, "fHUDOpacity" ) ) * 100 ) ) + Resources.Percentage;
            HUDOpacityTrackBar.Value = Convert.ToInt32( Convert.ToDecimal( _extras.GetLineValue( Fallout4PrefsLocation, "fHUDOpacity" ) ) * 100 );
            #endregion
            #region Color
            var hudColorRed = _extras.GetLineValue( Fallout4PrefsLocation, "iHUDColorR" );
            var hudColorGreen = _extras.GetLineValue( Fallout4PrefsLocation, "iHUDColorG" );
            var hudColorBlue = _extras.GetLineValue( Fallout4PrefsLocation, "iHUDColorB" );
            HUDColorRedTrackBar.Value = Convert.ToInt16( hudColorRed );
            HUDColorRedTextBox.Text = hudColorRed.ToString();
            HUDColorGreenTrackBar.Value = Convert.ToInt16( hudColorGreen );
            HUDColorGreenTextBox.Text = hudColorGreen.ToString();
            HUDColorBlueTrackBar.Value = Convert.ToInt16( hudColorBlue );
            HUDColorBlueTextBox.Text = hudColorBlue.ToString();
            #endregion
            #region Preview
            HUDColorPreviewBox.BackColor = Color.FromArgb( Convert.ToInt16( hudColorRed ), Convert.ToInt16( hudColorGreen ), Convert.ToInt16( hudColorBlue ) );
            #endregion
            #region FOV
            var hudFirstFov = _extras.GetLineValue( Fallout4Location, "fDefault1stPersonFOV" );
            var hudThirdFov = _extras.GetLineValue( Fallout4Location, "fDefaultWorldFOV" );
            hudFovFirst.Text = hudFirstFov.ToString();
            hudFovThird.Text = hudThirdFov.ToString();
            #endregion
            #endregion
            #region Pip-Boy
            #region Color
            var pipBoyColorRed = _extras.GetLineValue( Fallout4PrefsLocation, "fPipboyEffectColorR" );
            var pipBoyColorGreen = _extras.GetLineValue( Fallout4PrefsLocation, "fPipboyEffectColorG" );
            var pipBoyColorBlue = _extras.GetLineValue( Fallout4PrefsLocation, "fPipboyEffectColorB" );
            PipBoyColorRedTrackBar.Value = Convert.ToInt32( Convert.ToDecimal( _extras.GetLineValue( Fallout4PrefsLocation, "fPipboyEffectColorR" ) ) * 100 );
            PipBoyColorRedTextBox.Text = pipBoyColorRed.ToString();
            PipBoyColorGreenTrackBar.Value = Convert.ToInt32( Convert.ToDecimal( _extras.GetLineValue( Fallout4PrefsLocation, "fPipboyEffectColorG" ) ) * 100 );
            PipBoyColorGreenTextBox.Text = pipBoyColorGreen.ToString();
            PipBoyColorBlueTrackBar.Value = Convert.ToInt32( Convert.ToDecimal( _extras.GetLineValue( Fallout4PrefsLocation, "fPipboyEffectColorB" ) ) * 100 );
            PipBoyColorBlueTextBox.Text = pipBoyColorBlue.ToString();
            #endregion
            #endregion
        }

        public Form1() {
            // See if config files exists
            if(!File.Exists( Fallout4Location ))
            {
                MessageBox.Show(
                    Fallout4PrefsLocation + Resources.string_path_not_found_ + Resources.string_newLine +
                    Resources.string_please_run_game_, Resources.String_Error_, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            File.Exists(Fallout4PrefsLocation);
            // Some (most) coutries uses comma (,) as decimal mark, but some countries just has to fuck everything up.
            // And Bethesda uses a point (.) in their config file...
            // This should make it work for everybody.
            Application.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture( "en-US" );

            InitializeComponent();

            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;

            GetAllValues();
        }

        public sealed override bool AutoSize {
            get { return base.AutoSize; }
            set { base.AutoSize = value; }
        }

        // The buttons
        private void btnSave_Click( object sender, EventArgs e ) {
            // ATTENTION !!
            // THE FOLLOWING IS A MESS !!
            // IT READS THE WHOLE FILE TO MEMORY !!
            // PLEASE CONTACT ME ON GITHUB IF YOU HAVE A SOLUTION !!
            // http://github.com/XDRosenheim/Fallout4MoreConfig
            // But, hey, it works...

            // Get the WHOLE file
            var text = File.ReadAllText( Fallout4PrefsLocation );

            #region HUD
            #region Opacity
            // Make a pattern for Regex
            var pattern = @"fHUDOpacity=([0-9\.]+)";
            // What to write on the line we are editing
            var replacement = "fHUDOpacity=" + Math.Round( Convert.ToDouble( HUDOpacityTrackBar.Value ) / 100, 4 );
            // Give Regex the pattern
            var rgx = new Regex( pattern );
            // Write the file, but with changes
            text = rgx.Replace( text, replacement );
            #endregion
            #region HUD Color
            #region R
            pattern = @"iHUDColorR=([0-9\.]+)";
            replacement = "iHUDColorR=" + Math.Round( Convert.ToDouble( HUDColorRedTrackBar.Value ), 4 );
            rgx = new Regex( pattern );
            text = rgx.Replace( text, replacement );
            #endregion
            #region G
            pattern = @"iHUDColorG=([0-9\.]+)";
            replacement = "iHUDColorG=" + Math.Round( Convert.ToDouble( HUDColorGreenTrackBar.Value ), 4 );
            rgx = new Regex( pattern );
            text = rgx.Replace( text, replacement );
            #endregion
            #region B
            pattern = @"iHUDColorB=([0-9\.]+)";
            replacement = "iHUDColorB=" + Math.Round( Convert.ToDouble( HUDColorBlueTrackBar.Value ), 4 );
            rgx = new Regex( pattern );
            text = rgx.Replace( text, replacement );
            #endregion
            #endregion
            #region FOV
            pattern = @"fDefaultWorldFOV=([0-9\.]+)";
            replacement = "fDefaultWorldFOV=" + Math.Round( Convert.ToDouble( HUDColorRedTrackBar.Value ), 4 );
            rgx = new Regex( pattern );
            text = rgx.Replace( text, replacement );
            #endregion
            #endregion

            #region Saving
            #region Auto
            pattern = @"fAutosaveEveryXMins=([0-9\.]+)";
            replacement = "fAutosaveEveryXMins=" + Math.Round( Convert.ToDouble( SavingAutoSaveTextBox.Text ), 4 );
            rgx = new Regex( pattern );
            text = rgx.Replace( text, replacement );
            #endregion
            #region Quick Saves
            int saPaused = 0, saTravel = 0, saWaiting = 0, saSleeping = 0;
            pattern = @"bSaveOnPause=([0-9\.]+)";
            if(SavingQuickPause.Checked) { saPaused = 1; }
            if(SavingQuickTravel.Checked) { saTravel = 1; }
            if(SavingQuickWaiting.Checked) { saWaiting = 1; }
            if(SavingQuickSleeping.Checked) { saSleeping = 1; }
            replacement = "bSaveOnPause=" + saPaused;
            rgx = new Regex( pattern );
            text = rgx.Replace( text, replacement );
            pattern = @"bSaveOnTravel=([0-9\.]+)";
            replacement = "bSaveOnTravel=" + saTravel;
            rgx = new Regex( pattern );
            text = rgx.Replace( text, replacement );
            pattern = @"bSaveOnWait=([0-9\.]+)";
            replacement = "bSaveOnWait=" + saWaiting;
            rgx = new Regex( pattern );
            text = rgx.Replace( text, replacement );
            pattern = @"bSaveOnRest=([0-9\.]+)";
            replacement = "bSaveOnRest=" + saSleeping;
            rgx = new Regex( pattern );
            text = rgx.Replace( text, replacement );
            #endregion
            #endregion

            #region Gamepad
            int gpEnable = 0, gpRumble = 0;
            if(gamepadEnable.Checked) { gpEnable = 1; }
            if(gamepadRumble.Checked) { gpRumble = 1; }
            pattern = @"bGamepadEnable=([0-9\.]+)";
            replacement = "bGamepadEnable=" + gpEnable;
            rgx = new Regex( pattern );
            text = rgx.Replace( text, replacement );
            pattern = @"bGamePadRumble=([0-9\.]+)";
            replacement = "bGamePadRumble=" + gpRumble;
            rgx = new Regex( pattern );
            text = rgx.Replace( text, replacement );
            #endregion

            File.SetAttributes( Fallout4PrefsLocation, File.GetAttributes( Fallout4PrefsLocation ) & FileAttributes.Normal );
            File.SetAttributes( Fallout4Location, File.GetAttributes( Fallout4Location ) & FileAttributes.Normal );
            // Write to file
            File.WriteAllText( Fallout4PrefsLocation, text );

            if(!tweakReadonly.Checked) return;
            File.SetAttributes( Fallout4PrefsLocation, File.GetAttributes( Fallout4PrefsLocation ) & ~FileAttributes.ReadOnly );
            File.SetAttributes( Fallout4Location, File.GetAttributes( Fallout4Location ) & ~FileAttributes.ReadOnly );
        }
        private void btnDefault_Click( object sender, EventArgs e ) {
            GetAllValues();
        }
        private void btnSource_Click( object sender, EventArgs e ) {
            Process.Start( "http://github.com/XDRosenheim/Fallout4MoreConfig" );
        }

        // Scrollers - Track bars - Sliders - Whatever
        private void trackHudOpacity_Scroll( object sender, EventArgs e ) {
            HUDOpacityResult.Text = HUDOpacityTrackBar.Value + Resources.Percentage;
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

        // Audio Track Bars
        private void AudioMasterTrackbar_Scroll( object sender, EventArgs e ) {
            AudioMasterText.Text = AudioMasterTrackbar.Value.ToString();
        }
        private void AudioVal0TrackBar_Scroll( object sender, EventArgs e ) {
            AudioVal0Text.Text = AudioVal0TrackBar.Value.ToString();
        }
        private void AudioVal1TrackBar_Scroll( object sender, EventArgs e ) {
            AudioVal1Text.Text = AudioVal1TrackBar.Value.ToString();
        }
        private void AudioVal2TrackBar_Scroll( object sender, EventArgs e ) {
            AudioVal2Text.Text = AudioVal2TrackBar.Value.ToString();
        }
        private void AudioVal3TrackBar_Scroll( object sender, EventArgs e ) {
            AudioVal3Text.Text = AudioVal3TrackBar.Value.ToString();
        }
        private void AudioVal4TrackBar_Scroll( object sender, EventArgs e ) {
            AudioVal4Text.Text = AudioVal4TrackBar.Value.ToString();
        }
        private void AudioVal5TrackBar_Scroll( object sender, EventArgs e ) {
            AudioVal5Text.Text = AudioVal5TrackBar.Value.ToString();
        }
        private void AudioVal6TrackBar_Scroll( object sender, EventArgs e ) {
            AudioVal6Text.Text = AudioVal6TrackBar.Value.ToString();
        }
        private void AudioVal7TrackBar_Scroll( object sender, EventArgs e ) {
            AudioVal7Text.Text = AudioVal7TrackBar.Value.ToString();
        }

        //Changes
        private void resolutionFullscreen_CheckedChanged( object sender, EventArgs e ) {
            if(resolutionFullscreen.Checked) {
                resolutionBorderless.Checked = true;
                resolutionBorderless.Enabled = false;
            } else {
                resolutionBorderless.Enabled = true;
            }
        }
    }
}
