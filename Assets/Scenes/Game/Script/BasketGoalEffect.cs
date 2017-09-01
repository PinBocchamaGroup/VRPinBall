using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketGoalEffect : MonoBehaviour {

	private bool start;
	private bool end;

	private GameObject EffectObj;
	private GameObject EffectPosObj;

	private ParticleSystem particle;

	// Use this for initialization
	void Start () {
		start = false;
		end = false;
		EffectObj = (GameObject)Resources.Load ("Effect_07");
		//EffectPosObj = GameObject.Find("Effect Pos");
		//particle = EffectObj.GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (start && end) {
			Instantiate (EffectObj, EffectPosObj.transform.position + Vector3.down * 0.52f, Quaternion.identity);
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "start Goal") {
			start = true;
			EffectPosObj = col.gameObject;
		}
		if (col.tag == "end Goal") {
			end = true;
		}
	}


	void OnTriggerExit(Collider col){
		if (col.tag == "start Goal") {
			start = false;
		}
		if (col.tag == "end Goal") {
			end = false;
		}
	}

}
