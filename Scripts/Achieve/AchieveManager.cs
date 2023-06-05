/**************************************
 *** Designer:AL21115
 *** Date:2023.5.19
 *** Purpose:達成項目の管理を行う
 **************************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using System.Reflection;


public class AchieveManager : MonoBehaviour
{
    //アチーブメントの中身
    [SerializeField] private List<Achievement> achievements;
    //アチーブメントオブジェクト(UI)
    [SerializeField] private List<GameObject> achievementObjects;
    [SerializeField] private GameObject userDataManagerObject;
    private UserDataManager userDataManager;

    private void Awake()
    {
        userDataManager = userDataManagerObject.GetComponent<UserDataManager>();
    }

    private void Start()
    {
        ResetAchieve();
        StartCoroutine(UpdateUsertoAchieve());
    }

    private void ResetAchieve()
    {
        //各アチーブメントの中身を動的に生成
        for (int index = 0; index < achievements.Count; index++)
        {
            Achievement achievement = achievements[index];
            GameObject achievementObject = achievementObjects[index];
            achievementObject.transform.Find("Icon").GetComponent<Image>().sprite = achievement.icon;
            achievementObject.transform.Find("Text_Achieve").GetComponent<TMP_Text>().text = achievement.name;
            achievementObject.transform.Find("Silder/Text").GetComponent<TMP_Text>().text = achievement.currentprogress.ToString() + "/" + achievement.maxprogress.ToString()+achievement.unit;
            achievementObject.transform.Find("Silder").GetComponent<Slider>().maxValue = achievement.maxprogress;
            achievementObject.transform.Find("Silder").GetComponent<Slider>().value = achievement.currentprogress;
        }
    }

    //アチーブメント名を指定して、達成率を更新する.アチーブメントオブジェクトの中身も更新する.
    public void UpdateAchievementProgress(string achievementName,int currentprogress)
    {
        Achievement achievement = achievements.Find(x => x.name == achievementName);
        achievement.currentprogress = currentprogress;
        if (achievement.isAchieved)
            return;
        GameObject achievementObject = achievementObjects[achievements.IndexOf(achievement)];
        achievementObject.transform.Find("Silder/Text").GetComponent<TMP_Text>().text = achievement.currentprogress.ToString() + "/" + achievement.maxprogress.ToString();
        achievementObject.transform.Find("Silder").GetComponent<Slider>().value = achievement.currentprogress;
        if (achievement.currentprogress >= achievement.maxprogress)
            achievement.isAchieved = true;
    }

    //ユーザ情報からachievementsを更新する
    IEnumerator UpdateUsertoAchieve()
    {
        while (true)
        {
            //距離に関するアチーブメント
            double distance = userDataManager.GetDistanceTraveled();
            UpdateAchievementProgress("TravelDistanceLv1", (int)distance);
            UpdateAchievementProgress("TravelDistanceLv2", (int)distance);
            UpdateAchievementProgress("TravelDistanceLv3", (int)distance);
            //連続ログインに関するアチーブメント
            int consecutiveLogins = userDataManager.GetconsecutiveLogins();
            UpdateAchievementProgress("Login1week", consecutiveLogins);
            UpdateAchievementProgress("Login1month", consecutiveLogins);
            UpdateAchievementProgress("Login1year", consecutiveLogins);
            //都道府県に関するアチーブメント
            //int visitedPrefCnt = userDataManager.GetVisitedPrefectureCnt();
            //UpdateAchievementProgress("KantoMaster", consecutiveLogins);
            //UpdateAchievementProgress("ZenkokuMaster", consecutiveLogins);
            yield return new WaitForSeconds(60);
        }
    }
}
