using System;
using System.Configuration;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Fallout4MoreConfig.Properties;
using MyDLL;

namespace Fallout4MoreConfig {
    /// TODO: This list
    /// TODO: This list - HUD
    /// The preview, should have a/some screenshot(s) where the actual hud is shown.
    /// Screenshot should also work with FOV changes.
    /// 
    /// TODO: This list - Audio
    /// Val0-7 should be analliesed, so I know which does what. (They are not descriped in the configs)
    /// 
    /// TODO: This list - Pip-Boy
    /// The preview, should have a/some screenshot(s) where the actual hud is shown.
    /// 
    /// TODO: This list - Gamepad
    /// Add more things.
    /// Sensitivity?
    /// 
    /// TODO: This list - Resolution
    /// Presets.
    /// 
    public partial class Form1 : XCoolForm.XCoolForm {
        private static readonly Extras Extras = new Extras();
        public string CurrentVersion {
            get {
                return ApplicationDeployment.IsNetworkDeployed
                       ? ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString()
                       : Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        public string ConfigFile = Extras.ConfigFile();
        public string PrefsConfigFile = Extras.PrefsConfigFile();
        public string CustomConfigFile = Extras.CustomConfigFile();
        public string ConfigFileBackup = Extras.ConfigFileBackup();
        public string PrefsConfigFileBackup = Extras.PrefsConfigFileBackup();
        public string CustomConfigFileBackup = Extras.CustomConfigFileBackup();
        public void GetAllValues() {
            try {
                // Get values from current config
                #region Visuals
                #region Image Space
                VisualsDoF.Checked = Convert.ToInt16( Extras.GetIniValue( PrefsConfigFile, "Imagespace", "bDoDepthOfField" ) ) == 1;
                VisualsLensflare.Checked = Convert.ToInt16( Extras.GetIniValue( PrefsConfigFile, "Imagespace", "bLensFlare" ) ) == 1;
                VisualsGore.Checked = Convert.ToInt16( Extras.GetIniValue( ConfigFile, "General", "bDisableAllGore" ) ) == 1;
                VisualsScreenBlood.Checked = Convert.ToInt16( Extras.GetIniValue( ConfigFile, "ScreenSplatter", "bBloodSplatterEnabled" ) ) == 1;
                VisualsRadialBlur.Checked = Convert.ToInt32( Extras.GetIniValue( ConfigFile, "ImageSpace", "bDoRadialBlur" ) ) == 1;
                VisualWaterSky.Checked = Convert.ToInt16( Extras.GetIniValue( ConfigFile, "Water", "bReflectSky" ) ) == 1;
                VisualWaterLand.Checked = Convert.ToInt16( Extras.GetIniValue( ConfigFile, "Water", "bReflectLODLand" ) ) == 1;
                VisualWaterTree.Checked = Convert.ToInt16( Extras.GetIniValue( ConfigFile, "Water", "bReflectLODTrees" ) ) == 1;
                VisualWaterObjects.Checked = Convert.ToInt16( Extras.GetIniValue( ConfigFile, "Water", "bReflectLODObjects" ) ) == 1;
                #endregion
                #endregion
                #region Audio
                #region Master
                var masterVolume = Convert.ToDecimal( Extras.GetIniValue( PrefsConfigFile, "AudioMenu", "fAudioMasterVolume" ) );
                AudioMasterTrackbar.Value = (int)( masterVolume * 100 );
                AudioMasterText.Text = ( (int)( masterVolume * 100 ) ).ToString();
                #endregion
                #region Val
                #region 0
                var val0 = Convert.ToDecimal( Extras.GetIniValue( PrefsConfigFile, "AudioMenu", "fVal0" ) );
                AudioVal0TrackBar.Value = (int)( val0 * 100 );
                AudioVal0Text.Text = ( (int)( val0 * 100 ) ).ToString();
                #endregion
                #region 1
                var val1 = Convert.ToDecimal( Extras.GetIniValue( PrefsConfigFile, "AudioMenu", "fVal1" ) );
                AudioVal1TrackBar.Value = (int)( val1 * 100 );
                AudioVal1Text.Text = ( (int)( val1 * 100 ) ).ToString();
                #endregion
                #region 2
                var val2 = Convert.ToDecimal( Extras.GetIniValue( PrefsConfigFile, "AudioMenu", "fVal2" ) );
                AudioVal2TrackBar.Value = (int)( val2 * 100 );
                AudioVal2Text.Text = ( (int)( val2 * 100 ) ).ToString();
                #endregion
                #region 3
                var val3 = Convert.ToDecimal( Extras.GetIniValue( PrefsConfigFile, "AudioMenu", "fVal3" ) );
                AudioVal3TrackBar.Value = (int)( val3 * 100 );
                AudioVal3Text.Text = ( (int)( val3 * 100 ) ).ToString();
                #endregion
                #region 4
                var val4 = Convert.ToDecimal( Extras.GetIniValue( PrefsConfigFile, "AudioMenu", "fVal4" ) );
                AudioVal4TrackBar.Value = (int)( val4 * 100 );
                AudioVal4Text.Text = ( (int)( val4 * 100 ) ).ToString();
                #endregion
                #region 5
                var val5 = Convert.ToDecimal( Extras.GetIniValue( PrefsConfigFile, "AudioMenu", "fVal5" ) );
                AudioVal5TrackBar.Value = (int)( val5 * 100 );
                AudioVal5Text.Text = ( (int)( val5 * 100 ) ).ToString();
                #endregion
                #region 6
                var val6 = Convert.ToDecimal( Extras.GetIniValue( PrefsConfigFile, "AudioMenu", "fVal6" ) );
                AudioVal6TrackBar.Value = (int)( val6 * 100 );
                AudioVal6Text.Text = ( (int)( val6 * 100 ) ).ToString();
                #endregion
                #region 7
                var val7 = Convert.ToDecimal( Extras.GetIniValue( PrefsConfigFile, "AudioMenu", "fVal7" ) );
                AudioVal7TrackBar.Value = (int)( val7 * 100 );
                AudioVal7Text.Text = ( (int)( val7 * 100 ) ).ToString();
                #endregion
                #endregion
                #endregion
                #region Saving
                #region Auto-Save
                SavingAutoSaveTextBox.Text = Convert.ToInt32( Convert.ToDecimal( Extras.GetIniValue( PrefsConfigFile, "SaveGame", "fAutosaveEveryXMins" ) ) ).ToString();
                #endregion
                #region Quick-Save
                SavingQuickPause.Checked = Convert.ToInt16( Extras.GetIniValue( PrefsConfigFile, "MAIN", "bSaveOnPause" ) ) == 1;
                SavingQuickTravel.Checked = Convert.ToInt16( Extras.GetIniValue( PrefsConfigFile, "MAIN", "bSaveOnTravel" ) ) == 1;
                SavingQuickWaiting.Checked = Convert.ToInt16( Extras.GetIniValue( PrefsConfigFile, "MAIN", "bSaveOnWait" ) ) == 1;
                SavingQuickSleeping.Checked = Convert.ToInt16( Extras.GetIniValue( PrefsConfigFile, "MAIN", "bSaveOnRest" ) ) == 1;
                #endregion
                #endregion
                #region HUD
                #region Opacity
                HUDOpacityResult.Text = Convert.ToString( Convert.ToInt32( Convert.ToDecimal( Extras.GetIniValue( PrefsConfigFile, "MAIN", "fHUDOpacity" ) ) * 100 ) ) + Resources.Percentage;
                HUDOpacityTrackBar.Value = Convert.ToInt32( Convert.ToDecimal( Extras.GetIniValue( PrefsConfigFile, "MAIN", "fHUDOpacity" ) ) * 100 );
                #endregion
                #region Color
                #region Red
                var hudColorRed = Extras.GetIniValue( PrefsConfigFile, "Interface", "iHUDColorR" );
                hudColorRedTrackBar.Value = Convert.ToInt16( hudColorRed );
                hudColorRedTextBox.Text = hudColorRed.ToString();
                #endregion
                #region Green
                var hudColorGreen = Extras.GetIniValue( PrefsConfigFile, "Interface", "iHUDColorG" );
                hudColorGreenTrackBar.Value = Convert.ToInt16( hudColorGreen );
                hudColorGreenTextBox.Text = hudColorGreen.ToString();
                #endregion
                #region Blue
                var hudColorBlue = Extras.GetIniValue( PrefsConfigFile, "Interface", "iHUDColorB" );
                hudColorBlueTrackBar.Value = Convert.ToInt16( hudColorBlue );
                hudColorBlueTextBox.Text = hudColorBlue.ToString();
                #endregion
                #region Preview
                hudColorPreviewBox.BackColor = Color.FromArgb( Convert.ToInt16( hudColorRed ),
                    Convert.ToInt16( hudColorGreen ), Convert.ToInt16( hudColorBlue ) );
                #endregion
                #endregion
                #region FOV
                #region First Person
                var hudFirstFov = Extras.GetIniValue( ConfigFile, "Display", "fDefault1stPersonFOV" );
                hudFovFirst.Text = Convert.ToInt32( hudFirstFov ).ToString();
                #endregion
                #region World Person
                var hudThirdFov = Extras.GetIniValue( ConfigFile, "Display", "fDefaultWorldFOV" );
                hudFovThird.Text = Convert.ToInt32( hudThirdFov ).ToString();
                #endregion
                #endregion
                #region Quest Markers
                hudQuestMarkShow.Checked = Convert.ToInt16( Extras.GetIniValue( PrefsConfigFile, "GamePlay", "bShowQuestMarkers" ) ) == 1;
                hudQuestFloatingShow.Checked = Convert.ToInt16( Extras.GetIniValue( PrefsConfigFile, "GamePlay", "bShowFloatingQuestMarkers" ) ) == 1;
                #endregion
                #region Other
                hudCrosshair.Checked = Convert.ToInt16( Extras.GetIniValue( PrefsConfigFile, "MAIN", "bCrosshairEnabled" ) ) == 1;
                hudCompass.Checked = Convert.ToInt16( Extras.GetIniValue( PrefsConfigFile, "Interface", "bShowCompass" ) ) == 1;
                hudDialogCam.Checked = Convert.ToInt16( Extras.GetIniValue( PrefsConfigFile, "Interface", "bDialogueCameraEnable" ) ) == 1;
                hudDialogSubs.Checked = Convert.ToInt16( Extras.GetIniValue( PrefsConfigFile, "Interface", "bDialogueSubtitles" ) ) == 1;
                hudGeneralSubs.Checked = Convert.ToInt16( Extras.GetIniValue( PrefsConfigFile, "Interface", "bGeneralSubtitles" ) ) == 1;
                #endregion
                #endregion
                #region Pip-Boy
                #region Color
                #region Red
                PipBoyColorRedTrackBar.Value = Convert.ToInt32( Convert.ToDouble( Extras.GetIniValue( PrefsConfigFile, "Pipboy", "fPipboyEffectColorR" ).ToString() ) * 100 * 2.55 );
                PipBoyColorRedTextBox.Text = PipBoyColorRedTrackBar.Value.ToString();
                #endregion
                #region Green
                PipBoyColorGreenTrackBar.Value = Convert.ToInt32( Convert.ToDouble( Extras.GetIniValue( PrefsConfigFile, "Pipboy", "fPipboyEffectColorG" ).ToString() ) * 100 * 2.55 );
                PipBoyColorGreenTextBox.Text = PipBoyColorGreenTrackBar.Value.ToString();
                #endregion
                #region Blue
                PipBoyColorBlueTrackBar.Value = Convert.ToInt32( Convert.ToDouble( Extras.GetIniValue( PrefsConfigFile, "Pipboy", "fPipboyEffectColorB" ).ToString() ) * 100 * 2.55 );
                PipBoyColorBlueTextBox.Text = PipBoyColorBlueTrackBar.Value.ToString();
                #endregion
                #region Preview
                PipBoyColorPreview.BackColor = Color.FromArgb( PipBoyColorRedTrackBar.Value, PipBoyColorGreenTrackBar.Value, PipBoyColorBlueTrackBar.Value );
                #endregion
                #endregion
                #endregion
                #region VATS
                #region Color
                VATSColorR.Value = Convert.ToInt32( Convert.ToDouble( Extras.GetIniValue( PrefsConfigFile, "VATS", "fModMenuEffectColorR" ).ToString() ) * 100 * 2.55 );
                VATSColorG.Value = Convert.ToInt32( Convert.ToDouble( Extras.GetIniValue( PrefsConfigFile, "VATS", "fModMenuEffectColorG" ).ToString() ) * 100 * 2.55 );
                VATSColorB.Value = Convert.ToInt32( Convert.ToDouble( Extras.GetIniValue( PrefsConfigFile, "VATS", "fModMenuEffectColorB" ).ToString() ) * 100 * 2.55 );
                #endregion
                #region Highlight Color
                VATSHighlightColorR.Value = Convert.ToInt32( Convert.ToDouble( Extras.GetIniValue( PrefsConfigFile, "VATS", "fModMenuEffectHighlightColorR" ).ToString() ) * 100 * 2.55 );
                VATSHighlightColorG.Value = Convert.ToInt32( Convert.ToDouble( Extras.GetIniValue( PrefsConfigFile, "VATS", "fModMenuEffectHighlightColorG" ).ToString() ) * 100 * 2.55 );
                VATSHighlightColorB.Value = Convert.ToInt32( Convert.ToDouble( Extras.GetIniValue( PrefsConfigFile, "VATS", "fModMenuEffectHighlightColorB" ).ToString() ) * 100 * 2.55 );
                #endregion
                #region PA Color
                VATSPAColorR.Value = Convert.ToInt32( Convert.ToDouble( Extras.GetIniValue( PrefsConfigFile, "VATS", "fModMenuEffectPAColorR" ).ToString() ) * 100 * 2.55 );
                VATSPAColorG.Value = Convert.ToInt32( Convert.ToDouble( Extras.GetIniValue( PrefsConfigFile, "VATS", "fModMenuEffectPAColorG" ).ToString() ) * 100 * 2.55 );
                VATSPAColorB.Value = Convert.ToInt32( Convert.ToDouble( Extras.GetIniValue( PrefsConfigFile, "VATS", "fModMenuEffectPAColorB" ).ToString() ) * 100 * 2.55 );
                #endregion
                #region PA Highlight Color
                VATSHighlightPAColorR.Value = Convert.ToInt32( Convert.ToDouble( Extras.GetIniValue( PrefsConfigFile, "VATS", "fModMenuEffectHighlightPAColorR" ).ToString() ) * 100 * 2.55 );
                VATSHighlightPAColorG.Value = Convert.ToInt32( Convert.ToDouble( Extras.GetIniValue( PrefsConfigFile, "VATS", "fModMenuEffectHighlightPAColorG" ).ToString() ) * 100 * 2.55 );
                VATSHighlightPAColorB.Value = Convert.ToInt32( Convert.ToDouble( Extras.GetIniValue( PrefsConfigFile, "VATS", "fModMenuEffectHighlightPAColorB" ).ToString() ) * 100 * 2.55 );
                #endregion
                #endregion
                #region Controls
                gamepadEnable.Checked = Convert.ToInt16( Extras.GetIniValue( PrefsConfigFile, "Controls", "bGamepadEnable" ) ) == 1;
                gamepadRumble.Checked = Convert.ToInt16( Extras.GetIniValue( PrefsConfigFile, "Controls", "bGamepadRumble" ) ) == 1;
                controlsInverty.Checked = Convert.ToInt16( Extras.GetIniValue( PrefsConfigFile, "Controls", "bInvertYValues" ) ) == 1;
                controlsRunByDefault.Checked = Convert.ToInt16( Extras.GetIniValue( PrefsConfigFile, "Controls", "bAlwaysRunByDefault" ) ) == 1;
                controlsMouseAcceleration.Checked = Convert.ToInt16( Extras.GetIniValue( ConfigFile, "Controls", "bMouseAcceleration" ) ) == 1;
                #endregion
                #region Resolution
                ResolutionHeight.Text = Extras.GetIniValue( PrefsConfigFile, "Display", "iSize H" ).ToString();
                ResolutionWidth.Text = Extras.GetIniValue( PrefsConfigFile, "Display", "iSize W" ).ToString();
                #region Fullscreen / Borderless
                ResolutionFullscreen.Checked = Convert.ToInt32( Extras.GetIniValue( PrefsConfigFile, "Display", "bFull Screen" ) ) == 1;
                ResolutionBorderless.Checked = Convert.ToInt32( Extras.GetIniValue( PrefsConfigFile, "Display", "bBorderless" ) ) == 1;
                #endregion
                #endregion
                Text = @"Fallout 4 - Extended settings -- Version: " + CurrentVersion;
            } catch(Exception e) {
                // TODO: Button to copy error to clipboard.
                MessageBox.Show( Resources.Error_Sorry + Resources.string_newLine + Resources.string_newLine + e, Resources.Error_Header, MessageBoxButtons.OK );
                Application.Exit();
            }
        }
        public Form1() {
            // Some (most) coutries use comma (,) as decimal mark, but some countries just has to fuck everything up.
            // And Bethesda uses a point (.) in their config files...
            // This should make it work for everybody.
            Application.CurrentCulture = CultureInfo.CreateSpecificCulture( "en-US" );
            InitializeComponent();
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            AutoSize = true;
            restoreToolStripMenuItem.Enabled = false;
        }
        private void Form1_Load( object sender, EventArgs e ) {
            GetAllValues();
        }
        public sealed override bool AutoSize {
            get { return base.AutoSize; }
            set { base.AutoSize = value; }
        }
        // Scrollers - Track bars - Sliders - Whatever
        private void trackHudOpacity_Scroll( object sender, EventArgs e ) {
            HUDOpacityResult.Text = HUDOpacityTrackBar.Value + Resources.Percentage;
        }
        private void HUDColorRedTrackBar_Scroll( object sender, EventArgs e ) {
            hudColorRedTextBox.Text = hudColorRedTrackBar.Value.ToString();
            hudColorPreviewBox.BackColor = Color.FromArgb( hudColorRedTrackBar.Value, hudColorGreenTrackBar.Value, hudColorBlueTrackBar.Value );
        }
        private void HUDColorGreenTrackBar_Scroll( object sender, EventArgs e ) {
            hudColorGreenTextBox.Text = hudColorGreenTrackBar.Value.ToString();
            hudColorPreviewBox.BackColor = Color.FromArgb( hudColorRedTrackBar.Value, hudColorGreenTrackBar.Value, hudColorBlueTrackBar.Value );
        }
        private void HUDColorBlueTrackBar_Scroll( object sender, EventArgs e ) {
            hudColorBlueTextBox.Text = hudColorBlueTrackBar.Value.ToString();
            hudColorPreviewBox.BackColor = Color.FromArgb( hudColorRedTrackBar.Value, hudColorGreenTrackBar.Value, hudColorBlueTrackBar.Value );
        }
        private void PipBoyColorRedTrackBar_Scroll( object sender, EventArgs e ) {
            PipBoyColorRedTextBox.Value = Convert.ToDecimal( PipBoyColorRedTrackBar.Value * 100 * 2.55 / 255 );
            PipBoyColorPreview.BackColor = Color.FromArgb( PipBoyColorRedTrackBar.Value, PipBoyColorGreenTrackBar.Value, PipBoyColorBlueTrackBar.Value );
        }
        private void PipBoyColorGreenTrackBar_Scroll( object sender, EventArgs e ) {
            PipBoyColorGreenTextBox.Value = Convert.ToDecimal( PipBoyColorGreenTrackBar.Value * 100 * 2.55 / 255 );
            PipBoyColorPreview.BackColor = Color.FromArgb( PipBoyColorRedTrackBar.Value, PipBoyColorGreenTrackBar.Value, PipBoyColorBlueTrackBar.Value );
        }
        private void PipBoyColorBlueTrackBar_Scroll( object sender, EventArgs e ) {
            PipBoyColorBlueTextBox.Value = Convert.ToDecimal( PipBoyColorBlueTrackBar.Value * 100 * 2.55 / 255 );
            PipBoyColorPreview.BackColor = Color.FromArgb( PipBoyColorRedTrackBar.Value, PipBoyColorGreenTrackBar.Value, PipBoyColorBlueTrackBar.Value );
        }
        // Audio Track Bars
        // Voice?
        private void AudioMasterTrackbar_Scroll( object sender, EventArgs e ) {
            AudioMasterText.Text = AudioMasterTrackbar.Value.ToString();
        }
        // I still don't know what these do.
        private void AudioVal0TrackBar_Scroll( object sender, EventArgs e ) {
            AudioVal0Text.Text = AudioVal0TrackBar.Value.ToString();
        }
        // Music?
        private void AudioVal1TrackBar_Scroll( object sender, EventArgs e ) {
            AudioVal1Text.Text = AudioVal1TrackBar.Value.ToString();
        }
        // Effects?
        private void AudioVal2TrackBar_Scroll( object sender, EventArgs e ) {
            AudioVal2Text.Text = AudioVal2TrackBar.Value.ToString();
        }
        // Foorstpes?
        private void AudioVal3TrackBar_Scroll( object sender, EventArgs e ) {
            AudioVal3Text.Text = AudioVal3TrackBar.Value.ToString();
        }
        // Radio?
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
        // Changes
        private void resolutionFullscreen_CheckedChanged( object sender, EventArgs e ) {
            ResolutionBorderless.Enabled = !ResolutionFullscreen.Checked;
        }
        private void PipBoyColorRedTextBox_ValueChanged( object sender, EventArgs e ) {
            PipBoyColorRedTrackBar.Value = Convert.ToInt32( PipBoyColorRedTextBox.Text );
            PipBoyColorPreview.BackColor = Color.FromArgb( PipBoyColorRedTrackBar.Value, PipBoyColorGreenTrackBar.Value, PipBoyColorBlueTrackBar.Value );
        }
        private void PipBoyColorGreenTextBox_ValueChanged( object sender, EventArgs e ) {
            PipBoyColorGreenTrackBar.Value = Convert.ToInt32( PipBoyColorGreenTextBox.Text );
            PipBoyColorPreview.BackColor = Color.FromArgb( PipBoyColorRedTrackBar.Value, PipBoyColorGreenTrackBar.Value, PipBoyColorBlueTrackBar.Value );
        }
        private void PipBoyColorBlueTextBox_ValueChanged( object sender, EventArgs e ) {
            PipBoyColorBlueTrackBar.Value = Convert.ToInt32( PipBoyColorBlueTextBox.Text );
            PipBoyColorPreview.BackColor = Color.FromArgb( PipBoyColorRedTrackBar.Value, PipBoyColorGreenTrackBar.Value, PipBoyColorBlueTrackBar.Value );
        }
        private void hudColorRedTextBox_ValueChanged( object sender, EventArgs e ) {
            hudColorRedTrackBar.Value = Convert.ToInt32( hudColorRedTextBox.Text );
            hudColorPreviewBox.BackColor = Color.FromArgb( hudColorRedTrackBar.Value, hudColorGreenTrackBar.Value, hudColorBlueTrackBar.Value );
        }
        private void hudColorGreenTextBox_ValueChanged( object sender, EventArgs e ) {
            hudColorGreenTrackBar.Value = Convert.ToInt32( hudColorGreenTextBox.Text );
            hudColorPreviewBox.BackColor = Color.FromArgb( hudColorRedTrackBar.Value, hudColorGreenTrackBar.Value, hudColorBlueTrackBar.Value );
        }
        private void hudColorBlueTextBox_ValueChanged( object sender, EventArgs e ) {
            hudColorBlueTrackBar.Value = Convert.ToInt32( hudColorBlueTextBox.Text );
            hudColorPreviewBox.BackColor = Color.FromArgb( hudColorRedTrackBar.Value, hudColorGreenTrackBar.Value, hudColorBlueTrackBar.Value );
        }
        private void hudFovFirst_ValueChanged( object sender, EventArgs e ) {
            fovHeHe.Visible = hudFovFirst.Value > 120 || hudFovThird.Value > 120;
        }
        private void hudFovThird_ValueChanged( object sender, EventArgs e ) {
            fovHeHe.Visible = hudFovThird.Value > 120 || hudFovFirst.Value > 120;
        }
        // Menu Strip/Bar/Header/Easy List
        private void donateToolStripMenuItem_Click( object sender, EventArgs e ) {
            Process.Start( "https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=DRHX9UXNZTGXQ&lc=DK&item_name=XDRosenheim&item_number=F4MS%2ddonations&currency_code=DKK&bn=PP%2dDonationsBF%3abtn_donate_SM%2egif%3aNonHosted" );
        }
        private void sourceCodeToolStripMenuItem_Click( object sender, EventArgs e ) {
            Process.Start( "http://github.com/XDRosenheim/Fallout4MoreConfig" );
        }
        private void startGameToolStripMenuItem_Click( object sender, EventArgs e ) {
            var fo4 = new Process {
                StartInfo = {
                    FileName = Extras.SteamExePath(),
                    Arguments = "-applaunch 377160"
                }
            };
            fo4.Start();
        }
        private void reloadToolStripMenuItem_Click( object sender, EventArgs e ) {
            GetAllValues();
        }
        private void saveToolStripMenuItem_Click( object sender, EventArgs e ) {
            var prefsConfigFile = new IniFile( PrefsConfigFile );
            var configFile = new IniFile( ConfigFile );
            #region Visuals
            var visuDof = VisualsDoF.Checked ? "1" : "0";
            var visuLf = VisualsLensflare.Checked ? "1" : "0";
            var visuGore = VisualsGore.Checked ? "1" : "0";
            var visuBlood = VisualsScreenBlood.Checked ? "1" : "0";
            var visuRadBlur = VisualsRadialBlur.Checked ? "1" : "0";
            prefsConfigFile.Write( "Imagespace", "bDoDepthOfField", visuDof );
            prefsConfigFile.Write( "Imagespace", "bLensFlare", visuLf );
            configFile.Write( "General", "bDisableAllGore", visuGore );
            configFile.Write( "ScreenSplatter", "bBloodSplatterEnabled", visuBlood );
            configFile.Write( "ImageSpace", "bDoRadialBlur", visuRadBlur );
            var visWatObj = VisualWaterObjects.Checked ? "1" : "0";
            var visWatLand = VisualWaterLand.Checked ? "1" : "0";
            var visWatSky = VisualWaterSky.Checked ? "1" : "0";
            var visWatTre = VisualWaterTree.Checked ? "1" : "0";
            configFile.Write( "Water", "bReflectLODObjects", visWatObj );
            configFile.Write( "Water", "bReflectLODLand", visWatLand );
            configFile.Write( "Water", "bReflectSky", visWatSky );
            configFile.Write( "Water", "bReflectLODTrees", visWatTre );
            // FOV
            configFile.Write( "Display", "fDefaultWorldFOV", hudFovThird.Text );
            configFile.Write( "Interface", "fDefaultWorldFOV", hudFovThird.Text );
            prefsConfigFile.Write( "Display", "fDefaultWorldFOV", hudFovThird.Text );
            configFile.Write( "Display", "fDefault1stPersonFOV", hudFovFirst.Text );
            configFile.Write( "Interface", "fDefault1stPersonFOV", hudFovFirst.Text );
            prefsConfigFile.Write( "Display", "fDefault1stPersonFOV", hudFovFirst.Text );
            prefsConfigFile.Write( "General", "fDefaultFOV", hudFovFirst.Text );
            #endregion
            #region Audio
            prefsConfigFile.Write( "AudioMenu", "fAudioMasterVolume", ( (double)AudioMasterTrackbar.Value / 100 ).ToString( CultureInfo.CurrentCulture ) );
            prefsConfigFile.Write( "AudioMenu", "fVal0", ( (double)AudioVal0TrackBar.Value / 100 ).ToString( CultureInfo.CurrentCulture ) );
            prefsConfigFile.Write( "AudioMenu", "fVal1", ( (double)AudioVal1TrackBar.Value / 100 ).ToString( CultureInfo.CurrentCulture ) );
            prefsConfigFile.Write( "AudioMenu", "fVal2", ( (double)AudioVal2TrackBar.Value / 100 ).ToString( CultureInfo.CurrentCulture ) );
            prefsConfigFile.Write( "AudioMenu", "fVal3", ( (double)AudioVal3TrackBar.Value / 100 ).ToString( CultureInfo.CurrentCulture ) );
            prefsConfigFile.Write( "AudioMenu", "fVal4", ( (double)AudioVal4TrackBar.Value / 100 ).ToString( CultureInfo.CurrentCulture ) );
            prefsConfigFile.Write( "AudioMenu", "fVal5", ( (double)AudioVal5TrackBar.Value / 100 ).ToString( CultureInfo.CurrentCulture ) );
            prefsConfigFile.Write( "AudioMenu", "fVal6", ( (double)AudioVal6TrackBar.Value / 100 ).ToString( CultureInfo.CurrentCulture ) );
            prefsConfigFile.Write( "AudioMenu", "fVal7", ( (double)AudioVal7TrackBar.Value / 100 ).ToString( CultureInfo.CurrentCulture ) );
            #endregion
            #region Saving
            prefsConfigFile.Write( "SaveGame", "fAutosaveEveryXMins", SavingAutoSaveTextBox.Text );
            var saPaused = SavingQuickPause.Checked ? "1" : "0";
            var saTravel = SavingQuickTravel.Checked ? "1" : "0";
            var saWaiting = SavingQuickWaiting.Checked ? "1" : "0";
            var saSleeping = SavingQuickSleeping.Checked ? "1" : "0";
            prefsConfigFile.Write( "MAIN", "bSaveOnPause", saPaused );
            prefsConfigFile.Write( "MAIN", "bSaveOnTravel", saTravel );
            prefsConfigFile.Write( "MAIN", "bSaveOnWait", saWaiting );
            prefsConfigFile.Write( "MAIN", "bSaveOnRest", saSleeping );
            #endregion
            #region HUD
            prefsConfigFile.Write( "MAIN", "fHUDOpacity", Math.Round( Convert.ToDouble( HUDOpacityTrackBar.Value ) / 100, 4 ).ToString( CultureInfo.CurrentCulture ) );
            prefsConfigFile.Write( "Interface", "iHUDColorR", Math.Round( Convert.ToDouble( hudColorRedTrackBar.Value ), 4 ).ToString( CultureInfo.CurrentCulture ) );
            prefsConfigFile.Write( "Interface", "iHUDColorG", Math.Round( Convert.ToDouble( hudColorGreenTrackBar.Value ), 4 ).ToString( CultureInfo.CurrentCulture ) );
            prefsConfigFile.Write( "Interface", "iHUDColorB", Math.Round( Convert.ToDouble( hudColorBlueTrackBar.Value ), 4 ).ToString( CultureInfo.CurrentCulture ) );
            var hudHair = hudCrosshair.Checked ? "1" : "0";
            var hudDiaSubs = hudDialogSubs.Checked ? "1" : "0";
            var hudDiaCam = hudDialogCam.Checked ? "1" : "0";
            var hudGenSubs = hudGeneralSubs.Checked ? "1" : "0";
            var hudGps = hudCompass.Checked ? "1" : "0";
            prefsConfigFile.Write( "MAIN", "bCrosshairEnabled", hudHair );
            prefsConfigFile.Write( "Interface", "bDialogueSubtitles", hudDiaSubs );
            prefsConfigFile.Write( "Interface", "bDialogueCameraEnable", hudDiaCam );
            prefsConfigFile.Write( "Interface", "bGeneralSubtitles", hudGenSubs );
            prefsConfigFile.Write( "Interface", "bShowCompass", hudGps );
            var hudShowQuest = hudQuestMarkShow.Checked ? "1" : "0";
            var hudShowFloatingQuest = hudQuestFloatingShow.Checked ? "1" : "0";
            prefsConfigFile.Write( "GamePlay", "bShowQuestMarkers", hudShowQuest );
            prefsConfigFile.Write( "GamePlay", "bShowFloatingQuestMarkers", hudShowFloatingQuest );
            #endregion
            #region Pip-Boy
            if(PipBoyColorRedTextBox.Value != 0) {
                prefsConfigFile.Write( "Pipboy", "fPipboyEffectColorR", Math.Round( Convert.ToDouble( PipBoyColorRedTextBox.Value.ToString( "#.####" ) ) / 255, 4 ) );
            } else {
                prefsConfigFile.Write( "Pipboy", "fPipboyEffectColorR", "0" );
            }
            if(PipBoyColorGreenTextBox.Value != 0) {
                prefsConfigFile.Write( "Pipboy", "fPipboyEffectColorG", Math.Round( Convert.ToDouble( PipBoyColorGreenTextBox.Value.ToString( "#.####" ) ) / 255, 4 ) );
            } else {
                prefsConfigFile.Write( "Pipboy", "fPipboyEffectColorG", "0" );
            }
            if(PipBoyColorBlueTextBox.Value != 0) {
                prefsConfigFile.Write( "Pipboy", "fPipboyEffectColorB", Math.Round( Convert.ToDouble( PipBoyColorBlueTextBox.Value.ToString( "#.####" ) ) / 255, 4 ) );
            } else {
                prefsConfigFile.Write( "Pipboy", "fPipboyEffectColorB", "0" );
            }
            #endregion
            #region VATS
            #region Color
            if(VATSColorR.Value != 0) {
                prefsConfigFile.Write( "VATS", "fModMenuEffectColorR",
                    Math.Round( Convert.ToDouble( VATSColorR.Value.ToString( "#.####" ) ) / 255, 4 ) );
            } else {
                prefsConfigFile.Write( "VATS", "fModMenuEffectColorR", "0" );
            }
            if(VATSColorG.Value != 0) {
                prefsConfigFile.Write( "VATS", "fModMenuEffectColorG",
                    Math.Round( Convert.ToDouble( VATSColorG.Value.ToString( "#.####" ) ) / 255, 4 ) );
            } else {
                prefsConfigFile.Write( "VATS", "fModMenuEffectColorG", "0" );
            }
            if(VATSColorB.Value != 0) {
                prefsConfigFile.Write( "VATS", "fModMenuEffectColorB",
                    Math.Round( Convert.ToDouble( VATSColorB.Value.ToString( "#.####" ) ) / 255, 4 ) );
            } else {
                prefsConfigFile.Write( "VATS", "fModMenuEffectColorB", "0" );
            }
            #endregion
            #region Highlight Color
            if(VATSHighlightColorR.Value != 0) {
                prefsConfigFile.Write( "VATS", "fModMenuEffectHighlightColorR",
                    Math.Round( Convert.ToDouble( VATSHighlightColorR.Value.ToString( "#.####" ) ) / 255, 4 ) );
            } else {
                prefsConfigFile.Write( "VATS", "fModMenuEffectHighlightColorR", "0" );
            }
            if(VATSHighlightColorG.Value != 0) {
                prefsConfigFile.Write( "VATS", "fModMenuEffectHighlightColorG",
                    Math.Round( Convert.ToDouble( VATSHighlightColorG.Value.ToString( "#.####" ) ) / 255, 4 ) );
            } else {
                prefsConfigFile.Write( "VATS", "fModMenuEffectHighlightColorG", "0" );
            }
            if(VATSHighlightColorB.Value != 0) {
                prefsConfigFile.Write( "VATS", "fModMenuEffectHighlightColorB",
                    Math.Round( Convert.ToDouble( VATSHighlightColorB.Value.ToString( "#.####" ) ) / 255, 4 ) );
            } else {
                prefsConfigFile.Write( "VATS", "fModMenuEffectHighlightColorB", "0" );
            }
            #endregion
            #region PA Color
            if(VATSPAColorR.Value != 0) {
                prefsConfigFile.Write( "VATS", "fModMenuEffectPAColorR",
                    Math.Round( Convert.ToDouble( VATSPAColorR.Value.ToString( "#.####" ) ) / 255, 4 ) );
            } else {
                prefsConfigFile.Write( "VATS", "fModMenuEffectPAColorR", "0" );
            }
            if(VATSPAColorG.Value != 0) {
                prefsConfigFile.Write( "VATS", "fModMenuEffectPAColorG",
                    Math.Round( Convert.ToDouble( VATSPAColorG.Value.ToString( "#.####" ) ) / 255, 4 ) );
            } else {
                prefsConfigFile.Write( "VATS", "fModMenuEffectPAColorG", "0" );
            }
            if(VATSPAColorB.Value != 0) {
                prefsConfigFile.Write( "VATS", "fModMenuEffectPAColorB",
                    Math.Round( Convert.ToDouble( VATSPAColorB.Value.ToString( "#.####" ) ) / 255, 4 ) );
            } else {
                prefsConfigFile.Write( "VATS", "fModMenuEffectPAColorB", "0" );
            }
            #endregion
            #region PA Highlight Color
            if(VATSHighlightPAColorR.Value != 0) {
                prefsConfigFile.Write( "VATS", "fModMenuEffectHighlightPAColorR",
                    Math.Round( Convert.ToDouble( VATSHighlightPAColorR.Value.ToString( "#.####" ) ) / 255, 4 ) );
            } else {
                prefsConfigFile.Write( "VATS", "fModMenuEffectHighlightPAColorR", "0" );
            }
            if(VATSHighlightPAColorG.Value != 0) {
                prefsConfigFile.Write( "VATS", "fModMenuEffectHighlightPAColorG",
                    Math.Round( Convert.ToDouble( VATSHighlightPAColorG.Value.ToString( "#.####" ) ) / 255, 4 ) );
            } else {
                prefsConfigFile.Write( "VATS", "fModMenuEffectHighlightPAColorG", "0" );
            }
            if(VATSHighlightPAColorB.Value != 0) {
                prefsConfigFile.Write( "VATS", "fModMenuEffectHighlightPAColorB",
                    Math.Round( Convert.ToDouble( VATSHighlightPAColorB.Value.ToString( "#.####" ) ) / 255, 4 ) );
            } else {
                prefsConfigFile.Write( "VATS", "fModMenuEffectHighlightPAColorB", "0" );
            }
            #endregion
            #endregion
            #region Constols
            var gpEnable = gamepadEnable.Checked ? "1" : "0";
            var gpRumble = gamepadRumble.Checked ? "1" : "0";
            var invert = controlsInverty.Checked ? "1" : "0";
            var mouseAccel = controlsMouseAcceleration.Checked ? "1" : "0";
            var runByDefault = controlsRunByDefault.Checked ? "1" : "0";
            prefsConfigFile.Write( "Controls", "bGamepadEnable", gpEnable );
            prefsConfigFile.Write( "Controls", "bGamepadRumble", gpRumble );
            prefsConfigFile.Write( "Controls", "bInvertYValues", invert );
            configFile.Write( "Controls", "bMouseAcceleration", mouseAccel );
            configFile.Write( "Controls", "bAlwaysRunByDefault", runByDefault );
            prefsConfigFile.Write( "Controls", "bAlwaysRunByDefault", runByDefault );
            #endregion
            #region Resolution
            var resBorder = ResolutionBorderless.Checked ? "1" : "0";
            if(ResolutionFullscreen.Checked) {
                prefsConfigFile.Write( "Display", "bFull Screen", "1" );
                prefsConfigFile.Write( "Display", "bBorderless", "1" );
            } else {
                prefsConfigFile.Write( "Display", "bMaximizeWindow", "0" );
                prefsConfigFile.Write( "Display", "bFull Screen", "0" );
                prefsConfigFile.Write( "Display", "bBorderless", resBorder );
            }
            prefsConfigFile.Write( "Display", "iSize W", ResolutionWidth.Text );
            prefsConfigFile.Write( "Display", "iSize H", ResolutionHeight.Text );
            #endregion
            prefsConfigFile.Write( "General", "bAllowConsole", "1" );
        }
        private void backupToolStripMenuItem_Click( object sender, EventArgs e ) {

            if(File.Exists( ConfigFileBackup )) {
                new FileInfo( ConfigFileBackup ) { IsReadOnly = false };
                File.Delete( ConfigFileBackup );
            }
            if(File.Exists( PrefsConfigFileBackup )) {
                new FileInfo( PrefsConfigFileBackup ) { IsReadOnly = false };
                File.Delete( PrefsConfigFileBackup );
            }
            if(File.Exists( CustomConfigFile )) {
                new FileInfo( CustomConfigFile ) { IsReadOnly = false };
                File.Delete( CustomConfigFileBackup );
            }
            File.Copy( ConfigFile, ConfigFileBackup );
            new FileInfo(ConfigFileBackup) {IsReadOnly = true};
            File.Copy( PrefsConfigFile, PrefsConfigFileBackup );
            new FileInfo( PrefsConfigFileBackup ) { IsReadOnly = true };
            File.Copy( CustomConfigFile, CustomConfigFileBackup );
            new FileInfo( CustomConfigFileBackup ) { IsReadOnly = true };

        }
        private void restoreToolStripMenuItem_Click( object sender, EventArgs e ) {
            if(!File.Exists( ConfigFileBackup ) && !File.Exists( PrefsConfigFileBackup ) &&
                !File.Exists( CustomConfigFileBackup )) return;
            if(File.Exists( ConfigFileBackup )) {
                File.Delete( ConfigFile );
                File.Copy( ConfigFileBackup, ConfigFile );
            }
            if(File.Exists( PrefsConfigFileBackup )) {
                File.Delete( PrefsConfigFileBackup );
                File.Copy( PrefsConfigFileBackup, PrefsConfigFile );
            }
            if(File.Exists( CustomConfigFileBackup )) {
                File.Delete( CustomConfigFileBackup );
                File.Copy( CustomConfigFileBackup, CustomConfigFile );
            }
        }
    }
}
