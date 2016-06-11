using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ModalPanel : MonoBehaviour {


	public Image closeIcon;

	public GameObject modalPanelObject;

	private static ModalPanel modalPanel;




	public static ModalPanel Instance () {
		if (!modalPanel) {
			modalPanel = FindObjectOfType(typeof (ModalPanel)) as ModalPanel;
			if (!modalPanel)
				Debug.LogError ("There needs to be one active ModalPanel script on a GameObject in your scene.");
		}

		return modalPanel;
	}

	public void Close(){
		modalPanelObject.SetActive (false);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
