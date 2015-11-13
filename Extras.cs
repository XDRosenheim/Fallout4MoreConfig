using System;
using System.IO;
using System.Windows.Forms;
using Fallout4MoreConfig.Properties;

namespace Fallout4MoreConfig {
    internal class Extras {
        
        /// <summary>
        /// This is going to be moved to its own class later.
        /// WE ARE NOT EVEN IN AN ALPHA STAGE FOLKS!
        /// </summary>
        /// <param name="file">Full path to file, including filename.</param>
        /// <param name="command">The command used for the setting.</param>
        /// <returns>An object</returns>
        public object GetLineValue( string file, string command ) {
            using(var inputReader = new StreamReader( file )) {
                while(!inputReader.EndOfStream) {
                    var line = inputReader.ReadLine();
                    if (line != null && !line.StartsWith(command)) continue;
                    try {
                        if (line == null) continue;
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
    }

}
