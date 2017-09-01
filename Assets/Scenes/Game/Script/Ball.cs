using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Ball : NetworkBehaviour {

	//ホストから全クライアントへ送られる
	[SyncVar]
	private Vector3 syncPos;
	[SyncVar]
	private Vector3 syncVel;

	//Lerp: ２ベクトル間を補間する
	[SerializeField] float lerpRate = 15;

	Rigidbody rigid;

	void Start(){
		rigid = GetComponent<Rigidbody> ();
	}

	void Update ()
	{
		if (isServer) {
			TransmitPosition (); 
			DeleteBall ();
		}else{
			LerpPosition();	//2点間を補間する
		}
	}

	//ポジション補間用メソッド
	void LerpPosition ()
	{
		//Lerp(from, to, 割合) from〜toのベクトル間を補間する
		transform.position = Vector3.Lerp(transform.position, syncPos, Time.deltaTime * lerpRate);
		rigid.velocity = syncVel;

	}
	//クライアントからホストへ、Position情報を送る
	[Command]
	void CmdProvidePositionToServer (Vector3 pos, Vector3 vel)
	{
		//サーバー側が受け取る値
		syncPos = pos;
		syncVel = vel;
	}

	//クライアントのみ実行される
	[ClientCallback]
	//位置情報を送るメソッド
	void TransmitPosition ()
	{
		CmdProvidePositionToServer(transform.position, rigid.velocity);
	}

	//画面中のボール削除
	void DeleteBall(){
		if (Input.GetKeyDown (KeyCode.D)) {
			Destroy (this.gameObject);
		}
	}
}
