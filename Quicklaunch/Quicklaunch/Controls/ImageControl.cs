using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using JohnBPearson.FileObjects;
using JohnBPearson.FileObjects.Model;
using ToolTip = System.Windows.Controls.ToolTip;

namespace Quicklaunch.Controls
{

    public enum AnimationType
    { 
        Scale = 0,
        Bounce =1,
     
       
    }
    public class ImageControl : System.Windows.Controls.Image
    {


        public IFileSystemObjectBase FileSystemObject

        {
            get; private set;
        }

        public ScaleTransform scaleTransform
        {
            get; set;
        }


        public ImageControl(ScaleTransform scaleTransform, IFileSystemObjectBase fileSystemObjectBase) : base()
        {
            this.FileSystemObject = fileSystemObjectBase;
            this.scaleTransform = scaleTransform;

        }

        public ImageControl(ScaleTransform scaleTransform, IFileSystemObjectBase fileSystemObjectBase, string tooltipConents) : base()
        {
            this.FileSystemObject = fileSystemObjectBase;
            this.scaleTransform = scaleTransform;
            this.setTooltip(tooltipConents);
        }
        private bool _transforming;
        public bool Transforming
        {
            get
            {
                return _transforming;
            }
        }
     //   private TranslateTransform? translateTransform;
        //private DoubleAnimation? bounceAnimation;
        //private BounceEase? bounceEase;
        public void AnimateBounce()
        {
            //// 1. Create the transform and apply it to the element
            //if(this.translateTransform == null)
            //{
            //    translateTransform = new TranslateTransform();
            //}

            //this.RenderTransform = translateTransform;

            //// 2. Create the animation
            //if(this.bounceAnimation == null)
            //{
            //    this.bounceAnimation = new DoubleAnimation
            //    {
            //        From = -1050,           // Start 150 pixels above its original position
            //        To = 0,                // End at its original position
            //       Duration = new Duration(TimeSpan.FromSeconds(2))//, // 2-second animation
            //        //RepeatBehavior = new RepeatBehavior()
            //    };
            //}



            //// 3. Create and configure the BounceEase function
            //if(this.bounceEase == null)
            //{
            //    BounceEase bounceEase = new BounceEase
            //    {
            //        Bounces = 3,           // Number of bounces
            //        Bounciness = 2.0,      // Elasticity (higher = less bouncy/faster decay)
            //        EasingMode = EasingMode.EaseOut // Bounce at the end of the animation
            //    };

            //    // 4. Apply the easing function to the animation

            //}

            //bounceAnimation.EasingFunction = bounceEase;
            //// 5. Start the animation on the Y property of the TranslateTransform
            //translateTransform.BeginAnimation(TranslateTransform.YProperty, bounceAnimation);

            TranslateTransform translateTransform = new TranslateTransform();
            this.RenderTransform = translateTransform;

            // 2. Create the animation
            DoubleAnimation bounceAnimation = new DoubleAnimation
            {
                From = -100,           // Start 150 pixels above its original position
                To = 0,                // End at its original position
                Duration = new Duration(TimeSpan.FromSeconds(2)) // 2-second animation
            };

            // 3. Create and configure the BounceEase function
            BounceEase bounceEase = new BounceEase
            {
                Bounces = 3,           // Number of bounces
                Bounciness = 2.0,      // Elasticity (higher = less bouncy/faster decay)
                EasingMode = EasingMode.EaseOut // Bounce at the end of the animation
            };

            // 4. Apply the easing function to the animation
            bounceAnimation.EasingFunction = bounceEase;
            this._transforming = true;
            bounceAnimation.Completed += (s, c) => this._transforming = false;

            // 5. Start the animation on the Y property of the TranslateTransform
            translateTransform.BeginAnimation(TranslateTransform.YProperty, bounceAnimation);
        }
        public void StopBounceAnimation()
        {
            //if(translateTransform != null)
            //{
            //    translateTransform.BeginAnimation(TranslateTransform.YProperty, null); // Stops the animation
            //}
        }

        
        private const double scaleTransformFactor = 1.4;

        public void scaleUp()
        {



            if((this.RenderTransform is ScaleTransform))
            {

                var scaleTransform = (ScaleTransform)this.RenderTransform;
                scaleTransform.ScaleX = scaleTransformFactor;
                scaleTransform.ScaleY = scaleTransformFactor;
            }
            else if(this.LayoutTransform is ScaleTransform)
            {
                var scaleTransform = (ScaleTransform)this.LayoutTransform;
                scaleTransform.ScaleX = scaleTransformFactor;
                scaleTransform.ScaleY = scaleTransformFactor;
            }
            else
            {

                throw new Exception(Name + " is not a ScaleTransform");


                //image.scaleTransform.ScaleX = scaleTransformFactor;
                //image.scaleTransform.ScaleX = scaleTransformFactor;
            }
        }

        public void scaleDown()
        {

            ScaleTransform? temp = null;


            //  temp = this.LayoutTransform as ScaleTransform;

            if(this.LayoutTransform is ScaleTransform)
            {
                temp = this.LayoutTransform as ScaleTransform;
                temp.ScaleX = 1;
                temp.ScaleY = 1;
            }
            else if(this.RenderTransform is ScaleTransform)
            {
                temp = this.RenderTransform as ScaleTransform;
                temp.ScaleX = 1;
                temp.ScaleY = 1;
            }
            else
            {
                throw new Exception("ScaleTransform is null");
            }
        }

        private void setTooltip(string content)
        {


            // Source - https://stackoverflow.com/a/49650044
            // Posted by Anthony
            // Retrieved 2026-10-13, License - CC BY-SA 3.0

            var tooltip = new ToolTip { Content = content };
            this.ToolTip = tooltip;
            //tooltip.Opened += async delegate (object o, RoutedEventArgs args)
            //{
            //    var s = o as ToolTip;
            //    // let the tooltip display for 1 second
            //    await Task.Delay(1000);
            //    s.IsOpen = false;
            //    // wait till the close tooltip animation finishes before changing to old tooltip text
            //    await Task.Delay(1000);
            //    s.Content = "Old tooltip text";
            //};
            //tooltip.IsOpen = true;

        }
    }
}
