using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using UnityEngine.UI;

public class DisplayIPadress : MonoBehaviour {

	public GameObject IpAdressObj;

	// Use this for initialization
	void Start () {

		string targetSheet = "IP address取得";
		// ホスト名を取得する
		string hostname = Dns.GetHostName ();
		Debug.Log ("hostname=" + hostname);

		// ホスト名からIPアドレスを取得する
		IPAddress[] adrList = Dns.GetHostAddresses (hostname);
		foreach (IPAddress address in adrList) {
			Debug.Log (address.ToString ());
			IpAdressObj.GetComponent<Text> ().text = "IP : " + address;
		}
	}
}
