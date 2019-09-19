using System;
using XDroidFFmpeg.Services;
using IO.Microshow.Rxffmpeg;
using System.Threading.Tasks;
using System.Threading;

namespace XDroidFFmpeg.Droid.Services
{
    public class FFmpegServiceDroid : IFFmpegService
    {
        public async void RunCommand(string cmd, Action<int> callback)
        {
            //cancel current operations
            RxFFmpegInvoke.Instance.Exit();
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken ct = cts.Token;
            //kill video operations after 1 minute
            int timeout = 60000;
            cts.CancelAfter(timeout);
            var task = Task.Run(() =>
            {
                var li = new FFmpegListener(callback);
                var command = cmd.Split(" ");
                RxFFmpegInvoke.Instance.FFmpegListener = li;
                var i = RxFFmpegInvoke.Instance.RunCommand(command, li);

            }, ct);

            await Task.WhenAny(task);
            cts.Cancel();
        }
    }
}