using UnityEngine;
using System.Collections;

public class Mov : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 Right = Vector3.Cross (gameObject.transform.forward.normalized, gameObject.transform.up.normalized);
		if (Input.GetKey (KeyCode.A))
			gameObject.transform.position += Right;
		if (Input.GetKey (KeyCode.D))
			gameObject.transform.position -= Right;
	}
}
