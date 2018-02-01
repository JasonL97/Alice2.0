using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class navmesh_testing : MonoBehaviour
{
    public Graphic redOverlay;
    public float minRedDistance = 500;
    public float maxRedOpacity = 0.1f;

    public Transform player;
    public GameObject player1;
    public GameObject doggo;
    public Transform originalPos;

    // Use this for initialization
    void Start()
    {
        //if (player.GetComponent<Player>().isLabKey == false)
        //{
        //    doggo.SetActive(false);
        //}

    }
    // Update is called once per frame
    void Update()
    {

        NavMeshAgent agent = GetComponent<NavMeshAgent>();

        if (player.GetComponent<Player>().hideSpot == true)
        {

            agent.SetDestination(originalPos.position);
        }
        else
        {
            agent.SetDestination(player.position);
        }

        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= minRedDistance)
        {
            Color color = redOverlay.color;
            color.a = maxRedOpacity * (1 - distance / minRedDistance);
            redOverlay.color = color;
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("gameOverScreen");
        }
    }
}
