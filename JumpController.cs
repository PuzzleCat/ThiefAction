using UnityEngine;
using System.Collections;

public class JumpController : MonoBehaviour {

	public GameObject sneaking;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Street")) {
			sneaking.GetComponent<SneakingController> ().landJump ();
		}
	}
}
