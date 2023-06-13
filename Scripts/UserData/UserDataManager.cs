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

/// <summary>
/// ユーザ情報を管理するモジュール
/// </summary>
public class UserDataManager : MonoBehaviour
{
    //ユーザーデータを管理するキー(重要なデータではないためそのまま記述してある)
    private const string USERDATA_PREF_KEY = "UserData";
    //ユーザデータを管理するクラス
    private UserData userData;
    //移動距離
    public ReactiveProperty<double> distanceTraveled = new();
    //現在の連続ログイン数
    public ReactiveProperty<int> consecutiveLoginDay = new();
    //経験値
    public ReactiveProperty<int> exp = new();
    //レベル　
    public ReactiveProperty<int> level = new();
    //トータルプレイ時間
    public ReactiveProperty<float> totalPlayHours = new();
    //最高連続ログイン数
    public ReactiveProperty<int> maxConsecutiveLoginsDay = new();
    //累計消費kカロリー
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
        //キーが既に存在したら->既にデータが存在するとき
        if (PlayerPrefs.HasKey(USERDATA_PREF_KEY))
        {
            string loadjson = PlayerPrefs.GetString(USERDATA_PREF_KEY);
            userData = JsonUtility.FromJson<UserData>(loadjson);
            Debug.Log(userData);
        }
        //データが存在しない時、初期生成する
        else
        {
            userData = new UserData();
            userData.distanceTraveled = 0;
            userData.consecutiveLoginDay = 0;
            userData.exp = 0;
            userData.level = 1;
            userData.totalPlayHours = 0f;
            userData.maxConsecutiveLoginsDay = 0;
            userData.totalKcal = 0f;
        }
        SetReactivePropertys();
    }

    /// <summary>
    /// 変数をUIから監視できるようにするためのメソッド
    /// </summary>
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
        Debug.Log($"[UpdateDistanceTraveled]{distanceTraveled.Value}");
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
