using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using static IO.Microshow.Rxffmpeg.RxFFmpegInvoke;

namespace XDroidFFmpeg.Droid.Services
{
    public class FFmpegListener : Java.Lang.Object, IFFmpegListener
    {
        public Action<int> Callback { get; set; }

        public FFmpegListener(Action<int> callback)
        {
            Callback = callback;
        }

        public void OnCancel()
        {
            Callback?.Invoke(-1);
        }

        public void OnError(string p0)
        {
            Callback?.Invoke(-1);
        }

        public void OnFinish()
        {
            Callback?.Invoke(100);

        }

        public void OnProgress(int p0, long p1)
        {
            Callback?.Invoke(p0);
        }
    }
}