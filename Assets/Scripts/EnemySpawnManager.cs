using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : SpawnManager
{
	public float wavetime = 2;
	void Setting(Bandit _target)
	{
		_target.team = this.team;
		_target.state = BanditState.RUN;
		if (this.team == Team.ENEMY)
		{	_target.gameObject.GetComponent<SpriteRenderer>().flipX = false;

		}

	}
	

	void AutoSpawn()
	{
		
		GameObject spawnObject =
		   Instantiate(prefabList[1], transform.position, Quaternion.identity);
		Setting(spawnObject.GetComponent<Bandit>());
	}

	void AutoSpawn(index) {
		GameObject spawnObject = Instantiate(prefabList[index], transform.position, Quaternion.identity);
		Setting(spawnObject.GetComponent<Bandit>());
	}

	private void Start()
	{
		Invoke("AutoSpawn", wavetime);
	}

	private void Update()
	{
	  // ���� �ʿ���//
	  
	}



}
