using UnityEngine;
using System.Collections;

public class PotController : MonoBehaviour {

	private Vector3 pos;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		pos = transform.position;
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector3 (0, -5.0f, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("StreetEnd")) {
			StartCoroutine (respawn ());
		} else if (other.gameObject.CompareTag ("Police")) {
			StartCoroutine (respawn ());
		}
	}

	IEnumerator respawn(){
		yield return new WaitForSeconds (2);
		transform.eulerAngles = Vector3.zero;
		transform.position = pos;
		rb.velocity = new Vector3 (0, -5.0f, 0);
	}

}
