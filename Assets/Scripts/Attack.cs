using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  enum AttackType
{
    NONE,
    NORMAL,
    SKILL
}


public class Attack
{
    
    AttackType attackType = AttackType.NORMAL;
    public float damage = 0;
    //public float attack;

    public  Attack()
    {
        damage = 0;
        attackType = AttackType.NONE;
     
    }


    public Attack(float _damage)
    {
        damage = _damage;
        attackType = AttackType.NORMAL;
            
    }

    public Attack(AttackType type, float _damage)
	{
        damage = _damage;
        attackType = type;
	}

}
