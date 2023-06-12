/**************************************
 *** Designer:AL21115
 *** Date:2023.5.23
 *** ユーザ情報を管理するクラス
 **************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Unity.VisualScripting;

public class UserDataManager : MonoBehaviour
{
    private const string USERDATA_PREF_KEY = "UserData";
    private UserData userData;//ロードしたデータが格納される
    public ReactiveProperty<double> distanceTraveled = new();
    public ReactiveProperty<int> consecutiveLoginDay = new();
    public ReactiveProperty<int> exp = new();
    public ReactiveProperty<int> level = new();
    public ReactiveProperty<float> totalPlayHours = new();
    public ReactiveProperty<int> maxConsecutiveLoginsDay = new();
    public ReactiveProperty<float> totalKcal = new();

    /// <summary>
    /// 最初にデータをロードするメソッドを呼ぶ
    /// </summary>
    private void Awake()
    {
        Load();
    }

    /// <summary>
    /// データをロードするメソッド.データが存在しなければ新規作成する
    /// </summary>
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
            userData.consecutiveLoginDay = 0;
            userData.exp = 0;
            userData.level = 1;
            userData.totalPlayHours = 0f;
            userData.maxConsecutiveLoginsDay = 0;
            userData.totalKcal = 0f;
        }
        SetReactivePropertys();
    }

    public void SetReactivePropertys()
    {
        distanceTraveled.Value = userData.distanceTraveled;
        consecutiveLoginDay.Value = userData.consecutiveLoginDay;
        exp.Value = userData.exp;
        level.Value = userData.level;
        totalPlayHours.Value = userData.totalPlayHours;
        maxConsecutiveLoginsDay.Value = userData.maxConsecutiveLoginsDay;
        totalKcal.Value = userData.totalKcal;
    }


    /// <summary>
    /// データをセーブするメソッド
    /// </summary>
    public void Save()
    {
        string savejson = JsonUtility.ToJson(userData);
        PlayerPrefs.SetString(USERDATA_PREF_KEY, savejson);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// 距離を増加させるクラス
    /// </summary>
    /// <param name="moveDistance">増加する</param>
    public void UpdateDistanceTraveled(double moveDistance)
    {
        distanceTraveled.Value += moveDistance;
    }
    /// <summary>
    /// 消費カロリーを計算するクラス
    /// </summary>
    /// <returns></returns>
    public double CalculateCaloriesBurned(double moveDistance)
    {
        double weight = 70d;
        // 消費カロリーの計算式（例としてMET（代謝当量）を使用）
        // MET値は活動の強度によって異なる値を使用する必要があります
        // ここでは簡略化のために一定のMET値を使用しています
        double metValue = 3.5d;  // 適切なMET値を設定してください
        // 移動距離をメートルに変換
        double distanceInMeter = moveDistance * 1000d;
        // 消費カロリーの計算
        double calories = metValue * weight * distanceInMeter / 1000f;

        return calories;
    }
   
    /// <summary>
    /// 経験値を増加させるクラス
    /// 一定量を超えたらレベルも増加する
    /// </summary>
    /// <param name="addExp">増加する経験値の量</param>
    public void UpdateExp(int addExp)
    {
        exp.Value += addExp;
        // TODO　レベルアップ場合分け
        // TODO　必要な経験値を計算するメソッド作成
    }

    /// <summary>
    /// 総kcalを計算するクラス
    /// </summary>
    /// <param name="moveDistance"></param>
    public void UpdatetotalKcal(float addKcal)
    {
        totalKcal.Value += addKcal;
    }

    private void OnDestroy()
    {
        userData.distanceTraveled  = distanceTraveled.Value;
        userData.consecutiveLoginDay = consecutiveLoginDay.Value;
        userData.exp = exp.Value;
        userData.level = level.Value;
        userData.totalPlayHours = totalPlayHours.Value;
        userData.maxConsecutiveLoginsDay = maxConsecutiveLoginsDay.Value;
        userData.totalKcal = totalKcal.Value;
        Save();
    }
}
