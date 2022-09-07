
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.Content;
using androidcontrols.IInterface;
using AndroidX.RecyclerView.Widget;
using AndroidX.SwipeRefreshLayout.Widget;
using AndroidX.Fragment.App;
using AndroidX.AppCompat.App;
using Android.App;
using Android.OS;
using AlertDialog = AndroidX.AppCompat.App.AlertDialog;

namespace androidcontrols
{
    [Activity(Label = "BeneficairyActivity", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class BeneficairyActivity : AppCompatActivity, IBeneficiary
    {
        RecyclerView recyclerView;
        LinearLayoutManager mLayoutManager;
        BeneficairyAdapter adapter;
        SwipeRefreshLayout swipeRefresh;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            // Create your application here
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_beneficairy);
           
            swipeRefresh = FindViewById<SwipeRefreshLayout>(Resource.Id.parent_refresh);
            swipeRefresh.SetColorSchemeColors(Resource.Color.colorOne, Resource.Color.colorTwo, Resource.Color.colorThree);
            swipeRefresh.Refresh += RefreshLayout_Refresh;
           


        }


        private void RefreshLayout_Refresh(object sender, EventArgs e)
        {
           // Thread.Sleep(1000);
            swipeRefresh.Refreshing = false;
            passBeneficiary(null);
        }

        public List<BeneficairyModel> getBeneficiary()
        {
            List<BeneficairyModel> beneficairyModels = new List<BeneficairyModel>();
            beneficairyModels.Add(new BeneficairyModel() { acctNo = "0252122014", benName = "Olalekan Taiye", mPhotoID = Resource.Drawable.wema });
            beneficairyModels.Add(new BeneficairyModel() { acctNo = "0238712987", benName = "Adeshina Falade", mPhotoID = Resource.Drawable.wema });
            beneficairyModels.Add(new BeneficairyModel() { acctNo = "0873561098", benName = "Dada Odunayo", mPhotoID = Resource.Drawable.wema });
            beneficairyModels.Add(new BeneficairyModel() { acctNo = "782123982121", benName = "Nasiru Moses", mPhotoID = Resource.Drawable.wema });
            beneficairyModels.Add(new BeneficairyModel() { acctNo = "2163873810087", benName = "Moses Nasiru", mPhotoID = Resource.Drawable.wema });

            return beneficairyModels;
        }

        public void passBeneficiary(BeneficairyModel beneficairyModel)
        {
            //Toast.MakeText(this, $"Benficiary Name: {beneficairyModel.benName} \n Account No: {beneficairyModel.acctNo} ", ToastLength.Long).Show();
           // List<BeneficairyModel> post = getBeneficiaryUpdate();
            //adapter.UpdateData(post);


           // AlertDialogFragment alertDialog = new AlertDialogFragment();


            var dialogView = LayoutInflater.Inflate(Resource.Layout.alertdialog, null);
            AlertDialog alertDialog;
            using(var dialog = new AlertDialog.Builder(this))
            {
                dialog.SetView(dialogView);
                recyclerView = dialogView.FindViewById<RecyclerView>(Resource.Id.recyclerView_list);
                mLayoutManager = new LinearLayoutManager(this);
                recyclerView.SetLayoutManager(mLayoutManager);
                adapter = new BeneficairyAdapter(getBeneficiary(), this);
                recyclerView.SetAdapter(adapter);
                alertDialog = dialog.Create();
            }
            alertDialog.Show();
           // FragmentManager fragmentManager;
            //  FragmentTransaction transaction = FragmentManager.BeginTransaction();

            //     AndroidX.Fragment.App.FragmentManager fragmentManager = FragmentActivity.Su;
            //alertDialog.Show(this, "Beneficiary");
            /*
             *
             *Intent intent = new Intent();
            intent.PutExtra("BenNo", beneficairyModel.acctNo);
            intent.PutExtra("BenName", beneficairyModel.benName);
            SetResult(Result.Ok, intent);
            Finish();
             */

        }

        public List<BeneficairyModel> getBeneficiaryUpdate()
        {
            List<BeneficairyModel> beneficairyModels = new List<BeneficairyModel>();
            beneficairyModels.Add(new BeneficairyModel() { acctNo = "3023434121", benName = "AYinka Tokamg", mPhotoID = Resource.Drawable.wema });
            beneficairyModels.Add(new BeneficairyModel() { acctNo = "43874y871821", benName = "Benson Luqman", mPhotoID = Resource.Drawable.wema });
            beneficairyModels.Add(new BeneficairyModel() { acctNo = "83289903201", benName = "Bryte Ojulari", mPhotoID = Resource.Drawable.wema });

            return beneficairyModels;
        }


        public void deleteBeneficiary(BeneficairyModel beneficairy)
        {
            
        }
    }
}
