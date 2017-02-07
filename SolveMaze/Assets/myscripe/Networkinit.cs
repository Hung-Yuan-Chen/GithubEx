using UnityEngine;
using System.Collections;

public class Networkinit : MonoBehaviour {
	void start()
	{
		print("123");
	}

	void  OnNetworkInstantiate ( NetworkMessageInfo msg  ){ 
		print("12321");
		// This is our own player
		if (GetComponent<NetworkView>().isMine)
		{
			Debug.Log("mine");
			
			this.gameObject.GetComponent<NetworkInterpolatedTransform>().enabled=false;
			this.gameObject.GetComponent<mThirdPersonController>().enabled=true;
			this.gameObject.GetComponent<mThirdPersonCamera>().enabled=true;
			
		}
		// This is just some remote controlled player
		else
		{
			Debug.Log("not mine");
			name += "Remote";
			this.gameObject.GetComponent<NetworkInterpolatedTransform>().enabled=true;
			this.gameObject.GetComponent<mThirdPersonController>().enabled=false;
			this.gameObject.GetComponent<mThirdPersonCamera>().enabled=false;
		}
	}
	
}
