using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Spinner : NetworkBehaviour {
	//SyncVar: ホストサーバーからクライアントへ送られる
	//プレイヤーの角度
	[SyncVar] private Quaternion syncSpinnerRotation;

	[SerializeField] private float lerpRate = 15;

	private Quaternion lastSpinnerRot;

	private float threshold = 5;

	// Use this for initialization
	void Start () {
		lastSpinnerRot = transform.rotation;
		syncSpinnerRotation = Quaternion.identity;
	}

	// Update is called once per frame
	void Update () {
		if (isServer) {
			//クライアント側のPlayerの角度を取得
			TransmitRotations ();
		} else {
			//現在角度と取得した角度を補間する
			LerpRotations ();
		}
	}

	//角度を補間するメソッド
	void LerpRotations ()
	{
		//プレイヤーの角度とカメラの角度を補間
		transform.rotation = Quaternion.Lerp (transform.rotation,
			syncSpinnerRotation, Time.deltaTime * lerpRate);
	}

	//クライアントからホストへ送られる
	[Command]
	void CmdProvideRotationToServer (Quaternion spinnerRot)
	{
		syncSpinnerRotation = spinnerRot;
	}

	//クライアント側だけが実行できるメソッド
	[ClientCallback]
	void TransmitRotations ()
	{
		if (Quaternion.Angle (transform.rotation, lastSpinnerRot) > threshold) {
			CmdProvideRotationToServer (transform.rotation);
			lastSpinnerRot = transform.rotation;
		}
	}
}
