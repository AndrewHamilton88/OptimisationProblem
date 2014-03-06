using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using WMPLib;
using AxWMPLib;
using System.Windows.Forms;

namespace RouteChoiceGame
{
    public partial class WallTurningIntentionVideo : Form
    {
        public WallTurningIntentionVideo()
        {
            InitializeComponent();
        }

        WMPLib.WindowsMediaPlayer Player;

        private void PlayFile(String url)
        {
            Player = new WMPLib.WindowsMediaPlayer();
            Player.PlayStateChange +=
                new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(Player_PlayStateChange);
            Player.MediaError +=
                new WMPLib._WMPOCXEvents_MediaErrorEventHandler(Player_MediaError);
            Player.URL = url;
            Player.controls.play();
        }

        private void Player_MediaError(object pMediaObject)
        {
            MessageBox.Show("Cannot play media file.");
            this.Close();
        }

        private void PlayerScreen_Enter(object sender, EventArgs e)
        {
            PlayFile(@"C:\Data\Videos\Burgess Road1 - Series _WMPOCXEvents_EndOfStreamEvent Cars.avi");
        }


    }
}
