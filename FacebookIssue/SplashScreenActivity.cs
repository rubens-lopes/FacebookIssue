using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Org.Json;
using System.Collections.Generic;
using Xamarin.Facebook;
using Xamarin.Facebook.Login;

[assembly: MetaData("com.facebook.sdk.ApplicationId", Value = "@string/FacebookAppId")]
[assembly: MetaData("com.facebook.sdk.ApplicationName", Value = "@string/ApplicationName")]
namespace FacebookIssue
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class SplashScreenActivity : Activity, IFacebookCallback, GraphRequest.IGraphJSONObjectCallback
    {
        private ICallbackManager callbackManager;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            FacebookSdk.SdkInitialize(ApplicationContext);
            SetContentView(Resource.Layout.Main);

            callbackManager = CallbackManagerFactory.Create();
            LoginManager.Instance.RegisterCallback(callbackManager, this);
            FindViewById<Button>(Resource.Id.btnLogIn).Click += (sender, e) =>
            {
                LoginManager.Instance.LogInWithReadPermissions(this, new List<string>() { "public_profile", "email", "user_birthday" });
            };
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            callbackManager.OnActivityResult(requestCode, (int)resultCode, data);
        }

        public void OnCancel()
        {
            Toast.MakeText(this, "OnCancel", ToastLength.Long).Show();
        }

        public void OnError(FacebookException p0)
        {
            Toast.MakeText(this, "OnError", ToastLength.Long).Show();
        }

        public void OnSuccess(Java.Lang.Object p0)
        {
            Toast.MakeText(this, "OnSuccess", ToastLength.Long).Show();
        }

        public void OnCompleted(JSONObject p0, GraphResponse p1)
        {
            Toast.MakeText(this, "OnCompleted", ToastLength.Long).Show();
        }
    }
}