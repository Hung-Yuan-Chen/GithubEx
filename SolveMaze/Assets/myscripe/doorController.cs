using UnityEngine;
using System.Collections;

public class doorController : MonoBehaviour {
	public GameObject gb1;
	public GameObject gb2;
	public GameObject door;
	public GameObject fire;
	bool checker;
	// Use this for initialization
	void Start () {
		checker = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(gb1.GetComponent<planCheck>().on &&gb2.GetComponent<planCheck>().on && checker)
		{
			checker = false;
			if(Network.isServer){
				GetComponent<NetworkView>().RPC("DestoryDoor",RPCMode.AllBuffered);
			}
		}
	}
	[RPC]
	void DestoryDoor(){
		GameObject mfire = (GameObject)Instantiate (fire, door.transform.position, door.transform.rotation);
		Destroy (door, 0.5f);
		Destroy (mfire, 1.0f);
		Destroy (this.gameObject, 1.0f);
	}
}
