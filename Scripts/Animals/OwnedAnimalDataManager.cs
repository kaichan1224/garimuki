using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class OwnedAnimalDataManager : MonoBehaviour
{
    private string prefkey = "OWNED_ANIMAL_DATA";
    public OwnedAnimalData ownedAnimalData;
    [SerializeField] private List<GameObject> animalDatas;
    void Awake()
    {
        Load();
    }

    public void Load()
    {
        //データを読み込む時に、Spriteはデータ化されないため、対応するスプライトを読み込む必要がある.
        if (PlayerPrefs.HasKey(prefkey))
        {
            string loadjson = PlayerPrefs.GetString(prefkey);
            ownedAnimalData = JsonUtility.FromJson<OwnedAnimalData>(loadjson);
            for (int i = 0; i < ownedAnimalData.dataList.Count; i++)
            {
                foreach (var data in animalDatas)
                {
                    var par = data.GetComponent<Animal>().parameter;
                    if (ownedAnimalData.dataList[i].id == par.id)
                    {
                        ownedAnimalData.dataList[i].sprite = par.sprite;
                        break;
                    }
                }
            }
        }
        else
        {
            ownedAnimalData= new OwnedAnimalData();
            ownedAnimalData.dataList = new List<AnimalData>();
        }
    }

    private void Save()
    {
        string savejson = JsonUtility.ToJson(ownedAnimalData);
        PlayerPrefs.SetString(prefkey,savejson);
        PlayerPrefs.Save();
    }

    public void AddData(AnimalData animalData)
    {
        ownedAnimalData.dataList.Add(animalData);
    }

    private void OnDestroy()
    {
        Save();
    }
}
