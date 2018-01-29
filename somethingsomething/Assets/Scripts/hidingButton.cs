using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidingButton : MonoBehaviour {

    public GameObject thePlayer;
    public Player alice;
    public Animator CellaurDoorAnim;
    public Animator LabDoorAnim;
    public Animator StoreDoorAnim;
    public Animator BasementDoorAnim;
    public Animator UnlockedDoorAnim;


    // Update is called once per frame
    void Update () {       
       
	}

    public void OnButtonDown()
    {
        if (alice.hideSpot == true)
        {
            HidingScript hide = alice.HidingSpot.GetComponent<HidingScript>();
            hide.pressHide = true;
        }

        if (alice.nearLight)
        {
            alice.lantern.SetActive(true);
            alice.lightSource.SetActive(true);
            Destroy(alice.lantern);
        }

        if (alice.nearUnlockedDoor)
        {
            if (alice.unlockedDoorOpen == true)
            {
                UnlockedDoorAnim.SetBool("Open", true);
                UnlockedDoorAnim.gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
                UnlockedDoorAnim.gameObject.transform.GetChild(1).GetComponent<BoxCollider>().enabled = true;
                alice.unlockedDoorOpen = true;
            }
            else
            {
                UnlockedDoorAnim.SetBool("Open", false);
                UnlockedDoorAnim.gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
                UnlockedDoorAnim.gameObject.transform.GetChild(1).GetComponent<BoxCollider>().enabled = false;
                alice.unlockedDoorOpen = false;
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
            }
            else
            {
                CellaurDoorAnim.SetBool("Open", false);
                CellaurDoorAnim.gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
                CellaurDoorAnim.gameObject.transform.GetChild(1).GetComponent<BoxCollider>().enabled = false;
                alice.cellarDoorOpen = false;
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
            }
            else
            {
                LabDoorAnim.SetBool("Open", false);
                LabDoorAnim.gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
                LabDoorAnim.gameObject.transform.GetChild(1).GetComponent<BoxCollider>().enabled = false;
                alice.labDoorOpen = false;
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
            }
            else
            {
                StoreDoorAnim.SetBool("Open", false);
                StoreDoorAnim.gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
                StoreDoorAnim.gameObject.transform.GetChild(1).GetComponent<BoxCollider>().enabled = false;
                alice.storeDoorOpen = false;
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
            }else
            {
                BasementDoorAnim.SetBool("Open", false);
                BasementDoorAnim.gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
                BasementDoorAnim.gameObject.transform.GetChild(1).GetComponent<BoxCollider>().enabled = false;
                alice.basementDoorOpen = false;
            }

        }
    }
}
