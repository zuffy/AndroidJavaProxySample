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
	public RxjavaDisposable callHello(RequestListener listener) {
		if(isAndroid){
			AndroidJavaObject helloDisposable = mMainInterfaceObject.Call<AndroidJavaObject>("hello", new AdLocusListenerCallBack(listener));
			return new RxjavaDisposable(helloDisposable);
		}

		return null;
	}
}
