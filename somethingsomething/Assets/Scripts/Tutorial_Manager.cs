using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_Manager : MonoBehaviour {
	public GameObject TextBox;
	public Text theText;
	public TextAsset textFile;
	public GameObject Joystick;
	public string[] textLines;
	public int currentLine;
	public int endAtLine;
	private float savedTimeScale;
	public GameObject textManager;
	public GameObject tutorialmanager;
	public Image run, movement, stamina, use, pause;
	public GameObject run1, movement1, stamina1, use1, pause1;

	// Use this for initialization
	void Start () {
		
		if (textFile != null) 
		{
			textLines = (textFile.text.Split ('\n'));

		}
		if (endAtLine == 0) 
		{
			endAtLine = textLines.Length - 1;
		}
			TextBox.SetActive(true);
			Time.timeScale = 0;
		use1.SetActive (false);
		run1.SetActive (false);
		stamina1.SetActive (false);
		pause1.SetActive (false);
		 
	}
	
	// Update is called once per frame
	void Update () {
		theText.text = textLines[currentLine];
//		if (textManager.GetComponent<TextManager> ().prologue = true)
//		{
//			TextBox.SetActive(true);
//			Time.timeScale = 0;
//		}
		if (Input.GetButtonDown("Fire1"))
		{
			currentLine++;
		}
		if (currentLine == 0) {
			movement.gameObject.SetActive (true);
		}
		if (currentLine == 1) {
			movement.gameObject.SetActive (false);
			movement1.SetActive (false);
			use.gameObject.SetActive (true);
			use1.SetActive (true);
		}
		if (currentLine == 2) {
			use.gameObject.SetActive (false);
			use1.SetActive (false);
			run.gameObject.SetActive (true);
			run1.SetActive (true);
		}
		if (currentLine == 3) {
			run.gameObject.SetActive (false);
			run1.SetActive (false);
			stamina.gameObject.SetActive (true);
			stamina1.SetActive (true);
		}
		if (currentLine == 4) {
			stamina.gameObject.SetActive (false);
			stamina1.SetActive (false);
			pause.gameObject.SetActive (true);
			pause1.SetActive (true);
		}

		if (currentLine > endAtLine)
		{
			pause.gameObject.SetActive (false);
			TextBox.SetActive(false);
			use1.SetActive (true);
			run1.SetActive (true);
			stamina1.SetActive (true);
			movement1.SetActive (true);
			Time.timeScale = 1;
			tutorialmanager.SetActive (false);
		}
	}
}
