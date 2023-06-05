/**************************************
 *** Designer:AL21115
 *** Date:2023.5.23
 *** タイトルページのUI処理
 **************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitlePageManager : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] GameObject mapPage;
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(() =>
        {
            mapPage.SetActive(true);
            this.gameObject.SetActive(false);
        });
    }
}
