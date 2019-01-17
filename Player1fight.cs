using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1
{
    public static int player1hitpoint = 170;
    public static int player1attack = 48;
    public static int player1defense = 50;
    public static int player1resistance = 35;
    public static int player1magic = 0;
    public static float player1criticalrate = 0.05f; //0.05
    public static float player1evasion = 0.1f;
    public static int player1agility = 15;
}

public class Player1fight : MonoBehaviour {

    public static int playerhitpoint;
    public static int playermana;
    private GameObject attackoption;
    private GameObject skilloption;
    private GameObject runoption;
    private GameObject itemoption;
    public static bool enablefightingoption;
    private GameObject combatcursor;


    void Awake()
    {
        attackoption = GameObject.Find("attackoptioncard");
        skilloption = GameObject.Find("skilloptioncard");
        runoption = GameObject.Find("runoptioncard");
        itemoption = GameObject.Find("itemoptioncard");
        combatcursor = GameObject.Find("combatcursor");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(enablefightingoption == true)
        {
            attackoption.GetComponent<SpriteRenderer>().enabled = true;
            skilloption.GetComponent<SpriteRenderer>().enabled = true;
            runoption.GetComponent<SpriteRenderer>().enabled = true;
            itemoption.GetComponent<SpriteRenderer>().enabled = true;
            if (Input.GetKeyDown("w"))
            {
                combatcursor.transform.localPosition = runoption.transform.localPosition;
            }
            if (Input.GetKeyDown("s"))
            {
                combatcursor.transform.localPosition = attackoption.transform.localPosition;
            }
            if (Input.GetKeyDown("a"))
            {
                combatcursor.transform.localPosition = skilloption.transform.localPosition;
            }
            if (Input.GetKeyDown("d"))
            {
                combatcursor.transform.localPosition = itemoption.transform.localPosition;
            }
        }
        else
        {
            attackoption.GetComponent<SpriteRenderer>().enabled = false;
            skilloption.GetComponent<SpriteRenderer>().enabled = false;
            runoption.GetComponent<SpriteRenderer>().enabled = false;
            itemoption.GetComponent<SpriteRenderer>().enabled = false;
        }


        if(combatcursor.transform.localPosition == runoption.transform.localPosition)
        {
            if (Input.GetKeyDown("return"))
            {
                // do somethin for running away from combat
            }
        }
        //the same with attack,skills,item

        switch (StartCombat.playerrank)
        {
            case 0:
                if (StartCombat.turncalculator == 0)
                {
                    enablefightingoption = true;
                }
                else
                {
                    enablefightingoption = false;
                }
                break;
            case 1:
                if (StartCombat.turncalculator == 1)
                {
                    enablefightingoption = true;
                }
                else
                {
                    enablefightingoption = false;
                }
                break;
            case 2:
                if (StartCombat.turncalculator == 2)
                {
                    enablefightingoption = true;
                }
                else
                {
                    enablefightingoption = false;
                }
                break;
            case 3:
                if (StartCombat.turncalculator == 3)
                {
                    enablefightingoption = true;
                }
                else
                {
                    enablefightingoption = false;
                }
                break;
        }

    }
}
