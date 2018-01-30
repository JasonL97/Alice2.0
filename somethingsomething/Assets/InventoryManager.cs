using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
    public List<GameObject> InventorySpace;
    public List<GameObject> InventoryItems;
    public Player alice;
	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {

        CheckInventory();
		
	}

    void CheckInventory()
    {
        Debug.Log("Test");
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

        if (alice.isBasementKey)
        {
            InventoryItems[4].SetActive(true);
            InventoryItems[4].transform.position = InventorySpace[4].transform.position;
        }
    }
}
