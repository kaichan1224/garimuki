using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// ローディング画面のページを管理するモジュール
/// </summary>
public class LoadingPageManager : MonoBehaviour
{
    //3dマップのページ
    [SerializeField] private GameObject map3dPage;
    //ローディング中のスライダー
    [SerializeField] private Slider loadingSlider;
    //ローディング時間
    [SerializeField] private float loadingTime = 3f; // ロード時間（秒）
    //ローディング率を表すテキスト
    [SerializeField] private TMP_Text loadingText;
    /// <summary>
    /// ローディング画面がオンになった時の処理
    /// </summary>
    private void OnEnable()
    {
        StartCoroutine(NowLoading());
    }
    /// <summary>
    /// ローディング時の処理
    /// </summary>
    /// <returns></returns>
    IEnumerator NowLoading()
    {
        yield return null; // 1フレーム待機
        loadingText.text = "0%";

        float timer = 0f;

        //ローディングを行う
        while (timer < loadingTime)
        {
            timer += Time.deltaTime;
            //ローディング率を更新
            loadingSlider.value = timer / loadingTime;
            loadingText.text = ((int)(100 * timer / loadingTime)).ToString() + "%";
            yield return null;
        }
        //ページの切り替わり
        map3dPage.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
