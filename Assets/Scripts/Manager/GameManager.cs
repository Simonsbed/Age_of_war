using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

public class GameManager : MonoBehaviour
{
    public float money;
    public float exp;

    public const float MAX_MONEY = float.MaxValue;
    public const float MAX_EXP = float.MaxValue;

    public static GameManager instance;//싱글톤 디자인 패턴 적용을 위한 설정
    //public ObjectPool objectPool = new ObjectPool()

    private void Awake()
    {
        Singleton.SetPattern(ref instance, this, gameObject, false);
    }
    


    /// <summary>
    /// 특정 값을 뺄 때 사용합니다. 성공, 실패여부를 확인 할 수 있습니다.
    /// </summary>
    /// <param name="data">값을 뺄 대상</param>
    /// <param name="amount">얼마만큼 값을 뺄 건지 설정</param>
    /// <returns>true => 성공, false => 실패</returns>
    public bool Consume(ref float data, float amount)
	{
        if (data - amount < 0) //돈이 부곡할 경우
        {
            return false;
        }
        else
        {
            data -= amount;
            return true;
        }
	}
    /// <summary>
    /// 특정 값을 더할 때 사용합니다. 성공, 실패여부를 확인 할 수 있습니다.
    /// </summary>
    /// <param name="data">값을 더할 대상</param>
    /// <param name="amount">얼마만큼 값을 더할 건지 설정</param>
    /// <returns>성공, 실패 여부</returns>
    public bool Rise(ref float data, float amount, float MAX_VALUE)
	{

		if (float.IsInfinity(data+amount) || data+amount > MAX_VALUE)
		{
            return false;
		}
		else
		{
            data += amount;
            return true;
		}
	}
}
