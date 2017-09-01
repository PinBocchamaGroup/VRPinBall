using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FlipperManager : NetworkBehaviour {

	public GameObject UniduinoObj;
	public GameObject LegLeftObj;
	public GameObject LegRightObj;
	public GameObject ArmLObj;
	public GameObject ArmRObj;

	InfraredSensor legLeft;
	InfraredSensor legRight;
	Flipper flipperL;
	Flipper flipperR;

	[SyncVar]
	private float syncAngleL;
	[SyncVar]
	private float syncAngleR;

	// Use this for initialization
	void Start () {
		ServerSetUp ();
		flipperL = ArmLObj.GetComponent<Flipper> ();
		flipperR = ArmRObj.GetComponent<Flipper> ();
		syncAngleL = 0f;
		syncAngleR = 0f;
	}

	//serverならUniduinoを動作させる
	void ServerSetUp(){
		if (isServer) {
			UniduinoObj.SetActive (true);
			LegLeftObj.SetActive (true);
			LegRightObj.SetActive (true);
			legLeft = LegLeftObj.GetComponent<InfraredSensor> ();
			legRight = LegRightObj.GetComponent<InfraredSensor> ();
		}
	}

	
	// Update is called once per frame
	void Update () {
		GetAngle ();
		MoveFlipper ();
	}

	//Severなら距離センサから値取得
	[ClientCallback]
	void GetAngle(){
		if (isServer) {
			CmdProvideAngleToServer ((legLeft as IFlipperInput).Angle01, (legRight as IFlipperInput).Angle01);
		}
	}

	//angleの値送信
	[Command]
	void CmdProvideAngleToServer(float angleL, float angleR){
		syncAngleL = angleL;
		syncAngleR = angleR;
	}

	//フリッパーを動かす
	void MoveFlipper(){
		flipperL.ChangeFlipper (syncAngleL);
		flipperR.ChangeFlipper (syncAngleR);
	}
}
