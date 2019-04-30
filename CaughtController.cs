using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CaughtController : MonoBehaviour {

	public Text winLose;
	public GameObject sneaking;
	public GameObject won;
	public GameObject lost;

	// Use this for initialization
	void Start () {
		winLose.text = "";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("Rock")) {
			sneaking.GetComponent<SneakingController> ().stop ();
			sneaking.GetComponent<SneakingController> ().crawling ();
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("End")) {
			winLose.text = "You Made It!";
			StartCoroutine(finished());
			sneaking.GetComponent<Rigidbody2D> ().isKinematic = true;
		}
		else if (other.gameObject.CompareTag ("Police")) {
			winLose.text = "If you like cameras so much, you should be an actor, not a thief";
			lost.SetActive(true);
			sneaking.SetActive(false);
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.CompareTag ("Bound")) {
			winLose.text = "Like a moth to a flame... You Lose!";
			lost.SetActive (true);
			sneaking.SetActive (false);
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
		Application.LoadLevel ("Level1-4");
	}
	public void nextPart(){
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

	IEnumerator finished(){
		yield return new WaitForSeconds (2);
		won.SetActive (true);
	}

}
