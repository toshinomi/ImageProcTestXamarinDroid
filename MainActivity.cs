using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Graphics;
using System.Threading.Tasks;

namespace ImageProcTestXamarinDroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private ImageView   mImageView;
        private Bitmap      mBitmap;
        private Button      mBtnMono;
        private Button      mBtnReset;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            InitLayout();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        /// <summary>
        /// レイアウトの初期設定
        /// </summary>
        public void InitLayout()
        {
            mImageView = (ImageView)FindViewById(Resource.Id.image);

            mBitmap = BitmapFactory.DecodeResource(Resources, Resource.Drawable.dog);

            mBtnMono = (Button)FindViewById(Resource.Id.mono);
            mBtnMono.Click += OnClickBtnMono;

            mBtnReset = (Button)FindViewById(Resource.Id.reset);
            mBtnReset.Click += OnClickBtnReset;
        }

        /// <summary>
        /// モノクロボタンのクリックイベント
        /// </summary>
        /// <param name="s">オブジェクト</param>
        /// <param name="e">イベントのデータ</param>
        private async void OnClickBtnMono(object s, EventArgs e)
        {
            var gray = new GrayScale();
            var mutableBitmap = await Task.Run(() => gray.GoImgProc(mBitmap));
            mImageView.SetImageBitmap(mutableBitmap.Copy(Bitmap.Config.Argb8888, false));
        }

        /// <summary>
        /// リセットボタンのクリックイベント
        /// </summary>
        /// <param name="s">オブジェクト</param>
        /// <param name="e">イベントのデータ</param>
        private void OnClickBtnReset(object s, EventArgs e)
        {
            mImageView.SetImageBitmap(mBitmap);
        }
    }
}