using UnityEngine;
using System.Collections;

public class PathFollowing : MonoBehaviour {
	Vector3 toPos;
	// Use this for initialization
	void Start () {
		toPos = new Vector3 (Random.Range (5f, 20f), Random.Range (5f, 20f), Random.Range (5f, 20f));
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (gameObject.transform.position, toPos) > 1) {
						gameObject.transform.LookAt (toPos);
						gameObject.transform.position += gameObject.transform.forward * 0.1f;
				}
	}
}
