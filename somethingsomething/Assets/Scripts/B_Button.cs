using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Button : MonoBehaviour {

    public GameObject player;
    public bool Boosting = false;
    public LayerMask myLayerMask;
    public float elaspedTime = 0;
    Stamina pls;
    Player pl; 
    // Use this for initialization
    void Start () {
        pls = player.GetComponent<Stamina>();
        pl = player.GetComponent<Player>();
    }

    // Update is called once per frame
    public void Update()
    {

        OnButtonDown();
       

        if (Boosting && pls.currentStamina > 0)
        {
            elaspedTime = 0;
            pl.moveSpeed = 150;
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

    public void OnButtonDown()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(this.gameObject.GetComponent<RectTransform>(), Input.GetTouch(0).deltaPosition, player.GetComponent<Player>().mainCamera.GetComponent<Camera>()))
            {
                Debug.Log("Testing");
                if (Input.GetButton("Fire1") && pls.currentStamina != 0)
                {
                    Boosting = true;
                }

                if (Input.GetButtonUp("Fire1"))
                {
                    Boosting = false;
                }
            }
        }
    }
}
