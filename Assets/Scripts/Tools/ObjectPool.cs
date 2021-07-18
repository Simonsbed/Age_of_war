using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public enum ObjectPoolPolicy
{
	EMPTYABLE,
	NOT_EMPTYABLE
}*/

public class ObjectPool : IObjectPool
{

	public Queue<GameObject> pool;
	private ObjectPoolPolicy policy;
	private GameObject poolCashe;

	/// <summary>
	/// ObjectPool을 초기화 합니다.
	/// </summary>
	/// <param name="_origin">오브젝트 풀링을 적용할 GameObject 원형입니다. Prefab을 적용을 추천드립니다.</param>
	/// <param name="_policy">오브젝트 풀의 관리 정책입니다.</param>
	public ObjectPool(GameObject _origin, ObjectPoolPolicy _policy)
	{
		pool = new Queue<GameObject>();
		policy = _policy;
		poolCashe = _origin;
	}
	/// <summary>
	/// ObjectPool을 초기화 합니다.
	/// </summary>
	/// <param name="_origin">오브젝트 풀링을 적용할 GameObject 원형입니다. Prefab을 적용을 추천드립니다.</param>
	/// <param name="_initSize">오브젝트 풀링할 풀의 사이즈입니다.</param>
	public ObjectPool(GameObject _origin, int _initSize)
	{
		pool = new Queue<GameObject>();
		for (int i = 0; i < _initSize; i++)
		{
			poolCashe = Object.Instantiate(_origin);
			pool.Enqueue(poolCashe);
			poolCashe.SetActive(false);
		}
	}

	public GameObject Pop()
	{
		if (pool.Count == 0)
		{
			if (policy == ObjectPoolPolicy.EMPTYABLE) return null; //풀이 비었으면 null뱉어
			else { }//Add();
		}
		return pool.Dequeue();

	}

	public void Add(GameObject o)
	{
		o.SetActive(false);
		pool.Enqueue(o);
	}

	public void Recycle(ref GameObject target )
	{
		pool.Enqueue(target);
		target.SendMessage("Init", SendMessageOptions.RequireReceiver);//오브젝트 초기화 함수 실행, 초기화 함수(Init)가 없으면 실행되지 않을 수 있음
		target.SetActive(false);
	}


}
