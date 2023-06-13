/**************************************
 *** Designer:AL21115
 *** Date:2023.5.23
 *** タイトルページのUI処理
 **************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// タイトルページのボタンなどのUI操作を管理するモジュール
/// </summary>
public class TitlePageManager : MonoBehaviour
{
    //スタートボタン
    [SerializeField] Button startButton;
    //ローディングページ
    [SerializeField] GameObject loadingPage;
    /// <summary>
    /// ゲーム起動時の処理を行う
    /// </summary>
    void Start()
    {
        //スタートボタンが押された時の処理
        startButton.onClick.AddListener(() =>
        {
            //ローディング画面のオンにする
            loadingPage.SetActive(true);
            //今の画面をオフにする
            this.gameObject.SetActive(false);
        });
    }
}
