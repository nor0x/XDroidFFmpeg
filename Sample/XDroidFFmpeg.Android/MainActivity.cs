using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using IO.Microshow.Rxffmpeg;
using XDroidFFmpeg.Droid.Services;
using XDroidFFmpeg.Services;

namespace XDroidFFmpeg.Droid
{
    [Activity(Label = "XDroidFFmpeg", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.SetFlags("Shell_Experimental", "Visual_Experimental", "CollectionView_Experimental", "FastRenderers_Experimental");
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Startup.Init(ConfigureServices);
            RxFFmpegInvoke.Instance.SetDebug(true);
            requestPermission();
            LoadApplication(new App());
        }



        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private bool checkPermission()
        {
            var p = CheckSelfPermission(Android.Manifest.Permission.WriteExternalStorage);
            if (p == Permission.Granted)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void requestPermission()
        {

            if (ShouldShowRequestPermissionRationale(Android.Manifest.Permission.WriteExternalStorage))
            {

            }
            else
            {
                RequestPermissions(new string[] { Android.Manifest.Permission.WriteExternalStorage }, 1);
            }
        }

        void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
        {
            services.AddSingleton<IFFmpegService, FFmpegServiceDroid>();
        }
    }
}