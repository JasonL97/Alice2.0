using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour {

    private Animator anim;
    private Player alice;

    public bool isCellarOpen = false;
    public bool isLabOpen = false;
    public bool isStoreOpen = false;
    public bool isBasementOpen = false;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (isCellarOpen == true && alice.isCellarKey)
        {

        }
	}

}
