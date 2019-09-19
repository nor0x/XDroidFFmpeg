using System;
using System.Collections.Generic;
using System.Text;

namespace XDroidFFmpeg.Services
{
    public interface IFFmpegService
    {
        void RunCommand(string cmd, Action<int> callback);
    }
}
