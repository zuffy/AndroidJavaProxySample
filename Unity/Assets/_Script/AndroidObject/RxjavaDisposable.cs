using UnityEngine;

public class RxjavaDisposable : AndroidObjectMirror {

	public RxjavaDisposable(AndroidJavaObject ajo) : base(ajo) {
		
	}

	public void dispose() {
		Debug.Log("C# dispose!");
		AJObject.Call("dispose");
		Dispose();
	}
}
