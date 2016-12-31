using UnityEngine;
using System;

public abstract class AndroidObjectMirror : IDisposable {
	
	private AndroidJavaObject _AJObject;
	
	protected AndroidJavaObject AJObject { 
		get {
			return _AJObject; 
		}
		private set{
			_AJObject = value;
		} 
	}

	public AndroidObjectMirror(AndroidJavaObject ajo){
	  _AJObject = ajo;
	  InitFromJava(ajo);
	}

	public virtual void Dispose() { _AJObject.Dispose(); }

	protected virtual void InitFromJava(AndroidJavaObject ajo) {}
}