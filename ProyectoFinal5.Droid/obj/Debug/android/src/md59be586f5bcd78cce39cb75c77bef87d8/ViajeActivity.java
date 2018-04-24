package md59be586f5bcd78cce39cb75c77bef87d8;


public class ViajeActivity
	extends android.support.v7.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("ProyectoFinal5.Droid.ViajeActivity, ProyectoFinal5.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ViajeActivity.class, __md_methods);
	}


	public ViajeActivity ()
	{
		super ();
		if (getClass () == ViajeActivity.class)
			mono.android.TypeManager.Activate ("ProyectoFinal5.Droid.ViajeActivity, ProyectoFinal5.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
