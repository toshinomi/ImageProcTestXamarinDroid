using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;

/// <summary>
/// グレースケール
/// </summary>
class GrayScale
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    public GrayScale()
    {
    }

    /// <summary>
    /// デスクトラクタ
    /// </summary>
    ~GrayScale()
    {
    }

    /// <summary>
    /// グレースケールの実行
    /// </summary>
    /// <param name="image">ビットマップ</param>
    /// <returns>グレースケール後のビットマップ</returns>
    public Bitmap GoImageProcessing(Bitmap bitmap)
    {
        var pixels = new int[bitmap.Width * bitmap.Height];
        var resultPixels = new int[bitmap.Width * bitmap.Height];

        bitmap.GetPixels(pixels, 0, bitmap.Width, 0, 0, bitmap.Width, bitmap.Height);

        int count = 0;
        foreach (var argb in pixels)
        {
            var color = new Android.Graphics.Color(argb);
            var gray = (byte)((color.R + color.G + color.B) / 3);
            resultPixels[count++] = Android.Graphics.Color.Argb(color.A, gray, gray, gray);
        }

        var mutableBitmap = Bitmap.CreateBitmap(bitmap.Width, bitmap.Height, bitmap.GetConfig());
        mutableBitmap.SetPixels(resultPixels, 0, mutableBitmap.Width, 0, 0, mutableBitmap.Width, mutableBitmap.Height);

        return mutableBitmap;
    }
}