using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClimbingController : MonoBehaviour {

	public Text winLose;
	public GameObject won;
	public GameObject lost;

	private Vector3 target;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		winLose.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			target.z = transform.position.z;
		}
		transform.position = Vector3.MoveTowards (transform.position, target, 20.0f * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("Police")) {
			winLose.text = "You want to be a cleaner now, not a thief?";
			lost.SetActive (true);
			gameObject.SetActive (false);
		} else if (other.gameObject.CompareTag ("FlowerPot")) {
			winLose.text = "The sky is falling!";
			lost.SetActive (true);
			gameObject.SetActive (false);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Street")) {
			winLose.text = "Even Monkeys Fall from Trees...";
			lost.SetActive (true);
			gameObject.SetActive(false);
		} else if (other.gameObject.CompareTag ("Bound")) {
			winLose.text = "Caught in the Act! They found you!";
			lost.SetActive(true);
			gameObject.SetActive(false);
		} else if (other.gameObject.CompareTag ("Finish")) {
			winLose.text = "You Made It!";
			won.SetActive(true);
			gameObject.SetActive(false);
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
		Application.LoadLevel ("Level1-3");
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
		Application.LoadLevel ("Level1-4");
	}
}
