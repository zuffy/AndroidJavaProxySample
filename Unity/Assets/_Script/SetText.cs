using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetText : MonoBehaviour {
	
	RxjavaDisposable calling;
	Text tex;

	// Use this for initialization
	void Start () {
		tex = gameObject.GetComponent<Text>();
		tex.text = "start\n";
		calling = NativeInterface.getInstance().callHello((int rtn, string result)=> {
			tex.text += "rtn:" + rtn + " result:" + result + "\n";
		});

		StartCoroutine(wait());

	}

	private IEnumerator wait() {
		yield return new WaitForSeconds(2f);
		tex.text += "C# SetText set dispose!\n";
		Debug.Log("C# SetText set dispose!");
		calling.dispose();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
