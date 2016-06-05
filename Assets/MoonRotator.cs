using UnityEngine;
using System.Collections;

public class MoonRotator : MonoBehaviour {

	public float radius = 1.5f;

	public float timeScale = 3.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float x = radius * Mathf.Cos (Time.time * timeScale);
		float z = radius * Mathf.Sin (Time.time * timeScale);
		transform.localPosition = new Vector3 (x, 0.0f, z);
	}
}
