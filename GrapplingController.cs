using UnityEngine;
using System.Collections;

public class GrapplingController : MonoBehaviour {

	public GameObject player;
	public Color c1 = Color.gray;
	public Color c2 = Color.gray;
	public int lengthOfLineRenderer = 2;
	
	private LineRenderer lineRenderer;
	private Vector3 pull;
	private Vector3 target;
	
	// Use this for initialization
	void Start () {
		lineRenderer = GetComponent<LineRenderer> ();
		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		lineRenderer.SetColors(c1, c2);
		lineRenderer.SetWidth(0.2F, 0.2F);
		lineRenderer.SetVertexCount(lengthOfLineRenderer);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
	}

	void OnMouseDrag(){
		float t = Time.time;
		Vector3 pos = player.GetComponent<Rigidbody2D>().transform.position;
		lineRenderer.SetPosition (0, pos);
		lineRenderer.SetPosition (1, target);
		pull = target - pos;
		pull = 50.0f * pull / pull.magnitude;
		player.GetComponent<Rigidbody2D> ().AddForce (pull);
	}
	void OnMouseUp(){
		float t = Time.time;
		Vector3 pos = player.GetComponent<Rigidbody2D>().transform.position;
		lineRenderer.SetPosition (0, transform.position);
		lineRenderer.SetPosition (1, transform.position);
	}
}
