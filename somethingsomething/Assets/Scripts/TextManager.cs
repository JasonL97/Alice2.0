using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {
	public GameObject TextBox;
	public Text theText;
	public TextAsset textFile;
	public GameObject Joystick;
	private string[] textLines1;
	private int currentLine;
	private int endAtLine;
	private float savedTimeScale;
	public bool prologue = false;
	public GameObject tutorialmanager;
	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
		if (textFile != null) 
		{
			textLines1 = (textFile.text.Split ('\n'));

		}
		if (endAtLine == 0) 
		{
			endAtLine = textLines1.Length - 1;
		}
		Joystick.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if (currentLine < textLines1.Length)
        {
            theText.text = textLines1[currentLine];
        }

		if (Input.GetButtonDown("Fire1"))
		{
			currentLine++;
		}
		if (currentLine > endAtLine)
		{
			TextBox.SetActive(false);
			prologue = true;
			Time.timeScale = 1;
			tutorialmanager.SetActive (true);
			Joystick.SetActive (true);
		}

	}
}
