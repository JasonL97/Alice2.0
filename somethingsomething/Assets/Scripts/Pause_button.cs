using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_button : MonoBehaviour {
    public GameObject pauseCanvas;
    public GameObject InventoryPanel;
    public GameObject pauseButton;
    public GameObject backButton;
    public Player alice;
    public bool isTrue = true;
    private float savedTimeScale;

    // Use this for initialization
    void Start () {
        savedTimeScale = Time.timeScale;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenInventory()
    {
        //if (alice.FreezeMovement)
        //{
        //    pauseCanvas.SetActive(false);
        //    InventoryPanel.SetActive(false);         
        //    alice.FreezeMovement = false;
        //}
        //else
        //{
        //    alice.FreezeMovement = true;
        //}

        pauseCanvas.SetActive(true);

        if (alice.HaveBag)
        {
            InventoryPanel.SetActive(true);
            pauseButton.SetActive(false);
            isTrue = false;
        }
        else
        {
            alice.TextBoxBG.SetActive(true);
            alice.SystemText.gameObject.SetActive(true);
            alice.CharName.SetActive(false);
            alice.ChatText.gameObject.SetActive(false);
            alice.SystemText.text = "No Bag";           
        }

        
     
    }

    public void closeInventory()
    {
        pauseCanvas.SetActive(false);

        if (alice.HaveBag)
        {
            InventoryPanel.SetActive(false);
            pauseButton.SetActive(true);
        }

        isTrue = true;
        alice.FreezeMovement = false;
    }
}
