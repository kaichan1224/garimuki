using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadingPageManager : MonoBehaviour
{
    [SerializeField] private GameObject map3dPage;
    [SerializeField] private Slider loadingSlider;
    [SerializeField] private float loadingTime = 3f; // ロード時間（秒）
    [SerializeField] private TMP_Text loadingText;
    private void OnEnable()
    {
        StartCoroutine(NowLoading());
    }

    IEnumerator NowLoading()
    {
        yield return null; // 1フレーム待機
        loadingText.text = "0%";

        float timer = 0f;

        while (timer < loadingTime)
        {
            timer += Time.deltaTime;

            loadingSlider.value = timer / loadingTime; // スライダーの値を更新
            loadingText.text = ((int)(100 * timer / loadingTime)).ToString() + "%";
            yield return null; // 1フレーム待機
        }
        map3dPage.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
