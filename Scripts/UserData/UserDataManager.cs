/**************************************
 *** Designer:AL21115
 *** Date:2023.5.23
 *** ユーザ情報を管理するクラス
 **************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataManager : MonoBehaviour
{
    private const string USERDATA_PREF_KEY = "UserData";
    [SerializeField] private UserData userData;//ロードしたデータが格納される

    /// <summary>
    /// データをLoadするクラス.データが存在しなければ新規作成する
    /// </summary>
    private void Awake()
    {
        Load();
    }
    public void Load()
    {
        if (PlayerPrefs.HasKey(USERDATA_PREF_KEY))
        {
            string loadjson = PlayerPrefs.GetString(USERDATA_PREF_KEY);
            userData = JsonUtility.FromJson<UserData>(loadjson);
        }
        else
        {
            userData = new UserData();
            userData.distanceTraveled = 0f;
            userData.visitedPrefectures = new HashSet<string>();
        }
    }

    public void Save()
    {
        string savejson = JsonUtility.ToJson(userData);
        PlayerPrefs.SetString(USERDATA_PREF_KEY, savejson);
        PlayerPrefs.Save();
    }

    public void AddPrefecture(string prefectureName)
    {
        userData.visitedPrefectures.Add(prefectureName);
    }

    public int GetVisitedPrefectureCnt()
    {
        return userData.visitedPrefectures.Count; 
    }

    public double GetDistanceTraveled()
    {
        return userData.distanceTraveled;
    }


    public void UpdateDistanceTraveled(double moveDistance)
    {
        userData.distanceTraveled += moveDistance;
    }

    private void OnDestroy()
    {
        Save();
    }

    public int GetconsecutiveLogins()
    {
        return userData.consecutiveLogins;
    }
}
