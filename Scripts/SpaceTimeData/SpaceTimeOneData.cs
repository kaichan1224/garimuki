/**************************************
 *** Designer:AL21053
 *** Date:2023.6.13
 *** 時空間情報ユニット
 **************************************/


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpaceTimeOneData
{
    public Vector3 position;
    public SpaceTimeOneData(Vector3 position)
    {
        this.position = position;
    }
}