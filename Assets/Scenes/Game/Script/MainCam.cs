using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MainCam : NetworkBehaviour {

	public GameObject playerHostPos;
	public GameObject playerClientPos;

	void Start(){
		if (isServer) {
			transform.position = playerHostPos.transform.position;
			transform.rotation = playerHostPos.transform.rotation;
			Debug.Log ("isServer");
		} else {
			transform.position = playerClientPos.transform.position;
			transform.rotation = playerClientPos.transform.rotation;
			Debug.Log ("isClient");
		}
	}
}
