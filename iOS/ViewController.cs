using System;

using UIKit;

namespace devWarsztatyClean.iOS
{
    public partial class ViewController : UIViewController
    {
        int count = 1;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        private MainViewModel viewModel;

        public override void ViewDidLoad()
        {
            viewModel = new MainViewModel();
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            Button.AccessibilityIdentifier = "myButton";
            Button.TouchUpInside += delegate
            {
                var title = string.Format("{0} clicks!", count++);
                Button.SetTitle(title, UIControlState.Normal);
            };

            var x = new MyClass();

            TitleLabel.Text = viewModel.Title;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }

        private void ViewModel_PropertyChanged(
        	object sender,
        	System.ComponentModel.PropertyChangedEventArgs e)
        {
        	switch (e.PropertyName)
        	{
        		case "Title":
        			TitleLabel.Text = viewModel.Title;
                    break;
            }
        }
    }
}
