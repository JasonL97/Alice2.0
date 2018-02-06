using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Game : MonoBehaviour {

    public AudioSource sound;
    public void onMouseButton()
    {
        sound.Play();
        Application.Quit();
    }

}
