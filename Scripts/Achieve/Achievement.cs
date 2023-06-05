/**************************************
 *** Designer:AL21115
 *** Date:2023.5.23
 *** 達成項目のデータクラス
 **************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Achievement
{
    public string name;//アチーブメントの名前
    public string description;//説明
    public Sprite icon;//アイコン
    public int currentprogress;//現在の進捗率
    public int maxprogress;
    public string unit;
    public bool isAchieved;//達成したかどうか

    // コンストラクタ
    public Achievement(string name, string description, Sprite icon)
    {
        this.name = name;
        this.description = description;
        this.icon = icon;
        isAchieved = false;
    }
}

