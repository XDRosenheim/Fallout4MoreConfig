using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Fallout4MoreConfig.Properties;

namespace Fallout4MoreConfig {
    internal class Extras {
        public object GetLineValue( string file, string command ) {
            using(var inputReader = new StreamReader( file )) {
                while(!inputReader.EndOfStream) {
                    var line = inputReader.ReadLine();
                    if(line != null && !line.StartsWith( command )) continue;
                    try {
                        if(line == null) continue;
                        var splitLine = line.Split( new[] { '=' }, StringSplitOptions.RemoveEmptyEntries );
                        return splitLine[1];
                    } catch(Exception e) {
                        // TODO - Copy error to clipboard button.
                        MessageBox.Show( Resources.Extras_GetLineValue_ + e,
                            Resources.String_Error_, MessageBoxButtons.OK, MessageBoxIcon.Error );
                        Application.Exit();
                    }
                }
            }
            return "%ERROR%";
        }
        public string PrefsConfigFile() {
            return @"C:" + Environment.ExpandEnvironmentVariables( "%HOMEPATH%" )
                + @"\Documents\my games\Fallout4\Fallout4Prefs.ini";
        }
        public string ConfigFile() {
            return @"C:" + Environment.ExpandEnvironmentVariables( "%HOMEPATH%" )
                + @"\Documents\my games\Fallout4\Fallout4.ini";
        }

        public string Save(string command, string file, float math)
        {
            var replacement = command + "=" + math;
            var rgx = new Regex( command + @"([0-9\.]+)" );
            return rgx.Replace( file, replacement );
        }
    }
}
