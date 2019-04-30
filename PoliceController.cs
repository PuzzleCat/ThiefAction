using UnityEngine;
using System.Collections;

public class PoliceController : MonoBehaviour {

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		int start = Random.Range (0, 2);
		if (start == 0) {
			rb.velocity = new Vector3 (-5.0f, 0, 0);
		} else {
			rb.velocity = new Vector3 (5.0f, 0, 0);
			transform.localScale = new Vector3(3.0f, 3.0f, 1.0f);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.CompareTag("StreetEnd")){
			if(rb.velocity.x == -5.0f){
				rb.velocity = new Vector3(5.0f, 0, 0);
				transform.localScale = new Vector3(3.0f, 3.0f, 1.0f);
			}
			else{
				rb.velocity = new Vector3(-5.0f, 0, 0);
				transform.localScale = new Vector3(-3.0f, 3.0f, 1.0f);
			}
		}
		else if(other.gameObject.CompareTag("Police")){
			if(rb.velocity.x == -5.0f){
				rb.velocity = new Vector3(5.0f, 0, 0);
				transform.localScale = new Vector3(3.0f, 3.0f, 1.0f);
			}
			else{
				rb.velocity = new Vector3(-5.0f, 0, 0);
				transform.localScale = new Vector3(-3.0f, 3.0f, 1.0f);
			}
		}
	}
}
