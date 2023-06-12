using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LonlatGetter2 : MonoBehaviour
{
    [SerializeField] private TMP_Text test;
    [SerializeField] private int intervalTime = 5;
    public static LonlatGetter2 Instance { set; get; }

    public float latitude　= 35.6894f;
    public float longitude = 139.6917f;


    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartLocationService());
    }

    private IEnumerator StartLocationService()
    {
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
        {
            test.text = ("GPS not enabled");
            yield break;
        }

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait <= 0)
        {
            test.text = ("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            test.text = ("Unable to determine device location");
            yield break;
        }

        // Set locational infomations
        while (true)
        {
            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;
            yield return new WaitForSeconds(intervalTime);
        }
    }
}
