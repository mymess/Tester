using UnityEngine;
using System.Collections;

public class DialogFader : MonoBehaviour {

	private CanvasRenderer renderer;


	// Use this for initialization
	void Start () {
		renderer = GetComponent<CanvasRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter() {
		Debug.Log ("Enter");

	}

	public void OnMouseOver(){
		float red = renderer.GetMaterial ().color.r;
		float green = renderer.GetMaterial ().color.g;
		float blue = renderer.GetMaterial ().color.b;
		renderer.GetMaterial ().color += new Color(red, green, blue, .1f) * Time.deltaTime;

		Debug.Log ("Over");
	}

	public void OnMouseExit(){
		float red = renderer.GetMaterial ().color.r;
		float green = renderer.GetMaterial ().color.g;
		float blue = renderer.GetMaterial ().color.b;
		renderer.GetMaterial ().color -= new Color(red, green, blue, .1f) * Time.deltaTime;
		Debug.Log ("Exit");
	}

	/*
	public void SetAlpha () {
		if (fadeAlpha != null) {
			StopCoroutine (fadeAlpha);
		}
		fadeAlpha = FadeAlpha ();
		StartCoroutine (fadeAlpha);
	}


	IEnumerator FadeAlpha () {
		Color resetColor = dialog.color;
		resetColor.a = 1;
		displayText.color = resetColor;

		yield return new WaitForSeconds (displayTime);

		while (displayText.color.a > 0) {
			Color displayColor = displayText.color;
			displayColor.a -= Time.deltaTime / fadeTime;
			displayText.color = displayColor;
			yield return null;
		}
		yield return null;
	}
	*/

}
