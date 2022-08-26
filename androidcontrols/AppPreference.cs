using System;
using Android.Content;
using Android.Preferences;

namespace androidcontrols
{
    public class AppPreference
    {

        Context mContex;
        ISharedPreferences prefs;
        ISharedPreferencesEditor editor;

        private static string PREFERENCE_USER_KEY = "PREFERENCE_USER_KEY";

        public AppPreference(Context _context)
        {
            mContex = _context;
            prefs = PreferenceManager.GetDefaultSharedPreferences(mContex);
            editor = prefs.Edit();
        }

        public void saveUserData(string value)
        {
            editor.PutString(PREFERENCE_USER_KEY, value);
            editor.Commit();
        }


          public string getUserData()
         {
            return prefs.GetString(PREFERENCE_USER_KEY, "");
         }



    }
}
