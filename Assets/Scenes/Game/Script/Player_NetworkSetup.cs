using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player_NetworkSetup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (GetComponent<NetworkIdentity>().isLocalPlayer) {
			transform.Find ("Arm_L").gameObject.GetComponent<Flipper> ().enabled = true;
			Debug.Log ("aa");
		}
		Debug.Log (GetComponent<NetworkIdentity>().isLocalPlayer);
	}
}
