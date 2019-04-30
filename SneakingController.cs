using UnityEngine;
using System.Collections;

public class SneakingController : MonoBehaviour {

	public GameObject walk;
	public GameObject jump;
	public GameObject crawl;

	private bool jumped;
	private Vector3 target;
	private Rigidbody2D rb;
	private bool stopped;

	// Use this for initialization
	void Start () {
		jumped = false;
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector3 (3.0f, 0, 0);
		walk.SetActive (false);
		jump.SetActive (false);
		crawl.SetActive (true);
		walk.SetActive (true);
		jump.SetActive (false);
		crawl.SetActive (false);
		stopped = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (jumped == true){
			rb.AddForce (new Vector3 (0, -3.0f, 0));
			jump.transform.Rotate (new Vector3(0, 0, -180) * Time.deltaTime);
		} else {
			transform.position = new Vector3 (transform.position.x, -1.0f, transform.position.z);
		}
		walk.transform.position = transform.position;
		jump.transform.position = transform.position;
		crawl.transform.position = transform.position;
	}

	public void walking(){
		walk.SetActive (true);
		jump.SetActive (false);
		crawl.SetActive (false);
	}
	public void jumping(){
		if (jumped == false) {
			walk.SetActive (false);
			jump.SetActive (true);
			crawl.SetActive (false);
			jumped = true;
			rb.AddForce (new Vector3 (0, 3.0f, 0), ForceMode2D.Impulse);
		}
	}
	public void crawling(){
		walk.SetActive (false);
		jump.SetActive (false);
		crawl.SetActive (true);
	}
	public void landJump(){
		jumped = false;
		transform.eulerAngles = Vector3.zero;
		jump.transform.eulerAngles = Vector3.zero;
		transform.position = new Vector3(transform.position.x, -1.0f, transform.position.z);
		jump.SetActive(false);
		walk.SetActive(true);
		crawl.SetActive(false);
		rb.velocity = new Vector3 (3.0f, 0, 0);
		if (stopped == true) {
			rb.velocity = Vector3.zero;
		}
	}
	public void stop(){
		rb.velocity = Vector3.zero;
		stopped = true;
	}
	public void go(){
		rb.velocity = new Vector3 (3.0f, 0, 0);
		stopped = false;
	}
}
