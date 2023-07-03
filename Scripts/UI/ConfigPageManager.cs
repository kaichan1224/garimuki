/**************************************
 *** Designer:AL21115
 *** Date:2023.5.23
 *** 設定項目のページのUI処理
 **************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 設定画面におけるUIの処理を行うモジュール
/// TODO 位置情報の取得間隔等の修正をこの画面でできるようにする
/// </summary>
public class ConfigPageManager : MonoBehaviour
{
    //閉じるボタン
    [SerializeField] private Button closeButton;
    //3dマップのページ
    [SerializeField] private GameObject map3dPage;
    /// <summary>
    /// 設定画面がオンになった時の処理
    /// </summary>
    private void Start()
    {
        //閉じるボタンを押した時の処理
        closeButton.onClick.AddListener(() =>
        {
            map3dPage.SetActive(true);
            this.gameObject.SetActive(false);
        });
    }
}