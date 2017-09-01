using UnityEngine;
using System.Collections;

public class music : MonoBehaviour
{
    private AudioSource audioSource;        // AudioSorceを格納する変数の宣言.
    public AudioClip sound;             // 効果音を格納する変数の宣言.

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();   // AudioSorceコンポーネントを追加し、変数に代入.
        audioSource.clip = sound;       // 鳴らす音(変数)を格納.
        audioSource.loop = false;       // 音のループなし。

    }

    void OnCollisionEnter(Collision other)
    {

        audioSource.Play();     // 音を鳴らす.
    }


}
