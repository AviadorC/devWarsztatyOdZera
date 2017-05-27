using Android.App;
using Android.Widget;
using Android.OS;

namespace devWarsztatyClean.Droid
{
    [Activity(Label = "devWarsztatyClean", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        private MainViewModel viewModel;

        private TextView titleTextView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            viewModel = new MainViewModel();
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var x = new MyClass();

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);

            button.Click += delegate { viewModel.Title = $"{count++} clicks!"; };

            viewModel.PropertyChanged += ViewModel_PropertyChanged;

            titleTextView = FindViewById<TextView>(Resource.Id.title);
        }

        private void ViewModel_PropertyChanged(
            object sender, 
            System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Title":
                    titleTextView.Text = viewModel.Title;
                    break;
            }
        }
    }
}

