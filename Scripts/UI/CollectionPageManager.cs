/**************************************
 *** Designer:AL21115
 *** Date:2023.6.19
 *** 
***************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CollectionPageManager : MonoBehaviour
{
    public RectTransform contentRectTransform;
    [SerializeField] private Button exitButton;
    [SerializeField] private GameObject animalButtonPrefab;
    [SerializeField] private GameObject map3dPage;
    [SerializeField] private OwnedAnimalDataManager ownedAnimalDataManager;
    private List<GameObject> displayAnimalButtonList = new List<GameObject>();

    private void OnEnable()
    {
        foreach (var obj in displayAnimalButtonList)
        {
            obj.Destroy();
        }
        displayAnimalButtonList.Clear();
        exitButton.onClick.AddListener(() =>
        {
            map3dPage.SetActive(true);
            this.gameObject.SetActive(false);
        });
        for (int i = 0; i < ownedAnimalDataManager.ownedAnimalData.dataList.Count; i++)
        {
            var obj = Instantiate(animalButtonPrefab, contentRectTransform);
            obj.GetComponent<AnimalButton>().Init(ownedAnimalDataManager.ownedAnimalData.dataList[i]);
            displayAnimalButtonList.Add(obj);
        }
    }
}
