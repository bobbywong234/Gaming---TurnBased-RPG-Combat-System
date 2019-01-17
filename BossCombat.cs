using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS
{
    public static int BOSShitpoint = 1000;
    public static int BOSSattack = 57;
    public static int BOSSdefense = 39;
    public static int BOSSresistance = 35;
    public static int BOSSmagic = 0;
    public static float BOSScriticalrate = 0.05f; //0.05
    public static float BOSSevasion = 0.1f;
    public static int BOSSagility = 14;
    public static int BOSSexpamount = 300;
}

public class BossCombat : MonoBehaviour {

    public static int bosshitpoint;
    public static int bossmana;
    public static int bosstakingdamage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Enemy3.e3defense > player1.player1attack)
        {
            bosstakingdamage = 0;
        }
        else
        {
            bosstakingdamage = player1.player1attack - BOSS.BOSSdefense;
        }

        switch (StartCombat.e2rank)
        {
            case 0:
                if (StartCombat.turncalculator == 0)
                {
                    gameObject.GetComponent<Animator>().SetBool("attack", false);
                }
                break;
            case 1:
                if (StartCombat.turncalculator == 1)
                {
                    gameObject.GetComponent<Animator>().SetBool("attack", false);
                }
                break;
            case 2:
                if (StartCombat.turncalculator == 2)
                {
                    gameObject.GetComponent<Animator>().SetBool("attack", false);
                }
                break;
            case 3:
                if (StartCombat.turncalculator == 3)
                {
                    gameObject.GetComponent<Animator>().SetBool("attack", false);
                }
                break;
        }


    }
}
