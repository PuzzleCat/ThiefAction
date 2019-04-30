using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GlideController : MonoBehaviour {

	public Text winLose;
	public GameObject won;
	public GameObject lost;

	private float speed;
	private Rigidbody2D rb;
	private Vector3 temp;

	// Use this for initialization
	void Start () {
		speed = 5.0f;
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector3 (speed, 0, 0);
		winLose.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		temp = transform.eulerAngles;
		if (rb.velocity.x == 0) {
			if (rb.velocity.y > 0) {
				transform.eulerAngles = new Vector3 (0, 0, -270);
			} else if (rb.velocity.y < 0) {
				transform.eulerAngles = new Vector3 (0, 0, -90);
			} else if (rb.velocity.y == 0) {
				transform.eulerAngles = temp;
			}
		} else {
			if (rb.velocity.x > 0) {
				transform.eulerAngles = new Vector3 (0, 0, (180 * Mathf.Atan (rb.velocity.y / rb.velocity.x) / Mathf.PI));
			} else if (rb.velocity.x < 0) {
				transform.eulerAngles = new Vector3 (0, 0, (180 * Mathf.Atan (rb.velocity.y / rb.velocity.x) / Mathf.PI) - 180);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("Bound")) {
			winLose.text = "Like Icarus, you flew too high or plunged too deep...";
			lost.SetActive (true);
			gameObject.SetActive (false);
		} else if (other.gameObject.CompareTag ("Building")) {
			winLose.text = "Do you think you're a bull? You charged at the red!";
			lost.SetActive (true);
			gameObject.SetActive (false);
		} 
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("End")) {
			winLose.text = "You Made It!";
			StartCoroutine (end ());
		}
		else if (other.gameObject.CompareTag ("Police")) {
			winLose.text = "Being a chick magnet is not enough so now you're attracting bats too?";
			lost.SetActive (true);
			other.gameObject.SetActive (false);
			gameObject.SetActive (false);
		}
		else if (other.gameObject.CompareTag ("FlowerPot")) {
			winLose.text = "Time to hit the sack";
			lost.SetActive (true);
			other.gameObject.SetActive (false);
			gameObject.SetActive (false);
		}
	}

	public void up(){
		Vector2 goUp = new Vector2 (0, 3);
		rb.AddForce (goUp, ForceMode2D.Impulse);
	}
	public void down(){
		Vector2 goDown = new Vector2 (0, -3);
		rb.AddForce (goDown, ForceMode2D.Impulse);
	}

	IEnumerator end(){
		yield return new WaitForSeconds (2);
		rb.isKinematic = true;
		won.SetActive (true);
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
		Application.LoadLevel ("Level1-2");
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
		Application.LoadLevel ("Level1-1");
	}
	public void boost(){
		rb.velocity = new Vector3 (10.0f, 0, 0);
		StartCoroutine (boostTime ());
	}
	IEnumerator boostTime(){
		yield return new WaitForSeconds (1);
		rb.velocity = new Vector3 (5.0f, 0, 0);
	}
}
