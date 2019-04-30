using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {

	public GameObject Level2;
	public GameObject Level3;
	public GameObject rainbowQuartz;
	public GameObject ruby;
	public GameObject sapphire;
	public GameObject emerald;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("Unlock") == 0) {
			Level2.SetActive (true);
			Level3.SetActive (true);
			ruby.SetActive (false);
			sapphire.SetActive (false);
			emerald.SetActive (false);
		} else if (PlayerPrefs.GetInt ("Unlock") == 1) {
			Level2.SetActive (false);
			Level3.SetActive (true);
			ruby.SetActive (true);
			sapphire.SetActive (false);
			emerald.SetActive (false);
		} else if (PlayerPrefs.GetInt ("Unlock") == 2) {
			Level2.SetActive (false);
			Level3.SetActive (false);
			ruby.SetActive (true);
			sapphire.SetActive (true);
			emerald.SetActive (false);
		} else {
			Level2.SetActive (false);
			Level3.SetActive (false);
			ruby.SetActive (true);
			sapphire.SetActive (true);
			emerald.SetActive (true);
		}
		if (PlayerPrefs.GetInt ("Practice") == 0) {
			rainbowQuartz.SetActive (false);
		} else {
			rainbowQuartz.SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
