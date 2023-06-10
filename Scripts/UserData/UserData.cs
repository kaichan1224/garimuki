/**************************************
 *** Designer:AL21115
 *** Date:2023.5.23
 *** ユーザ情報のデータクラス
 *** Last Editor:AL21115
 *** Last Edited Date:2023.6.10
 **************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UserData
{
    //移動距離
    public double distanceTraveled;
    //連続ログイン数
    public int consecutiveLoginDay;
    //最高ログイン数
    public int maxConsecutiveLoginsDay;
    //プレイ時間
    public float totalPlayHours;
    //総消費kcal
    public float totalKcal;
    //現在のexp
    public int exp;
    //現在のレベル
    public int level;
}
