using UnityEngine;
using System.Collections;

public class SwallowController : MonoBehaviour {

	public GameObject player;

	private Vector3 target;
	private Vector3 temp;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		target = player.transform.position;
		transform.position = Vector3.MoveTowards (transform.position, target, 5.0f * Time.deltaTime);
		temp = transform.eulerAngles;
		if ((player.transform.position.x - transform.position.x) > 0) {
			transform.eulerAngles = new Vector3 (0, 0, (180 * Mathf.Atan ((player.transform.position.y - transform.position.y) / (player.transform.position.x - transform.position.x)) / Mathf.PI) - 90);
		} else if ((player.transform.position.x - transform.position.x) < 0) {
			transform.eulerAngles = new Vector3 (0, 0, 90 + (180 * Mathf.Atan ((player.transform.position.y - transform.position.y) / (player.transform.position.x - transform.position.x)) / Mathf.PI));
		} else if ((player.transform.position.x - transform.position.x) == 0 && (player.transform.position.y - transform.position.y) < 0) {
			transform.eulerAngles = new Vector3 (0, 0, 180);
		} else if ((player.transform.position.x - transform.position.x) == 0 && (player.transform.position.y - transform.position.y) > 0) {
			transform.eulerAngles = new Vector3 (0, 0, 0);
		} else if ((player.transform.position.x - transform.position.x) == 0 && (player.transform.position.y - transform.position.y) == 0) {
			transform.eulerAngles = temp;
		}
	}
}
