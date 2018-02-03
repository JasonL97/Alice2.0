using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.AI;

public class hidingButton : MonoBehaviour {

    public GameObject thePlayer;
    public Player alice;
    public GameObject CellaurDoor;
    public GameObject LabDoor;
    public GameObject StoreDoor;
    public GameObject BasementDoor;
    public GameObject UnlockedDoor;
    public AudioSource musicPlayer;
    public AudioClip doorOpen;
    public AudioClip doorClose;
    public GameObject TextBoxBG;
    public Text ChatText;
    public Text SystemText;
    public GameObject CharName;
    public GameObject DoggoNewSpawnLoc;
    public bool LabKeyChat = false;
    public bool LabNoteChat = false;
    public bool DiaryChat = false;
    public bool StoreKeyChat = false;
    public int ChatLength = 0;
    public bool TextPopUp = false;
    public GameObject UI_JoyStick;
    public GameObject PauseButton;
    public GameObject RUnButton;
    public Image InteractBtn;
    public GameObject StaminaBar;
    float TimePassed = 0;

    void Start()
    {
        UnlockedDoor.GetComponent<NavMeshObstacle>().enabled = false;
        CellaurDoor.GetComponent<NavMeshObstacle>().enabled = false;
        LabDoor.GetComponent<NavMeshObstacle>().enabled = false;
        StoreDoor.GetComponent<NavMeshObstacle>().enabled = false;
        BasementDoor.GetComponent<NavMeshObstacle>().enabled = false;
    }
    // Update is called once per frame
    void FixedUpdate () {
      
            if(SystemText.gameObject.activeSelf)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    TextPopUp = false;
                    SystemText.gameObject.SetActive(true);
                    ChatText.gameObject.SetActive(true);
                    CharName.SetActive(true);
                    TextBoxBG.SetActive(false);
                    alice.FreezeMovement = false;
                }
            }

        if (ChatText.gameObject.activeSelf)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (LabNoteChat && ChatLength < 2)
                {
                    ChatLength++;
                    TextBoxBG.SetActive(true);
                    SystemText.gameObject.SetActive(false);
                    CharName.SetActive(true);
                    ChatText.gameObject.SetActive(true);
                    ChatText.text = "Forgive me my dear Margaret... There's no turning back now...'";
                }
                else if (LabKeyChat && ChatLength < 3)
                {
                    ChatLength++;
                    switch (ChatLength)
                    {
                        case 2:
                            TextBoxBG.SetActive(true);
                            SystemText.gameObject.SetActive(false);
                            CharName.SetActive(true);
                            ChatText.gameObject.SetActive(true);
                            ChatText.text = "'Dear William, I have hidden the key to your lab in the Cellar. Hopefully little Alice doesn't play in there again'";
                            break;

                        case 3:
                            TextBoxBG.SetActive(true);
                            SystemText.gameObject.SetActive(false);
                            CharName.SetActive(true);
                            ChatText.gameObject.SetActive(true);
                            ChatText.text = "It must be a note to the owner of this place...";
                            break;
                    }
                }
                else if(DiaryChat && ChatLength < 2)
                {
                    ChatLength++;
                    TextBoxBG.SetActive(true);
                    SystemText.gameObject.SetActive(false);
                    CharName.SetActive(true);
                    ChatText.gameObject.SetActive(true);
                    ChatText.text = "But it looks like I can still use it.";
                }
                else if (StoreKeyChat && ChatLength < 4)
                {
                    ChatLength++;
                    switch (ChatLength)
                    {
                        case 2:
                            TextBoxBG.SetActive(true);
                            SystemText.gameObject.SetActive(false);
                            CharName.SetActive(true);
                            ChatText.gameObject.SetActive(true);
                            ChatText.text = "'The key to the store room is here... It's been weeks since I left the basement.";
                            break;

                        case 3:
                            TextBoxBG.SetActive(true);
                            SystemText.gameObject.SetActive(false);
                            CharName.SetActive(true);
                            ChatText.gameObject.SetActive(true);
                            ChatText.text = "I should really look for the key to the basement door, last I remember I dropped it in the store room.'";
                            break;

                        case 4:
                            TextBoxBG.SetActive(true);
                            SystemText.gameObject.SetActive(false);
                            CharName.SetActive(true);
                            ChatText.gameObject.SetActive(true);
                            ChatText.text = "I should try to find the basement key...";
                            break;
                    }
                }
                else
                {
                    if (alice.HaveBag)                   
                        alice.TutBag = true;
                    
                    if (alice.Dog_Spawn)
                        alice.TutHide = true;

                    if (alice.HaveDiary)
                        alice.TutSave = true;

                    LabKeyChat = false;
                    LabNoteChat = false;
                    StoreKeyChat = false;
                    DiaryChat = false;
                    SystemText.gameObject.SetActive(true);
                    ChatText.gameObject.SetActive(true);
                    CharName.SetActive(true);
                    TextBoxBG.SetActive(false);
                    alice.FreezeMovement = false;
                    EnableUI();
                }
            }
        }             
	}

    public void OnButtonDown()
    {
    
        if (alice.hideSpot == true)
        {
            HidingScript hide = alice.HidingSpot.GetComponent<HidingScript>();
            hide.pressHide = true;
            alice.GetComponent<Player>().isHiding = true;
        }

        if (alice.nearLight && alice.lantern != null)
        {
            alice.lantern.SetActive(true);
            alice.lightSource.SetActive(true);
            alice.nearLight = false;
            alice.QuestionMark.SetActive(false);
            Destroy(alice.lantern);
            alice.lantern = null;
        }

        if (alice.nearBag && alice.bag != null)
        {
            alice.bag.SetActive(true);
            alice.nearBag = false;
            alice.HaveBag = true;
            alice.QuestionMark.SetActive(false);
            Destroy(alice.bag);
            alice.bag = null;
            TextBoxBG.SetActive(true);
            SystemText.gameObject.SetActive(false);
            CharName.SetActive(true);
            ChatText.gameObject.SetActive(true);
            DisableUI();
            ChatText.text = "I can use this to store all the items that I have collected";
            alice.FreezeMovement = true;
        }

        if (alice.nearNote && alice.note != null)
        {
            alice.note.SetActive(true);           
            alice.HaveNote = true;
            Destroy(alice.note);
            alice.QuestionMark.SetActive(false);
            alice.note = null;
            TextBoxBG.SetActive(true);
            SystemText.gameObject.SetActive(false);
            CharName.SetActive(true);
            ChatText.gameObject.SetActive(true);
            DisableUI();
            ChatText.text = "'Oh god... What have I done?!It's not suppose to be like this! ";
            ChatLength = 1;
            LabNoteChat = true;
            alice.FreezeMovement = true;
        }

        if (alice.nearDairy && alice.diary != null)
        {
            alice.diary.SetActive(true);
            alice.HaveDiary = true;
            alice.QuestionMark.SetActive(false);
            Destroy(alice.diary);
            alice.diary = null;
            TextBoxBG.SetActive(true);
            SystemText.gameObject.SetActive(false);
            CharName.SetActive(true);
            ChatText.gameObject.SetActive(true);
            DisableUI();
            ChatText.text = "A diary... Most of the pages have been torn out....";
            DiaryChat = true;
            ChatLength = 1;
            alice.FreezeMovement = true;
        }

        #region Door Mechanics
        if (alice.nearUnlockedDoor)
        {
            
            if (alice.unlockedDoorOpen == false)
            {
                UnlockedDoor.transform.localEulerAngles = new Vector3(0, -90, 0);           
                alice.unlockedDoorOpen = true;
                UnlockedDoor.GetComponent<NavMeshObstacle>().enabled = true;
                musicPlayer.PlayOneShot(doorOpen);  
            }
            else
            {
                UnlockedDoor.transform.localEulerAngles = new Vector3(0, -90, 0);
                UnlockedDoor.GetComponent<NavMeshObstacle>().enabled = false;
                alice.unlockedDoorOpen = false;
                musicPlayer.PlayOneShot(doorClose);
    
            }
        }

        if (alice.nearCellarDoor)
        {
            if (alice.isCellarKey)
            {
                if (alice.cellarDoorOpen == false)
                {
                    CellaurDoor.transform.localEulerAngles = new Vector3(0, 0, 0);
                    alice.cellarDoorOpen = true;
                    CellaurDoor.GetComponent<NavMeshObstacle>().enabled = true;
                    musicPlayer.PlayOneShot(doorOpen);                  
                }
                else
                {
                    CellaurDoor.transform.localEulerAngles = new Vector3(0, 90, 0);
                    alice.cellarDoorOpen = false;
                    CellaurDoor.GetComponent<NavMeshObstacle>().enabled = false;
                    musicPlayer.PlayOneShot(doorClose);                   
                }
            }
            else
            {
                TextBoxBG.SetActive(true);
                SystemText.gameObject.SetActive(true);
                ChatText.gameObject.SetActive(false);
                CharName.SetActive(false);
                DisableUI();
                SystemText.text = "The door appears to be locked.";
                TextPopUp = true;
            }
        }


        if (alice.nearLabDoor)
        {
            if (alice.isLabKey)
            {
                if (alice.labDoorOpen == false)
                {
                    LabDoor.transform.localEulerAngles = new Vector3(0, -90, 0);
                    alice.labDoorOpen = true;
                    musicPlayer.PlayOneShot(doorOpen);
                    LabDoor.GetComponent<NavMeshObstacle>().enabled = true;
                }
                else
                {
                    LabDoor.transform.localEulerAngles = new Vector3(0, 0, 0);
                    alice.labDoorOpen = false;
                    LabDoor.GetComponent<NavMeshObstacle>().enabled = false;
                    musicPlayer.PlayOneShot(doorClose);
                }
            }
            else
            {
                TextBoxBG.SetActive(true);
                SystemText.gameObject.SetActive(true);
                ChatText.gameObject.SetActive(false);
                CharName.SetActive(false);
                DisableUI();
                SystemText.text = "The door appears to be locked.";
                TextPopUp = true;
            }
        }

        if (alice.nearStoreDoor)
        {
            if (alice.isStoreKey)
            {
                if (alice.storeDoorOpen == false)
                {
                    StoreDoor.transform.localEulerAngles = new Vector3(0, -180, 0);
                    alice.storeDoorOpen = true;
                    StoreDoor.GetComponent<NavMeshObstacle>().enabled = true;
                    musicPlayer.PlayOneShot(doorOpen);
                    if (!alice.FirstTimeOpenStore)
                    {
                        alice.doggo.SetActive(false);
                        alice.doggo.transform.rotation = DoggoNewSpawnLoc.transform.rotation;
                        alice.doggo.transform.position = DoggoNewSpawnLoc.transform.position;
                        alice.doggo.SetActive(true);
                    }

                    alice.FirstTimeOpenStore = true;                                  
                }
                else
                {
                    StoreDoor.transform.localEulerAngles = new Vector3(0, -90, 0);
                    StoreDoor.GetComponent<NavMeshObstacle>().enabled = false;
                    alice.storeDoorOpen = false;
                    musicPlayer.PlayOneShot(doorClose);
                }
            }
            else
            {
                TextBoxBG.SetActive(true);
                SystemText.gameObject.SetActive(true);
                ChatText.gameObject.SetActive(false);
                CharName.SetActive(false);
                DisableUI();
                SystemText.text = "The door appears to be locked.";
                TextPopUp = true;
            }
        }

        if (alice.nearBasementDoor)
        {
            if (alice.isBasementKey)
            {
                if (alice.basementDoorOpen == false)
                {
                    BasementDoor.transform.localEulerAngles = new Vector3(0, -180, 0);
                    BasementDoor.GetComponent<NavMeshObstacle>().enabled = true;
                    alice.basementDoorOpen = true;
                    musicPlayer.PlayOneShot(doorOpen);            
                }
                else
                {
                    BasementDoor.transform.localEulerAngles = new Vector3(0, -90, 0);
                    BasementDoor.GetComponent<NavMeshObstacle>().enabled = false;
                    alice.basementDoorOpen = false;
                    musicPlayer.PlayOneShot(doorClose);                
                }
            }
            else
            {
                TextBoxBG.SetActive(true);
                SystemText.gameObject.SetActive(true);
                ChatText.gameObject.SetActive(false);
                CharName.SetActive(false);
                SystemText.text = "The door appears to be locked.";
                DisableUI();
                TextPopUp = true;
            }
            //SceneManager.LoadScene("winScene");
        }
        #endregion

        #region Key Mechanics
        if (alice.nearCellarKey)
        {
            alice.isCellarKey = true;
            Destroy(alice.CellarKey);
            alice.QuestionMark.SetActive(false);
            TextBoxBG.SetActive(true);
            CharName.SetActive(true);
            SystemText.gameObject.SetActive(false);
            ChatText.gameObject.SetActive(true);
            ChatText.text = "A key...? I wonder where can I use this...?";
            DisableUI();
            TextPopUp = true;
            alice.nearCellarKey = false;
            alice.FreezeMovement = true;
        }

        if (alice.nearLabKey)
        {
            alice.isLabKey = true;
            alice.isCellarKey = true;
            Destroy(alice.LabKey);
            alice.QuestionMark.SetActive(false);
            TextBoxBG.SetActive(true);
            CharName.SetActive(true);
            SystemText.gameObject.SetActive(false);
            ChatText.gameObject.SetActive(true);
            ChatText.text = "Another key... There's a note too..";
            DisableUI();
            TextPopUp = true;
            alice.nearLabKey = false;
            LabKeyChat = true;
            ChatLength = 1;
            alice.FreezeMovement = true;
        }

        if (alice.nearStoreKey)
        {
            alice.isStoreKey = true;
            Destroy(alice.StoreKey);
            TextBoxBG.SetActive(true);
            alice.QuestionMark.SetActive(false);
            CharName.SetActive(true);
            SystemText.gameObject.SetActive(false);
            ChatText.gameObject.SetActive(true);
            ChatText.text = "A key... There's a another note too...";
            DisableUI();
            StoreKeyChat = true;
            TextPopUp = true;
            alice.nearStoreKey = false;
            alice.FreezeMovement = true;
        }

        if (alice.nearBaseKey)
        {
            alice.doggo.SetActive(false);
            alice.isBasementKey = true;
            alice.QuestionMark.SetActive(false);
            Destroy(alice.BasementKey);
            TextBoxBG.SetActive(true);
            CharName.SetActive(true);
            SystemText.gameObject.SetActive(false);
            ChatText.gameObject.SetActive(true);
            ChatText.text = "The key to the basement door! I should get out of here now...!";
            DisableUI();
            TextPopUp = true;
            alice.nearBaseKey = false;
            alice.FreezeMovement = true;
        }
        #endregion
    }

    void DisableUI()
    {
        PauseButton.SetActive(false);
        RUnButton.SetActive(false);
        UI_JoyStick.SetActive(false);
        InteractBtn.enabled = false;
        StaminaBar.SetActive(false);
    }

    void EnableUI()
    {
        StaminaBar.SetActive(true);
        PauseButton.SetActive(true);
        RUnButton.SetActive(true);
        UI_JoyStick.SetActive(true);
        InteractBtn.enabled = true;
    }
}
