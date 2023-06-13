/**************************************
 *** Designer:AL21115
 *** Date:2023.6.10
 *** プレイヤー画面のページのUI処理
 **************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UniRx;

/// <summary>
/// プレイヤーに関するユーザデータを管理する
/// </summary>
public class PlayerInfoPageManager : MonoBehaviour
{
    //各UI要素
    //閉じるボタン
    [SerializeField] private Button backButton;
    //3dマップが表示されるページ
    [SerializeField] private GameObject map3dPage;
    //レベルのテキスト
    [SerializeField] private TMP_Text levelText;
    //総Kcalのテキスト
    [SerializeField] private TMP_Text totalKcalText;
    //総移動距離のテキスト
    [SerializeField] private TMP_Text moveDistanceText;
    //ユーザデータ管理部
    [SerializeField] private UserDataManager userDataManager;
    /// <summary>
    /// 画面が表示された時の処理
    /// </summary>
    private void OnEnable()
    {
        //閉じるボタンを押された時の処理
        backButton.onClick.AddListener(() =>
        {
            map3dPage.SetActive(true);
            this.gameObject.SetActive(false);
        });
        //ユーザデータの値が変更された時にUIに反映されるようにする
        userDataManager.level
            .Subscribe(x => levelText.text = x.ToString())
            .AddTo(this);
        userDataManager.totalKcal
            .Subscribe(x => totalKcalText.text = x.ToString() + "kcal")
            .AddTo(this);
        userDataManager.distanceTraveled
            .Subscribe(x => moveDistanceText.text = x.ToString() + "km")
            .AddTo(this);
    }
}
