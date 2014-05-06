using UnityEngine;
using System.Collections;

public enum Team
{
	Borg,
	Federation,
	Romulan
}

public class GameEnt : MonoBehaviour
{
	public Team ObjectTeam;
	public int AttackPower = 10;
	public int AttackSpeed = 1;
	public int Health = 100;
	public Vector3 TargetDirection;
	public Vector3 Velocity;
	public bool IsAlive;
	// Use this for initialization
	void Start ()
	{
		IsAlive = true;
	}

	// Update is called once per frame
	void Update ()
	{
		if (IsAlive || Health != 0) {
		} else {
			//Fire up a death animation
			
		}
	}

	public int GetHealth()
	{
		return Health;
	}

	public void ApplyDamage(int damage)
	{
		if (Health > damage)
						Health -= damage;
				else {
						Health = 0;
						IsAlive = false;
				}
	}
}

