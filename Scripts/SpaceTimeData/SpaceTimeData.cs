/**************************************
 *** Designer:AL21115
 *** Date:2023.5.23
 *** 時空間情報のデータクラス
 **************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpaceTimeData
{
    public List<SpaceTimeOneData> dataList;
}

[Serializable]
public class SpaceTimeOneData
{
    public Vector3 position;
    public SpaceTimeOneData(Vector3 position)
    {
        this.position = position;
    }
}
