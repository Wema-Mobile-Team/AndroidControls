using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;
using System.Collections.Generic;
using Google.Android.Material.Button;
using Android.Content;

namespace androidcontrols
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private FloatingActionButton fab;
        private const int BENNO = 100;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
             fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
             fab.Click += FabOnClick;
             AppCompatCheckBox appCompatCheck = FindViewById< AppCompatCheckBox >( Resource.Id.controls_checked);
            AppCompatRadioButton maleControl = FindViewById<AppCompatRadioButton>(Resource.Id.male_control);
            AppCompatRadioButton femaleControl = FindViewById<AppCompatRadioButton>(Resource.Id.female_control);

            AppCompatRadioButton preferControl = FindViewById<AppCompatRadioButton>(Resource.Id.prefer_control);
            MaterialButton appCompatButton = FindViewById<MaterialButton>(Resource.Id.btn_proceed);
            appCompatButton.Click += (o, e) =>
            {
                Intent intent = new Intent(this, typeof(BeneficairyActivity));
                StartActivityForResult(intent,100);
            };


            maleControl.Click += ControlsClick;
            femaleControl.Click += ControlsClick;
            preferControl.Click += ControlsClick;




            appCompatCheck.Click += (o, e) =>
             {
                 if (appCompatCheck.Checked)
                 {
                     showMessage("I'm Checked, Devs");
                 }
                 else showMessage("Not a Dev Member");
             };
        }


        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if(requestCode == BENNO)
            {
                if(resultCode == Result.Ok)
                {

                    string benName = data.GetStringExtra("BenName");
                    string benNo = data.GetStringExtra("BenNo");
                    showMessage($"Benficiary Name: {benName} \n Account No: {benNo} ");

                }
                else
                {
                    showMessage("Beneficiary Not Received");
                }
            }

        }

        private void ControlsClick(object sender,EventArgs e)
        {
            AppCompatRadioButton rb = (AppCompatRadioButton)sender;
            showMessage($"{rb.Text} is clicked");
        }

        /*
         *  public void checkedListener(object sender, Compound.CheckedChangedEventArgs e)
         {

                if(e.isChecked) .....
                 else ..... 
         }
         */

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            switch (id){
                case Resource.Id.action_settings:
                    
                    break;
                case Resource.Id.action_devs:
                    Snackbar.Make(fab, "Replace with your own action", Snackbar.LengthLong)
                    .SetAction("Action", (View.IOnClickListener)null).Show();
                    //Toast.MakeText(this, "I clicked on the developers", ToastLength.Long);
                    break;

            }

           

            return base.OnOptionsItemSelected(item);
        }

        private void showMessage(string message)
        {
            Snackbar.Make(fab, message, Snackbar.LengthLong)
                    .SetAction("Action", (View.IOnClickListener)null).Show();
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (View.IOnClickListener)null).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
