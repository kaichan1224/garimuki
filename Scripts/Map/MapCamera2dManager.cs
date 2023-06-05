/**************************************
 *** Designer:AL21115
 *** Date:2023.5.23
 *** マップの拡大移動処理
 **************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCamera2dManager : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    void Update()
    {
        transform.position = new Vector3(player.position.x,transform.position.y,player.position.z);
    }
}
