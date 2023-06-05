/**************************************
 *** Designer:AL21115
 *** Date:2023.5.23
 *** 設定項目のページのUI処理
 **************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigPageManager : MonoBehaviour
{
    [SerializeField] private Button closeButton;
    [SerializeField] private GameObject map3dPage;
    private void OnEnable()
    {
        closeButton.onClick.AddListener(()=>
        {
            map3dPage.SetActive(true);
            this.gameObject.SetActive(false);
        });
    }
}
