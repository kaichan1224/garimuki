using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlay : MonoBehaviour
{
    private AudioSource Audio;//AudioSourceを入れる
    bool isAudioStart = false; //曲再生の判定
    [SerializeField] private float destoryLimit;
    void Start()
    {
        Audio = GetComponent<AudioSource>();//AudioSourceの取得
        Audio.Play();//AudioSourceを再生
        isAudioStart = true;//曲の再生を判定
    }
    void Update()
    {
        if (!Audio.isPlaying && isAudioStart)
        //曲が再生されていない、尚且つ曲の再生が開始されている時
        {
            Destroy(gameObject,destoryLimit);//オブジェクトを消す
        }
    }
}

