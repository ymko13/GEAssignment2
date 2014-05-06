using UnityEngine;
using System.Collections;

public class myFlocking : MonoBehaviour
{
	private myFlockingController FlockController;
	public Vector3 Velocity;
	public Vector3 TargetPosition = Vector3.zero;
	public Vector3 ForwardVector;
	public float distance;
	public bool RequestNewPosition = true;
	// Use this for initialization
	void Start ()
	{
		FlockController = transform.parent.gameObject.GetComponent ("myFlockingController") as myFlockingController;
		Random.seed = (int)Random.value;
		StartCoroutine ("Steering");
	}

	IEnumerator Steering()
	{
		while (true) {
			if(FlockController.Flock && !RequestNewPosition && TargetPosition != Vector3.zero)
			{
				Vector3 curPos = gameObject.transform.position;
				distance = Vector3.Distance(TargetPosition, curPos);

				if(distance < FlockController.MinDistance)
				{
					RequestNewPosition = true;
				}

				Vector3 desiredDir = TargetPosition - gameObject.transform.position;
				desiredDir.Normalize ();
				Vector3 currentDir = gameObject.transform.forward;

				gameObject.transform.LookAt (desiredDir);//Vector3.Slerp(currentDir,desiredDir, 0.5f));

				Velocity = gameObject.transform.forward * (FlockController.MaxVelocity - FlockController.MinVelocity + 1) * Time.deltaTime;
				float magnitude = rigidbody.velocity.magnitude;
				
				if(magnitude < FlockController.MinVelocity)
					Velocity = Velocity.normalized * FlockController.MinVelocity;
				else if(magnitude > FlockController.MaxVelocity)
					Velocity = Velocity.normalized * FlockController.MaxVelocity;

				rigidbody.velocity = Velocity;
			}

			float wait = FlockController.GetFloatRange(0.14f, 0.2f);
			yield return new WaitForSeconds(wait);
				}
	}

	// Update is called once per frame
	void Update ()
	{

	}
}

