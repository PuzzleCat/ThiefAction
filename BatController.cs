using UnityEngine;
using System.Collections;

public class BatController : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if ((player.transform.position - transform.position).magnitude <= 100.0f) {
			GetComponent<Rigidbody2D> ().velocity = new Vector3 (-5.0f, 0, 0);
		}
	}
}
