/**************************************
 *** Designer:AL21115
 *** Date:2023.6.13
 *** 位置情報取得
 **************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// 位置情報取得を行うモジュール
/// </summary>
public class LonlatGetter : MonoBehaviour
{
    //位置情報の取得間隔
    [SerializeField] private int intervalTime = 5;
    public static LonlatGetter Instance { set; get; }

    //経度
    public float latitude　= 35.6894f;
    //緯度
    public float longitude = 139.6917f;


    /// <summary>
    /// 位置情報取得処理を開始するメソッド
    /// </summary>
    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartLocationService());
    }

    /// <summary>
    /// 位置情報を定期的に取得する非同期処理メソッド
    /// </summary>
    /// <returns>待ち時間</returns>
    private IEnumerator StartLocationService()
    {
        // ユーザーが位置情報を取得可能にしているか
        if (!Input.location.isEnabledByUser)
        {
            yield break;
        }

        // 位置情報取得開始
        Input.location.Start();
        Input.compass.enabled = true;

        // 取得時間が20秒超えたら取得できないようにする
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait <= 0)
        {
            yield break;
        }

        // 接続がされていない時
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            yield break;
        }

        // 位置情報を定期的に取得
        while (true)
        {
            //経度取得
            latitude = Input.location.lastData.latitude;
            //緯度取得
            longitude = Input.location.lastData.longitude;
            yield return new WaitForSeconds(intervalTime);
        }
    }
}
