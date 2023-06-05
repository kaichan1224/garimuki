/**************************************
 *** Designer:AL21115
 *** Date:2023.5.23
 *** プレイヤーの移動
 **************************************/
using System.Collections;
using System.Collections.Generic;
using Mapbox.Unity.Location;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;
using UnityEngine;
using UnityEngine.UI;
using Mapbox.Unity.Map;
using Unity.Collections;

public class PlayerMoveManager : MonoBehaviour
{
    [SerializeField] private AbstractMap map2d;
    [SerializeField] private AbstractMap map3d;

    [SerializeField] private LonLatGetter lonLatGetter;

    [SerializeField]
    private bool isOperateMode = false;

    [SerializeField]
    private float speed = 2f;

    [SerializeField]
    private GameObject userDataManagerObject;

    private UserDataManager userDataManager;
    private Location prevLocation;
    private Location currentLocation;

    private void Awake()
    {
        userDataManager = userDataManagerObject.GetComponent<UserDataManager>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (!isOperateMode)
        {
            if (lonLatGetter.CanGetLonLat())
            {
                Vector3 mapPos;
                if (map2d.gameObject.activeSelf)
                {
                    prevLocation.Latitude = map2d.WorldToGeoPosition(transform.position).x;
                    prevLocation.Longitude = map2d.WorldToGeoPosition(transform.position).y;
                    mapPos = map2d.GeoToWorldPosition(new Vector2d(lonLatGetter.location.Latitude, lonLatGetter.location.Longitude), true);
                }
                else
                {
                    prevLocation.Latitude = map3d.WorldToGeoPosition(transform.position).x;
                    prevLocation.Longitude = map3d.WorldToGeoPosition(transform.position).y;
                    mapPos = map3d.GeoToWorldPosition(new Vector2d(lonLatGetter.location.Latitude, lonLatGetter.location.Longitude), true);
                }
                transform.position = new Vector3(mapPos.x, 0.5f, mapPos.z);
                transform.localEulerAngles = new Vector3(0, 0, 360 - Input.compass.trueHeading);//プレイヤーの回転
                currentLocation.Latitude = map2d.WorldToGeoPosition(transform.position).x;
                currentLocation.Longitude = map2d.WorldToGeoPosition(transform.position).y;
                DataUpdate();
            }
            else
            {
                Debug.Log("計測不可");
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += new Vector3(0,0,speed);
            }
            if(Input.GetKey(KeyCode.A))
            {
                transform.position += new Vector3(-speed, 0,0);
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
    }

    private void DataUpdate()
    {
        userDataManager.UpdateDistanceTraveled(NaviMath.LatlngDistance(prevLocation,currentLocation));
    }
}
