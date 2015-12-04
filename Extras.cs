using System;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using MyDLL;

namespace Fallout4MoreConfig {
    internal class Extras {
        public dynamic GetLineValue( string file, string section, string key ) {
            dynamic configIniFile;
            if(file == PrefsConfigFile()) {
                configIniFile = new IniFile( PrefsConfigFile() );
            } else if(file == ConfigFile()) {
                configIniFile = new IniFile( ConfigFile() );
            } else {
                return null;
            }
            return configIniFile.Read( section, key );
        }
        public string PrefsConfigFile() {
            return "C:" + Environment.ExpandEnvironmentVariables( "%HOMEPATH%" )
                + "\\Documents\\my games\\Fallout4\\Fallout4Prefs.ini";
        }
        public string ConfigFile() {
            return "C:" + Environment.ExpandEnvironmentVariables( "%HOMEPATH%" )
                + "\\Documents\\my games\\Fallout4\\Fallout4.ini";
        }
        public string CustomConfigFile() {
            return "C:" + Environment.ExpandEnvironmentVariables( "%HOMEPATH%" )
                + "\\Documents\\my games\\Fallout4\\Fallout4Custom.ini";
        }
        public string ConfigFileBackup() {
            return "C:" + Environment.ExpandEnvironmentVariables( "%HOMEPATH%" )
                + "\\Documents\\my games\\Fallout4\\Fallout4.backup.ini";
        }
        public string PrefsConfigFileBackup() {
            return "C:" + Environment.ExpandEnvironmentVariables( "%HOMEPATH%" )
                + "\\Documents\\my games\\Fallout4\\Fallout4Prefs.backup.ini";
        }
        public string CustomConfigFileBackup() {
            return "C:" + Environment.ExpandEnvironmentVariables( "%HOMEPATH%" )
                + "\\Documents\\my games\\Fallout4\\Fallout4Custom.backup.ini";
        }
        public string Save( string command, string file, float math ) {
            var replacement = command + "=" + math;
            var rgx = new Regex( command + @"([0-9\.]+)" );
            return rgx.Replace( file, replacement );
        }
        public string SteamExePath() {
            var regKey = Registry.CurrentUser;
            regKey = regKey.OpenSubKey( @"Software\Valve\Steam" );
            return regKey != null ? regKey.GetValue( "SteamExe" ).ToString() : null;
        }
    }
}
