using System;
using System.IO;
using System.Windows.Forms;
using Fallout4MoreConfig.Properties;

namespace Fallout4MoreConfig {
    internal static class Program {
        private static readonly Extras Extras = new Extras();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main() {
            // See if config files exists
            if(!File.Exists( Extras.ConfigFile() )) {
                MessageBox.Show(
                    Extras.ConfigFile() + Resources.Error_Path_not_found_ + Resources.string_newLine + Resources.Run_Game,
                    Resources.Error_Header, MessageBoxButtons.OK,
                    MessageBoxIcon.Error );
                Application.Exit();
                return;
            }
            if(!File.Exists( Extras.PrefsConfigFile() )) {
                MessageBox.Show(
                    Extras.PrefsConfigFile() + Resources.Error_Path_not_found_ + Resources.string_newLine + Resources.Run_Game,
                    Resources.Error_Header, MessageBoxButtons.OK,
                    MessageBoxIcon.Error );
                Application.Exit();
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );
            Application.Run( new Form1() );
        }
    }
}
