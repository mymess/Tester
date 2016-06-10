using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;

[ExecuteInEditMode]
public class LatitudeDegValidator : MonoBehaviour {

	public InputField latitudeDeg;

	public InputField latitudeMin;


	// Use this for initialization
	void Start () {
		latitudeDeg = GetComponent<InputField> ();
		latitudeMin = GetComponent<InputField> ();

		latitudeDeg.onValueChanged.AddListener (ValidateLatitudeDegrees);
		latitudeDeg.onValidateInput += ValidateDegrees;
	}
	
	// Update is called once per frame
	void Update () {
		int value;
		Int32.TryParse (latitudeDeg.text, out value);
		if (latitudeDeg.isFocused) {
			if (Input.GetKey (KeyCode.UpArrow)) {
				value++;		
			} else if (Input.GetKey (KeyCode.DownArrow)) {
				value--;
			} else if (Input.GetKey (KeyCode.Tab)) {
				Debug.Log ("TAB PRESSED");
				latitudeMin.Select ();
				latitudeMin.ActivateInputField ();
				latitudeMin.interactable = true;
			}
		}
		latitudeDeg.text = value.ToString();

	}

	public char ValidateDegrees(string text, int charIndex, char addedChar)
	{
		if (!Char.IsDigit (addedChar) && addedChar != '-') {
			return '\0';
		}
		string text2 = text.Insert (charIndex, addedChar.ToString ());

		Regex reg = new Regex ("^-?[0-9]{0,2}$");
		if (!reg.Match(text2).Success) {
			return '\0';
		}
		return addedChar;
	}


	public void ValidateLatitudeDegrees(string text){
		int value;

		if (Int32.TryParse (text, out value)) {			
			if (value > 90 || value <-90) {
				string sign = value<0? "-":"";
				latitudeDeg.text = sign + "90";//.Substring (0, value.ToString ().Length - 2);
				latitudeMin.text = "00";
			}
		} 
	}
}
