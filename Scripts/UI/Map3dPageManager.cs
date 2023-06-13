/**************************************
 *** Designer:AL21115
 *** Date:2023.5.23
 *** 3dMapのページのUI処理
 **************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 3dマップページにおけるUIの処理を行うモジュール
/// </summary>
public class Map3dPageManager : MonoBehaviour
{
    //3dと2dを切り替えるボタン
    [SerializeField] private Button mapSwitchButton;
    //プロフィールに飛ぶボタン
    [SerializeField] private Button playerInfoPageButton;
    //メニューに飛ぶボタン
    [SerializeField] private Button menuButton;
    //メニューページ
    [SerializeField] private GameObject menuPage;
    //2dマップのページ
    [SerializeField] private GameObject map2dPage;
    //2dマップを表示するカメラ
    [SerializeField] private GameObject camera2d;
    //3dマップを表示するカメラ
    [SerializeField] private GameObject camera3d;
    //2dマップ
    [SerializeField] private GameObject map2d;
    //3dマップ
    [SerializeField] private GameObject map3d;
    //ユーザー情報ページ
    [SerializeField] private GameObject playerInfoPage;
    /// <summary>
    /// 3dマップページを起動した時に処理を行うメソッド
    /// </summary>
    private void OnEnable()
    {
        //マップスイッチボタンを押された時の処理を行う
        mapSwitchButton.onClick.AddListener(()=>
        {
            map2dPage.SetActive(true);
            camera3d.SetActive(false);
            camera2d.SetActive(true);
            map3d.SetActive(false);
            map2d.SetActive(true);
            this.gameObject.SetActive(false);
        });
        //メニューボタンを押した時の処理を行う
        menuButton.onClick.AddListener(() =>
        {
            menuPage.SetActive(true);
            this.gameObject.SetActive(false);
        });
        //ユーザ情報ページボタンを押した時の処理を行う
        playerInfoPageButton.onClick.AddListener(() =>
        {
            playerInfoPage.SetActive(true);
            this.gameObject.SetActive(false);
        });
    }
}
