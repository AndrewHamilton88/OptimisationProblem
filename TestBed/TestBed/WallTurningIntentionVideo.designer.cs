namespace RouteChoiceGame
{
    partial class WallTurningIntentionVideo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WallTurningIntentionVideo));
            this.PlayerScreen = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // PlayerScreen
            // 
            this.PlayerScreen.Enabled = true;
            this.PlayerScreen.Location = new System.Drawing.Point(176, 80);
            this.PlayerScreen.Name = "PlayerScreen";
            this.PlayerScreen.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("PlayerScreen.OcxState")));
            this.PlayerScreen.Size = new System.Drawing.Size(857, 512);
            this.PlayerScreen.TabIndex = 1;
            this.PlayerScreen.Enter += new System.EventHandler(this.PlayerScreen_Enter);
            // 
            // WallTurningIntentionVideo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(55)))), ((int)(((byte)(94)))));
            this.ClientSize = new System.Drawing.Size(1248, 644);
            this.Controls.Add(this.PlayerScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WallTurningIntentionVideo";
            this.Text = "WallTurningIntentionVideo";
            ((System.ComponentModel.ISupportInitialize)(this.PlayerScreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer PlayerScreen;

    }
}