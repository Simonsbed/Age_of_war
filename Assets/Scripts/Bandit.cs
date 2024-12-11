using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum BanditState
{
	ATTACK,
	IDLE,
	RUN,
	HURT,
	DEATH,
	NONE
}
public class Bandit : GameSystem
{
	public List<GameObject> FoundObject;
	public float attack;
	public float runSpeed = 8f;
	public float closeDistance = 5.0f;
	public float shortDis;
	public Team team = Team.NONE; 
	public Animator ani;
	private CapsuleCollider2D capsuleCollider2D;
	private Rigidbody2D rigidbody2D;
	private bool isAttacking = false;

	public BanditState state = BanditState.NONE;

// 
	IEnumerator StateCheck()
	{

		while (true)
		{
			
			switch (state)
			{
				case BanditState.ATTACK:
					Attack();
					break;
				case BanditState.IDLE:
					break;
				case BanditState.RUN:
					Run();
					break;
				case BanditState.HURT:
					Hurt();
					break;
				case BanditState.DEATH:
					Death();
					break;
				default:
					break;
					
			}
			yield return null;
		}
		

	}

	/*public override void Init()
	{
		attack = 0;
		runSpeed = 0;

	} */


	private void OnTriggerEnter2D(Collider2D collider)
	{
		Bandit bandit = collider.gameObject.GetComponent<Bandit>();
		if (bandit != null)
		{
			if (bandit.team != this.team && bandit.team != Team.NONE)
			{
				state = BanditState.ATTACK;
			}
		}

	}


	void Attack()
	{
		
		ani.SetTrigger("Hurt");
		Attack newAttack = new Attack();
		newAttack.Attack();
	}

	void Idle()
	{


	}


	void Run()
	{
		Vector2 movemont = transform.right * runSpeed * Time.deltaTime;
		movemont.x *= Convert.ToInt32(team);
		rigidbody2D.MovePosition(movemont + (Vector2)transform.position);

	}

	void Hurt()
	{



	}

	
	void Death()
	{


	}

	public Bandit DistanceCheck()
	{
		/* if (bandit)
		{
			Vector3 offset = bandit.transform.position - transform.position;
			float sqrLen = offset.sqrMagnitude;

			if (sqrLen < closeDistance * closeDistance )
			{
				Attack();
			}
		
		}
		*/
		FoundObject = new List<GameObject>(GameObject.FindGameObjectsWithTag("Bandit"));
		shortDis = float.MaxValue;

		int shortestindex = 0;

		for (int i = 0; i < FoundObject.Count; i++)
		{
			Bandit bandit = FoundObject[i].GetComponent<Bandit>();

			if (bandit.team != this.team && bandit.team != Team.NONE)
			{
					float Distance = Vector2.Distance(gameObject.transform.position, bandit.transform.position);
				if (Distance < shortDis)
				{
					// ���� �ִ� ���� ����Ѵ�.
					shortestindex = i;

					shortDis = Distance;
					
				}
			}
		}
		if (shortDis == float.MaxValue) return null;
		else return FoundObject[shortestindex].GetComponent<Bandit>();
		}

	private void Start()
	{
		capsuleCollider2D = GetComponent<CapsuleCollider2D>();
		rigidbody2D = GetComponent<Rigidbody2D>();
		StartCoroutine(nameof(StateCheck));
		ani = gameObject.GetComponent<Animator>();

		
	}
	// ���ٰ� ������ ������ �Ǵ� �� 
	void OnEnabled()
	{
		state = BanditState.RUN;
		attack = 0;
		runSpeed = 0;

	}



	private void Update()
	{
		
	}


}
