using System;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using androidcontrols.IInterface;
using AndroidX.AppCompat.Widget;
using AndroidX.RecyclerView.Widget;

namespace androidcontrols
{
    public class BeneficairyAdapter : RecyclerView.Adapter
    {
         List<BeneficairyModel> beneficairies;
         IBeneficiary callback;
        public BeneficairyAdapter(List<BeneficairyModel> _beneficairies, IBeneficiary _callbacks)
        {
            beneficairies = _beneficairies; callback = _callbacks;
        }

        public override int ItemCount => beneficairies.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            BeneficairyViewHolder vh = holder as BeneficairyViewHolder;
            vh.txtAcctNo.Text = beneficairies[position].acctNo;
            vh.txtAccName.Text = beneficairies[position].benName;
            vh.image.SetImageResource(beneficairies[position].mPhotoID);
          
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.show_beneficiaries,parent,false);
            BeneficairyViewHolder viewHolder = new BeneficairyViewHolder(itemView, beneficairies,callback);
            return viewHolder;
        }


        public class BeneficairyViewHolder : RecyclerView.ViewHolder
        {
            public AppCompatImageView image { get; set; }
            public TextView txtAcctNo { get; set; }

            public TextView txtAccName { get; set; }

          
            public BeneficairyViewHolder(View view, List<BeneficairyModel> _beneficairies, IBeneficiary callbacks) :base(view)
            {
                image = view.FindViewById<AppCompatImageView>(Resource.Id.image_bene);
                txtAcctNo = view.FindViewById<TextView>(Resource.Id.txt_AcctNo);
                txtAccName = view.FindViewById<TextView>(Resource.Id.txt_AcctName);

                view.Click += delegate {
                    callbacks.passBeneficiary(_beneficairies[base.AdapterPosition]);
                };
            }

        }

    }
}
