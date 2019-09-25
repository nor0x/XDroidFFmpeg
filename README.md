<img src="https://raw.githubusercontent.com/nor0x/XDroidFFmpeg/master/Art/logo.svg?sanitize=true" width="150px" />

# XDroidFFmpeg
Xamarin.Android bindings for [RxFFmpeg](https://github.com/microshow/RxFFmpeg). (Kudos [@microshow](https://github.com/microshow))  This `Java Bindings Library` provides performant audio and video processing / editing powered by `FFmpeg 4.0` + `X264` + `mp3lame` + `fdk-aac`.

[![](https://img.shields.io/nuget/vpre/XDroidFFmpeg.svg)](https://nuget.org/packages/XDroidFFmpeg)

## Why XDroidFFmpeg?

Using [FFmpeg](https://github.com/FFmpeg/FFmpeg) in `(Xamarin.)Android` seems easy at first - there are some projects around, but there are some gotchas like getting compilation for different ABIs right and adding support for hardware acceleration. [RxFFmpeg](https://github.com/microshow/RxFFmpeg) is doing a great job of making it easy to run commands against `ffmpeg`. I was struggling with getting FFmpeg performance right on Xamarin.Android that's way I started binding [RxFFmpeg](https://github.com/microshow/RxFFmpeg) since they have support for `Android` `MediaCodec`. One goal with this `Java Bindings Library` is to make it as easy as possible to call into the native `ffmpeg` commands from `Xamarin.Android`. 

Major credits to [@microshow](https://github.com/microshow) for doing the hard work 👍.

## Getting started

### NuGet
XDroidFFmpeg is up on NuGet and GitHub
[https://www.nuget.org/packages/XDroidFFmpeg](https://www.nuget.org/packages/XDroidFFmpeg)
[https://github.com/nor0x/XDroidFFmpeg/packages](https://github.com/nor0x/XDroidFFmpeg/packages)


### Project
Start by adding a reference to [RxFFmpeg_Bindings.csproj](https://github.com/nor0x/XDroidFFmpeg/blob/master/RxFFmpeg_Bindings/RxFFmpeg_Bindings.csproj "RxFFmpeg_Bindings.csproj") to the `Xamarin.Android` project. Set API Level and supported ABIs in the project properties. Hint: use `arm64-v8a` for best performance on supported devices.

## Running `ffmpeg` commands 

Running commands against `ffmpeg` is as simple as:

    var command = cmd.Split(" ");
    RxFFmpegInvoke.Instance.RunCommand(command, null);
For getting callbacks an implementation of `IFFmpegListener` can be passed to `RunCommand`

There is also a demo project which demonstrates adding `.PNG` watermark to an `.MP4` video. To get the demo working you need to create a `ffmpegtest` folder in `/storage/emulated/0/` and add a `video.mp4` and `watermark.png` file to this folder.

#### Watermark Demo
<img src="https://raw.githubusercontent.com/nor0x/XDroidFFmpeg/master/Art/demo.gif?raw=true" width="350px" />

More demo scenarios might be added in the future. Head over to [ffmpeg documentation](https://ffmpeg.org/ffmpeg.html) for more.

## Contribution

Feel free to create issues and PRs  😃
