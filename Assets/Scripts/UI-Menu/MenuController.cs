using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class MenuController : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler {


	public Image timeImage;
	public Image locationImage;
	public Image settingsImage;
	public Image playImage;
	public Image pauseImage;

	private Image menuImage;


	private float initialAlpha = .5f;

	void Awake(){
		menuImage = GetComponent<Image> ();
		Hide ();
	}		

	public void Highlight(){
		Color color = menuImage.color;
		color.a = 1f;
		menuImage.color = color;
	}

	public void Reset(){
		Color color = menuImage.color;
		color.a = initialAlpha;
		menuImage.color = color;
	}


	public void Show(){
		Image[] images = GetComponentsInChildren<Image> ();

		foreach (Image current in images){
			Color color = current.color;
			color.a = initialAlpha;
			current.color = color;			
		}
		Color parentColor = menuImage.color;
		parentColor.a = 1;
		menuImage.color = parentColor;
	}

	public void Hide(){

		Image[] images = GetComponentsInChildren<Image> ();

		Color parentColor = menuImage.color;
		parentColor.a = 0;
		menuImage.color = parentColor;

		foreach (Image current in images){
			Color color = current.color;
			color.a = 0;
			current.color = color;			
		}

	}

	public void OnPointerEnter (PointerEventData eventData)
	{
		Show ();
	}

	public void OnPointerExit (PointerEventData eventData)
	{
		Hide ();
	}


	public void playPauseToggle(){
		playImage.gameObject.SetActive (!playImage.gameObject.activeSelf);
		pauseImage.gameObject.SetActive (!pauseImage.gameObject.activeSelf);
	}

	/*
	void OnMouseUp(){
		GameObject go = GetObjectUnderMouse ();
		if (go == null) {
			return;
		}
		Image img = go.GetComponent<Image> ();
		if (img != null) {
			if (img.Equals(timeImage)) {
				
			}
		}


	}


	GameObject GetObjectUnderMouse(){
		List<RaycastResult> results = RaycastMouse ();

		GameObject go = null;
		if (results != null && results.Count > 0) {
			foreach (RaycastResult r in results) {
				go = r.gameObject;
				Image img = go.GetComponent<Image> ();
				if (img != null) {
					break;
				}
			}
		}
		return go;
	}

	List<RaycastResult> RaycastMouse(){

		PointerEventData pointerData = new PointerEventData (EventSystem.current)
		{
			pointerId = -1,
		};

		pointerData.position = Input.mousePosition;

		List<RaycastResult> results = new List<RaycastResult>();
		EventSystem.current.RaycastAll(pointerData, results);



		return results;
	}

	*/

}
