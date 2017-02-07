using UnityEngine;
using System.Collections;

public class SpawnPrefab : MonoBehaviour {

	public GameObject playerPrefab;

	void  OnNetworkLoadedLevel (){
		Debug.Log("Server creat player");
		Network.Instantiate(playerPrefab, transform.position, transform.rotation, 0);
		
	}
	
	void  OnPlayerDisconnected ( NetworkPlayer player  ){
		Debug.Log("Server destroying player");
		Network.RemoveRPCs(player, 0);
		Network.DestroyPlayerObjects(player);
	}

}
