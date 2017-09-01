using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetCOMPort : MonoBehaviour {
	
	public GameObject COMPortObj;

	private Text comPort;

	void Start(){
		comPort = COMPortObj.GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {
		StaticScript.comPort = comPort.text;
	}
}
