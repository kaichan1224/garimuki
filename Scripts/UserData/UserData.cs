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
    //総消費kcal
    public double totalKcal;
    //現在のexp
    public int exp;
    //現在のレベル
    public int level;
    //テイムした動物の数
    public int tameCnt;
    //次回経験値を獲得するのに必要な移動距離
    public double nextRequiredDistance;
    //既にNormalの見た目に変化したかどうかのフラグ
    public bool isNormal;
    //既にMukimukiの見た目に変化したかどうかのフラグ
    public bool isMukimuki;
    //キャラクターの名前
    public string name;
    //オペレートモード
    public bool isOperate;
}
