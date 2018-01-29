using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Button : MonoBehaviour {

    public GameObject player;
    public bool Boosting = false;
    public float elaspedTime = 0;
    Stamina pls;
    Player pl; 
    // Use this for initialization
    void Start () {
        pls = player.GetComponent<Stamina>();
        pl = player.GetComponent<Player>();
    }
	
	// Update is called once per frame
	public void Update () {

        if (Boosting && pls.currentStamina > 0)
        {
            elaspedTime = 0;
            pls.currentStamina -= 20 * Time.deltaTime;
        }
        else
        {
            Boosting = false;
            pl.moveSpeed = 100;
            elaspedTime += Time.deltaTime;
            if (elaspedTime >= 3)
            {
                if (pls.currentStamina <= 100)
                {
                    pls.currentStamina += 10 * Time.deltaTime;
                }
            }
        }
        
        
	}

    void buttonPressed()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Boosting = true;
        }
        else
        {
            Boosting = false;
        }
    }

    public void OnButtonDown()
    {
        
        if (pls.currentStamina != 0)
        {
            if (Boosting == false)
            {
                Player pl = player.GetComponent<Player>();
                pl.moveSpeed = 150;
                Boosting = true;               
            }
            else if (Boosting == true)
            {
                Player pl = player.GetComponent<Player>();
                pl.moveSpeed = 100f;
                Boosting = false;
            }
        }      
    }
  
}
