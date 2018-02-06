using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<GameObject> InventorySpace;
    public List<GameObject> InventoryItems;
    public Text DescriptionText;
    public Image ItemImage;
    public Player alice;
    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

        CheckInventory();
    }

    void CheckInventory()
    {

        if (alice.lightSource.activeSelf)
        {
            InventoryItems[0].SetActive(true);
            InventoryItems[0].transform.position = InventorySpace[0].transform.position;
        }

        if (alice.isCellarKey)
        {
            InventoryItems[1].SetActive(true);
            InventoryItems[1].transform.position = InventorySpace[1].transform.position;
        }

        if (alice.isLabKey)
        {
            Debug.Log("Test1");
            InventoryItems[2].SetActive(true);
            InventoryItems[2].transform.position = InventorySpace[2].transform.position;
        }

        if (alice.isStoreKey)
        {
            InventoryItems[3].SetActive(true);
            InventoryItems[3].transform.position = InventorySpace[3].transform.position;
        }
        if (alice.HaveNote)
        {
            InventoryItems[4].SetActive(true);
            InventoryItems[4].transform.position = InventorySpace[4].transform.position;
        }
        if (alice.isBasementKey)
        {
            InventoryItems[5].SetActive(true);
            InventoryItems[5].transform.position = InventorySpace[5].transform.position;
        }
    }

    public void Input_1stSpace()
    {
        if (alice.lightSource.activeSelf)
        {
            DescriptionText.gameObject.SetActive(true);
            ItemImage.gameObject.SetActive(true);
            DescriptionText.text = "A lantern I found. It helps to light up the way.";
            ItemImage.sprite = InventoryItems[0].GetComponent<Image>().sprite;
        }
    }

    public void Input_2ndSpace()
    {
        if (alice.isCellarKey)
        {
            DescriptionText.gameObject.SetActive(true);
            ItemImage.gameObject.SetActive(true);
            DescriptionText.text = "A key... I wonder where can I use it?";
            ItemImage.sprite = InventoryItems[2].GetComponent<Image>().sprite;
        }
    }

    public void Input_3rdSpace()
    {
        if (alice.isLabKey)
        {
            DescriptionText.gameObject.SetActive(true);
            ItemImage.gameObject.SetActive(true);
            DescriptionText.text = "This seems to be the key to a certain lab...?";
            ItemImage.sprite = InventoryItems[1].GetComponent<Image>().sprite;
        }
    }
    

    public void Input_4thSpace()
    {
        if (alice.isStoreKey)
        {
            DescriptionText.gameObject.SetActive(true);
            ItemImage.gameObject.SetActive(true);
            DescriptionText.text = "This key seems to unlock the Store room. I wonder whats in there?";
            ItemImage.sprite = InventoryItems[3].GetComponent<Image>().sprite;
        }
    }

    public void Input_5thSpace()
    {
        if (alice.HaveNote)
        {
            DescriptionText.gameObject.SetActive(true);
            ItemImage.gameObject.SetActive(true);
            DescriptionText.text = "A note left behind by the owner of this place...";
            ItemImage.sprite = InventoryItems[4].GetComponent<Image>().sprite;
        }
    }
    public void Input_6thSpace()
    {
        if (alice.isBasementKey)
        {
            DescriptionText.gameObject.SetActive(true);
            ItemImage.gameObject.SetActive(true);
            DescriptionText.text = "The key to the basement door. Now I can finally get out of here...!";
            ItemImage.sprite = InventoryItems[5].GetComponent<Image>().sprite;
        }
    }
}