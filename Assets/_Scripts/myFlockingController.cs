using UnityEngine;
using System.Collections;

public class myFlockingController : MonoBehaviour
{
	public float MinVelocity = 0.5f;
	public float MaxVelocity = 2.0f;
	public float MinDistance = 1.0f;
	public float MaxDistance = 2.0f;
	public int FlockSize = 0;

	public GameObject rTarget;

	private GameObject [] allChildren;
	public bool Flock = false;

	// Use this for initialization
	void Start ()
	{
		Random.seed = 5161623;
		FlockSize = transform.childCount;
		allChildren = new GameObject[FlockSize];
		for (int i = 0; i < FlockSize; i++) {
			allChildren[i] = transform.GetChild(i).gameObject;
			(allChildren[i].GetComponent("AIStateMachine") as AIStateMachine).friendlyTarget = rTarget;
				}
	}

	// Update is called once per frame
	void Update ()
	{
		for (int i = 0; i < FlockSize; i++) {
			GameObject currentChild = allChildren[i];
			myFlocking f = (currentChild.GetComponent("myFlocking") as myFlocking);
			bool requestnewPos = f.RequestNewPosition;
			if(requestnewPos)
			{
				//Get a new position around the main object
				Vector3 newPos = new Vector3(-500,-500,-500);
				//Get local pos and transfer to world
				Vector3 randPos = GetSphere();
				randPos *= GetFloatRange(MinDistance,MaxDistance);
				newPos = rTarget.transform.position + randPos;
				f.TargetPosition = newPos;
				f.RequestNewPosition = false;
			}
			//Add main velocity, so the flock moves with the ship
			currentChild.rigidbody.velocity += rTarget.rigidbody.velocity;
				}
	}

	public GameObject[] GetAllChildren()
	{
		return allChildren;
	}
	
	public float GetFloat()
	{
		return Random.value;
	}

	public float GetFloatRange(float min, float max)
	{
		return Random.Range(min,max);
	}

	public Vector3 GetSphere()
	{
		return Random.insideUnitSphere;
	}
}

