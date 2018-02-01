using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Button : MonoBehaviour
{

    public GameObject player;
    public bool Boosting = false;
    public LayerMask myLayerMask;
    public float elaspedTime = 0;
    Stamina pls;
    Player pl;
    // Use this for initialization
    void Start()
    {
        pls = player.GetComponent<Stamina>();
        pl = player.GetComponent<Player>();
    }

    // Update is called once per frame
    public void Update()
    {

        

        bool sprinting = false;//Input.GetKey(KeyCode.LeftShift);
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (RectTransformUtility.RectangleContainsScreenPoint(
                    this.gameObject.GetComponent<RectTransform>(),
                    touch.position,
                    player.GetComponent<Player>().mainCamera.GetComponent<Camera>()))
                {
                    sprinting = true;
                }
            }
        }
        if (sprinting && pls.currentStamina > 0)
        {
            elaspedTime = 0;
            pl.moveSpeed = 400;
            pls.currentStamina -= 20 * Time.deltaTime;
        }
        else
        {
            pl.moveSpeed = 200;
            elaspedTime += Time.deltaTime;
            if (elaspedTime >= 3)
            {
                if (pls.currentStamina <= 100)
                {
                    pls.currentStamina += 10 * Time.deltaTime;
                }
            }
        }



        //if (Boosting && pls.currentStamina > 0)
        //{
        //    elaspedTime = 0;
        //    pl.moveSpeed = 300;
        //    pls.currentStamina -= 20 * Time.deltaTime;
        //}
        //else
        //{
        //    Boosting = false;
        //    pl.moveSpeed = 200;
        //    elaspedTime += Time.deltaTime;
        //    if (elaspedTime >= 3)
        //    {
        //        if (pls.currentStamina <= 100)
        //        {
        //            pls.currentStamina += 10 * Time.deltaTime;
        //        }
        //    }
        //}
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
