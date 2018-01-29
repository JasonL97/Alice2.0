using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HidingScript : MonoBehaviour {

    //public SkinnedMeshRenderer alice;
    public GameObject HideButton;
    public bool isHide = false;
    public bool pressHide = false;
    public Player alicePlayerScript;
    public Animator aliceAnim;
    public Camera mainCam;
    public Camera hideCam;

    public GameObject hideSpot1;
    public GameObject hideSpot2;
    public GameObject hideSpot3;
    public GameObject hideSpot4;

    public float timePassed = 0.0f;
    public float timeThreshold = 1.0f;

    // Use this for initialization
    void Start () {
        //alice = GetComponent<SkinnedMeshRenderer>();
        //alice.enabled = true;
        mainCam.enabled = true;
        hideCam.enabled = false;
    }

    // Update is called once per frame
    void Update () {
        Hide();
	}

    void Hide()
    {      
        if (isHide == false && pressHide == true && alicePlayerScript.isMoving == false)
        {           
            hidingButton HideScript = HideButton.GetComponent<hidingButton>();
            isHide = true;
            //alice.enabled = false;
            mainCam.enabled = false;
            hideCam.enabled = true;
            aliceAnim.SetBool("isHiding", true);
            pressHide = false;

        } else if(alicePlayerScript.isMoving == true)
        {
            isHide = false;
            //alice.enabled = true;
            hideCam.enabled = false;
            aliceAnim.SetBool("isHiding", false);
            mainCam.enabled = true;
        }
        
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            timePassed += Time.deltaTime;
            if(timePassed >= timeThreshold)
            {
                hideSpot1.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                timePassed = 0f;
            }
        }

        if (col.gameObject.tag == "Player")
        {
            timePassed += Time.deltaTime;
            if (timePassed >= timeThreshold)
            {
                hideSpot2.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                timePassed = 0f;
            }
        }

        if (col.gameObject.tag == "Player")
        {
            timePassed += Time.deltaTime;
            if (timePassed >= timeThreshold)
            {
                hideSpot3.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                timePassed = 0f;
            }
        }

        if (col.gameObject.tag == "Player")
        {
            timePassed += Time.deltaTime;
            if (timePassed >= timeThreshold)
            {
                hideSpot4.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                timePassed = 0f;
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            hideSpot1.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }

        if (col.gameObject.tag == "Player")
        {
            hideSpot2.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }

        if (col.gameObject.tag == "Player")
        {
            hideSpot3.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }

        if (col.gameObject.tag == "Player")
        {
            hideSpot4.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
