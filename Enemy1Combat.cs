using System.Collections;
using UnityEngine;



public class Enemy1
{
    public static int e1hitpoint = 200;
    public static int e1attack = 27;
    public static int e1defense = 6;
    public static int e1resistance = 0;
    public static int e1magic = 0;
    public static float e1criticalrate = 0.05f; //0.05
    public static float e1evasion = 0.1f;
    public static int e1agility = 6;
    public static int e1expamount = 50;
}

public class Enemy1Combat : MonoBehaviour
{
    public static int e1hitpoint;
    public static int e1Mana;
    public static bool initializing;
    public static int e1takingdamage;
    


    private void OnCollisionEnter2D(Collision2D collision)
    {
      if(collision.gameObject.name == "player1")
        {
            e1hitpoint -= e1takingdamage;
            StartCombat.turncalculator += 1;
        }
    }

    void Awake()
    {
       
    }

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      if(Enemy1.e1defense > player1.player1attack)
        {
            e1takingdamage = 0;
        }
        else
        {
            e1takingdamage = player1.player1attack - Enemy1.e1defense;
        }

      

      if(StartCombat.combatstarted == true)
        {
            if(initializing == true)
            {
                //initailizing data from enemy1 parameters class, so the original data will not be affected
                //even if the enemy1 has been defeated
                //the reason why I didn't use xml database, is beacause xml data can be easily edited by players
                //if they know how to open xml file and edit data.
                e1hitpoint = Enemy1.e1hitpoint;
                e1Mana = Enemy1.e1magic;
            }
      }

      //from case 0 to 3 it will tell this gameobject's action priority
      //the turncalculator will addup by 1 if any collision happen between the gameobjects
      //so gameobject will start action if previous gameobject finish their turns
      //and stoped its action if it finised its action
      switch (StartCombat.e1rank) // combat order based the rank model once the monster in the scene collided with player
        {
            case 0:
                if(StartCombat.turncalculator == 0 ) // starting value
                {
                    gameObject.GetComponent<Animator>().SetBool("attack", false);
                }
                break;
            case 1:
                // if other gameobject take the firstturn, 
                //then turncalculator variables will add up to 1 in this scenerio, 
                //so from 0 to 1 enemy1 will not do anything 
                //because its action prioirties is 1 in this case
                if (StartCombat.turncalculator == 1) 
                {
                    gameObject.GetComponent<Animator>().SetBool("attack", false);
                }
                break;
            case 2:
                //same with the case1
                if (StartCombat.turncalculator == 2)
                {
                    gameObject.GetComponent<Animator>().SetBool("attack", false);
                }
                break;
            case 3:
                //same with the case1
                if (StartCombat.turncalculator == 3)
                {
                    gameObject.GetComponent<Animator>().SetBool("attack", false);
                }
                break;
        }

    }

    IEnumerator initiliinge1data()
    {
        initializing = false;
        yield return new WaitForSeconds(0);
    }
}
