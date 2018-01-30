using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {
	public GameObject TextBox;
	public Text theText;
	public TextAsset textFile;
	public GameObject Joystick;
	public string[] textLines;
	public int currentLine;
	public int endAtLine;
	private float savedTimeScale;

	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
		if (textFile != null) 
		{
			textLines = (textFile.text.Split ('\n'));

		}
		if (endAtLine == 0) 
		{
			endAtLine = textLines.Length - 1;
		}
		Joystick.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

		theText.text = textLines[currentLine];

		if (Input.GetButtonDown("Fire1"))
		{
			currentLine++;
		}
		if (currentLine > endAtLine)
		{
			TextBox.SetActive(false);
			Joystick.SetActive(true);
			Time.timeScale = 1;
		}

	}
}
