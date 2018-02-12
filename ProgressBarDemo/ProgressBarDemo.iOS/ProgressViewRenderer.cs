using CoreAnimation;
using CoreGraphics;
using ProgressBarDemo;
using ProgressBarDemo.iOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ProgressView), typeof(ProgressViewRenderer))]
namespace ProgressBarDemo.iOS
{
    public class ProgressViewRenderer : ViewRenderer
    {
        CAShapeLayer progressLayer;
        UILabel label;


        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            Setup();
            Complete = ((ProgressView)Element).Progress;
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == "Progress")
            {
                Complete = ((ProgressView)Element).Progress;
            }
        }

        void Setup()
        {
            BackgroundColor = UIColor.Clear;

            Layer.CornerRadius = 25;
            Layer.BorderWidth = 10;
            Layer.BorderColor = UIColor.Blue.CGColor;
            Layer.BackgroundColor = UIColor.Cyan.CGColor;

            progressLayer = new CAShapeLayer()
            {
                FillColor = UIColor.Red.CGColor,
                Frame = Bounds
            };
            Layer.AddSublayer(progressLayer);

            label = new UILabel(Bounds)
            {
                TextAlignment = UITextAlignment.Center,
                TextColor = UIColor.White,
                BackgroundColor = UIColor.Clear,
                Font = UIFont.FromName("ChalkboardSE-Bold", 20)
            };
            InsertSubview(label, 100);
        }

        double complete;
        public double Complete
        {
            get { return complete; }
            set { complete = value; label.Text = $"{value * 100} %"; SetNeedsDisplay(); }
        }

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            var progressWidth = (rect.Width - (Layer.BorderWidth * 2)) * complete;
            var progressRect = new CGRect(rect.X + Layer.BorderWidth, rect.Y + Layer.BorderWidth, progressWidth, (rect.Height - Layer.BorderWidth * 2));
            progressLayer.Path = UIBezierPath.FromRoundedRect(progressRect, 25).CGPath;

            label.Frame = Bounds;
        }
    }
}
