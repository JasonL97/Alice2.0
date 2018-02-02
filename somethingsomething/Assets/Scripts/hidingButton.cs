using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hidingButton : MonoBehaviour {

    public GameObject thePlayer;
    public Player alice;
    public Animator CellaurDoorAnim;
    public Animator LabDoorAnim;
    public Animator StoreDoorAnim;
    public Animator BasementDoorAnim;
    public Animator UnlockedDoorAnim;
    public AudioSource musicPlayer;
    public AudioClip doorOpen;
    public AudioClip doorClose;


    // Update is called once per frame
    void Update () {       
       
	}

    public void OnButtonDown()
    {
        if (alice.hideSpot == true)
        {
            HidingScript hide = alice.HidingSpot.GetComponent<HidingScript>();
            hide.pressHide = true;
            alice.GetComponent<Player>().isHiding = true;
        }

        if (alice.nearLight && alice.lantern != null)
        {
            alice.lantern.SetActive(true);
            alice.lightSource.SetActive(true);
            Destroy(alice.lantern);
            alice.lantern = null;
        }

        if (alice.nearUnlockedDoor)
        {
            
            if (alice.unlockedDoorOpen == false)
            {
                UnlockedDoorAnim.SetBool("Open", true);
                UnlockedDoorAnim.gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
                UnlockedDoorAnim.gameObject.transform.GetChild(1).GetComponent<BoxCollider>().enabled = true;
                alice.unlockedDoorOpen = true;
                musicPlayer.clip = doorOpen;
                musicPlayer.Play();
            }
            else
            {
                UnlockedDoorAnim.SetBool("Open", false);
                UnlockedDoorAnim.gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
                UnlockedDoorAnim.gameObject.transform.GetChild(1).GetComponent<BoxCollider>().enabled = false;
                alice.unlockedDoorOpen = false;
                musicPlayer.clip = doorClose;
                musicPlayer.Play();
            }
        }

        if (alice.isCellarKey && alice.nearCellarDoor)
        {
            if (alice.cellarDoorOpen == false)
            {
                CellaurDoorAnim.SetBool("Open", true);
                CellaurDoorAnim.gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
                CellaurDoorAnim.gameObject.transform.GetChild(1).GetComponent<BoxCollider>().enabled = true;
                alice.cellarDoorOpen = true;
                musicPlayer.clip = doorOpen;
                musicPlayer.Play();

            }
            else
            {
                CellaurDoorAnim.SetBool("Open", false);
                CellaurDoorAnim.gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
                CellaurDoorAnim.gameObject.transform.GetChild(1).GetComponent<BoxCollider>().enabled = false;
                alice.cellarDoorOpen = false;
                musicPlayer.clip = doorClose;
                musicPlayer.Play();

            }
        }

        if (alice.isLabKey && alice.nearLabDoor)
        {
            if (alice.labDoorOpen == false)
            {
                LabDoorAnim.SetBool("Open", true);
                LabDoorAnim.gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
                LabDoorAnim.gameObject.transform.GetChild(1).GetComponent<BoxCollider>().enabled = true;
                alice.labDoorOpen = true;
                musicPlayer.clip = doorOpen;
                musicPlayer.Play();

            }
            else
            {
                LabDoorAnim.SetBool("Open", false);
                LabDoorAnim.gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
                LabDoorAnim.gameObject.transform.GetChild(1).GetComponent<BoxCollider>().enabled = false;
                alice.labDoorOpen = false;
                musicPlayer.clip = doorClose;
                musicPlayer.Play();

            }
        }

        if (alice.isStoreKey && alice.nearStoreDoor)
        {
            if (alice.storeDoorOpen == false)
            {
                StoreDoorAnim.SetBool("Open", true);
                StoreDoorAnim.gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
                StoreDoorAnim.gameObject.transform.GetChild(1).GetComponent<BoxCollider>().enabled = true;
                alice.storeDoorOpen = true;
                musicPlayer.clip = doorOpen;
                musicPlayer.Play();

            }
            else
            {
                StoreDoorAnim.SetBool("Open", false);
                StoreDoorAnim.gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
                StoreDoorAnim.gameObject.transform.GetChild(1).GetComponent<BoxCollider>().enabled = false;
                alice.storeDoorOpen = false;
                musicPlayer.clip = doorClose;
                musicPlayer.Play();

            }
        }

        if (alice.isBasementKey && alice.nearBasementDoor)
        {
            if (alice.basementDoorOpen == false)
            {
                BasementDoorAnim.SetBool("Open", true);
                BasementDoorAnim.gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
                BasementDoorAnim.gameObject.transform.GetChild(1).GetComponent<BoxCollider>().enabled = true;
                alice.basementDoorOpen = true;
                musicPlayer.clip = doorOpen;
                musicPlayer.Play();


            }
            else
            {
                BasementDoorAnim.SetBool("Open", false);
                BasementDoorAnim.gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
                BasementDoorAnim.gameObject.transform.GetChild(1).GetComponent<BoxCollider>().enabled = false;
                alice.basementDoorOpen = false;
                musicPlayer.clip = doorClose;
                musicPlayer.Play();

            }
            SceneManager.LoadScene("winScene");
        }
    }
}
