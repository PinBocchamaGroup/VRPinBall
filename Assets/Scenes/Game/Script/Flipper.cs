using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour {

	/// <summary>
	/// バネの強さ(勢い)
	/// </summary>
	public float spring;
	/// <summary>
	/// スピード
	/// </summary>
	public float damper;
	/// <summary>
	/// 角度
	/// </summary>
	public float openAngle;
	/// <summary>
	/// 通常時の角度
	/// </summary>
	public float closeAngle;

	private HingeJoint hj;
	private Rigidbody rb;
	JointSpring spr;

	void Start () {
		hj = gameObject.GetComponent<HingeJoint>();
		hj.useSpring = true;
		rb = gameObject.GetComponent<Rigidbody>();
		rb.useGravity = false;
	}

	float TransAngle(float angle01){
		return Mathf.Lerp (closeAngle, openAngle, angle01);
	}

	public void ChangeFlipper(float input){
		JointSpring spr = hj.spring;
		spr.spring = spring;
		spr.damper = damper;
		spr.targetPosition = TransAngle(input);
		hj.spring = spr;
	}
}