using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3
{
    public static int e3hitpoint = 230;
    public static int e3attack = 10;
    public static int e3defense = 6;
    public static int e3resistance = 0;
    public static int e3magic = 37;
    public static float e3criticalrate = 0.05f; //0.05
    public static float e3evasion = 0.1f;
    public static int e3agility = 1;
    public static int e3expamount = 50;
    public static int fireballdamage = 25;
}

public class Enemy3Combat : MonoBehaviour {


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player1")
        {
            e3hitpoint -= e3takingdamage;
        }
    }

    public static int e3hitpoint;
    public static int e3Mana;
    public static int e3takingdamage;
    public static bool initializing;
    private float e3AIprobablity;
    public static int turnnumber;
    
    

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        e3AIprobablity = Random.Range(0f, 1f);

        if(e3AIprobablity <= 0.6f)
        {
            //60% that enemy3 will us magic attack
            gameObject.GetComponent<Animator>().SetBool("fireball", true);
        }

        if (Enemy3.e3defense > player1.player1attack)
        {
            e3takingdamage = 0;
        }
        else
        {
            e3takingdamage = player1.player1attack - Enemy3.e3defense;
        }

        switch (StartCombat.e3rank)
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

        if (StartCombat.combatstarted == true)
        {
            if (initializing == true)
            {
                //initailizing data from enemy1 parameters class, so the original data will not be affected
                //even if the enemy1 has been defeated
                //the reason why I didn't use xml database, is beacause xml data can be easily edited by players
                //if they know how to open xml file and edit data.
                e3hitpoint = Enemy3.e3hitpoint;
                e3Mana = Enemy3.e3magic;
            }
        }
    }

    IEnumerator initiliinge1data()
    {
        initializing = false;
        yield return new WaitForSeconds(0);
    }
}

