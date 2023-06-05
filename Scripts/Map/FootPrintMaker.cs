/**************************************
 *** Designer:AL21115
 *** Date:2023.5.23
 *** 足跡作成
 **************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class FootPrintMaker : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float intervalTime = 1f;

    [SerializeField]
    private GameObject spaceTimeDataManagerObject;
    private SpaceTimeDataManager spaceTimeDataManager;
    // 前回のピン設置時間を格納する変数
    float lastPinPlacementTime = 0.0f;
    [SerializeField] private float adjust = 0f;//足跡が表示する位置の調整
    private LineRenderer line;
    [SerializeField]
    private Material lineMaterial;
    private void Awake()
    {
        lineMaterial.SetTextureScale("_MainTex", new Vector2(-0.5f, 0.5f));
        spaceTimeDataManager = spaceTimeDataManagerObject.GetComponent<SpaceTimeDataManager>();
    }

    private void Start()
    {
        line = gameObject.AddComponent<LineRenderer>();
        line.material = lineMaterial;
        line.positionCount = 0;
        line.loop = false;
        line.startWidth = 1f;                   // 開始点の太さを0.1にする
        line.endWidth = 1f;
        line.textureMode = LineTextureMode.Tile;
        line.positionCount = 0;
        line.loop = false;
        spaceTimeDataManager.Load(SpaceTimeDataManager.GetYYMMDD());
        SpaceTimeData loadData = spaceTimeDataManager.spaceTimeData;
        foreach (SpaceTimeOneData data in loadData.spaceTimeData)
        {
            Vector3 position = data.position;
            line.positionCount++;
            line.SetPosition(line.positionCount - 1, new Vector3(position.x, position.y + adjust, position.z));
        }
    }

    void Update()
    {
        // ピンを設置する時間かどうか確認する
        if (Time.time - lastPinPlacementTime < intervalTime)
        {
            return;
        }
        // プレイヤーの位置にピンを設置する
        Vector3 position = player.position;
        spaceTimeDataManager.AddData(new SpaceTimeOneData(position));
        //線を描写する部分
        line.positionCount++;
        line.SetPosition(line.positionCount-1, new Vector3(position.x, position.y +adjust, position.z));
        // 前回のピン設置時間を更新する
        lastPinPlacementTime = Time.time;
    }
}
