using UnityEngine;

public class AdLocusListenerCallBack : AndroidJavaProxy {
	NativeInterface.RequestListener callback;
	public AdLocusListenerCallBack(NativeInterface.RequestListener call):base("com.test.callbacktest.IUnityCallback") {
		callback = call;
	}
	public virtual void onSuccess(string result) {
		if(callback != null) {
			callback(0, result);
		}
	}
	public virtual void onError(int errorcode, string msg) {
		if(callback != null) {
			callback(errorcode, msg);
		}
	}
}