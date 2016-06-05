using UnityEngine;

using System.Collections;

public class Rotation : MonoBehaviour {

	public float translationScale = 1f;
	public float rotationScale = 10f;

	public float radius = 10f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (
			0, 
			Time.deltaTime* rotationScale
			, 0));
		float x = radius * Mathf.Cos (Time.time*translationScale );
		float y = radius * Mathf.Sin (Time.time*translationScale);
		transform.position = new Vector3 (x, 0, y);
		
	}
}
