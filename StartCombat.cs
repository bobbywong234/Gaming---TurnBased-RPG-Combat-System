using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class StartCombat : MonoBehaviour {

    public static bool combatstarted;
    private Camera combatfocus;
    public int[] Agilities  =  new int [4];
    public static int playerrank;
    public static int e1rank;
    public static int e2rank;
    public static int e3rank;

    public static int turncalculator;
    
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if any enemy in "Scene1" has collide with player1, figth started
        if (SceneManager.GetActiveScene().name == "Scene1")
        {
            for (int i = 1; i < 9; i++)
            {
                if (collision.gameObject.name == "Enemy" + i)
                {
                    combatstarted = true;
                    //use array to collect each gameobject's agility
                    Agilities[0] = player1.player1agility;
                    Agilities[1] = Enemy1.e1agility;
                    Agilities[2] = BOSS.BOSSagility;
                    Agilities[3] = Enemy3.e3agility;
                    //end

                    //this mathmatic model to give an order that make sure gameobject take turn sequentially
                    // based on their agility.
                    for (int x = 0; x < 4; x++)
                    {
                        if (player1.player1agility - Agilities[x] < 0)
                        {
                            playerrank += 1;
                        }

                        if (Enemy1.e1agility - Agilities[x] < 0)
                        {
                            e1rank += 1;
                        }

                        if (BOSS.BOSSagility - Agilities[x] < 0)
                        {
                            e2rank += 1;
                        }

                        if (Enemy3.e3agility - Agilities[x] < 0)
                        {
                            e3rank += 1;
                        }
                    }
                    //end

                }

            }
        }
       
    }

    void Awake()
    {
        //combatfocus = GameObject.Find("CombatCamera").GetComponent<Camera>();
    }

    // Use this for initialization
    void Start () {

      
    }
	
	// Update is called once per frame
	void Update () {
        //Note: this is an empty child gameobject follow with player in scene1, or you can simply add this
        //script into you player movement script in the scene.
    
        if (turncalculator > 3) {turncalculator = 0; }
      

        if (combatstarted == true)
        {
            gameObject.GetComponent<Animator>().SetBool("Startcombat", true);
            combatfocus.cullingMask = -1;// go to the figting Scene
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("Startcombat", false);
            combatfocus.cullingMask = 0;
        }
	}
}
