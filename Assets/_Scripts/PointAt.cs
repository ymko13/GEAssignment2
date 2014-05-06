using UnityEngine;
using System.Collections;

public class PointAt : MonoBehaviour {
	GameObject lookAt;
	// Use this for initialization
	void Start () {
		lookAt = GameObject.FindGameObjectWithTag ("EARTH");
	}
	
	// Update is called once per frame
	void Update () {
		if (lookAt != null) {
						gameObject.transform.LookAt (lookAt.transform.position);
				}
	}
}
