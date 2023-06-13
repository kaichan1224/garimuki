/**************************************
 *** Designer:AL21115
 *** Date:2023.5.23
 *** マップの拡大移動処理
 **************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの場所を追跡するようにカメラを移動させるためのモジュール
/// </summary>
public class MapCamera2dManager : MonoBehaviour
{
    //　プレイヤーのtransformをインスペクターから取得する
    [SerializeField] private Transform player;

    /// <summary>
    ///　カメラがプレイヤーに追従する処理を行うメソッド
    /// </summary>
    void Update()
    {
        transform.position = new Vector3(player.position.x,transform.position.y,player.position.z);
    }
}
