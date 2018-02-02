using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 15.0f;
    public float drag = 0.5f;
    public float terminalRotationSpeed = 25.0f;
    public Vector3 MoveVector { set; get; }
    public VirtualJoystick joystick;

    public float Stamina = 100;
    public float frontDirection;
    public Rigidbody thisRigidbody;
    public GameObject mainCamera;
    public GameObject hideCamera;
    public Vector3 camera;
    public float cameraSpeed = 20f;
    Vector3 forward, right;
    public GameObject lightSource;
    public GameObject doggo;

   
    public bool isCellarKey = false;
    public bool isLabKey = false;
    public bool isStoreKey = false;
    public bool isBasementKey = false;
    public bool unlockedDoorOpen = true;
    public bool cellarDoorOpen = false;
    public bool labDoorOpen = false;
    public bool storeDoorOpen = false;
    public bool basementDoorOpen = false;
    

    public float distance = 1f;
    //public SkinnedMeshRenderer alice;
    //Collider myCollider;

    public bool isMoving = false;
    public bool isIdling = false;
    public bool isHiding = false;
    public bool hideSpot = false;
    public bool isRun = false;
    public bool pressRun = false;
    public bool pressLight = false;
    public GameObject HidingSpot;
    public GameObject lantern;
    public bool nearLight = false;
    public bool nearCellarDoor = false;
    public bool nearLabDoor = false;
    public bool nearStoreDoor = false;
    public bool nearBasementDoor = false;
    public bool nearUnlockedDoor = false;
    //public bool isHide = false;
    //public bool pressHide = false;

    public AudioSource musicPlayer;
    public AudioClip item_pickup;

    private Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        thisRigidbody = gameObject.GetComponent<Rigidbody>();
        thisRigidbody.maxAngularVelocity = terminalRotationSpeed;
        thisRigidbody.drag = drag;
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        //alice = GetComponent<SkinnedMeshRenderer>();
        //alice.enabled = true;

    }

    void LateUpdate()
    {
        if (mainCamera.activeSelf == true)
        {
            Debug.Log(mainCamera);  
            mainCamera.transform.rotation = Quaternion.Euler(50, 45, 0);
            mainCamera.transform.position = thisRigidbody.position - (Quaternion.Euler(50, 45, 0) * Vector3.forward * distance);
        }
    }

    //void CamSwitch()
    //{
    //    if (Camera.main.enabled == false)
    //    {
    //        hideCamera.transform.rotation = Quaternion.Euler(35, 45, 0);
    //        hideCamera.transform.position = thisRigidbody.position - (Quaternion.Euler(35, 45, 0) * Vector3.forward * distance);
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        MoveVector = PoolInput();
        if (joystick.Horizontal() > 0 || joystick.Vertical() > 0 || joystick.Horizontal() < 0 || joystick.Vertical() < 0)
        {
            Move();
        }
        else {
            isMoving = false;
            isIdling = true;
            anim.SetBool("isIdle", true);
            anim.SetBool("isMove", false);
            transform.forward = new Vector3(transform.forward.x, transform.forward.y, frontDirection);
        }
        if (isHiding == true)
        {
            thisRigidbody.isKinematic = true;
            GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            thisRigidbody.isKinematic = false;
            GetComponent<BoxCollider>().enabled = true;
        }

    }

    void Move()
    {
        Vector3 direction = PoolInput();
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * joystick.Horizontal();
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * joystick.Vertical();

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        frontDirection = heading.z;
        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
        isMoving = true;
        anim.SetBool("isIdle", false);
        anim.SetBool("isMove", true);


    }

    Vector3 PoolInput()
    {
        Vector3 dir = Vector3.zero;
        dir.x = joystick.Horizontal();
        dir.z = joystick.Vertical();

        if (dir.magnitude > 1)
            dir.Normalize();
        return dir;
    }


    //void cameraFunct()
    //{
    //    camera = new Vector3(mainCamera.transform.position.x + (joystick.Horizontal() * cameraSpeed * Time.deltaTime), mainCamera.transform.position.y + (joystick.Vertical() * cameraSpeed * Time.deltaTime),
    //        mainCamera.transform.position.z - (joystick.Horizontal() * cameraSpeed * Time.deltaTime));
    //    mainCamera.transform.position = camera;
    //}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "HidingSpot")
        {
            HidingSpot = collision.gameObject;
            hideSpot = true;
        }

        if(collision.gameObject.tag == "LabKey")
        {
            isLabKey = true;
            Destroy(collision.gameObject);
            doggo.SetActive(true);
            musicPlayer.clip = item_pickup;
            musicPlayer.Play();
        }

        if (collision.gameObject.tag == "CellarKey")
        {
            isCellarKey = true;
            Destroy(collision.gameObject);
            musicPlayer.clip = item_pickup;
            musicPlayer.Play();

        }

        if (collision.gameObject.tag == "BasementKey")
        {
            isBasementKey = true;
            Destroy(collision.gameObject);
            musicPlayer.clip = item_pickup;
            musicPlayer.Play();

        }
        if (collision.gameObject.tag == "StoreKey")
        {
            isStoreKey = true;
            Destroy(collision.gameObject);
            musicPlayer.clip = item_pickup;
            musicPlayer.Play();

        }

    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "HidingSpot")
        {
            HidingSpot = null;
            hideSpot = false;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "lantern")
        {
            nearLight = true;
        }

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

   }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "lantern")
        {
            nearLight = false;
        }

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
}
