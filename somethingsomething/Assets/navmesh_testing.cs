using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navmesh_testing : MonoBehaviour {
    public Transform player;
    // Use this for initialization
    void Start()
    {
        
    }
	// Update is called once per frame
	void Update () {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = player.position;
        
    }
}
