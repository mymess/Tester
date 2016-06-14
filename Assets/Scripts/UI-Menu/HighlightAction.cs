using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


using System.Collections;

public class HighlightAction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	private Image image;

	private Image menuImage;

	private float initialAlpha = .5f;

	// Use this for initialization
	void Awake () {
		image = GetComponent<Image> ();
		menuImage = gameObject.GetComponentInParent<Image> ();
		Hide ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Hide(){
		Color c = image.color;
		c.a = 0f;
		image.color = c;
	}


	public void Highlight(){
		Color color = image.color;
		color.a = 1f;
		image.color = color;
	}

	public void Reset(){
		Color color = image.color;
		color.a = menuImage.color.a==0? 0 : initialAlpha;
		image.color = color;
	}
				
	public void OnPointerEnter (PointerEventData eventData)
	{
		Highlight ();
	}

	public void OnPointerExit (PointerEventData eventData)
	{
		Reset ();
	}
}
