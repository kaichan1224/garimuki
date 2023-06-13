/**************************************
 *** Designer:AL21115
 *** Date:2023.5.23
 *** 2dMapのページのUI処理
 **************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 2dマップページにおけるUIの処理を行うモジュール
/// </summary>
public class Map2dPageManager : MonoBehaviour
{
    //3dと2dを切り替えるボタン
    [SerializeField] private Button mapSwitchButton;
    //メニューに飛ぶボタン
    [SerializeField] private Button menuButton;
    //メニューページ
    [SerializeField] private GameObject menuPage;
    //3dマップのページ
    [SerializeField] private GameObject map3dPage;
    //2dマップを表示するカメラ
    [SerializeField] private GameObject camera2d;
    //3dマップを表示するカメラ
    [SerializeField] private GameObject camera3d;
    //2dマップ
    [SerializeField] private GameObject map2d;
    //3dマップ
    [SerializeField] private GameObject map3d;
    /// <summary>
    /// 2dマップページを起動した時に処理を行うメソッド
    /// </summary>
    private void OnEnable()
    {
        //マップスイッチボタンを押された時の処理を行う
        mapSwitchButton.onClick.AddListener(() =>
        {
            map3dPage.SetActive(true);
            camera3d.SetActive(true);
            camera2d.SetActive(false);
            map3d.SetActive(true);
            map2d.SetActive(false);
            this.gameObject.SetActive(false);
        });
        //メニューボタンを押した時の処理を行う
        menuButton.onClick.AddListener(() =>
        {
            menuPage.SetActive(true);
            this.gameObject.SetActive(false);
        });
    }
}
