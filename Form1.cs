using System;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Fallout4MoreConfig.Properties;

namespace Fallout4MoreConfig {
    /// TODO - This list
    /// HUD:
    /// The preview, should have a/some screenshot(s) where the actual hud is shown.
    /// Screenshot should also work with FOV changes.
    /// 
    /// Audio:
    /// Val0-7 should be analliesed, so I know which does what. (They are not descriped in the configs)
    /// 
    /// Visuals:
    /// More options............. To come.......... Soon(TM)
    /// 
    /// PIP-BOY:
    /// Make it work.
    /// The preview, should have a/some screenshot(s) where the actual hud is shown.
    /// 
    /// VATS:
    /// Make it work.
    /// 
    /// Gamepad:
    /// Sensitivity?
    /// 
    /// Resolution:
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
                var pipBoyColorRed = Extras.GetLineValue( Fallout4PrefsLocation, "fPipboyEffectColorR" );
                PipBoyColorRedTrackBar.Value = Convert.ToInt32( Convert.ToDouble( Extras.GetLineValue( Fallout4PrefsLocation, "fPipboyEffectColorR" ).ToString() ) * 100 * 2.55 );
                PipBoyColorRedTextBox.Text = pipBoyColorRed.ToString();
                #endregion
                #region Green
                var pipBoyColorGreen = Extras.GetLineValue( Fallout4PrefsLocation, "fPipboyEffectColorG" );
                PipBoyColorGreenTrackBar.Value = Convert.ToInt32( Convert.ToDouble( Extras.GetLineValue( Fallout4PrefsLocation, "fPipboyEffectColorG" ).ToString() ) * 100 * 2.55 );
                PipBoyColorGreenTextBox.Text = pipBoyColorGreen.ToString();
                #endregion
                #region Blue
                var pipBoyColorBlue = Extras.GetLineValue( Fallout4PrefsLocation, "fPipboyEffectColorB" );
                PipBoyColorBlueTrackBar.Value = Convert.ToInt32( Convert.ToDouble( Extras.GetLineValue( Fallout4PrefsLocation, "fPipboyEffectColorB" ).ToString() ) * 100 * 2.55 );
                PipBoyColorBlueTextBox.Text = pipBoyColorBlue.ToString();
                #endregion
                #region Preview
                PipBoyColorPreview.BackColor = Color.FromArgb(PipBoyColorRedTrackBar.Value, PipBoyColorGreenTrackBar.Value, PipBoyColorBlueTrackBar.Value);
                #endregion
                #endregion
                #endregion
                #region VATS

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
                MessageBox.Show( e.ToString(), @"Error", MessageBoxButtons.OK );
                Application.Exit();
            }
        }
        public Form1() {
            // See if config files exists
            if(!File.Exists( Fallout4Location )) {
                MessageBox.Show(
                    Fallout4Location + Resources.string_path_not_found_,
                    Resources.String_Error_, MessageBoxButtons.OK,
                    MessageBoxIcon.Error );
            }
            if(!File.Exists( Fallout4PrefsLocation )) {
                MessageBox.Show(
                    Fallout4PrefsLocation + Resources.string_path_not_found_,
                    Resources.String_Error_, MessageBoxButtons.OK,
                    MessageBoxIcon.Error );
            }

            // Some (most) coutries uses comma (,) as decimal mark, but some countries just has to fuck everything up.
            // And Bethesda uses a point (.) in their config files...
            // This should make it work for everybody.
            Application.CurrentCulture = CultureInfo.CreateSpecificCulture( "en-US" );

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
            // THE FOLLOWING IS A MESS !!
            // IT READS THE WHOLE FILE TO MEMORY !!
            // PLEASE CONTACT ME ON GITHUB IF YOU HAVE A SOLUTION !!
            // http://github.com/XDRosenheim/Fallout4MoreConfig
            // But, hey, it works...

            var prefsFile = File.ReadAllText( Fallout4PrefsLocation );
            var nonFile = File.ReadAllText( Fallout4Location );
            // ReSharper disable once RedundantAssignment
            var pattern = "";
            // ReSharper disable once RedundantAssignment
            var replacement = "";
            // ReSharper disable once JoinDeclarationAndInitializer
            Regex rgx;

            #region Visuals
            #region Image Space
            int visuDof = 0, visuLf = 0, visuGore = 0, visuBlood = 0;
            if(VisualsDoF.Checked) { visuDof = 1; }
            if(VisualsLensflare.Checked) { visuLf = 1; }
            if(VisualsGore.Checked) { visuGore = 1; }
            if(VisualsScreenBlood.Checked) { visuBlood = 1; }
            #region DoF
            pattern = @"bDoDepthOfField=([0-9\.]+)";
            replacement = "bDoDepthOfField=" + visuDof;
            rgx = new Regex( pattern );
            nonFile = rgx.Replace( nonFile, replacement );
            #endregion
            #region Flare
            pattern = @"bLensFlare=([0-9\.]+)";
            replacement = "bLensFlare=" + visuLf;
            rgx = new Regex( pattern );
            nonFile = rgx.Replace( nonFile, replacement );
            #region Gore
            #endregion
            pattern = @"bDisableAllGore=([0-9\.]+)";
            replacement = "bDisableAllGore=" + visuGore;
            rgx = new Regex( pattern );
            nonFile = rgx.Replace( nonFile, replacement );
            #endregion
            #region Blood on screen
            pattern = @"bBloodSplatterEnabled=([0-9\.]+)";
            replacement = "bBloodSplatterEnabled=" + visuBlood;
            rgx = new Regex( pattern );
            nonFile = rgx.Replace( nonFile, replacement );
            #endregion
            #endregion
            #region Water Reflections
            int visWatObj = 0, visWatLand = 0, visWatSky = 0, visWatTre = 0;
            if(VisualWaterObjects.Checked) { visWatObj = 1; }
            if(VisualWaterLand.Checked) { visWatLand = 1; }
            if(VisualWaterSky.Checked) { visWatSky = 1; }
            if(VisualWaterTree.Checked) { visWatTre = 1; }
            #region Objects
            pattern = @"bReflectLODObjects=([0-9\.]+)";
            replacement = "bReflectLODObjects=" + visWatObj;
            rgx = new Regex( pattern );
            nonFile = rgx.Replace( nonFile, replacement );
            #endregion
            #region Land
            pattern = @"bReflectLODLand=([0-9\.]+)";
            replacement = "bReflectLODLand=" + visWatLand;
            rgx = new Regex( pattern );
            nonFile = rgx.Replace( nonFile, replacement );
            #endregion
            #region Sky
            pattern = @"bReflectSky=([0-9\.]+)";
            replacement = "bReflectSky=" + visWatSky;
            rgx = new Regex( pattern );
            nonFile = rgx.Replace( nonFile, replacement );
            #endregion
            #region Trees
            pattern = @"bReflectLODTrees=([0-9\.]+)";
            replacement = "bReflectLODTrees=" + visWatTre;
            rgx = new Regex( pattern );
            nonFile = rgx.Replace( nonFile, replacement );
            #endregion
            #endregion
            #endregion
            #region Audio
            #region Master
            var saveMasterVolume = (double)AudioMasterTrackbar.Value / 100;
            pattern = @"fAudioMasterVolume=([0-9\.]+)";
            replacement = "fAudioMasterVolume=" + saveMasterVolume;
            rgx = new Regex( pattern );
            prefsFile = rgx.Replace( prefsFile, replacement );
            #endregion
            #region Val
            #region 0
            var saveVol0 = (double)AudioVal0TrackBar.Value / 100;
            pattern = @"fVal0=([0-9\.]+)";
            replacement = "fVal0=" + saveVol0;
            rgx = new Regex( pattern );
            prefsFile = rgx.Replace( prefsFile, replacement );
            #endregion
            #region 1
            var saveVol1 = (double)AudioVal1TrackBar.Value / 100;
            pattern = @"fVal1=([0-9\.]+)";
            replacement = "fVal1=" + saveVol1;
            rgx = new Regex( pattern );
            prefsFile = rgx.Replace( prefsFile, replacement );
            #endregion
            #region 2
            var saveVol2 = (double)AudioVal2TrackBar.Value / 100;
            pattern = @"fVal2=([0-9\.]+)";
            replacement = "fVal2=" + saveVol2;
            rgx = new Regex( pattern );
            prefsFile = rgx.Replace( prefsFile, replacement );
            #endregion
            #region 3
            var saveVol3 = (double)AudioVal3TrackBar.Value / 100;
            pattern = @"fVal3=([0-9\.]+)";
            replacement = "fVal3=" + saveVol3;
            rgx = new Regex( pattern );
            prefsFile = rgx.Replace( prefsFile, replacement );
            #endregion
            #region 4
            var saveVol4 = (double)AudioVal4TrackBar.Value / 100;
            pattern = @"fVal4=([0-9\.]+)";
            replacement = "fVal4=" + saveVol4;
            rgx = new Regex( pattern );
            prefsFile = rgx.Replace( prefsFile, replacement );
            #endregion
            #region 5
            var saveVol5 = (double)AudioVal5TrackBar.Value / 100;
            pattern = @"fVal5=([0-9\.]+)";
            replacement = "fVal5=" + saveVol5;
            rgx = new Regex( pattern );
            prefsFile = rgx.Replace( prefsFile, replacement );
            #endregion
            #region 6
            var saveVol6 = (double)AudioVal6TrackBar.Value / 100;
            pattern = @"fVal6=([0-9\.]+)";
            replacement = "fVal6=" + saveVol6;
            rgx = new Regex( pattern );
            prefsFile = rgx.Replace( prefsFile, replacement );
            #endregion
            #region 7
            var saveVol7 = (double)AudioVal7TrackBar.Value / 100;
            pattern = @"fVal7=([0-9\.]+)";
            replacement = "fVal7=" + saveVol7;
            rgx = new Regex( pattern );
            prefsFile = rgx.Replace( prefsFile, replacement );
            #endregion
            #endregion
            #endregion
            #region Saving
            #region Auto
            pattern = @"fAutosaveEveryXMins=([0-9\.]+)";
            replacement = "fAutosaveEveryXMins=" + Math.Round( Convert.ToDouble( SavingAutoSaveTextBox.Text ), 4 );
            rgx = new Regex( pattern );
            prefsFile = rgx.Replace( prefsFile, replacement );
            #endregion
            #region Quick Saves
            int saPaused = 0, saTravel = 0, saWaiting = 0, saSleeping = 0;
            if(SavingQuickPause.Checked) { saPaused = 1; }
            if(SavingQuickTravel.Checked) { saTravel = 1; }
            if(SavingQuickWaiting.Checked) { saWaiting = 1; }
            if(SavingQuickSleeping.Checked) { saSleeping = 1; }
            #region Pause
            pattern = @"bSaveOnPause=([0-9\.]+)";
            replacement = "bSaveOnPause=" + saPaused;
            rgx = new Regex( pattern );
            prefsFile = rgx.Replace( prefsFile, replacement );
            #endregion
            #region Travel
            pattern = @"bSaveOnTravel=([0-9\.]+)";
            replacement = "bSaveOnTravel=" + saTravel;
            rgx = new Regex( pattern );
            prefsFile = rgx.Replace( prefsFile, replacement );
            #endregion
            #region Wait
            pattern = @"bSaveOnWait=([0-9\.]+)";
            replacement = "bSaveOnWait=" + saWaiting;
            rgx = new Regex( pattern );
            prefsFile = rgx.Replace( prefsFile, replacement );
            #endregion
            #region Sleep
            pattern = @"bSaveOnRest=([0-9\.]+)";
            replacement = "bSaveOnRest=" + saSleeping;
            rgx = new Regex( pattern );
            prefsFile = rgx.Replace( prefsFile, replacement );
            #endregion
            #endregion
            #endregion
            #region HUD
            #region Opacity
            // TODO Move to Extras class.
            //prefsFile = Extras.Save( "fHUDOpacity", prefsFile, (float)Math.Round( Convert.ToDouble( HUDOpacityTrackBar.Value ) / 100, 4 ) );
            pattern = @"fHUDOpacity=([0-9\.]+)";
            replacement = "fHUDOpacity=" + Math.Round( Convert.ToDouble( HUDOpacityTrackBar.Value ) / 100, 4 );
            rgx = new Regex( pattern );
            prefsFile = rgx.Replace( prefsFile, replacement );
            #endregion
            #region HUD Color
            #region R
            pattern = @"iHUDColorR=([0-9\.]+)";
            replacement = "iHUDColorR=" + Math.Round( Convert.ToDouble( hudColorRedTrackBar.Value ), 4 );
            rgx = new Regex( pattern );
            prefsFile = rgx.Replace( prefsFile, replacement );
            #endregion
            #region G
            pattern = @"iHUDColorG=([0-9\.]+)";
            replacement = "iHUDColorG=" + Math.Round( Convert.ToDouble( hudColorGreenTrackBar.Value ), 4 );
            rgx = new Regex( pattern );
            prefsFile = rgx.Replace( prefsFile, replacement );
            #endregion
            #region B
            pattern = @"iHUDColorB=([0-9\.]+)";
            replacement = "iHUDColorB=" + Math.Round( Convert.ToDouble( hudColorBlueTrackBar.Value ), 4 );
            rgx = new Regex( pattern );
            prefsFile = rgx.Replace( prefsFile, replacement );
            #endregion
            #endregion
            #region FOV
            #region World
            pattern = @"fDefaultWorldFOV=([0-9\.]+)";
            replacement = "fDefaultWorldFOV=" + hudFovThird.Text;
            rgx = new Regex( pattern );
            nonFile = rgx.Replace( nonFile, replacement );
            #endregion
            #region 1st
            pattern = @"fDefault1stPersonFOV=([0-9\.]+)";
            replacement = "fDefault1stPersonFOV=" + hudFovFirst.Text;
            rgx = new Regex( pattern );
            nonFile = rgx.Replace( nonFile, replacement );
            #endregion
            #endregion
            #region Other
            int hudHair = 0, hudDiaSubs = 0, hudDiaCam = 0, hudGenSubs = 0, hudGps = 0;
            if(hudCrosshair.Checked) { hudHair = 1; }
            if(hudDialogSubs.Checked) { hudDiaSubs = 1; }
            if(hudDialogCam.Checked) { hudDiaCam = 1; }
            if(hudGeneralSubs.Checked) { hudGenSubs = 1; }
            if(hudCompass.Checked) { hudGps = 1; }
            #region Crosshair
            pattern = @"bCrosshairEnabled=([0-9\.]+)";
            replacement = "bCrosshairEnabled=" + hudHair;
            rgx = new Regex( pattern );
            prefsFile = rgx.Replace( prefsFile, replacement );
            #endregion
            #region Dialog Subtitles
            pattern = @"bDialogueSubtitles=([0-9\.]+)";
            replacement = "bDialogueSubtitles=" + hudDiaSubs;
            rgx = new Regex( pattern );
            prefsFile = rgx.Replace( prefsFile, replacement );
            #endregion
            #region Dialog Camera
            pattern = @"bDialogueCameraEnable=([0-9\.]+)";
            replacement = "bDialogueCameraEnable=" + hudDiaCam;
            rgx = new Regex( pattern );
            prefsFile = rgx.Replace( prefsFile, replacement );
            #endregion
            #region General Subtitles
            pattern = @"bGeneralSubtitles=([0-9\.]+)";
            replacement = "bGeneralSubtitles=" + hudGenSubs;
            rgx = new Regex( pattern );
            prefsFile = rgx.Replace( prefsFile, replacement );
            #endregion
            #region Show Compass
            pattern = @"bShowCompass=([0-9\.]+)";
            replacement = "bShowCompass=" + hudGps;
            rgx = new Regex( pattern );
            prefsFile = rgx.Replace( prefsFile, replacement );
            #endregion
            #endregion
            #endregion
            #region Pip-Boy
            #region Color
            pattern = @"fPipboyEffectColorR=([0-9\.]+)";
            replacement = "fPipboyEffectColorR=" + PipBoyColorRedTextBox.Text;
            rgx = new Regex( pattern );
            prefsFile = rgx.Replace( prefsFile, replacement );
            pattern = @"fPipboyEffectColorG=([0-9\.]+)";
            replacement = "fPipboyEffectColorG=" + PipBoyColorGreenTextBox.Text;
            rgx = new Regex( pattern );
            prefsFile = rgx.Replace( prefsFile, replacement );
            pattern = @"fPipboyEffectColorB=([0-9\.]+)";
            replacement = "fPipboyEffectColorB=" + PipBoyColorBlueTextBox.Text;
            rgx = new Regex( pattern );
            prefsFile = rgx.Replace( prefsFile, replacement );
            #endregion
            #endregion
            #region VATS
            #endregion
            #region Gamepad
            int gpEnable = 0, gpRumble = 0;
            if(gamepadEnable.Checked) { gpEnable = 1; }
            if(gamepadRumble.Checked) { gpRumble = 1; }
            #region Enable
            pattern = @"bGamepadEnable=([0-9\.]+)";
            replacement = "bGamepadEnable=" + gpEnable;
            rgx = new Regex( pattern );
            prefsFile = rgx.Replace( prefsFile, replacement );
            #endregion
            #region Rumble
            pattern = @"bGamePadRumble=([0-9\.]+)";
            replacement = "bGamePadRumble=" + gpRumble;
            rgx = new Regex( pattern );
            prefsFile = rgx.Replace( prefsFile, replacement );
            #endregion
            #endregion
            #region Resolution
            var resBorder = 0;
            // If fullscreen is checked, also check borderless.
            // Better safe than sorry.
            #region Fullscreen || Borderless
            if(ResolutionFullscreen.Checked) {
                pattern = @"bFull Screen=([0-9\.]+)";
                replacement = "bFull Screen=1";
                rgx = new Regex( pattern );
                prefsFile = rgx.Replace( prefsFile, replacement );
                pattern = @"bBorderless=([0-9\.]+)";
                replacement = "bBorderless=1";
                rgx = new Regex( pattern );
                prefsFile = rgx.Replace( prefsFile, replacement );
            } else {
                pattern = @"bFull Screen=([0-9\.]+)";
                replacement = "bFull Screen=0";
                rgx = new Regex( pattern );
                prefsFile = rgx.Replace( prefsFile, replacement );
                if(ResolutionBorderless.Checked) { resBorder = 1; }
                pattern = @"bBorderless=([0-9\.]+)";
                replacement = "bBorderless=" + resBorder;
                rgx = new Regex( pattern );
                prefsFile = rgx.Replace( prefsFile, replacement );
            }
            #endregion
            #region Size Width
            pattern = @"iSize W=([0-9\.]+)";
            replacement = "iSize W=" + ResolutionWidth.Value;
            rgx = new Regex( pattern );
            prefsFile = rgx.Replace( prefsFile, replacement );
            #endregion
            #region Size Height
            pattern = @"iSize H=([0-9\.]+)";
            replacement = "iSize H=" + ResolutionHeight.Value;
            rgx = new Regex( pattern );
            prefsFile = rgx.Replace( prefsFile, replacement );
            #endregion
            #endregion

            // "Unlock" the files if they are set to READ ONLY.
            File.SetAttributes( Fallout4PrefsLocation, File.GetAttributes( Fallout4PrefsLocation ) & FileAttributes.Normal );
            File.SetAttributes( Fallout4Location, File.GetAttributes( Fallout4Location ) & FileAttributes.Normal );
            // Write to file
            File.WriteAllText( Fallout4PrefsLocation, prefsFile );
            File.WriteAllText( Fallout4Location, nonFile );
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
            var red = Math.Round( Convert.ToDouble( PipBoyColorRedTrackBar.Value ) / 255, 4 );
            PipBoyColorRedTextBox.Text = red.ToString( "0.0000" );
            PipBoyColorPreview.BackColor = Color.FromArgb( PipBoyColorRedTrackBar.Value, PipBoyColorGreenTrackBar.Value, PipBoyColorBlueTrackBar.Value );
        }
        private void PipBoyColorGreenTrackBar_Scroll( object sender, EventArgs e ) {
            var green = Math.Round( Convert.ToDouble( PipBoyColorGreenTrackBar.Value ) / 255, 4 );
            PipBoyColorGreenTextBox.Text = green.ToString( "0.0000" );
            PipBoyColorPreview.BackColor = Color.FromArgb( PipBoyColorRedTrackBar.Value, PipBoyColorGreenTrackBar.Value, PipBoyColorBlueTrackBar.Value );
        }
        private void PipBoyColorBlueTrackBar_Scroll( object sender, EventArgs e ) {
            var blue = Math.Round( Convert.ToDouble( PipBoyColorBlueTrackBar.Value ) / 255, 4 );
            PipBoyColorBlueTextBox.Text = blue.ToString( "0.0000" );
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

    }
}
