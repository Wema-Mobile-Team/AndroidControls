
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using androidcontrols.db;
using androidcontrols.model;
using Google.Android.Material.Button;
using Google.Android.Material.TextField;
using Newtonsoft.Json;

namespace androidcontrols
{

    [Activity(Label = "DesignActivity", Theme = "@style/AppTheme.NoActionBar")]
    public class DesignActivity : Activity
    {
         Context mContex;
        ISharedPreferences prefs;
        ISharedPreferencesEditor editor;
        AppPreference appPreference;
        AppDatabase db;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
               SetContentView(Resource.Layout.textinputdesigns);
               mContex = this;
               db = new AppDatabase();
               db.createDatabase();
               prefs = PreferenceManager.GetDefaultSharedPreferences(mContex);
               editor = prefs.Edit();
               MaterialButton btnChecker = FindViewById<MaterialButton>(Resource.Id.btn_erroChecker);
               TextInputLayout layout = FindViewById<TextInputLayout>(Resource.Id.password_layout);
               appPreference = new AppPreference(mContex);
               InitializePreference();

               
            btnChecker.Click += delegate {
                try
                {
                    var post = new Post() { title = "Learning", userId = 0, body = "Hello, how are you doing" };
                    db.insertPost(post);
                    loadData();
                }
                catch (Exception ex)
                {
                    Log.Info("insertPost", ex.Message);
                }
            
                loadData();
                // loginUserAccount("2348097926728", "Test12345");
                //  retrieveSavedData();
                // layout.Error = GetString(Resource.String.error_dev);
            }; ;

          NetworkUtils.baseUrl = "ee";

        }

        private void loadData()
        {
            var postList = db.fetchAllPost();
            var result = "";
        }


        public  async void loginUserAccount(string email, string password)
        {
            string result = string.Empty;
            try
            {
                LoginModel model = new LoginModel() { phoneNumber = email, password = password };
                var rawString = JsonConvert.SerializeObject(model);
                result = await NetworkUtils.PostUserData("/auth/login", rawString);
                if (!string.IsNullOrEmpty(result))
                {
                    /*
                     *   var desiioo = JsonConvert.DeserializeObject<LoginModel>(result);
                   var collected = desiioo.phoneNumber;
                     */
                    Toast.MakeText(this, "Logged in successfully", ToastLength.Long).Show();
                }
                else
                {
                    Toast.MakeText(this, "Oops!, Kindly try again.", ToastLength.Long).Show();
                }
            }catch(Exception e)
            {
                result = e.Message;
            }

         
        }

        private void InitializePreference()
        {
            appPreference.saveUserData("Adeshina and Nasiru");

        }

        private void retrieveSavedData()
        {
            /*
             * 
             *    bool mBooleanSaved = prefs.GetBoolean("One", false);
               var mBooleand = prefs.GetInt("Two",0);
               var savedString = "";
             */

            var result = appPreference.getUserData();
            var tt = "";

        }



    }


    public class LoginModel
    {
        public string phoneNumber { get; set; }
        public string password { get; set; }
    }

   
}
