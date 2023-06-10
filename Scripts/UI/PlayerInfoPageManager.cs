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

public class PlayerInfoPageManager : MonoBehaviour
{
    //各UI要素
    [SerializeField] private Button backButton;
    [SerializeField] private GameObject map3dPage;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text totalKcalText;
    [SerializeField] private TMP_Text moveDistanceText;
    //ユーザmodel
    [SerializeField] private UserDataManager userDataManager;
    private void OnEnable()
    {
        backButton.onClick.AddListener(() =>
        {
            map3dPage.SetActive(true);
            this.gameObject.SetActive(false);
        });

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
