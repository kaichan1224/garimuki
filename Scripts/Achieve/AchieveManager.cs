/**************************************
 *** Designer:AL21115
 *** Date:2023.5.19
 *** Purpose:達成項目の管理を行う
 *** Last Editor:AL21115
 *** Last Edited Date:2023.6.10
 **************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using System.Reflection;
using UniRx;

// TODO　全体的に置き換える
public class AchieveManager : MonoBehaviour
{
    //アチーブメントの中身
    [SerializeField] private List<Achievement> achievements;
    //アチーブメントオブジェクト(UI)
    [SerializeField] private List<GameObject> achievementObjects;

    [SerializeField] private UserDataManager userDataManager;
    private void Start()
    {
        ResetAchieve();
        StartCoroutine(UpdateUsertoAchieve());
    }

    /// <summary>
    /// アチーブメントの中身を動的に生成
    /// </summary>
    private void ResetAchieve()
    {
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

    /// <summary>
    /// アチーブメント名を指定して、達成率を更新する.アチーブメントオブジェクトの中身も更新する.
    /// </summary>
    /// <param name="achievementName">更新するアチーブメントの名前</param>
    /// <param name="currentprogress">アチーブメントの項目に関する現在の数値</param>
    public void UpdateAchievementProgress(string achievementName,int currentprogress)
    {
        //指定した名前のアチーブメントを取得
        Achievement achievement = achievements.Find(x => x.name == achievementName);
        //達成率を更新
        achievement.currentprogress = currentprogress;
        //既に達成していたら処理終了
        if (achievement.isAchieved)
            return;
        //指定したアチーブメントの表示を更新する
        GameObject achievementObject = achievementObjects[achievements.IndexOf(achievement)];
        //テキストの更新
        achievementObject.transform.Find("Silder/Text").GetComponent<TMP_Text>().text = achievement.currentprogress.ToString() + "/" + achievement.maxprogress.ToString();
        //Sliderの更新
        achievementObject.transform.Find("Silder").GetComponent<Slider>().value = achievement.currentprogress;
        if (achievement.currentprogress >= achievement.maxprogress)
            achievement.isAchieved = true;
    }

    /// <summary>
    /// ユーザ情報からachievementsを更新する
    /// TODO 60秒の定期実行：Unirxに置き換えれるなら置き換えた方が良い
    /// </summary>
    /// <returns>待ち時間60秒</returns>
    IEnumerator UpdateUsertoAchieve()
    {
        while (true)
        {
            //距離に関するアチーブメント
            double distance = userDataManager.distanceTraveled.Value;
            UpdateAchievementProgress("TravelDistanceLv1", (int)distance);
            UpdateAchievementProgress("TravelDistanceLv2", (int)distance);
            UpdateAchievementProgress("TravelDistanceLv3", (int)distance);
            //テイム数に関するアチーブメント
            int tameCnt = userDataManager.userData.tameCnt;
            UpdateAchievementProgress("BegginerHunter", tameCnt);
            UpdateAchievementProgress("IntermediateHunter", tameCnt);
            UpdateAchievementProgress("AdvancedHunter", tameCnt);
            //テイムの種類に関するアチーブメント
            int tameSort = 0;
            UpdateAchievementProgress("TameMaster", tameSort);
            yield return new WaitForSeconds(60);
        }
    }
}
