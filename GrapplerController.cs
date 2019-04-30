using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GrapplerController : MonoBehaviour {

	public Text winLose;
	public GameObject won;
	public GameObject lost;
	public GameObject cat1;
	public GameObject cat2;
	public GameObject cat3;
	public GameObject restartButton;

	private Rigidbody2D rb;
	private int catCount;

	// Use this for initialization
	void Start () {
		winLose.text = "";
		rb = GetComponent<Rigidbody2D> ();
		rb.isKinematic = true;
		StartCoroutine (begin ());
		catCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("Street")) {
			winLose.text = "Humpty-Dumpty had a Great Fall!";
			lost.SetActive(true);
			rb.isKinematic = true;
			restartButton.SetActive(false);
		} else if (other.gameObject.CompareTag ("Bound")) {
			winLose.text = "Like a sunfish, you went into shock by jumping too much";
			lost.SetActive(true);
			rb.isKinematic = true;
			restartButton.SetActive(false);
		}

	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.CompareTag("End")){
			winLose.text = "You Made It!";
			rb.isKinematic = true;
			won.SetActive(true);
			gameObject.SetActive(false);
			restartButton.SetActive(false);
		}
		else if(other.gameObject.CompareTag("Police")){
			winLose.text = "Are you turning yourself in?";
			lost.SetActive(true);
			rb.isKinematic = true;
			gameObject.SetActive(false);
			restartButton.SetActive(false);
		}
		else if(other.gameObject.CompareTag("Net")){
			catCount = catCount + 1;
			if(catCount == 1){
				cat1.SetActive(true);
				rb.mass = 1.5f;
				other.gameObject.SetActive(false);
			}
			else if(catCount == 2){
				cat1.SetActive(false);
				rb.mass = 2.0f;
				cat2.SetActive(true);
				other.gameObject.SetActive(false);
			}
			else if(catCount == 3){
				cat2.SetActive(false);
				rb.mass = 2.5f;
				cat3.SetActive(true);
				other.gameObject.SetActive(false);
			}
		}
	}

	IEnumerator begin(){
		yield return new WaitForSeconds (3);
		rb.isKinematic = false;
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
		Application.LoadLevel ("Level1-2");
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
		Application.LoadLevel ("Level1-3");
	}
}
