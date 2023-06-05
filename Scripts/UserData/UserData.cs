/**************************************
 *** Designer:AL21115
 *** Date:2023.5.23
 *** ユーザ情報のデータクラス
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
    public int consecutiveLogins;
    //前回のログイン日
    //public string lastLoginDate;
    //行ったことがある県
    public HashSet<string> visitedPrefectures;
}
