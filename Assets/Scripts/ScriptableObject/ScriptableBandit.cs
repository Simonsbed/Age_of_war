using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Bandit 형 오브젝트들의 초기값을 가지고 있습니다.
/// </summary>
[CreateAssetMenu(fileName ="ScriptableBandit",menuName ="ScriptableObject/Bandit")]
public class ScriptableBandit : ScriptableObject
{
	public float Hp = 1f;
	public float attack = 0f;
	public float runSpeed = 8f;
	public GameObject prefab;
}
