/**************************************
 *** Designer:AL21115
 *** Date:2023.5.23
 *** 位置情報取得
 **************************************/
using System.Collections;
using UnityEngine;

/// <summary>経緯度取得クラス</summary>
public class LonLatGetter : MonoBehaviour
{
    /// <summary>経緯度取得間隔（秒）</summary>
    [SerializeField]
    private float IntervalSeconds = 1.0f;

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
        while (true)
        {
            GetLocation();
            yield return new WaitForSeconds(IntervalSeconds);
        }
    }

    private void GetLocation()
    {
        locationServiceStatus = Input.location.status;
        if (Input.location.isEnabledByUser)
        {
            switch (locationServiceStatus)
            {
                case LocationServiceStatus.Stopped:
                    Input.compass.enabled = true;
                    Input.location.Start();
                    break;
                case LocationServiceStatus.Running:
                    location.Longitude = Input.location.lastData.longitude;
                    location.Latitude = Input.location.lastData.latitude;
                    break;
                default:
                    break;
            }
        }
    }


}