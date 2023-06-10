/**************************************
 *** Designer:AL21115
 *** Date:2023.5.23
 *** プレイヤーの移動
 *** Last Editor:AL21115
 *** Last Edited:2023.6.8
***************************************/
using System.Collections;
using System.Collections.Generic;
using Mapbox.Unity.Location;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;
using UnityEngine;
using UnityEngine.UI;
using Mapbox.Unity.Map;
using Unity.Collections;
using static UnityEditor.PlayerSettings;

public class PlayerMoveManager : MonoBehaviour
{
    // 2dマップを管理するクラス
    [SerializeField] private AbstractMap map2d;
    // 3dマップを管理するクラス
    [SerializeField] private AbstractMap map3d;
    //　位置情報を取得するためのクラス
    [SerializeField] private LonLatGetter lonLatGetter;

    //　プレイヤーがキーボードで操作できるようにするためのフラグ(debug用)
    [SerializeField] private bool isOperateMode = false;

    //　キーボードで操作する際の移動スピード
    [SerializeField] private float speed = 2f;
    // ユーザーデータを管理するためのクラス
    [SerializeField] private UserDataManager userDataManager;
    // 距離を取得する間隔
    [SerializeField] private float intervalTime = 10f;
    //　直前の位置
    private Location prevLocation;
    //　今現在の位置
    private Location currentLocation;

    private void Start()
    {
        StartCoroutine(DataUpdate());
    }

    private void Update()
    {
        if (isOperateMode)
            OperateMove();
        else
            MoveByLonLat();
    }

    private void OperateMove()
    {
        //キーボード操作の場合の移動方法WASDで移動する.
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed, 0, 0);
        }
    }

    //　プレイヤー移動処理
    private void MoveByLonLat()
    {
        // 位置情報が取得可能なら
        if (lonLatGetter.CanGetLonLat())
        {
            Vector3 mapPos;
            // map2dを用いて、緯度経度をゲームシーン上の座標に変換する
            // 表示されているマップのよって非アクティブかどうかが異なるため、アクティブになっているマップの方でメソッドを呼び出す必要がある
            if (map2d.gameObject.activeSelf)
            {
                mapPos = map2d.GeoToWorldPosition(new Vector2d(lonLatGetter.location.Latitude, lonLatGetter.location.Longitude), true);
            }
            else
            {
                mapPos = map3d.GeoToWorldPosition(new Vector2d(lonLatGetter.location.Latitude, lonLatGetter.location.Longitude), true);
            }
            //プレイヤーの場所を変更する
            transform.position = new Vector3(mapPos.x, 0.5f, mapPos.z);
            //プレイヤーをスマホが向いている方向に回転させる
            transform.localEulerAngles = new Vector3(0, 0, 360 - Input.compass.trueHeading);
        }
        else
        {
            Debug.Log("計測不可");
        }
    }

    //ある時間間隔kmに変換した後ユーザデータ管理部を更新する
    IEnumerator DataUpdate()
    {
        while (true)
        {
            if (!lonLatGetter.CanGetLonLat())
                break;
            //10秒前の位置
            if (map2d.gameObject.activeSelf)
            {
                prevLocation.Latitude = map2d.WorldToGeoPosition(transform.position).x;
                prevLocation.Longitude = map2d.WorldToGeoPosition(transform.position).y;
            }
            else
            {
                prevLocation.Latitude = map3d.WorldToGeoPosition(transform.position).x;
                prevLocation.Longitude = map3d.WorldToGeoPosition(transform.position).y;
            }
            yield return new WaitForSeconds(intervalTime);
            //10秒経過後の位置
            if (map2d.gameObject.activeSelf)
            {
                currentLocation.Latitude = map2d.WorldToGeoPosition(transform.position).x;
                currentLocation.Longitude = map2d.WorldToGeoPosition(transform.position).y;
            }
            else
            {
                currentLocation.Latitude = map3d.WorldToGeoPosition(transform.position).x;
                currentLocation.Longitude = map3d.WorldToGeoPosition(transform.position).y;
            }
            var addDistance = NaviMath.LatlngDistance(prevLocation, currentLocation);
            Debug.Log(addDistance);
            userDataManager.UpdateDistanceTraveled(addDistance);
        }
    }
}
