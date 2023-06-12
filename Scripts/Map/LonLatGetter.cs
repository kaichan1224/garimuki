/**************************************
 *** Designer:AL21115
 *** Date:2023.5.23
 *** 位置情報取得
 **************************************/
using System.Collections;
using UnityEngine;
using TMPro;

/// <summary>経緯度取得クラス</summary>
public class LonLatGetter : MonoBehaviour
{
    /// <summary>経緯度取得間隔（秒）</summary>
    [SerializeField]
    private float IntervalSeconds = 1f;
    [SerializeField] private TMP_Text test;
    [SerializeField] private TMP_Text test2;

    /// <summary>ロケーションサービスのステータス</summary>
    private LocationServiceStatus locationServiceStatus;

    //　緯度経度
    public Location location;

    /// <summary>緯度経度情報が取得可能か</summary>
    /// <returns>可能ならtrue、不可能ならfalse</returns>
    public bool CanGetLonLat()
    {
        return Input.location.isEnabledByUser;
    }

    /// <summary>経緯度取得処理</summary>
    /// <returns>一定期間毎に非同期実行するための戻り値</returns>
    private IEnumerator Start()
    {
        test.text = "Start";
        while (true)
        {
            GetLocation();
            Debug.Log(1);
            yield return new WaitForSeconds(IntervalSeconds);
        }
    }

    private void GetLocation()
    {
        locationServiceStatus = Input.location.status;
        if (Input.location.isEnabledByUser)
        {
            test.text = "GetLocation";
            switch (locationServiceStatus)
            {
                case LocationServiceStatus.Stopped:
                    //Input.compass.enabled = true;
                    Input.location.Start();
                    test2.text = "Stop";
                    break;
                case LocationServiceStatus.Running:
                    location.Longitude = Input.location.lastData.longitude;
                    location.Latitude = Input.location.lastData.latitude;
                    test2.text = "Run";
                    break;
                default:
                    test2.text = "ELSE";
                    break;
            }
            test.text += location.Longitude.ToString();
        }
        else
        {
            test.text = "GetLocation NG";
        }
    }


}