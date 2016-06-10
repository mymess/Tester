using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using System.Collections;

public class TimeLocationSettings : MonoBehaviour{
	//, IPointerDownHandler, IDragHandler {


	private Rect windowRect;// = new Rect(20, 20, 120, 50);
	private Vector2 pointerOffset;
	private RectTransform canvasRectTransform;
	private RectTransform panelRectTransform;


	public void Show(){
		gameObject.SetActive (true);
	}


	public void Close(){
		gameObject.SetActive(false);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Escape)){
			Close();
		}		
	}

	/*
	void Awake () {
		Canvas canvas = GetComponentInParent <Canvas>();
		if (canvas != null) {
			canvasRectTransform = canvas.transform as RectTransform;
			panelRectTransform = transform.parent as RectTransform;
		} else {
			Debug.Log ("canvas null");
		}
	}



	public void OnPointerDown (PointerEventData data) {
		panelRectTransform.SetAsLastSibling ();
		RectTransformUtility.ScreenPointToLocalPointInRectangle (panelRectTransform, data.position, data.pressEventCamera, out pointerOffset);
	}

	public void OnDrag (PointerEventData data) {
		if (panelRectTransform == null)
			return;

		Vector2 pointerPostion = ClampToWindow (data);

		Vector2 localPointerPosition;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (
			canvasRectTransform, pointerPostion, data.pressEventCamera, out localPointerPosition
		)) {
			panelRectTransform.localPosition = localPointerPosition - pointerOffset;
		}
	}

	Vector2 ClampToWindow (PointerEventData data) {
		Vector2 rawPointerPosition = data.position;

		Vector3[] canvasCorners = new Vector3[4];
		canvasRectTransform.GetWorldCorners (canvasCorners);

		float clampedX = Mathf.Clamp (rawPointerPosition.x, canvasCorners[0].x, canvasCorners[2].x);
		float clampedY = Mathf.Clamp (rawPointerPosition.y, canvasCorners[0].y, canvasCorners[2].y);

		Vector2 newPointerPosition = new Vector2 (clampedX, clampedY);
		return newPointerPosition;
	}
	*/
}
