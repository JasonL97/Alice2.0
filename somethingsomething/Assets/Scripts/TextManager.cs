using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {
	public GameObject TextBox;
	public Text theText;
    public GameObject SystemText;
	public TextAsset textFile;
	public GameObject Joystick;
	private string[] textLines;
	private int currentLine;
	private int endAtLine;
    public Player alice;
	private float savedTimeScale;
	public bool prologue = false;
	public GameObject prolougeManager;
    public GameObject tutorialCanvas;
    public TutorialScript tutorialS;
	// Use this for initialization
	void Start () {
         alice.FreezeMovement = true;
		if (textFile != null) 
		{
			textLines = (textFile.text.Split ('\n'));
		}
		if (endAtLine == 0) 
		{
			endAtLine = textLines.Length - 1;
		}
		Joystick.SetActive(false);
        SystemText.SetActive(false);
        TextBox.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {

        if (currentLine < textLines.Length)
        {
            theText.text = textLines[currentLine];
        }

		if (Input.GetButtonDown("Fire1"))
		{
			currentLine++;
		}
		if (currentLine > endAtLine)
		{
			TextBox.SetActive(false);
            tutorialS.tut1.SetActive(true);
			prologue = true;
            alice.FreezeMovement = false;
            Joystick.SetActive (true);
            prolougeManager.SetActive (false);
            tutorialCanvas.SetActive(true);
            tutorialCanvas.GetComponent<TutorialScript>().StartGame = true;      
        }

    }
}
