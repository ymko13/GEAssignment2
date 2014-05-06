using UnityEngine;
using System.Collections;

public enum AiStates
{
	Idle, //Do nothing
	Follow, //Follow a point
	Attack, //Attack a target
	Assist, //Wander around a target, attacking it's targets
	Seek, //Find a target

	TotalStates
}

public class AIStateMachine : MonoBehaviour
{
	public AIState [] states;
	bool changing_state;
	public AiStates current_state;
	public GUIText text;

	public GameObject target;
	public GameObject friendlyTarget;

	public GameEnt entityStats;


	public bool AllowFollow;
	public bool AllowAttack;
	public bool AllowAssist;
	public bool AllowSeek;

	// Use this for initialization
	void Start ()
	{
		current_state = AiStates.Idle;
		changing_state = false;
		states = new AIState[(int)AiStates.TotalStates];
		states [(int)AiStates.Idle] = new StateIdle ();
		if (AllowFollow)
			states [(int)AiStates.Follow] = new StateFollow ();
		if (AllowAttack)
			states [(int)AiStates.Attack] = new StateAttack ();
		if (AllowAssist)
			states [(int)AiStates.Assist] = new StateAssist ();
		if (AllowSeek)
			states [(int)AiStates.Seek] = new StateSeek ();
		entityStats = gameObject.GetComponent ("GameEnt") as GameEnt;
	}

	// Update is called once per frame
	void Update ()
	{
		text.text = " " + states [(int)current_state].StateName () + " Health:" + entityStats.Health.ToString();
		if (current_state == AiStates.Idle) {
			SwitchState(AiStates.Follow);
				}
		states [(int)current_state].OnUpdate (this, Time.deltaTime);
	}

	public void SwitchState(AiStates newState)
	{
		if(!changing_state && current_state != newState)
		{
			changing_state = true;
			
			AIState currentState = states[(int)current_state];

			if(currentState != null)
			{
				currentState.OnExit(this);
			}
			
			current_state = newState;
			
			currentState = states[(int)current_state];
			
			if(currentState != null)
			{
				currentState.OnEnter(this);
			}
			changing_state = false;
		}
	}
}

public class AIState
{
	public virtual void OnEnter(AIStateMachine sm){}
	public virtual void OnUpdate(AIStateMachine sm, float timeDelta){}
	public virtual void OnExit(AIStateMachine sm){}
	public virtual string StateName() { return "State:BaseClass"; } 
}

public class StateIdle : AIState
{
	public override void OnEnter(AIStateMachine sm)
	{

	}
	public override void OnUpdate(AIStateMachine sm, float timeDelta)
	{

	}
	public override void OnExit(AIStateMachine sm)
	{

	}

	public override string StateName() { return "State:Idle"; }  
}

public class StateFollow : AIState
{
	myFlockingController f;
	public override void OnEnter(AIStateMachine sm)
	{
		f = sm.transform.parent.gameObject.GetComponent("myFlockingController") as myFlockingController;
		f.Flock = true;
	}
	public override void OnUpdate(AIStateMachine sm, float timeDelta)
	{
		//sm.gameObject.transform.Rotate (new Vector3 (0, 0, 0));
	}
	public override void OnExit(AIStateMachine sm)
	{
		f.Flock = false;
	}
	
	public override string StateName() { return "State:Follow"; }  
}

public class StateAttack : AIState
{
	public override void OnEnter(AIStateMachine sm)
	{

	}
	public override void OnUpdate(AIStateMachine sm, float timeDelta)
	{
		
	}
	public override void OnExit(AIStateMachine sm)
	{
		
	}
	
	public override string StateName() { return "State:Attack"; }  
}

public class StateAssist : AIState
{
	public override void OnEnter(AIStateMachine sm)
	{

	}
	public override void OnUpdate(AIStateMachine sm, float timeDelta)
	{
		
	}
	public override void OnExit(AIStateMachine sm)
	{
		
	}
	
	public override string StateName() { return "State:Assist"; }  
}

public class StateSeek : AIState
{
	public override void OnEnter(AIStateMachine sm)
	{

	}
	public override void OnUpdate(AIStateMachine sm, float timeDelta)
	{
		
	}
	public override void OnExit(AIStateMachine sm)
	{
		
	}
	
	public override string StateName() { return "State:Seek"; }  
}
