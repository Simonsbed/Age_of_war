using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectPoolPolicy
{
	EMPTYABLE,
	NOT_EMPTYABLE
}
public interface IObjectPool
{
	public void Add(GameObject o);
	public GameObject Pop();
	public void Recycle(ref GameObject o);

}
