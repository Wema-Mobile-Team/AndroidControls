
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using androidcontrols.IInterface;
using AndroidX.RecyclerView.Widget;
using AndroidX.SwipeRefreshLayout.Widget;

namespace androidcontrols
{
    [Activity(Label = "BeneficairyActivity", Theme = "@style/AppTheme.NoActionBar")]
    public class BeneficairyActivity : Activity, IBeneficiary
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
            recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView_list);
            mLayoutManager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(mLayoutManager);
            adapter = new BeneficairyAdapter(getBeneficiary(),this);
            recyclerView.SetAdapter(adapter);
            swipeRefresh = FindViewById<SwipeRefreshLayout>(Resource.Id.parent_refresh);
            swipeRefresh.SetColorSchemeColors(Resource.Color.colorOne, Resource.Color.colorTwo, Resource.Color.colorThree);
            swipeRefresh.Refresh += RefreshLayout_Refresh;

        }


        private void RefreshLayout_Refresh(object sender, EventArgs e)
        {
            Thread.Sleep(1000);
            swipeRefresh.Refreshing = false;
        }

        public List<BeneficairyModel> getBeneficiary()
        {
            List<BeneficairyModel> beneficairyModels = new List<BeneficairyModel>();
            beneficairyModels.Add(new BeneficairyModel() { acctNo = "0252122014", benName = "Olalekan Taiye", mPhotoID = Resource.Drawable.wema });
            beneficairyModels.Add(new BeneficairyModel() { acctNo = "0238712987", benName = "Adeshina Falade", mPhotoID = Resource.Drawable.wema });
            beneficairyModels.Add(new BeneficairyModel() { acctNo = "0873561098", benName = "Dada Odunayo", mPhotoID = Resource.Drawable.wema });

            return beneficairyModels;
        }

        public void passBeneficiary(BeneficairyModel beneficairyModel)
        {
            Toast.MakeText(this, $"Benficiary Name: {beneficairyModel.benName} \n Account No: {beneficairyModel.acctNo} ", ToastLength.Long).Show();
            Intent intent = new Intent();
            intent.PutExtra("BenNo", beneficairyModel.acctNo);
            intent.PutExtra("BenName", beneficairyModel.benName);
            SetResult(Result.Ok, intent);
            Finish();

        }

        public void deleteBeneficiary(BeneficairyModel beneficairy)
        {
            
        }
    }
}
