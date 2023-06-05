/**************************************
 *** Designer:AL21115
 *** Date:2023.5.23
 *** 3dMapのページのUI処理
 **************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map3dPageManager : MonoBehaviour
{
    [SerializeField] private Button mapSwitchButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private GameObject menuPage;
    [SerializeField] private GameObject map2dPage;
    [SerializeField] private GameObject camera2d;
    [SerializeField] private GameObject camera3d;
    [SerializeField] private GameObject map2d;
    [SerializeField] private GameObject map3d;
    private void OnEnable()
    {
        mapSwitchButton.onClick.AddListener(()=>
        {
            map2dPage.SetActive(true);
            camera3d.SetActive(false);
            camera2d.SetActive(true);
            map3d.SetActive(false);
            map2d.SetActive(true);
            this.gameObject.SetActive(false);
        });

        menuButton.onClick.AddListener(() =>
        {
            menuPage.SetActive(true);
            this.gameObject.SetActive(false);
        });
    }
}
