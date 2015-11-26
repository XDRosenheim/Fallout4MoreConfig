using System;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Fallout4MoreConfig.Properties;
using Ini;

namespace Fallout4MoreConfig {
    /// TODO: This list
    /// TODO: This list - HUD
    /// The preview, should have a/some screenshot(s) where the actual hud is shown.
    /// Screenshot should also work with FOV changes.
    /// 
    /// TODO: This list - Audio
    /// Val0-7 should be analliesed, so I know which does what. (They are not descriped in the configs)
    /// 
    /// TODO: This list - Visuals
    /// More options............. To come.......... Soon(TM)
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
    public partial class Form1 : Form {
        private static readonly Extras Extras = new Extras();
        public string CurrentVersion {
            get {
                return ApplicationDeployment.IsNetworkDeployed
                       ? ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString()
                       : Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        public string Fallout4Location = Extras.ConfigFile();
        public string Fallout4PrefsLocation = Extras.PrefsConfigFile();
        public void GetAllValues() {
            try {
                // Get values from current config
                #region Visuals
                #region Image Space
                VisualsDoF.Checked = Convert.ToInt16( Extras.GetLineValue( Fallout4PrefsLocation, "bDoDepthOfField" ) ) == 1;
                VisualsLensflare.Checked = Convert.ToInt16( Extras.GetLineValue( Fallout4PrefsLocation, "bLensFlare" ) ) == 1;
                VisualsGore.Checked = Convert.ToInt16( Extras.GetLineValue( Fallout4Location, "bDisableAllGore" ) ) == 1;
                VisualsScreenBlood.Checked = Convert.ToInt16( Extras.GetLineValue( Fallout4Location, "bBloodSplatterEnabled" ) ) == 1;
                #endregion
                #region Water Reflections
                VisualWaterSky.Checked = Convert.ToInt16( Extras.GetLineValue( Fallout4Location, "bReflectSky" ) ) == 1;
                VisualWaterLand.Checked = Convert.ToInt16( Extras.GetLineValue( Fallout4Location, "bReflectLODLand" ) ) == 1;
                VisualWaterTree.Checked = Convert.ToInt16( Extras.GetLineValue( Fallout4Location, "bReflectLODTrees" ) ) == 1;
                VisualWaterObjects.Checked = Convert.ToInt16( Extras.GetLineValue( Fallout4Location, "bReflectLODObjects" ) ) == 1;
                #endregion
                #endregion
                #region Audio
                #region Master
                var masterVolume = Convert.ToDecimal( Extras.GetLineValue( Fallout4PrefsLocation, "fAudioMasterVolume" ) );
                AudioMasterTrackbar.Value = (int)( masterVolume * 100 );
                AudioMasterText.Text = ( (int)( masterVolume * 100 ) ).ToString();
                #endregion
                #region Val
                #region 0
                var val0 = Convert.ToDecimal( Extras.GetLineValue( Fallout4PrefsLocation, "fVal0" ) );
                AudioVal0TrackBar.Value = (int)( val0 * 100 );
                AudioVal0Text.Text = ( (int)( val0 * 100 ) ).ToString();
                #endregion
                #region 1
                var val1 = Convert.ToDecimal( Extras.GetLineValue( Fallout4PrefsLocation, "fVal1" ) );
                AudioVal1TrackBar.Value = (int)( val1 * 100 );
                AudioVal1Text.Text = ( (int)( val1 * 100 ) ).ToString();
                #endregion
                #region 2
                var val2 = Convert.ToDecimal( Extras.GetLineValue( Fallout4PrefsLocation, "fVal2" ) );
                AudioVal2TrackBar.Value = (int)( val2 * 100 );
                AudioVal2Text.Text = ( (int)( val2 * 100 ) ).ToString();
                #endregion
                #region 3
                var val3 = Convert.ToDecimal( Extras.GetLineValue( Fallout4PrefsLocation, "fVal3" ) );
                AudioVal3TrackBar.Value = (int)( val3 * 100 );
                AudioVal3Text.Text = ( (int)( val3 * 100 ) ).ToString();
                #endregion
                #region 4
                var val4 = Convert.ToDecimal( Extras.GetLineValue( Fallout4PrefsLocation, "fVal4" ) );
                AudioVal4TrackBar.Value = (int)( val4 * 100 );
                AudioVal4Text.Text = ( (int)( val4 * 100 ) ).ToString();
                #endregion
                #region 5
                var val5 = Convert.ToDecimal( Extras.GetLineValue( Fallout4PrefsLocation, "fVal5" ) );
                AudioVal5TrackBar.Value = (int)( val5 * 100 );
                AudioVal5Text.Text = ( (int)( val5 * 100 ) ).ToString();
                #endregion
                #region 6
                var val6 = Convert.ToDecimal( Extras.GetLineValue( Fallout4PrefsLocation, "fVal6" ) );
                AudioVal6TrackBar.Value = (int)( val6 * 100 );
                AudioVal6Text.Text = ( (int)( val6 * 100 ) ).ToString();
                #endregion
                #region 7
                var val7 = Convert.ToDecimal( Extras.GetLineValue( Fallout4PrefsLocation, "fVal7" ) );
                AudioVal7TrackBar.Value = (int)( val7 * 100 );
                AudioVal7Text.Text = ( (int)( val7 * 100 ) ).ToString();
                #endregion
                #endregion
                #endregion
                #region Saving
                #region Auto-Save
                SavingAutoSaveTextBox.Text = Convert.ToInt32( Convert.ToDecimal( Extras.GetLineValue( Fallout4PrefsLocation, "fAutosaveEveryXMins" ) ) ).ToString();
                #endregion
                #region Quick-Save
                SavingQuickPause.Checked = Convert.ToInt16( Extras.GetLineValue( Fallout4PrefsLocation, "bSaveOnPause" ) ) == 1;
                SavingQuickTravel.Checked = Convert.ToInt16( Extras.GetLineValue( Fallout4PrefsLocation, "bSaveOnTravel" ) ) == 1;
                SavingQuickWaiting.Checked = Convert.ToInt16( Extras.GetLineValue( Fallout4PrefsLocation, "bSaveOnWait" ) ) == 1;
                SavingQuickSleeping.Checked = Convert.ToInt16( Extras.GetLineValue( Fallout4PrefsLocation, "bSaveOnRest" ) ) == 1;
                #endregion
                #endregion
                #region HUD
                #region Opacity
                HUDOpacityResult.Text = Convert.ToString( Convert.ToInt32( Convert.ToDecimal( Extras.GetLineValue( Fallout4PrefsLocation, "fHUDOpacity" ) ) * 100 ) ) + Resources.Percentage;
                HUDOpacityTrackBar.Value = Convert.ToInt32( Convert.ToDecimal( Extras.GetLineValue( Fallout4PrefsLocation, "fHUDOpacity" ) ) * 100 );
                #endregion
                #region Color
                #region Red
                var hudColorRed = Extras.GetLineValue( Fallout4PrefsLocation, "iHUDColorR" );
                hudColorRedTrackBar.Value = Convert.ToInt16( hudColorRed );
                hudColorRedTextBox.Text = hudColorRed.ToString();
                #endregion
                #region Green
                var hudColorGreen = Extras.GetLineValue( Fallout4PrefsLocation, "iHUDColorG" );
                hudColorGreenTrackBar.Value = Convert.ToInt16( hudColorGreen );
                hudColorGreenTextBox.Text = hudColorGreen.ToString();
                #endregion
                #region Blue
                var hudColorBlue = Extras.GetLineValue( Fallout4PrefsLocation, "iHUDColorB" );
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
                var hudFirstFov = Extras.GetLineValue( Fallout4Location, "fDefault1stPersonFOV" );
                hudFovFirst.Text = Convert.ToInt32( hudFirstFov ).ToString();
                #endregion
                #region World Person
                var hudThirdFov = Extras.GetLineValue( Fallout4Location, "fDefaultWorldFOV" );
                hudFovThird.Text = Convert.ToInt32( hudThirdFov ).ToString();
                #endregion
                #endregion
                #region Other
                hudCrosshair.Checked = Convert.ToInt16( Extras.GetLineValue( Fallout4PrefsLocation, "bCrosshairEnabled" ) ) == 1;
                hudCompass.Checked = Convert.ToInt16( Extras.GetLineValue( Fallout4PrefsLocation, "bShowCompass" ) ) == 1;
                hudDialogCam.Checked = Convert.ToInt16( Extras.GetLineValue( Fallout4PrefsLocation, "bDialogueCameraEnable" ) ) == 1;
                hudDialogSubs.Checked = Convert.ToInt16( Extras.GetLineValue( Fallout4PrefsLocation, "bDialogueSubtitles" ) ) == 1;
                hudGeneralSubs.Checked = Convert.ToInt16( Extras.GetLineValue( Fallout4PrefsLocation, "bGeneralSubtitles" ) ) == 1;
                #endregion
                #endregion
                #region Pip-Boy
                #region Color
                #region Red
                PipBoyColorRedTrackBar.Value = Convert.ToInt32( Convert.ToDouble( Extras.GetLineValue( Fallout4PrefsLocation, "fPipboyEffectColorR" ).ToString() ) * 100 * 2.55 );
                PipBoyColorRedTextBox.Text = PipBoyColorRedTrackBar.Value.ToString();
                #endregion
                #region Green
                PipBoyColorGreenTrackBar.Value = Convert.ToInt32( Convert.ToDouble( Extras.GetLineValue( Fallout4PrefsLocation, "fPipboyEffectColorG" ).ToString() ) * 100 * 2.55 );
                PipBoyColorGreenTextBox.Text = PipBoyColorGreenTrackBar.Value.ToString();
                #endregion
                #region Blue
                PipBoyColorBlueTrackBar.Value = Convert.ToInt32( Convert.ToDouble( Extras.GetLineValue( Fallout4PrefsLocation, "fPipboyEffectColorB" ).ToString() ) * 100 * 2.55 );
                PipBoyColorBlueTextBox.Text = PipBoyColorBlueTrackBar.Value.ToString();
                #endregion
                #region Preview
                PipBoyColorPreview.BackColor = Color.FromArgb( PipBoyColorRedTrackBar.Value, PipBoyColorGreenTrackBar.Value, PipBoyColorBlueTrackBar.Value );
                #endregion
                #endregion
                #endregion
                #region VATS
                #region Color
                VATSColorR.Value = Convert.ToInt32( Convert.ToDouble( Extras.GetLineValue( Fallout4PrefsLocation, "fModMenuEffectColorR" ).ToString() ) * 100 * 2.55 );
                VATSColorG.Value = Convert.ToInt32( Convert.ToDouble( Extras.GetLineValue( Fallout4PrefsLocation, "fModMenuEffectColorG" ).ToString() ) * 100 * 2.55 );
                VATSColorB.Value = Convert.ToInt32( Convert.ToDouble( Extras.GetLineValue( Fallout4PrefsLocation, "fModMenuEffectColorB" ).ToString() ) * 100 * 2.55 );
                #endregion
                #region Highlight Color
                VATSHighlightColorR.Value = Convert.ToInt32( Convert.ToDouble( Extras.GetLineValue( Fallout4PrefsLocation, "fModMenuEffectHighlightColorR" ).ToString() ) * 100 * 2.55 );
                VATSHighlightColorG.Value = Convert.ToInt32( Convert.ToDouble( Extras.GetLineValue( Fallout4PrefsLocation, "fModMenuEffectHighlightColorG" ).ToString() ) * 100 * 2.55 );
                VATSHighlightColorB.Value = Convert.ToInt32( Convert.ToDouble( Extras.GetLineValue( Fallout4PrefsLocation, "fModMenuEffectHighlightColorB" ).ToString() ) * 100 * 2.55 );
                #endregion
                #region PA Color
                VATSPAColorR.Value = Convert.ToInt32( Convert.ToDouble( Extras.GetLineValue( Fallout4PrefsLocation, "fModMenuEffectPAColorR" ).ToString() ) * 100 * 2.55 );
                VATSPAColorG.Value = Convert.ToInt32( Convert.ToDouble( Extras.GetLineValue( Fallout4PrefsLocation, "fModMenuEffectPAColorG" ).ToString() ) * 100 * 2.55 );
                VATSPAColorB.Value = Convert.ToInt32( Convert.ToDouble( Extras.GetLineValue( Fallout4PrefsLocation, "fModMenuEffectPAColorB" ).ToString() ) * 100 * 2.55 );
                #endregion
                #region PA Highlight Color
                VATSHighlightPAColorR.Value = Convert.ToInt32( Convert.ToDouble( Extras.GetLineValue( Fallout4PrefsLocation, "fModMenuEffectHighlightPAColorR" ).ToString() ) * 100 * 2.55 );
                VATSHighlightPAColorG.Value = Convert.ToInt32( Convert.ToDouble( Extras.GetLineValue( Fallout4PrefsLocation, "fModMenuEffectHighlightPAColorG" ).ToString() ) * 100 * 2.55 );
                VATSHighlightPAColorB.Value = Convert.ToInt32( Convert.ToDouble( Extras.GetLineValue( Fallout4PrefsLocation, "fModMenuEffectHighlightPAColorB" ).ToString() ) * 100 * 2.55 );
                #endregion
                #endregion
                #region Gamepad

                #endregion
                #region Resolution
                #region Height
                var resHeight = Extras.GetLineValue( Fallout4PrefsLocation, "iSize H" );
                ResolutionHeight.Text = resHeight.ToString();
                #endregion
                #region Width
                var resWidth = Extras.GetLineValue( Fallout4PrefsLocation, "iSize W" );
                ResolutionWidth.Text = resWidth.ToString();
                #endregion
                #region Fullscreen / Borderless
                ResolutionFullscreen.Checked = Convert.ToInt32( Extras.GetLineValue( Fallout4PrefsLocation, "bFull Screen" ) ) == 1;
                ResolutionBorderless.Checked = Convert.ToInt32( Extras.GetLineValue( Fallout4PrefsLocation, "bBorderless" ) ) == 1;
                #endregion
                #endregion
                Text = @"Fallout 4 - Extended settings -- Version: " + CurrentVersion;
            } catch(Exception e) {
                // TODO: Button to copy error to clipboard.
                MessageBox.Show( Resources.Error_Sorry + Resources.string_newLine + e, @"Error", MessageBoxButtons.OK );
                Application.Exit();
            }
        }
        public Form1() {
            // See if config files exists
            if(!File.Exists( Fallout4Location )) {
                MessageBox.Show(
                    // TODO: Button to copy error to clipboard.
                    Fallout4Location + Resources.Error_Path_not_found_,
                    Resources.Error_Header, MessageBoxButtons.OK,
                    MessageBoxIcon.Error );
            }
            if(!File.Exists( Fallout4PrefsLocation )) {
                MessageBox.Show(
                    // TODO: Button to copy error to clipboard.
                    Fallout4PrefsLocation + Resources.Error_Path_not_found_,
                    Resources.Error_Header, MessageBoxButtons.OK,
                    MessageBoxIcon.Error );
            }
            // Some (most) coutries use comma (,) as decimal mark, but some countries just has to fuck everything up.
            // And Bethesda uses a point (.) in their config files...
            // This should make it work for everybody.
            Application.CurrentCulture = CultureInfo.CreateSpecificCulture( "en-US" );
            InitializeComponent();
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            AutoSize = true;
            GetAllValues();
        }
        public sealed override bool AutoSize {
            get { return base.AutoSize; }
            set { base.AutoSize = value; }
        }
        // The buttons
        private void btnSave_Click( object sender, EventArgs e ) {
            var betterPrefsFile = new IniFile( Fallout4PrefsLocation );
            var betterNonFile = new IniFile( Fallout4Location );
            #region Visuals - WORKS
            var visuDof = VisualsDoF.Checked ? "1" : "0";
            var visuLf = VisualsLensflare.Checked ? "1" : "0";
            var visuGore = VisualsGore.Checked ? "1" : "0";
            var visuBlood = VisualsScreenBlood.Checked ? "1" : "0";
            betterPrefsFile.IniWriteValue( "Imagespace", "bDoDepthOfField", visuDof );
            betterPrefsFile.IniWriteValue( "Imagespace", "bLensFlare", visuLf );
            betterNonFile.IniWriteValue( "General", "bDisableAllGore", visuGore );
            betterNonFile.IniWriteValue( "ScreenSplatter", "bBloodSplatterEnabled", visuBlood );
            var visWatObj = VisualWaterObjects.Checked ? "1" : "0";
            var visWatLand = VisualWaterLand.Checked ? "1" : "0";
            var visWatSky = VisualWaterSky.Checked ? "1" : "0";
            var visWatTre = VisualWaterTree.Checked ? "1" : "0";
            betterNonFile.IniWriteValue( "Water", "bReflectLODObjects", visWatObj );
            betterNonFile.IniWriteValue( "Water", "bReflectLODLand", visWatLand );
            betterNonFile.IniWriteValue( "Water", "bReflectSky", visWatSky );
            betterNonFile.IniWriteValue( "Water", "bReflectLODTrees", visWatTre );
            #endregion
            #region Audio - WORKS
            betterPrefsFile.IniWriteValue( "AudioMenu", "fAudioMasterVolume", ( (double)AudioMasterTrackbar.Value / 100 ).ToString( CultureInfo.CurrentCulture ) );
            betterPrefsFile.IniWriteValue( "AudioMenu", "fVal0", ( (double)AudioVal0TrackBar.Value / 100 ).ToString( CultureInfo.CurrentCulture ) );
            betterPrefsFile.IniWriteValue( "AudioMenu", "fVal1", ( (double)AudioVal1TrackBar.Value / 100 ).ToString( CultureInfo.CurrentCulture ) );
            betterPrefsFile.IniWriteValue( "AudioMenu", "fVal2", ( (double)AudioVal2TrackBar.Value / 100 ).ToString( CultureInfo.CurrentCulture ) );
            betterPrefsFile.IniWriteValue( "AudioMenu", "fVal3", ( (double)AudioVal3TrackBar.Value / 100 ).ToString( CultureInfo.CurrentCulture ) );
            betterPrefsFile.IniWriteValue( "AudioMenu", "fVal4", ( (double)AudioVal4TrackBar.Value / 100 ).ToString( CultureInfo.CurrentCulture ) );
            betterPrefsFile.IniWriteValue( "AudioMenu", "fVal5", ( (double)AudioVal5TrackBar.Value / 100 ).ToString( CultureInfo.CurrentCulture ) );
            betterPrefsFile.IniWriteValue( "AudioMenu", "fVal6", ( (double)AudioVal6TrackBar.Value / 100 ).ToString( CultureInfo.CurrentCulture ) );
            betterPrefsFile.IniWriteValue( "AudioMenu", "fVal7", ( (double)AudioVal7TrackBar.Value / 100 ).ToString( CultureInfo.CurrentCulture ) );
            #endregion
            #region Saving - WORKS
            betterPrefsFile.IniWriteValue( "SaveGame", "fAutosaveEveryXMins", SavingAutoSaveTextBox.Text );
            var saPaused = SavingQuickPause.Checked ? "1" : "0";
            var saTravel = SavingQuickTravel.Checked ? "1" : "0";
            var saWaiting = SavingQuickWaiting.Checked ? "1" : "0";
            var saSleeping = SavingQuickSleeping.Checked ? "1" : "0";
            betterPrefsFile.IniWriteValue( "MAIN", "bSaveOnPause", saPaused );
            betterPrefsFile.IniWriteValue( "MAIN", "bSaveOnTravel", saTravel );
            betterPrefsFile.IniWriteValue( "MAIN", "bSaveOnWait", saWaiting );
            betterPrefsFile.IniWriteValue( "MAIN", "bSaveOnRest", saSleeping );
            #endregion
            #region HUD - WORKS
            betterPrefsFile.IniWriteValue( "MAIN", "fHUDOpacity", Math.Round( Convert.ToDouble( HUDOpacityTrackBar.Value ) / 100, 4 ).ToString( CultureInfo.CurrentCulture ) );
            betterPrefsFile.IniWriteValue( "Interface", "iHUDColorR", Math.Round( Convert.ToDouble( hudColorRedTrackBar.Value ), 4 ).ToString( CultureInfo.CurrentCulture ) );
            betterPrefsFile.IniWriteValue( "Interface", "iHUDColorG", Math.Round( Convert.ToDouble( hudColorGreenTrackBar.Value ), 4 ).ToString( CultureInfo.CurrentCulture ) );
            betterPrefsFile.IniWriteValue( "Interface", "iHUDColorB", Math.Round( Convert.ToDouble( hudColorBlueTrackBar.Value ), 4 ).ToString( CultureInfo.CurrentCulture ) );
            // FOV
            betterNonFile.IniWriteValue( "Display", "fDefaultWorldFOV", hudFovThird.Text );
            betterNonFile.IniWriteValue( "Interface", "fDefaultWorldFOV", hudFovThird.Text );
            betterPrefsFile.IniWriteValue( "Display", "fDefaultWorldFOV", hudFovThird.Text );
            betterNonFile.IniWriteValue( "Display", "fDefault1stPersonFOV", hudFovFirst.Text );
            betterNonFile.IniWriteValue( "Interface", "fDefault1stPersonFOV", hudFovFirst.Text );
            betterPrefsFile.IniWriteValue( "Display", "fDefault1stPersonFOV", hudFovFirst.Text );
            var hudHair = hudCrosshair.Checked ? "1" : "0";
            var hudDiaSubs = hudDialogSubs.Checked ? "1" : "0";
            var hudDiaCam = hudDialogCam.Checked ? "1" : "0";
            var hudGenSubs = hudGeneralSubs.Checked ? "1" : "0";
            var hudGps = hudCompass.Checked ? "1" : "0";
            betterPrefsFile.IniWriteValue( "MAIN", "bCrosshairEnabled", hudHair );
            betterPrefsFile.IniWriteValue( "Interface", "bDialogueSubtitles", hudDiaSubs );
            betterPrefsFile.IniWriteValue( "Interface", "bDialogueCameraEnable", hudDiaCam );
            betterPrefsFile.IniWriteValue( "Interface", "bGeneralSubtitles", hudGenSubs );
            betterPrefsFile.IniWriteValue( "Interface", "bShowCompass", hudGps );
            #endregion
            #region Pip-Boy - WORKS
            #region Color
            if(PipBoyColorRedTextBox.Value != 0) {
                betterPrefsFile.IniWriteValue( "Pipboy", "fPipboyEffectColorR", Math.Round( Convert.ToDouble( PipBoyColorRedTextBox.Value.ToString( "#.####" ) ) / 255, 4 ) );
            } else {
                betterPrefsFile.IniWriteValue( "Pipboy", "fPipboyEffectColorR", "0" );
            }
            if(PipBoyColorGreenTextBox.Value != 0) {
                betterPrefsFile.IniWriteValue( "Pipboy", "fPipboyEffectColorG", Math.Round( Convert.ToDouble( PipBoyColorGreenTextBox.Value.ToString( "#.####" ) ) / 255, 4 ) );
            } else {
                betterPrefsFile.IniWriteValue( "Pipboy", "fPipboyEffectColorG", "0" );
            }
            if(PipBoyColorBlueTextBox.Value != 0) {
                betterPrefsFile.IniWriteValue( "Pipboy", "fPipboyEffectColorB", Math.Round( Convert.ToDouble( PipBoyColorBlueTextBox.Value.ToString( "#.####" ) ) / 255, 4 ) );
            } else {
                betterPrefsFile.IniWriteValue( "Pipboy", "fPipboyEffectColorB", "0" );
            }
            #endregion
            #endregion
            #region VATS - WORKS
            #region Color
            if(VATSColorR.Value != 0) {
                betterPrefsFile.IniWriteValue( "VATS", "fModMenuEffectColorR", 
                    Math.Round( Convert.ToDouble( VATSColorR.Value.ToString( "#.####" ) ) / 255, 4 ) );
            } else {
                betterPrefsFile.IniWriteValue( "VATS", "fModMenuEffectColorR", "0" );
            }
            if(VATSColorG.Value != 0) {
                betterPrefsFile.IniWriteValue( "VATS", "fModMenuEffectColorG", 
                    Math.Round( Convert.ToDouble( VATSColorG.Value.ToString( "#.####" ) ) / 255, 4 ) );
            } else {
                betterPrefsFile.IniWriteValue( "VATS", "fModMenuEffectColorG", "0" );
            }
            if(VATSColorB.Value != 0) {
                betterPrefsFile.IniWriteValue( "VATS", "fModMenuEffectColorB", 
                    Math.Round( Convert.ToDouble( VATSColorB.Value.ToString( "#.####" ) ) / 255, 4 ) );
            } else {
                betterPrefsFile.IniWriteValue( "VATS", "fModMenuEffectColorB", "0" );
            }
            #endregion
            #region Highlight Color
            if(VATSHighlightColorR.Value != 0) {
                betterPrefsFile.IniWriteValue( "VATS", "fModMenuEffectHighlightColorR", 
                    Math.Round( Convert.ToDouble( VATSHighlightColorR.Value.ToString( "#.####" ) ) / 255, 4 ) );
            } else {
                betterPrefsFile.IniWriteValue( "VATS", "fModMenuEffectHighlightColorR", "0" );
            }
            if(VATSHighlightColorG.Value != 0) {
                betterPrefsFile.IniWriteValue( "VATS", "fModMenuEffectHighlightColorG", 
                    Math.Round( Convert.ToDouble( VATSHighlightColorG.Value.ToString( "#.####" ) ) / 255, 4 ) );
            } else {
                betterPrefsFile.IniWriteValue( "VATS", "fModMenuEffectHighlightColorG", "0" );
            }
            if(VATSHighlightColorB.Value != 0) {
                betterPrefsFile.IniWriteValue( "VATS", "fModMenuEffectHighlightColorB", 
                    Math.Round( Convert.ToDouble( VATSHighlightColorB.Value.ToString( "#.####" ) ) / 255, 4 ) );
            } else {
                betterPrefsFile.IniWriteValue( "VATS", "fModMenuEffectHighlightColorB", "0" );
            }
            #endregion
            #region PA Color
            if(VATSPAColorR.Value != 0) {
                betterPrefsFile.IniWriteValue( "VATS", "fModMenuEffectPAColorR", 
                    Math.Round( Convert.ToDouble( VATSPAColorR.Value.ToString( "#.####" ) ) / 255, 4 ) );
            } else {
                betterPrefsFile.IniWriteValue( "VATS", "fModMenuEffectPAColorR", "0" );
            }
            if(VATSPAColorG.Value != 0) {
                betterPrefsFile.IniWriteValue( "VATS", "fModMenuEffectPAColorG", 
                    Math.Round( Convert.ToDouble( VATSPAColorG.Value.ToString( "#.####" ) ) / 255, 4 ) );
            } else {
                betterPrefsFile.IniWriteValue( "VATS", "fModMenuEffectPAColorG", "0" );
            }
            if(VATSPAColorB.Value != 0) {
                betterPrefsFile.IniWriteValue( "VATS", "fModMenuEffectPAColorB", 
                    Math.Round( Convert.ToDouble( VATSPAColorB.Value.ToString( "#.####" ) ) / 255, 4 ) );
            } else {
                betterPrefsFile.IniWriteValue( "VATS", "fModMenuEffectPAColorB", "0" );
            }
            #endregion
            #region PA Highlight Color
            if(VATSHighlightPAColorR.Value != 0) {
                betterPrefsFile.IniWriteValue( "VATS", "fModMenuEffectHighlightPAColorR",
                    Math.Round( Convert.ToDouble( VATSHighlightPAColorR.Value.ToString( "#.####" ) ) / 255, 4 ) );
            } else {
                betterPrefsFile.IniWriteValue( "VATS", "fModMenuEffectHighlightPAColorR", "0" );
            }
            if(VATSHighlightPAColorG.Value != 0) {
                betterPrefsFile.IniWriteValue( "VATS", "fModMenuEffectHighlightPAColorG",
                    Math.Round( Convert.ToDouble( VATSHighlightPAColorG.Value.ToString( "#.####" ) ) / 255, 4 ) );
            } else {
                betterPrefsFile.IniWriteValue( "VATS", "fModMenuEffectHighlightPAColorG", "0" );
            }
            if(VATSHighlightPAColorB.Value != 0) {
                betterPrefsFile.IniWriteValue( "VATS", "fModMenuEffectHighlightPAColorB",
                    Math.Round( Convert.ToDouble( VATSHighlightPAColorB.Value.ToString( "#.####" ) ) / 255, 4 ) );
            } else {
                betterPrefsFile.IniWriteValue( "VATS", "fModMenuEffectHighlightPAColorB", "0" );
            }
            #endregion
            #endregion
            #region Gamepad - WORKS
            var gpEnable = gamepadEnable.Checked ? "1" : "0";
            var gpRumble = gamepadRumble.Checked ? "1" : "0";
            betterPrefsFile.IniWriteValue( "Controls", "bGamepadEnable", gpEnable );
            betterPrefsFile.IniWriteValue( "Controls", "bGamepadRumble", gpRumble );
            #endregion
            #region Resolution - WORKS
            var resBorder = ResolutionBorderless.Checked ? "1" : "0";
            if(ResolutionFullscreen.Checked) {
                betterPrefsFile.IniWriteValue( "Display", "bFull Screen", "1" );
                betterPrefsFile.IniWriteValue( "Display", "bBorderless", "1" );
            } else {
                betterPrefsFile.IniWriteValue( "Display", "bFull Screen", "0" );
                betterPrefsFile.IniWriteValue( "Display", "bBorderless", resBorder );
            }
            betterPrefsFile.IniWriteValue( "Display", "iSize W", ResolutionWidth.Text );
            betterPrefsFile.IniWriteValue( "Display", "iSize H", ResolutionHeight.Text );
            #endregion
        }
        private void btnReWrite_Click( object sender, EventArgs e ) {
            GetAllValues();
        }
        private void btnSource_Click( object sender, EventArgs e ) {
            Process.Start( "http://github.com/XDRosenheim/Fallout4MoreConfig" );
        }
        private void btnDonate_Click( object sender, EventArgs e ) {
            Process.Start(
                "https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=DRHX9UXNZTGXQ&lc=DK&item_name=XDRosenheim&item_number=F4MS%2ddonations&currency_code=DKK&bn=PP%2dDonationsBF%3abtn_donate_SM%2egif%3aNonHosted" );
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
        private void AudioMasterTrackbar_Scroll( object sender, EventArgs e ) {
            AudioMasterText.Text = AudioMasterTrackbar.Value.ToString();
        }
        // I still don't know what these do.
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
    }
}
