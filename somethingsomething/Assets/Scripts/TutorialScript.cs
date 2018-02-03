using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{

    public GameObject tut1;
    public GameObject tut2;
    public GameObject tut3;
    public GameObject tut4;
    public GameObject tut5;
    public GameObject tut6;
    public GameObject tutorial_Canvas;
    public GameObject prolougueManager;
    public Player alice;
    public bool StartGame = false;
    public bool TeachInven = false;
    public bool TeachHide = false;
    public bool TeachSave = false;

    // Use this for initialization
    void Start()
    {
        tut1.gameObject.SetActive(true);
        tutorial_Canvas.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorial_Canvas.activeSelf == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (StartGame && tut1.gameObject.activeSelf == true)
                {
                    tut1.gameObject.SetActive(false);
                    tut2.gameObject.SetActive(true);
                    alice.FreezeMovement = true;
                }
                else if (StartGame && tut2.gameObject.activeSelf == true)
                {
                    StartGame = false;
                    tut2.gameObject.SetActive(false);
                    alice.FreezeMovement = false;
                }

                if (TeachInven && alice.TutBag)
                {
                    TeachInven = false;
                    alice.FreezeMovement = false;
                    tut3.gameObject.SetActive(false);
                }

                if (TeachHide && alice.TutHide)
                { 
                    TeachHide = false;
                    alice.SurpriseMark.SetActive(false);
                    alice.Dog_Spawn_Past = true;                   
                    tut4.gameObject.SetActive(false);
                    alice.FreezeMovement = false;
                }

                if (TeachSave && alice.TutSave)
                {
                    TeachSave = false;
                    alice.FreezeMovement = false;
                    tut5.gameObject.SetActive(false);
                }         
            }
        }
    }
}

   



