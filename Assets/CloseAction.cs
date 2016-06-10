using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class CloseAction : MonoBehaviour {

	void Update(){
		if (Input.GetKey (KeyCode.Escape)) {
			gameObject.SetActive (false);
		}
	}


	public void Close(GameObject panel){
		panel.SetActive (false);
	}
}
