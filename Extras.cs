using System;
using System.Windows.Forms;
using Fallout4MoreConfig.Properties;
using Microsoft.Win32;
using MyDLL;

namespace Fallout4MoreConfig {
    internal class Extras {
        public dynamic GetIniValue( string file, string section, string key ) {
            dynamic configIniFile = null;
            try {
                if(file == PrefsConfigFile()) {
                    configIniFile = new IniFile( PrefsConfigFile() );
                } else if(file == ConfigFile()) {
                    configIniFile = new IniFile( ConfigFile() );
                }
            } catch(Exception)
            {
                return null;
            }
            return configIniFile.Read( section, key );
        }
        // Primary config files.
        public string PrefsConfigFile() {
            return ConfigPath() + "Fallout4Prefs.ini";
        }
        public string ConfigFile() {
            return ConfigPath() + "Fallout4.ini";
        }
        public string CustomConfigFile() {
            return ConfigPath() + "Fallout4Custom.ini";
        }
        // For backups. See how sweet I am?
        public string ConfigFileBackup() {
            return ConfigPath() + "backup.Fallout4.ini";
        }
        public string PrefsConfigFileBackup() {
            return ConfigPath() + "backup.Fallout4Prefs.ini";
        }
        public string CustomConfigFileBackup() {
            return ConfigPath() + "backup.Fallout4Custom.ini";
        }

        public string ConfigPath() {
            return Environment.ExpandEnvironmentVariables( "%HOMEDRIVE%" ) +
                   Environment.ExpandEnvironmentVariables( "%HOMEPATH%" ) +
                   "\\Documents\\my games\\Fallout4\\";
        }
        public string SteamExePath() {
            var regKey = Registry.CurrentUser;
            try {
                regKey = regKey.OpenSubKey( @"Software\Valve\Steam" );
                return regKey != null ? regKey.GetValue( "SteamExe" ).ToString() : null;
            } catch(Exception) {
                MessageBox.Show( Resources.NoFound_SteamPath, Resources.Error_Header, MessageBoxButtons.OK );
            }
            return null;
        }
    }
}
