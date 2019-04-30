using UnityEngine;
using System.Collections;

public class NestController : MonoBehaviour {

	public GameObject nestBird;
	public GameObject swallow;
	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if ((player.transform.position - transform.position).magnitude <= 10.0f) {
			nestBird.SetActive (true);
		}
		if ((player.transform.position - transform.position).magnitude <= 7.0f) {
			swallow.SetActive (true);
			nestBird.SetActive (false);
		}
		if ((player.transform.position - transform.position).magnitude > 10.0f) {
			nestBird.SetActive (false);
		}
	}
}
