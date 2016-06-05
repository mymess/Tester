using UnityEngine;
using System.Collections;

public class LightOrbit : MonoBehaviour {

	public Light light1;
	public Light light2;

	public float scale = 2.0f;
	public float radius = 2.0f;
	public float y = .8f;

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		
		float x = radius * Mathf.Cos (Time.time * scale);
		float z = radius * Mathf.Sin (Time.time * scale);

		float x2 = radius * Mathf.Cos (Time.time * scale + Mathf.PI/2);
		float z2 = radius * Mathf.Sin (Time.time * scale + Mathf.PI/2);
		light1.transform.position = new Vector3 (x, y, z);
		light2.transform.position = new Vector3 (x2, y, z2);

		Vector3 target = Camera.main.transform.position;
		Vector3 rel1 = target - light1.transform.position ;
		Vector3 rel2 = target - light2.transform.position ;
		light1.transform.rotation = Quaternion.LookRotation (rel1);
		light2.transform.rotation = Quaternion.LookRotation (rel2);
	}
}
