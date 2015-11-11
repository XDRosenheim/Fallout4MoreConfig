namespace Fallout4MoreConfig
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabVisuals = new System.Windows.Forms.TabPage();
            this.tabAudio = new System.Windows.Forms.TabPage();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.tabHUD = new System.Windows.Forms.TabPage();
            this.trackHudOpacity = new System.Windows.Forms.TrackBar();
            this.HUDOpacityLabel = new System.Windows.Forms.Label();
            this.HUDOpacityValue = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.btnOMFGQUIT = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tabPipBoy = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabHUD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackHudOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabVisuals);
            this.tabControl1.Controls.Add(this.tabAudio);
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Controls.Add(this.tabHUD);
            this.tabControl1.Controls.Add(this.tabPipBoy);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(9, 3);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(326, 233);
            this.tabControl1.TabIndex = 0;
            // 
            // tabVisuals
            // 
            this.tabVisuals.BackColor = System.Drawing.Color.Transparent;
            this.tabVisuals.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabVisuals.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabVisuals.Location = new System.Drawing.Point(4, 22);
            this.tabVisuals.Name = "tabVisuals";
            this.tabVisuals.Size = new System.Drawing.Size(318, 207);
            this.tabVisuals.TabIndex = 0;
            this.tabVisuals.Text = "Visuals";
            // 
            // tabAudio
            // 
            this.tabAudio.BackColor = System.Drawing.Color.Transparent;
            this.tabAudio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabAudio.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabAudio.Location = new System.Drawing.Point(4, 22);
            this.tabAudio.Name = "tabAudio";
            this.tabAudio.Size = new System.Drawing.Size(318, 207);
            this.tabAudio.TabIndex = 1;
            this.tabAudio.Text = "Audio";
            // 
            // tabSettings
            // 
            this.tabSettings.BackColor = System.Drawing.Color.Transparent;
            this.tabSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Size = new System.Drawing.Size(318, 207);
            this.tabSettings.TabIndex = 2;
            this.tabSettings.Text = "Settings";
            // 
            // tabHUD
            // 
            this.tabHUD.BackColor = System.Drawing.Color.Transparent;
            this.tabHUD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabHUD.Controls.Add(this.HUDOpacityValue);
            this.tabHUD.Controls.Add(this.HUDOpacityLabel);
            this.tabHUD.Controls.Add(this.trackHudOpacity);
            this.tabHUD.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabHUD.Location = new System.Drawing.Point(4, 22);
            this.tabHUD.Name = "tabHUD";
            this.tabHUD.Size = new System.Drawing.Size(318, 207);
            this.tabHUD.TabIndex = 3;
            this.tabHUD.Text = "HUD";
            // 
            // trackHudOpacity
            // 
            this.trackHudOpacity.Location = new System.Drawing.Point(8, 33);
            this.trackHudOpacity.Maximum = 100;
            this.trackHudOpacity.Name = "trackHudOpacity";
            this.trackHudOpacity.Size = new System.Drawing.Size(95, 45);
            this.trackHudOpacity.TabIndex = 1;
            this.trackHudOpacity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackHudOpacity.Value = 100;
            this.trackHudOpacity.Scroll += new System.EventHandler(this.trackHudOpacity_Scroll);
            // 
            // HUDOpacityLabel
            // 
            this.HUDOpacityLabel.AutoSize = true;
            this.HUDOpacityLabel.Location = new System.Drawing.Point(9, 14);
            this.HUDOpacityLabel.Name = "HUDOpacityLabel";
            this.HUDOpacityLabel.Size = new System.Drawing.Size(43, 13);
            this.HUDOpacityLabel.TabIndex = 2;
            this.HUDOpacityLabel.Text = "Opacity";
            // 
            // HUDOpacityValue
            // 
            this.HUDOpacityValue.AutoSize = true;
            this.HUDOpacityValue.Location = new System.Drawing.Point(110, 33);
            this.HUDOpacityValue.Name = "HUDOpacityValue";
            this.HUDOpacityValue.Size = new System.Drawing.Size(33, 13);
            this.HUDOpacityValue.TabIndex = 3;
            this.HUDOpacityValue.Text = "100%";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(4, 235);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(85, 235);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(75, 23);
            this.btnDefault.TabIndex = 2;
            this.btnDefault.Text = "Default";
            this.btnDefault.UseVisualStyleBackColor = true;
            // 
            // btnOMFGQUIT
            // 
            this.btnOMFGQUIT.Location = new System.Drawing.Point(166, 235);
            this.btnOMFGQUIT.Name = "btnOMFGQUIT";
            this.btnOMFGQUIT.Size = new System.Drawing.Size(75, 23);
            this.btnOMFGQUIT.TabIndex = 3;
            this.btnOMFGQUIT.Text = "Close";
            this.btnOMFGQUIT.UseVisualStyleBackColor = true;
            this.btnOMFGQUIT.Click += new System.EventHandler(this.btnOMFGQUIT_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(247, 235);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Button9002";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // tabPipBoy
            // 
            this.tabPipBoy.BackColor = System.Drawing.Color.Transparent;
            this.tabPipBoy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPipBoy.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPipBoy.Location = new System.Drawing.Point(4, 22);
            this.tabPipBoy.Name = "tabPipBoy";
            this.tabPipBoy.Size = new System.Drawing.Size(318, 207);
            this.tabPipBoy.TabIndex = 4;
            this.tabPipBoy.Text = "Pip-Boy";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 262);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnOMFGQUIT);
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabHUD.ResumeLayout(false);
            this.tabHUD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackHudOpacity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabVisuals;
        private System.Windows.Forms.TabPage tabAudio;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.TabPage tabHUD;
        private System.Windows.Forms.TrackBar trackHudOpacity;
        private System.Windows.Forms.Label HUDOpacityValue;
        private System.Windows.Forms.Label HUDOpacityLabel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Button btnOMFGQUIT;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TabPage tabPipBoy;
    }
}

