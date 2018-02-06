using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 200f;
    public float drag = 0.5f;
    public float terminalRotationSpeed = 25.0f;
    public Vector3 MoveVector { set; get; }
    public VirtualJoystick joystick;
    public TutorialScript tutScript;

    public float Stamina = 100;
    public float frontDirection;
    public Rigidbody thisRigidbody;
    public GameObject mainCamera;
    public GameObject hideCamera;
    public Vector3 camera;
    public float cameraSpeed = 20f;
    Vector3 forward, right;
    public GameObject lightSource;
    public bool HaveBag = false;
    public bool HaveNote = false;
    public bool HaveDiary = false;
    public GameObject doggo;

    public Text ChatText;
    public Text SystemText;
    public GameObject TextBoxBG;
    public GameObject CharName;
   
    public bool isCellarKey = false;
    public bool isLabKey = false;
    public bool isStoreKey = false;
    public bool isBasementKey = false;
    public bool unlockedDoorOpen = false;
    public bool cellarDoorOpen = false;
    public bool labDoorOpen = false;
    public bool storeDoorOpen = false;
    public bool basementDoorOpen = false;

    public bool CellarTrigger = false;
    public bool C_TriggerPast = false;
    public bool Dog_Spawn_Past = false;
    public bool Dog_Spawn = false;

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
    public GameObject bag;
    public GameObject note;
    public GameObject diary;
    public GameObject CellarKey;
    public GameObject LabKey;
    public GameObject StoreKey;
    public GameObject BasementKey;

    public GameObject CellarDoor;
    public GameObject SurpriseMark;
    public GameObject QuestionMark;

    public bool nearLight = false;
    public bool nearBag = false;
    public bool nearNote = false;
    public bool nearDairy = false;
    public bool nearCellarDoor = false;
    public bool nearLabDoor = false;
    public bool nearStoreDoor = false;
    public bool nearBasementDoor = false;
    public bool nearUnlockedDoor = false;

    public bool nearCellarKey = false;
    public bool nearLabKey = false;
    public bool nearStoreKey = false;
    public bool nearBaseKey = false;

    public bool TutBag = false;
    public bool TutHide = false;
    public bool TutSave = false;

    public bool TeachInvenPass = false;
    public bool TeachHidePass = false;
    public bool TeachSavePass = false;

    public bool FreezeMovement = false;
    public bool FirstTimeOpenStore = false;

    public bool TextPopUp = false;

    public float TimePassed = 0;
    //public bool isHide = false;
    //public bool pressHide = false;

    public AudioSource aliceHeart;
    public AudioSource sourceSound;
    public AudioClip doorLocked;
    public AudioClip walking;
    public AudioClip heartbeat;

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
        SurpriseMark.SetActive(false);
        QuestionMark.SetActive(false);
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

    void FixedUpdate()
    {            
         
        if (SurpriseMark.activeSelf)
            SurpriseMark.transform.position = new Vector3(this.transform.position.x, SurpriseMark.transform.position.y, this.transform.position.z);

        if (QuestionMark.activeSelf)
            QuestionMark.transform.position = new Vector3(this.transform.position.x, QuestionMark.transform.position.y, this.transform.position.z);

        if (CellarTrigger)
        {
            TimePassed += Time.deltaTime;
            if(TimePassed > 0.75f)
            {
                CellarTrigger = false;
                C_TriggerPast = true;
                SurpriseMark.SetActive(false);
                TimePassed = 0;
                FreezeMovement = false;        
            }
        }

        if(HaveBag && !TeachInvenPass && TutBag)
        {
            tutScript.TeachInven = true;
            tutScript.tut3.SetActive(true);          
            TeachInvenPass = true;
            FreezeMovement = true;
        }

        if(HaveDiary && !TeachSavePass && TutSave)
        {
            tutScript.TeachSave = true;
            tutScript.tut5.SetActive(true);
            TeachSavePass = true;
            FreezeMovement = true;
        }

        if (Dog_Spawn && !TeachHidePass && TutHide && !FreezeMovement)
        {
            tutScript.TeachHide = true;
            tutScript.tut4.SetActive(true);               
            TeachHidePass = true;
            FreezeMovement = true;       
        }
    }

    void Update()
    {
        MoveVector = PoolInput();
        if (joystick.Horizontal() > 0 || joystick.Vertical() > 0 || joystick.Horizontal() < 0 || joystick.Vertical() < 0)
        {
            Move();
        }
        else {
            sourceSound.Stop();
            isMoving = false;
            isIdling = true;
            anim.SetBool("isIdle", true);
            anim.SetBool("isMove", false);
            transform.forward = new Vector3(transform.forward.x, transform.forward.y, frontDirection);
        }
        if (isHiding == true)
        {
            if(aliceHeart.clip != heartbeat)
                aliceHeart.clip = heartbeat;

            if (!aliceHeart.isPlaying)
            {
                aliceHeart.Play();
            }
            thisRigidbody.isKinematic = true;
            GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            aliceHeart.Stop();
            thisRigidbody.isKinematic = false;
            GetComponent<BoxCollider>().enabled = true;
        }

    }

    void Move()
    {
        if (!FreezeMovement)
        {
            Vector3 direction = PoolInput();
            Vector3 rightMovement = right * moveSpeed * Time.deltaTime * joystick.Horizontal();
            Vector3 upMovement = forward * moveSpeed * Time.deltaTime * joystick.Vertical();
            sourceSound.clip = walking;
            if (!sourceSound.isPlaying)
            {
                sourceSound.Play();
            }
            Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
            frontDirection = heading.z;
            transform.forward = heading;
            transform.position += rightMovement;
            transform.position += upMovement;
            isMoving = true;
            anim.SetBool("isIdle", false);
            anim.SetBool("isMove", true);
        }

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


    void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag == "HidingSpot")
            {
                HidingSpot = col.gameObject;
                hideSpot = true;
            }    
        
            if (col.gameObject.tag == "lantern")
            {
                nearLight = true;

                QuestionMark.SetActive(true);
                QuestionMark.transform.position = new Vector3(this.transform.position.x, QuestionMark.transform.position.y, this.transform.position.z);
             }

            if (col.gameObject.tag == "bag")
            {
                nearBag = true;
            QuestionMark.SetActive(true);
            QuestionMark.transform.position = new Vector3(this.transform.position.x, QuestionMark.transform.position.y, this.transform.position.z);
        }
        
            if(col.gameObject.tag == "Note")
            {
                nearNote = true;
            QuestionMark.SetActive(true);
            QuestionMark.transform.position = new Vector3(this.transform.position.x, QuestionMark.transform.position.y, this.transform.position.z);
        }

            if (col.gameObject.tag == "Diary")
            {
                nearDairy = true;
            QuestionMark.SetActive(true);
            QuestionMark.transform.position = new Vector3(this.transform.position.x, QuestionMark.transform.position.y, this.transform.position.z);
        }

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

            #region CheckKey
            if (col.gameObject.tag == "CellarKey")
            {
                nearCellarKey = true;
            QuestionMark.SetActive(true);
            QuestionMark.transform.position = new Vector3(this.transform.position.x, QuestionMark.transform.position.y, this.transform.position.z);
        }
            if (col.gameObject.tag == "LabKey")
            {
                nearLabKey = true;
            QuestionMark.SetActive(true);
            QuestionMark.transform.position = new Vector3(this.transform.position.x, QuestionMark.transform.position.y, this.transform.position.z);
        }
            if (col.gameObject.tag == "StoreKey")
            {
                nearStoreKey = true;
            QuestionMark.SetActive(true);
            QuestionMark.transform.position = new Vector3(this.transform.position.x, QuestionMark.transform.position.y, this.transform.position.z);
        }
            if (col.gameObject.tag == "BasementKey")
            {
                nearBaseKey = true;
            QuestionMark.SetActive(true);
            QuestionMark.transform.position = new Vector3(this.transform.position.x, QuestionMark.transform.position.y, this.transform.position.z);
        }
            #endregion

            if(col.gameObject.tag == "CellarRoomTrigger" && !C_TriggerPast)
            {
                CellarTrigger = true;
                CellarDoor.transform.localEulerAngles = new Vector3(0, 90, 0);
            sourceSound.PlayOneShot(doorLocked);
                SurpriseMark.transform.position = new Vector3(this.transform.position.x, SurpriseMark.transform.position.y, this.transform.position.z);
                cellarDoorOpen = false;
                SurpriseMark.SetActive(true);
                isCellarKey = false;
                FreezeMovement = true;
            }

            if (col.gameObject.tag == "DogSpawnTrigger" && !Dog_Spawn_Past && C_TriggerPast)
            {
                doggo.SetActive(true);
                Dog_Spawn = true;
                CellarDoor.transform.localEulerAngles = new Vector3(0, 90, 0);
            sourceSound.PlayOneShot(doorLocked);
                SurpriseMark.transform.position = new Vector3(this.transform.position.x, SurpriseMark.transform.position.y, this.transform.position.z);
                TextBoxBG.SetActive(true);
                SystemText.gameObject.SetActive(false);
                CharName.SetActive(true);
                ChatText.gameObject.SetActive(true);
                ChatText.text = "Wha... What is that thing...! I should get away from it...!";           
                cellarDoorOpen = false;
                SurpriseMark.SetActive(true);
                FreezeMovement = true;
            }
        //if (col.gameObject.tag == "WinArea")
        //{
        //    SceneManager.LoadScene("winScreen");
        //}
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "HidingSpot")
        {
            HidingSpot = null;
            hideSpot = false;
        }
        if (col.gameObject.tag == "lantern")
        {
            nearLight = false;
            QuestionMark.SetActive(false);
            
        }

        if (col.gameObject.tag == "bag")
        {
            nearBag = false;
            QuestionMark.SetActive(false);
        }

        if (col.gameObject.tag == "Note")
        {
            nearNote = false;
            QuestionMark.SetActive(false);
        }

        if (col.gameObject.tag == "Diary")
        {
            nearDairy = false;
            QuestionMark.SetActive(false);
        }

        #region CheckDoor
        if (col.gameObject.tag == "bag")
        {
            nearBag = false;
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
        #endregion

        #region Check Key
        if (col.gameObject.tag == "CellarKey")
        {
            nearCellarKey = false;
            QuestionMark.SetActive(false);
        }
        if (col.gameObject.tag == "LabKey")
        {
            nearLabKey = false;
            QuestionMark.SetActive(false);
        }
        if (col.gameObject.tag == "StoreKey")
        {
            nearStoreKey = false;
            QuestionMark.SetActive(false);
        }
        if (col.gameObject.tag == "BasementKey")
        {
            nearBaseKey = false;
            QuestionMark.SetActive(false);
        }
        #endregion
    }
}
