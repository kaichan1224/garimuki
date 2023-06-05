/**************************************
 *** Designer:AL21115
 *** Date:2023.5.23
 *** 達成項目のページのUI処理
 **************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AchievePageManager : MonoBehaviour
{
    [SerializeField] private GameObject map3dPage;
    [SerializeField] private Button backButton;
    private void OnEnable()
    {
        backButton.onClick.AddListener(() =>
        {
            map3dPage.SetActive(true);
            this.gameObject.SetActive(false);
        });
    }
}
