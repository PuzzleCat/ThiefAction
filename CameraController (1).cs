using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private float y;

	// Use this for initialization
	void Start () {
		y = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (player.transform.position.x, y, -10);
	}
}
