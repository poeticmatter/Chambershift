using UnityEngine;
using System.Collections;

public class MovementManager : MonoBehaviour {

	public float moveTime;
	public float moveDelay;
	public float timeSinceLastMove;

	public static MovementManager inst;

	private MovingObject player = null;
	private float inverseMoveTime;

	void Awake () {
		inst = this;
		inverseMoveTime = 1f / moveTime;
	}

	void Update()
	{
		if (!GameManager.inst.IsGameRunning())
		{
			return;
		}
		if (player == null)
		{
			player = GameObject.FindGameObjectWithTag("Player").GetComponent<MovingObject>();
		}
		timeSinceLastMove += Time.deltaTime;
		if (timeSinceLastMove > moveDelay)
		{
			if (FallingObjects() || DoShift())
			{
				AudioManager.inst.PlayShift();
				timeSinceLastMove = 0;
			}
			MoveEnemies();
		}
	}

	private bool DoShift()
	{
		int h = (int)Input.GetAxisRaw("Horizontal");
		int v = (int)Input.GetAxisRaw("Vertical");
		if (h==0 && v==0)
		{
			return false;
		}
		if (h != 0) { v = 0; } //Can't move both at the same time;

		MovingObject [] movingObjects = FindObjectsOfType<MovingObject>();
		bool shifted = false;
		for (int i = 0; i < movingObjects.Length; i++)
		{
			if ((v!=0 && MatchesX(player, movingObjects[i])) || (h != 0 && MatchesY(player, movingObjects[i])))
			{
				movingObjects[i].Move(h, v, inverseMoveTime);
				shifted = true;
			}
		}
		return shifted;
	}

	private bool MatchesX(MovingObject a, MovingObject b)
	{
		return a.getRoundedX() == b.getRoundedX();
	}

	private bool MatchesY(MovingObject a, MovingObject b)
	{
		return a.getRoundedY() == b.getRoundedY();
	}

	private bool FallingObjects()
	{
		FallingObject[] fallingObjects = FindObjectsOfType<FallingObject>();
		bool falling = false;

		for (int i = 0; i < fallingObjects.Length; i++)
		{
			if (!fallingObjects[i].IsGrounded() && !fallingObjects[i].GetComponent<MovingObject>().moving)
			{
				fallingObjects[i].MovingObject.Move(0, -1, inverseMoveTime);
				falling = true;
			}		
		}

		return falling;
	}

	private void MoveEnemies()
	{
		EnemyMovement[] enemies = FindObjectsOfType<EnemyMovement>();
		for (int i = 0; i < enemies.Length; i++)
		{
			if (enemies[i].GetComponent<FallingObject>().IsGrounded() && !enemies[i].moving)
			{
				enemies[i].Advance(inverseMoveTime);
			}
		}
	}
	
}
