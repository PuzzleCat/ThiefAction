using UnityEngine;
using System.Collections;

public class RockController : MonoBehaviour {

	private Rigidbody2D rb;
	private Vector3 pos;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector3 (-3.0f, 0, 0);
		pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("Player")) {
			transform.position = pos;
			rb.velocity = new Vector3 (-3.0f, 0, 0);
		} else if (other.gameObject.CompareTag ("Wall")) {
			transform.position = pos;
			rb.velocity = new Vector3 (-3.0f, 0, 0);
		}
	}
}
