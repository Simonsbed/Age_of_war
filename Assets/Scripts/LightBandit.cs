using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBandit : Bandit
{
    //Manager 만들 예정 
    public int level;
    public float maxExp;
    public float curExp;
    public int attLevel;
    public int hpLevel;
    public int speedLevel;
    public int speedLevel;
    public int coolDownLevel;
    public float getExpLevel;
    public int getGoldLevel;

    public void GetExp(float exp){
        curExp += exp;
        if (curExp >= maxExp) {
            LevelUp();
        }
        PlayerPrefs.SetFloat("MaxExp", maxExp);
        PlayerPrefs.SetFloat("CurExp", curExp);

        public void LevelUp(){
            level += 1;
            maxExp *= 2;
            curExp = 0;
            PlayerPrefs.SetInt("Level", level);
            PlayerPrefs.SetInt("MaxExp", maxExp);
            PlayerPrefs.SetInt("CurExp", curExp);
        }
    }
}
