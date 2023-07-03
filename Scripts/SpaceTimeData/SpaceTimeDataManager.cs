/**************************************
 *** Designer:AL21115
 *** Date:2023.5.23
 *** 時空間情報の管理
 **************************************/
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class SpaceTimeDataManager : MonoBehaviour
{
    private const string SPACETIMEDATA_PREF_KEY = "SpaceTimeData";
    public SpaceTimeData spaceTimeData;
    void Awake()
    {
        Load(GetYYMMDD());
    }

    public void Load(string yymmdd)
    {
        if (PlayerPrefs.HasKey(SPACETIMEDATA_PREF_KEY+yymmdd))
        {
            string loadjson = PlayerPrefs.GetString(SPACETIMEDATA_PREF_KEY+yymmdd);
            spaceTimeData = JsonUtility.FromJson<SpaceTimeData>(loadjson);
        }
        else
        {
            spaceTimeData= new SpaceTimeData();
            spaceTimeData.dataList= new List<SpaceTimeOneData>();
        }
    }

    private void Save(string yymmdd)
    {
        string savejson = JsonUtility.ToJson(spaceTimeData);
        PlayerPrefs.SetString(SPACETIMEDATA_PREF_KEY+yymmdd, savejson);
        PlayerPrefs.Save();
    }

    public void AddData(SpaceTimeOneData addData)
    {
        spaceTimeData.dataList.Add(addData);
    }

    public static string GetYYMMDD()
    {
        DateTime currentDate = DateTime.Today;
        string dateString = currentDate.ToString("yyyy-MM-dd");
        return dateString;
    }

    private void OnDestroy()
    {
        Save(GetYYMMDD());
    }
}
