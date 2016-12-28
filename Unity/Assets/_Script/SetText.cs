using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetText : MonoBehaviour {
		
	// Use this for initialization
	void Start () {
		Text tex = gameObject.GetComponent<Text>();
		tex.text = "start\n";
		string s = NativeInterface.getInstance().callHello((int rtn, string result)=> {
			tex.text += "rtn:" + rtn + " result:" + result + "\n";
		});

		
		tex.text += s + "\n";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
