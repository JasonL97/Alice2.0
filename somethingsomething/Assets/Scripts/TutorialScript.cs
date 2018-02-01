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

    // Use this for initialization
    void Start()
    {
        tutorial_Canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorial_Canvas.activeSelf == true)
        {
            Time.timeScale = 0;
            if (Input.GetButtonDown("Fire1"))
            {
                if (tut1.gameObject.activeSelf == true)
                {
                    tut1.gameObject.SetActive(false);
                    tut2.gameObject.SetActive(true);
                }
                else if (tut2.gameObject.activeSelf == true)
                {
                    tut2.gameObject.SetActive(false);
                    tut3.gameObject.SetActive(true);
                }
                else if (tut3.gameObject.activeSelf == true)
                {
                    tut3.gameObject.SetActive(false);
                    tut4.gameObject.SetActive(true);
                }
                else if (tut4.gameObject.activeSelf == true)
                {
                    tut4.gameObject.SetActive(false);
                    tut5.gameObject.SetActive(true);
                }
                else if (tut5.gameObject.activeSelf == true)
                {
                    tut5.gameObject.SetActive(false);
                    tut6.gameObject.SetActive(true);
                }
                else if (tut6.gameObject.activeSelf == true)
                {
                    tut6.gameObject.SetActive(false);
                    Time.timeScale = 1;
                    tutorial_Canvas.SetActive(false);
                }
            }
        }
    }
}

   



