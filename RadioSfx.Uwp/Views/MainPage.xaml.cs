using Newtonsoft.Json;
using RadioSfx.Uwp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.System.Display;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RadioSfx.Uwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private bool isPlaying;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void LoadStream(MediaSource stream)
        {
            SfxPlayer.Source = stream;
            SfxPlayer.MediaPlayer.Play();
        }

        private void BaseButton_Click(object sender, RoutedEventArgs e)
        {
            if (isPlaying) SfxPlayer.MediaPlayer.Pause();
            else
            {
                var stream = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/SFX/laugh.mp3"));
                LoadStream(stream);
            }
        }

        private void MediaPlayerElement_CurrentStateChanged(MediaPlaybackSession sender, object args)
        {
            isPlaying = false;
            MediaPlaybackSession playbackSession = sender as MediaPlaybackSession;
            if (playbackSession != null)
            {
                if (playbackSession.PlaybackState == MediaPlaybackState.Playing)
                {
                    isPlaying = true;
                }
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SfxPlayer.Source = null;
            SfxPlayer.MediaPlayer.PlaybackSession.PlaybackStateChanged += MediaPlayerElement_CurrentStateChanged;

            ReadSampleData();

            base.OnNavigatedTo(e);
        }

        private async Task ReadSampleData()
        {
            var json = await File.ReadAllTextAsync("ms-appx:///Assets/Data/samplepreset.json"); 
            var array = JsonConvert.DeserializeObject<List<Preset>>(json);


        }
    }
}
