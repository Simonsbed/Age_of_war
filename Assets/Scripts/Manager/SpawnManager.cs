using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public List<GameObject> prefabList;
    public GameObject HeavyBanditPrefab;
    public GameObject LightBanditPrefab;

	public Team team = Team.NONE;

	void Setting( Bandit _target)
	{
		_target.team = this.team;
		_target.state = BanditState.RUN;
		if (this.team == Team.ENEMY )
		{
			_target.gameObject.GetComponent<SpriteRenderer>().flipX = false;
		}

	}

	public void Spawn()
	{
		GameObject spawnObject =
		   Instantiate(prefabList[0] , transform.position, Quaternion.identity);
		/*GameObject LightBandit =
		   Instantiate(LightBanditPrefab, transform.position, Quaternion.identity);
		GameObject EnemyHeavyBandit =
		   Instantiate(HeavyBanditPrefab, transform.position, Quaternion.identity);
		GameObject EnemyLightBandit =
		   Instantiate(LightBanditPrefab, transform.position, Quaternion.identity);*/
		
		Setting( spawnObject.GetComponent<Bandit>());

	}

	public void Spawn(int _id)
	{
		GameObject spawnObject =
		   Instantiate(prefabList[_id], transform.position, Quaternion.identity);
		Setting(spawnObject.GetComponent<Bandit>());
	}

	private void Start()
	{
		
		
	}

	// Update is called once per frame
	void Update()
    {
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			Spawn();
		}
    }
}
