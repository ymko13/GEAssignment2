using UnityEngine;
using System.Collections;

public class EarthRotation : MonoBehaviour {

	GameObject clouds;
	GameObject atmos;
	Vector3 normalScale = new Vector3(0,0,0);
	Vector3 changeFactor = new Vector3(0,0,0);
	int ticks = 0;
	// Use this for initialization
	void Start () {
		clouds = GameObject.FindGameObjectWithTag ("EARTH_CLOUD");
		atmos = GameObject.FindGameObjectWithTag ("EARTH_CLOUD1");
	}
	
	// Update is called once per frame
	void Update () {
		if (normalScale == Vector3.zero) {
			normalScale = gameObject.transform.localScale;
			changeFactor = normalScale / 400;
				}
		//gameObject.transform.Rotate (new Vector3 (0, 0.03f, 0.02f));

		gameObject.transform.RotateAround (Vector3.zero, (new Vector3 (3, 20, 10)).normalized, 1 * Time.deltaTime);
		clouds.transform.RotateAround (Vector3.zero, (new Vector3 (3, 10, 20)).normalized, -0.5f * Time.deltaTime);
		atmos.transform.RotateAround (Vector3.zero, (new Vector3 (20, 3, 10)).normalized, 0.5f * Time.deltaTime);

		if (ticks > 250)
			gameObject.transform.localScale = gameObject.transform.localScale + changeFactor * Time.deltaTime;
		else if (ticks == 0)
			ticks = 500;
		else
			gameObject.transform.localScale = gameObject.transform.localScale - changeFactor * Time.deltaTime;

		ticks--;
		//ticks++;
	}
}
