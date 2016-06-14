using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using System.Globalization;

public class LocationValidators : MonoBehaviour {



	private double latitude;

	private double longitude;

	public InputField latitudeDeg;

	public InputField latitudeMin;

	public InputField latitudeSec;

	public InputField longitudeDeg;

	public InputField longitudeMin;

	public InputField longitudeSec;

	public Text nsText;



	void Start () {
		latitudeDeg.onValueChanged.AddListener (ValidateLatitudeDegrees);
		latitudeDeg.onValidateInput += ValidateDegrees;
		latitudeMin.onValueChange.AddListener (ValideLatitudeMinutes);
		latitudeMin.onValidateInput += ValideMinutesSeconds;


		latitude  = 0;
		longitude = 0;
	}


	void Update () {
		int latDeg, latMin;
		Int32.TryParse (latitudeDeg.text, out latDeg);
		Int32.TryParse (latitudeMin.text, out latMin);
		if (latitudeDeg.isFocused) {
			if (Input.GetKey (KeyCode.UpArrow)) {
				latDeg++;		
			} else if (Input.GetKey (KeyCode.DownArrow)) {
				latDeg--;
			} else if (Input.GetKey (KeyCode.Tab)) {
				if (Input.GetKey (KeyCode.LeftShift)) {
					//latitudeDeg.Select ();
					//latitudeDeg.ActivateInputField ();
				} else {
					latitudeMin.Select ();
					latitudeMin.ActivateInputField ();
				}
			}
			latitude = (int)Mathf.Clamp (latDeg, -90.0f, 90.0f) + Mathf.Clamp (latMin, 0, 60f)/60f;

			UpdateNS ();


			latitudeDeg.text = Math.Abs(latDeg).ToString ();
		}






	}

	public char ValidateDegrees(string text, int charIndex, char addedChar)
	{
		if(addedChar =='-'){
			ToggleNsText ();
		}
		if (!Char.IsDigit (addedChar) || addedChar == '-') {
			return '\0';
		}
		string text2 = text.Insert (charIndex, addedChar.ToString ());

		Regex reg = new Regex ("^-?[0-9]{0,2}$");
		if (!reg.Match(text2).Success) {
			return '\0';
		}
		return addedChar;
	}


	public char ValideMinutesSeconds(string text, int charIndex, char addedChar){
		if (!Char.IsDigit (addedChar)) {
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

	public void ValideLatitudeMinutes(string text){
		int value;
		if (Int32.TryParse (text, out value)) {			
			if (value > 90 || value <-90) {
				string sign = value<0? "-":"";
				latitudeDeg.text = sign + "90";//.Substring (0, value.ToString ().Length - 2);
				latitudeMin.text = "00";
			}
		} 
	}


	string validateMinutesOrSeconds(int min){
		int valid;
		if (min >= 60 || min < 0) {
			valid = 0;
		}else {
			valid = min;
		}
		return valid.ToString("##");

	}

	private void UpdateNS(){
		nsText.text = latitude >= 0 ? "N" : "S";
	}

	private void ToggleNsText(){
		nsText.text = nsText.text.Equals ("N") ? "S" : "N";
	}

	private void UpdateLatitude(){
		int sign = nsText.text.Equals ("N") ? 1 : -1;
		double degrees, minutes, seconds = 0;
		Double.TryParse(latitudeDeg.text, out degrees);
		Double.TryParse(latitudeMin.text, out minutes);

		latitude = sign*( degrees + minutes/60d + seconds/3600d);

	}

	
	
}
