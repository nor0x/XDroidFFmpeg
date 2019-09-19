using XDroidFFmpeg.Services;
using Xamarin.Forms.Xaml;

using Xamarin.Forms;
using System.Windows.Input;

namespace XDroidFFmpeg.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        string _command;
        public string Command
        {
            get => _command;
            set
            {
                Progress = 0;
                SetProperty(ref _command, value);
            }
        }

        double _progress;
        public double Progress
        {
            get => _progress;
            set => SetProperty(ref _progress, value);
        }

        string _progressString;
        public string ProgressString
        {
            get => _progressString;
            set => SetProperty(ref _progressString, value);
        }

        bool _buttonEnabled;
        public bool ButtonEnabled
        {
            get => _buttonEnabled;
            set => SetProperty(ref _buttonEnabled, value);
        }
        public MainViewModel()
        {
            Progress = 0;
            ProgressString = "0%";
            ButtonEnabled = true;
            RunFFmpegCommand = new Command(() =>
            {
                ButtonEnabled = false;
                Progress = 0;
                ProgressString = "0%";
                Startup.ServiceProvider.GetService<IFFmpegService>().RunCommand(Command, (p) =>
                {
                    Progress = (double)p / 100;
                    ProgressString = p + "%";
                    if (p == 100)
                    {
                        ButtonEnabled = true;
                    }
                });
            });

            SetDefaultCmdCommand = new Command(() =>
            {
                Command = "ffmpeg -i /storage/emulated/0/ffmpegtest/video.mp4 -i /storage/emulated/0/ffmpegtest/watermark.png -filter_complex overlay=(W-w)/2:(H-h)/2 -preset ultrafast /storage/emulated/0/ffmpegtest/final.mp4 -y";
            });
        }
        

        public ICommand RunFFmpegCommand { get; }
        public ICommand SetDefaultCmdCommand { get; }

             }
}