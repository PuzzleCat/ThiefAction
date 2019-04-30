using UnityEngine;
using System.Collections;

public class SackController : MonoBehaviour {

	public GameObject player;
	public GameObject balloon;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if((player.transform.position.y - transform.position.y) < 0){
			if((transform.position.x - player.transform.position.x) <= 10.0f){
				rb.velocity = new Vector3(0, -3.0f, 0);
				balloon.GetComponent<Rigidbody2D>().velocity = new Vector3 (0, 3.0f, 0);
			}
		}
		else{
			if((transform.position.x - player.transform.position.x) <= 10.0f){
				rb.velocity = new Vector3(0, -3.0f, 0);
				balloon.GetComponent<Rigidbody2D>().velocity = new Vector3 (0, 3.0f, 0);
			}
		}

	}
}
