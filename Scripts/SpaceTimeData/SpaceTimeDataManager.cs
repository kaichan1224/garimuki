/**************************************
 *** Designer:AL21053
 *** Date:2023.6.17
 *** 時空間情報の管理
 **************************************/
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class SpaceTimeDataManager : MonoBehaviour
{
    public SpaceTimeData spaceTimeData;
    void Start()
    {
        if (System.IO.File.Exists(Application.persistentDataPath + "/" + GetYYMMDD() + ".json") == false)
        {
            ResetData();
        }
    }

    public void Load(string yymmdd)
    {
        string data = "";
        StreamReader reader;
        reader = new StreamReader(Application.persistentDataPath + "/"+yymmdd+".json");
        data = reader.ReadToEnd();
        reader.Close();
        spaceTimeData = JsonUtility.FromJson<SpaceTimeData>(data);
    }

    private void Save(SpaceTimeData saveData)
    {
        StreamWriter writer;
        string jsonData = JsonUtility.ToJson(saveData);
        writer = new StreamWriter(Application.persistentDataPath + "/"+GetYYMMDD()+".json", false);
        writer.Write(jsonData);
        writer.Flush();
        writer.Close();
    }

    public void AddData(SpaceTimeOneData addData)
    {
        spaceTimeData.spaceTimeData.Add(addData);
    }

    public static string GetYYMMDD()
    {
        DateTime currentDate = DateTime.Today;
        string dateString = currentDate.ToString("yyyy-MM-dd");
        return dateString;
    }

    public void ResetData()
    {
        SpaceTimeData data = new SpaceTimeData();
        Save(data);
    }

    private void OnDestroy()
    {
        Save(spaceTimeData);
    }
}
