using UnityEngine;
using System.Collections;

public class NativeInterface {

	public const string TAG = "NativeInterface";

	private static AndroidJavaObject 			mMainInterfaceObject;
	private static NativeInterface 				_instance;

    static bool isAndroid = Application.platform == RuntimePlatform.Android;

	public static NativeInterface getInstance() {
		if(_instance == null) {
			_instance 				 = new NativeInterface();

			if (isAndroid) {
				AndroidJavaClass Class = new AndroidJavaClass("com.test.callbacktest.UnityInterfaceManager");
            	mMainInterfaceObject = Class.CallStatic<AndroidJavaObject>("getInstance");
	        }
			
		}
		return _instance;
	}

	public delegate void RequestListener(int rtn, string result);
	public string callHello(RequestListener listener) {
		string ssss = "hello default";
		if(isAndroid){
			ssss = mMainInterfaceObject.Call<string>("hello", new AdLocusListenerCallBack(listener));
		}

		return ssss;
	}


	public class AdLocusListenerCallBack : AndroidJavaProxy {
		RequestListener callback;
		public AdLocusListenerCallBack(RequestListener call):base("com.test.callbacktest.IUnityCallback") {
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

}
