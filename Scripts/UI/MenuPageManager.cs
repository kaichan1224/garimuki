/**************************************
 *** Designer:AL21115
 *** Date:2023.5.23
 *** メニューのページのUI処理
 **************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPageManager : MonoBehaviour
{
    [SerializeField] private Button closeButton;
    [SerializeField] private Button settingButton;
    [SerializeField] private Button achieveButton;
    [SerializeField] private Button searchButton;

    [SerializeField] GameObject mapPage;
    [SerializeField] private GameObject settingPage;
    [SerializeField] private GameObject achievePage;
    //[SerializeField] private GameObject searchPage;
    private void OnEnable()
    {
        closeButton.onClick.AddListener(()=>
        {
            mapPage.SetActive(true);
            this.gameObject.SetActive(false);
        });

        settingButton.onClick.AddListener(() =>
        {
            settingPage.SetActive(true);
            this.gameObject.SetActive(false);
        });

        achieveButton.onClick.AddListener(() =>
        {
            achievePage.SetActive(true);
            this.gameObject.SetActive(false);
        });

        searchButton.onClick.AddListener(() =>
        {
            //searchPage.SetActive(true);
            //this.gameObject.SetActive(false);
        });
    }
}
