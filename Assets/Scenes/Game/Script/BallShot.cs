using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BallShot : NetworkBehaviour {

	public GameObject BallObj;
	/// <summary>
	/// shot minimum speed
	/// </summary>
	public float minSpeed;
	/// <summary>
	/// shot maximum speed
	/// </summary>
	public float maxSpeed;

	// Update is called once per frame
	void Update () {
		if (isServer) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				Shot ();
			}
		} 
	}

	void Shot(){
		GameObject ball = (GameObject)Instantiate (BallObj, transform.position, Quaternion.identity);
		NetworkServer.Spawn (ball);
		Rigidbody rigid = ball.GetComponent<Rigidbody> ();
		rigid.AddForce (Vector3.up * Random.Range(minSpeed,maxSpeed), ForceMode.Impulse);
	}
}
