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

    public bool nearCellarDoor = false;
    public bool nearLabDoor = false;
    public bool nearStoreDoor = false;
    public bool nearBasementDoor = false;
    public bool nearUnlockedDoor = false;

    public GameObject CellaurDoor;
    public GameObject LabDoor;
    public GameObject StoreDoor;
    public GameObject BasementDoor;
    public GameObject UnlockedDoor;

    public Transform player;
    public GameObject player1;
    public GameObject doggo;
    public Transform originalPos;
    public NavMeshAgent agent;
    public NavMeshPath agentPath;
    public List<GameObject> WayPointList;
    public TutorialScript tutScript;
    float ViewDistance = 400;
    float EnemyNPlayerDistance;

    public AudioSource doggrowl;
    public AudioClip dogGrowl;
    // Use this for initialization
    void Start()
    {
        //if (player.GetComponent<Player>().isLabKey == false)
        //{
        //    doggo.SetActive(false);
        //}
        agentPath = new NavMeshPath();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDoorCol();

        agent = GetComponent<NavMeshAgent>();

        if (!tutScript.TeachHide && player1.GetComponent<Player>().Dog_Spawn_Past && !player1.GetComponent<Player>().FreezeMovement)
        {
            if (player.GetComponent<Player>().hideSpot == true)
            {
                if (!agent.hasPath)
                {
                    RandomWayPoint();
                }
            }
            else
            {
                //if (!agent.hasPath)
                //{
                //    RandomWayPoint();
                //}

                Vector3 targetDir = player.position - transform.position;
                float angleToPlayer = (Vector3.Angle(targetDir, transform.forward));
                EnemyNPlayerDistance = Vector3.Distance(transform.position, player.position);
                if (EnemyNPlayerDistance < 600 && angleToPlayer >= -45 && angleToPlayer <= 45)
                {
                    Debug.Log("Player in sight!");
                    doggrowl.clip = dogGrowl;
                    doggrowl.Play();
                    NavMesh.CalculatePath(this.transform.position, player.position, NavMesh.AllAreas, agentPath);
                    agent.SetPath(agentPath);
                }
                else
                {
                    if (!agent.hasPath)
                    {
                        RandomWayPoint();
                    }
                }
               // Debug.DrawRay(this.transform.position, this.transform.forward * ViewDistance, Color.red);
            }
        }

        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= minRedDistance)
        {
            Color color = redOverlay.color;
            color.a = maxRedOpacity * (1 - distance / minRedDistance);
            redOverlay.color = color;
        }

    }

    //void LateUpdate()
    //{
    //    if (player.GetComponent<Player>().hideSpot == true)
    //    {
    //        agent.SetDestination(originalPos.position);
    //    }
    //    else
    //    {
    //          RandomWayPoint();
    //    }
    //}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("gameOverScreen");
        }
    }

    void RandomWayPoint()
    {
        if (this.gameObject != null)
        {
            int RanNum = Random.Range(0, 7);
            Debug.Log("Num: " + RanNum);
            switch (RanNum)
            {
                case 0:
                    NavMesh.CalculatePath(this.transform.position, WayPointList[0].transform.position, NavMesh.AllAreas, agentPath);
                    agent.SetPath(agentPath);
                    break;

                case 1:
                    NavMesh.CalculatePath(this.transform.position, WayPointList[1].transform.position, NavMesh.AllAreas, agentPath);
                    agent.SetPath(agentPath);
                    break;

                case 2:
                    NavMesh.CalculatePath(this.transform.position, WayPointList[2].transform.position, NavMesh.AllAreas, agentPath);
                    agent.SetPath(agentPath);
                    break;

                case 3:
                    NavMesh.CalculatePath(this.transform.position, WayPointList[3].transform.position, NavMesh.AllAreas, agentPath);
                    agent.SetPath(agentPath);
                    break;

                case 4:
                    NavMesh.CalculatePath(this.transform.position, WayPointList[4].transform.position, NavMesh.AllAreas, agentPath);
                    agent.SetPath(agentPath);
                    break;

                case 5:
                    NavMesh.CalculatePath(this.transform.position, WayPointList[5].transform.position, NavMesh.AllAreas, agentPath);
                    agent.SetPath(agentPath);
                    break;

                case 6:
                    NavMesh.CalculatePath(this.transform.position, WayPointList[6].transform.position, NavMesh.AllAreas, agentPath);
                    agent.SetPath(agentPath);
                    break;
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        #region CheckDoor
        if (col.gameObject.tag == "cellarDoor")
        {
            nearCellarDoor = true;
        }
        if (col.gameObject.tag == "labDoor")
        {
            nearLabDoor = true;
        }
        if (col.gameObject.tag == "storeDoor")
        {
            nearStoreDoor = true;
        }
        if (col.gameObject.tag == "basementDoor")
        {
            nearBasementDoor = true;
        }
        if (col.gameObject.tag == "unlockedDoor")
        {
            nearUnlockedDoor = true;
        }
        #endregion
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "cellarDoor")
        {
            nearCellarDoor = false;
        }
        if (col.gameObject.tag == "labDoor")
        {
            nearLabDoor = false;
        }
        if (col.gameObject.tag == "storeDoor")
        {
            nearStoreDoor = false;
        }
        if (col.gameObject.tag == "basementDoor")
        {
            nearBasementDoor = false;
        }
        if (col.gameObject.tag == "unlockedDoor")
        {
            nearUnlockedDoor = false;
        }
    }

    void CheckDoorCol()
    {
        if (nearBasementDoor)
        {
            BasementDoor.GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            BasementDoor.GetComponent<BoxCollider>().enabled = true;
        }

        if (nearStoreDoor)
        {
            StoreDoor.GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            StoreDoor.GetComponent<BoxCollider>().enabled = true;
        }

        if (nearLabDoor)
        {
            LabDoor.GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            LabDoor.GetComponent<BoxCollider>().enabled = true;
        }

        if (nearCellarDoor)
        {
            CellaurDoor.GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            CellaurDoor.GetComponent<BoxCollider>().enabled = true;
        }

        if (nearUnlockedDoor)
        {
            UnlockedDoor.GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            UnlockedDoor.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
