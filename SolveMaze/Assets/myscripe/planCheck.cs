using UnityEngine;
using System.Collections;

public class planCheck : MonoBehaviour {
	public Material m1;
	public Material m2;
	public bool on;
	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<Renderer>().material = m1;
		on = false;
	}

	void OnTriggerEnter(Collider other) {
		this.gameObject.GetComponent<Renderer>().material = m2;
		on = true;
	}
	void OnTriggerExit(Collider other) {
		this.gameObject.GetComponent<Renderer>().material = m1;
		on = false;
	}
}
