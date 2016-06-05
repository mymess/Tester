using UnityEngine;
using System.Collections;

public class Sinus : MonoBehaviour {
	public Color c1 = Color.yellow;
	public Color c2 = Color.red;
	public int lengthOfLineRenderer = 300;

	public int numLines = 60;

	void Start() {
		LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
		/*
		for(int i=0; i<numLines; i
		GameObject go = new GameObject ();
		go.transform.parent = gameObject.transform;
		*/
		lineRenderer.useWorldSpace = false;
		//lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		lineRenderer.SetColors(c1, c2);
		lineRenderer.SetWidth(0.4F, 0.04F);
		lineRenderer.SetVertexCount(lengthOfLineRenderer);
	}

	void Update() {
		LineRenderer lineRenderer = GetComponent<LineRenderer>();
		float t = Time.time;
		int i = 0;

		while (i < lengthOfLineRenderer) {
			Vector3 pos = new Vector3(i * .5F, 1.0f* Mathf.Sin(i+t), 0);
			lineRenderer.SetPosition(i, pos);
			i++;
		}
	}
}