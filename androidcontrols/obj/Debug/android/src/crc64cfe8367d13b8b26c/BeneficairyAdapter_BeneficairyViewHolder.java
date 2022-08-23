package crc64cfe8367d13b8b26c;


public class BeneficairyAdapter_BeneficairyViewHolder
	extends androidx.recyclerview.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("androidcontrols.BeneficairyAdapter+BeneficairyViewHolder, androidcontrols", BeneficairyAdapter_BeneficairyViewHolder.class, __md_methods);
	}


	public BeneficairyAdapter_BeneficairyViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == BeneficairyAdapter_BeneficairyViewHolder.class)
			mono.android.TypeManager.Activate ("androidcontrols.BeneficairyAdapter+BeneficairyViewHolder, androidcontrols", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
