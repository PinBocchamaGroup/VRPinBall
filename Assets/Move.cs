using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{

    public Transform player;    //プレイヤーを代入
    public float speed = 1; //移動速度
    public float limitDistance = 1000f; //敵キャラクターがどの程度近づいてくるか設定(この値以下には近づかない）

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("hos").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.position;                 //プレイヤーの位置
        Vector3 direction = playerPos - transform.position; //方向と距離を求める。
        float distance = direction.sqrMagnitude;            //directionから距離要素だけを取り出す。
        direction = direction.normalized;                   //単位化（距離要素を取り除く）

        direction = direction.normalized;   //単位化（距離要素を取り除く）
        transform.LookAt(player);   //プレイヤーの方を向く

        Vector3 angle = transform.eulerAngles;
        angle.y = -180;
        transform.eulerAngles = angle;

        //プレイヤーの距離が一定以上でなければ、敵キャラクターはプレイヤーへ近寄ろうとしない
        if (distance >= limitDistance)
        {

            //プレイヤーとの距離が制限値以上なので普通に近づく
            transform.position = transform.position + (direction * speed * Time.deltaTime);

        }
        else if (distance < limitDistance)
        {

            //プレイヤーとの距離が制限値未満（近づき過ぎ）なので、後退する。
            transform.position = transform.position - (direction * speed * Time.deltaTime);
        }
    }
}