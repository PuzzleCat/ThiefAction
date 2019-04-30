using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonController : MonoBehaviour {

	public Text screen;
	public Text winLose;
	public GameObject won;
	public GameObject lost;
	public GameObject WinLose;
	public Text levelMode;

	private int first;
	private int second;
	private int third;
	private int fourth;
	private int fifth;
	private int sixth;
	private int seventh;
	private string answer;
	private bool begin;
	private int tries;

	// Use this for initialization
	void Start () {
		tries = 0;
		begin = false;
		winLose.text = "";
		screen.text = "";
		first = Random.Range (0, 10);
		second = Random.Range (0, 10);
		third = Random.Range (0, 10);
		fourth = Random.Range (0, 10);
		fifth = Random.Range (0, 10);
		sixth = Random.Range (0, 10);
		seventh = Random.Range (0, 10);
		answer = "" + first + second + third + fourth + fifth + sixth + seventh;
		screen.text = answer;
		if (levelMode.text == "Level 1") {
			StartCoroutine (wipe ());
		} else if (levelMode.text == "Level 2") {
			StartCoroutine (wipe2 ());
		}
		else if (levelMode.text == "Level 3") {
			StartCoroutine (wipe3 ());
		}
		else if (levelMode.text == "Practice") {
			StartCoroutine (wipe5 ());
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void one(){
		if (begin == true) {
			screen.text = screen.text + "1";
		}
	}
	public void two(){
		if (begin == true) {
			screen.text = screen.text + "2";
		}
	}
	public void three(){
		if (begin == true) {
			screen.text = screen.text + "3";
		}
	}
	public void four(){
		if (begin == true) {
			screen.text = screen.text + "4";
		}
	}
	public void five(){
		if (begin == true) {
			screen.text = screen.text + "5";
		}
	}
	public void six(){
		if (begin == true) {
			screen.text = screen.text + "6";
		}
	}
	public void seven(){
		if (begin == true) {
			screen.text = screen.text + "7";
		}
	}
	public void eight(){
		if (begin == true) {
			screen.text = screen.text + "8";
		}
	}
	public void nine(){
		if (begin == true) {
			screen.text = screen.text + "9";
		}
	}
	public void zero(){
		if (begin == true) {
			screen.text = screen.text + "0";
		}
	}
	public void clear(){
		if (begin == true) {
			screen.text = "";
		}
	}
	public void enter(){
		if (begin == true) {
			tries = tries + 1;
			if(screen.text == answer){
				WinLose.SetActive(true);
				winLose.text = "You Made It!";
				if(levelMode.text == "Level 1" && PlayerPrefs.GetInt("Unlock") == 0){
					PlayerPrefs.SetInt("Unlock", 1);
				}
				else if(levelMode.text == "Level 2" && PlayerPrefs.GetInt("Unlock") == 1){
					PlayerPrefs.SetInt("Unlock", 2);
				}
				else if(levelMode.text == "Level 3" && PlayerPrefs.GetInt("Unlock") == 2){
					PlayerPrefs.SetInt("Unlock", 3);
				}
				else if(levelMode.text == "Practice" && PlayerPrefs.GetInt("Practice") == 0){
					PlayerPrefs.SetInt("Practice", 1);
				}
				StartCoroutine(finished());
			}
			else{
				if(tries == 3){
					WinLose.SetActive(true);
					winLose.text = "Too many mistakes. You've been caught!";
					lost.SetActive(true);
				}
				else{
					screen.text = "ERROR";
					StartCoroutine(wipe());
				}
			}

		}
	}
	public void restart(){
		if (PlayerPrefs.GetInt ("Return") == 0) {
			PlayerPrefs.SetInt ("Return", 1);
		}
		else if (PlayerPrefs.GetInt ("Return") == 1) {
			PlayerPrefs.SetInt ("Return", 2);
		}
		else if (PlayerPrefs.GetInt ("Return") == 2) {
			PlayerPrefs.SetInt ("Return", 3);
		}
		Application.LoadLevel ("Level1-5");
	}
	public void done(){
		if (PlayerPrefs.GetInt ("Return") == 0) {
			PlayerPrefs.SetInt ("Return", 1);
		}
		else if (PlayerPrefs.GetInt ("Return") == 1) {
			PlayerPrefs.SetInt ("Return", 2);
		}
		else if (PlayerPrefs.GetInt ("Return") == 2) {
			PlayerPrefs.SetInt ("Return", 3);
		}
		Application.LoadLevel ("Start");
	}

	IEnumerator wipe(){
		yield return new WaitForSeconds (3);
		screen.text = "";
		begin = true;
	}
	IEnumerator wipe2(){
		yield return new WaitForSeconds (2);
		screen.text = "";
		begin = true;
	}
	IEnumerator wipe3(){
		yield return new WaitForSeconds (1);
		screen.text = "";
		begin = true;
	}
	IEnumerator wipe5(){
		yield return new WaitForSeconds (5);
		screen.text = "";
		begin = true;
	}
	IEnumerator finished(){
		yield return new WaitForSeconds (2);
		won.SetActive (true);
	}
}
