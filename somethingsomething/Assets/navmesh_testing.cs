using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class navmesh_testing : MonoBehaviour {
    public Transform player;
    public GameObject player1;
    public GameObject doggo;
    public Transform originalPos;
    
    // Use this for initialization
    void Start()
    {
        if (player.GetComponent<Player>().isLabKey == false)
        {
            doggo.SetActive(false);
        }

    }
    // Update is called once per frame
    void Update () {
       
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
       
        if (player.GetComponent<Player>().hideSpot == true)
        {

            agent.SetDestination(originalPos.position);
            Debug.Log(originalPos.position);
        }
        agent.SetDestination(player.position);

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("gameOverScreen");
        }
    }
}
