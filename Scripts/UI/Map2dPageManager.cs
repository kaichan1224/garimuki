/**************************************
 *** Designer:AL21115
 *** Date:2023.5.23
 *** 2dMapのページのUI処理
 **************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map2dPageManager : MonoBehaviour
{
    [SerializeField] private Button mapSwitchButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private GameObject menuPage;
    [SerializeField] private GameObject map3dPage;
    [SerializeField] private GameObject camera2d;
    [SerializeField] private GameObject camera3d;
    [SerializeField] private GameObject map2d;
    [SerializeField] private GameObject map3d;
    private void OnEnable()
    {
        mapSwitchButton.onClick.AddListener(() =>
        {
            map3dPage.SetActive(true);
            camera3d.SetActive(true);
            camera2d.SetActive(false);
            map3d.SetActive(true);
            map2d.SetActive(false);
            this.gameObject.SetActive(false);
        });

        menuButton.onClick.AddListener(() =>
        {
            menuPage.SetActive(true);
            this.gameObject.SetActive(false);
        });
    }
}
