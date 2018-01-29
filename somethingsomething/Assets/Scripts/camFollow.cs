using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollow : MonoBehaviour {

    public Transform player;
    private Transform myTransform;
    private Vector3 offset;

    // Use this for initialization
    void Start () {
        myTransform = transform;
        offset = player.position + myTransform.position;
    }
	
	// Update is called once per frame
	void LateUpdate () {
        myTransform.position = player.position + offset;
    }
}
