using UnityEngine;
using System.Collections;

public class CleanerController : MonoBehaviour {

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		int r = Random.Range (0, 2);
		if (r == 0) {
			rb.velocity = new Vector3 (0, -5.0f, 0);
		} else {
			rb.velocity = new Vector3 (0, 5.0f, 0);		
		}
		StartCoroutine (move ());
	}
	
	// Update is called once per frame
	void Update () {
		transform.eulerAngles = Vector3.zero;
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("StreetEnd")) {
			if(rb.velocity.y < 0){
				rb.velocity = new Vector3(0, 5.0f, 0);
			}else{
				rb.velocity = new Vector3(0, -5.0f, 0);
			}
		}
		else if (other.gameObject.CompareTag ("Police")) {
			if(rb.velocity.y < 0){
				rb.velocity = new Vector3(0, 5.0f, 0);
			}else{
				rb.velocity = new Vector3(0, -5.0f, 0);
			}
		}
	}

	IEnumerator move(){
		yield return new WaitForSeconds (2);
		rb.isKinematic = true;
		StartCoroutine (stay ());
	}

	IEnumerator stay(){
		yield return new WaitForSeconds (1);
		rb.isKinematic = false;
		int r = Random.Range (0, 2);
		if (r == 0) {
			rb.velocity = new Vector3 (0, -5.0f, 0);
		} else {
			rb.velocity = new Vector3 (0, 5.0f, 0);		
		}
		StartCoroutine (move ());
	}

}
