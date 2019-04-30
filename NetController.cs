using UnityEngine;
using System.Collections;

public class NetController : MonoBehaviour {

	public GameObject caught;
	public GameObject helicopter;

	private float y;
	private float z;

	// Use this for initialization
	void Start () {
		y = transform.position.y;
		z = transform.position.z;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = new Vector3 (helicopter.transform.position.x, y, z);
		transform.eulerAngles = Vector3.zero;
	}

	public void Caught(){
		caught.SetActive (true);
	}
}
