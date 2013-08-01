using System;
using System.Drawing;

using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;

namespace JanBecaus
{
    public static class UIColorExtensions
    {

        public static UIImage ImageFromColor (this UIColor color)
        {
            RectangleF rect = new RectangleF (0.0f, 0.0f, 1.0f, 1.0f);
            UIGraphics.BeginImageContext (rect.Size);
            CGContext context = UIGraphics.GetCurrentContext ();

            context.SetFillColor (color.CGColor);
            context.FillRect (rect);

            UIImage image = UIGraphics.GetImageFromCurrentImageContext ();
            UIGraphics.EndImageContext ();

            return image;
        }
    }
}

