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
            //// Get values from current config
            // Settings
            // Auto-Save
            SavingAutoSaveTextBox.Text = Convert.ToInt32( _extras.GetLineValue( Fallout4PrefsLocation, "fAutosaveEveryXMins" ) ).ToString();
            // HUD
            // Opacity
            HUDOpacityResult.Text = Convert.ToString( Convert.ToInt32( Convert.ToDecimal( _extras.GetLineValue( Fallout4PrefsLocation, "fHUDOpacity" ) ) * 100 ) ) + Resources.Percentage;
            HUDOpacityTrackBar.Value = Convert.ToInt32( Convert.ToDecimal( _extras.GetLineValue( Fallout4PrefsLocation, "fHUDOpacity" ) ) * 100 );
            // Color
            var hudColorRed = _extras.GetLineValue( Fallout4PrefsLocation, "iHUDColorR" );
            var hudColorGreen = _extras.GetLineValue( Fallout4PrefsLocation, "iHUDColorG" );
            var hudColorBlue = _extras.GetLineValue( Fallout4PrefsLocation, "iHUDColorB" );
            HUDColorRedTrackBar.Value = Convert.ToInt16( hudColorRed );
            HUDColorRedTextBox.Text = hudColorRed.ToString();
            HUDColorGreenTrackBar.Value = Convert.ToInt16( hudColorGreen );
            HUDColorGreenTextBox.Text = hudColorGreen.ToString();
            HUDColorBlueTrackBar.Value = Convert.ToInt16( hudColorBlue );
            HUDColorBlueTextBox.Text = hudColorBlue.ToString();
            // Preview
            HUDColorPreviewBox.BackColor = Color.FromArgb(
                Convert.ToInt16( hudColorRed ),
                Convert.ToInt16( hudColorGreen ),
                Convert.ToInt16( hudColorBlue )
                );

            // Pip-Boy
            // Color
            var pipBoyColorRed = _extras.GetLineValue( Fallout4PrefsLocation, "fPipboyEffectColorR" );
            var pipBoyColorGreen = _extras.GetLineValue( Fallout4PrefsLocation, "fPipboyEffectColorG" );
            var pipBoyColorBlue = _extras.GetLineValue( Fallout4PrefsLocation, "fPipboyEffectColorB" );
            PipBoyColorRedTrackBar.Value = Convert.ToInt32( Convert.ToDecimal( _extras.GetLineValue( Fallout4PrefsLocation, "fPipboyEffectColorR" ) ) * 100 );
            PipBoyColorRedTextBox.Text = pipBoyColorRed.ToString();
            PipBoyColorGreenTrackBar.Value = Convert.ToInt32( Convert.ToDecimal( _extras.GetLineValue( Fallout4PrefsLocation, "fPipboyEffectColorG" ) ) * 100 );
            PipBoyColorGreenTextBox.Text = pipBoyColorGreen.ToString();
            PipBoyColorBlueTrackBar.Value = Convert.ToInt32( Convert.ToDecimal( _extras.GetLineValue( Fallout4PrefsLocation, "fPipboyEffectColorB" ) ) * 100 );
            PipBoyColorBlueTextBox.Text = pipBoyColorBlue.ToString();

            SavingQuickPause.Checked = Convert.ToInt16( _extras.GetLineValue( Fallout4PrefsLocation, "" ) ) == 1;
            SavingQuickTravel.Checked = Convert.ToInt16( _extras.GetLineValue( Fallout4PrefsLocation, "" ) ) == 1;
            SavingQuickWaiting.Checked = Convert.ToInt16( _extras.GetLineValue( Fallout4PrefsLocation, "" ) ) == 1;
            SavingQuickSleeping.Checked = Convert.ToInt16( _extras.GetLineValue( Fallout4PrefsLocation, "" ) ) == 1;
        }

        public Form1() {
            // Some (most) coutries uses comma (,) as decimal mark, but some countries just has to fuck everything up.
            // And Bethesda uses the a point (.) in their config file...
            // This fixes it.
            Application.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture( "en-US" );

            InitializeComponent();

            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;

            GetAllValues();
        }

        public sealed override bool AutoSize
        {
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
            var pattern = @"fHUDOpacity=([0-9\.]+)";
            var replacement = "fHUDOpacity=" + Math.Round( Convert.ToDouble( HUDOpacityTrackBar.Value ) / 100, 4 );
            Regex rgx = new Regex( pattern );
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

            // Write to file
            File.WriteAllText( Fallout4PrefsLocation, text );
        }
        private void btnDefault_Click( object sender, EventArgs e ) {
            GetAllValues();
        }
        private void btnOMFGQUIT_Click( object sender, EventArgs e ) {
            Application.Exit();
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
    }
}
