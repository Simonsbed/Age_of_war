using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Team
{
    UNION = 1,
    ENEMY = -1,
    NONE = 0
}


public class GameSystem : MonoBehaviour
{
    [SerializeField]
    protected float Hp;

   

    public bool ReduceHp(float amount)
    {
		if (amount > Hp)
		{
            Hp = 0;
            return true;
		}

        if (Hp - amount > 0)
        {
            Hp -= amount;
            return true;
        }
        else
        {
            return false;
        }
        
        
        
    }
	/*public virtual void Init()
	 {

		 Hp = 0;
	 }*/

	private void OnEnable()
	{
        Hp = 0;
	}

}
