/**************************************
 *** Designer:AL21115
 *** Date:2023.5.23
 *** メニューのページのUI処理
 **************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// メニューページにおけるUIの処理を行うモジュール
/// </summary>
public class MenuPageManager : MonoBehaviour
{
    //閉じるボタン
    [SerializeField] private Button closeButton;
    //設定ページへ飛ぶボタン
    [SerializeField] private Button settingButton;
    //達成ページへ飛ぶボタン
    [SerializeField] private Button achieveButton;
    //検索ページへ飛ぶボタン
    [SerializeField] private Button searchButton;

    //3dマップページ
    [SerializeField] private GameObject map3dPage;
    //設定ページ
    [SerializeField] private GameObject settingPage;
    //アチーブメントページ
    [SerializeField] private GameObject achievePage;
    /// <summary>
    /// 画面が表示された時の処理
    /// </summary>
    private void OnEnable()
    {
        //閉じるボタンを押した時の処理
        closeButton.onClick.AddListener(()=>
        {
            map3dPage.SetActive(true);
            this.gameObject.SetActive(false);
        });

        //設定ボタンを押した時の処理
        settingButton.onClick.AddListener(() =>
        {
            settingPage.SetActive(true);
            this.gameObject.SetActive(false);
        });

        //アチーブメントボタンを押した時の処理
        achieveButton.onClick.AddListener(() =>
        {
            achievePage.SetActive(true);
            this.gameObject.SetActive(false);
        });

        //検索ボタンを押した時の処理
        searchButton.onClick.AddListener(() =>
        {
            //searchPage.SetActive(true);
            //this.gameObject.SetActive(false);
        });
    }
}
