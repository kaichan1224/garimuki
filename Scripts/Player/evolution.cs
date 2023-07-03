using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UniRx;
using UnityEngine.TextCore.Text;
using TMPro;

/// <summary>
/// キャラクターの進化時演出のモジュール
/// </summary>
public class evolution : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private float scaleDuration = 1.0f;
    [SerializeField] private float maxScale = 1.5f;
    [SerializeField] private GameObject effect;
    [SerializeField] private MusicManager musicManager;
    [SerializeField] private GameObject iwaSound;
    [SerializeField] private UserDataManager userDataManager;
    [SerializeField] private GameObject backWall;
    [SerializeField] private GameObject evoPlace;
    [SerializeField] private GameObject evoBallNormal;
    [SerializeField] private GameObject evoBallMuki;
    [SerializeField] private GameObject evoCam;
    [SerializeField] private GameObject evoWallNormal;
    [SerializeField] private GameObject evoWallMuki;
    [SerializeField] private GameObject map3dCamera;
    [SerializeField] private GameObject map3dPage;
    [SerializeField] private GameObject evoBody;
    [SerializeField] private GameObject evoNormal;
    [SerializeField] private GameObject evoMukimuki;
    [SerializeField] private GameObject evoPanel;
    private Vector3 ballForce = new Vector3(0,0,-1);
    private float power = 2000f;
    private int normalLevel = 10;
    private int mukimukiLevel = 20;
    void Start()
    {
        userDataManager.level
        .Where(value => value == normalLevel)
        .Subscribe(_ =>
        {
            if (!userDataManager.isNormal.Value)
                StartEvoNormal();
            userDataManager.isNormal.Value = true;
        })
        .AddTo(this);

        userDataManager.level
        .Where(value => value == mukimukiLevel)
        .Subscribe(_ =>
        {
            if (!userDataManager.isMukimuki.Value)
                StartEvoMuki();
            userDataManager.isMukimuki.Value = true;
        })
        .AddTo(this);
    }

    void StartEvoNormal()
    {
        // テキストの初期スケールを設定
        text.transform.localScale = Vector3.zero;
        musicManager.StopBgm();
        map3dCamera.SetActive(false);
        backWall.SetActive(true);
        evoPlace.SetActive(true);
        evoCam.SetActive(true);
        evoWallNormal.SetActive(true);
        evoBody.SetActive(true);
        evoPanel.SetActive(true);
        if (userDataManager.level.Value == normalLevel)
            evoNormal.SetActive(true);
        else
            evoMukimuki.SetActive(true);
        evoBallNormal.SetActive(true);
        map3dPage.SetActive(false);
        Sequence sequence = DOTween.Sequence();
        sequence
            .AppendInterval(0.1f)
            .AppendCallback(() =>
            {
                evoBallNormal.GetComponent<Rigidbody>().AddForce(power * ballForce);
                Instantiate(iwaSound);
            })
            .AppendInterval(0.3f)
            .AppendCallback(()=>
            {
                Instantiate(effect, evoBody.transform.position, Quaternion.identity);
                musicManager.StartEvoBgm();
            })
            .AppendInterval(0.7f)
            .Append(text.transform.DOScale(maxScale, scaleDuration).SetEase(Ease.OutElastic))
            .AppendInterval(3.5f)
            .OnComplete(() =>
            {
                musicManager.StartIdleBgm();
                FinishEvoNormal();
            });
    }

    void FinishEvoNormal()
    {
        backWall.SetActive(false);
        map3dCamera.SetActive(true);
        evoPlace.SetActive(false);
        evoCam.SetActive(false);
        evoWallNormal.SetActive(false);
        evoBody.SetActive(false);
        evoPanel.SetActive(false);
        if (userDataManager.level.Value == normalLevel)
            evoNormal.SetActive(false);
        else
            evoMukimuki.SetActive(false);
        evoBallNormal.SetActive(false);
        map3dPage.SetActive(true);
    }

    void StartEvoMuki()
    {
        // テキストの初期スケールを設定
        text.transform.localScale = Vector3.zero;
        musicManager.StopBgm();
        backWall.SetActive(true);
        map3dCamera.SetActive(false);
        evoPlace.SetActive(true);
        evoCam.SetActive(true);
        evoWallMuki.SetActive(true);
        evoBody.SetActive(true);
        evoPanel.SetActive(true);
        if (userDataManager.level.Value == normalLevel)
            evoNormal.SetActive(true);
        else
            evoMukimuki.SetActive(true);
        evoBallMuki.SetActive(true);
        map3dPage.SetActive(false);
        Sequence sequence = DOTween.Sequence();
        sequence
            .AppendInterval(0.1f)
            .AppendCallback(() =>
            {
                evoBallMuki.GetComponent<Rigidbody>().AddForce(power * ballForce);
                Instantiate(iwaSound);
            })
            .AppendInterval(0.3f)
            .AppendCallback(() =>
            {
                Instantiate(effect, evoBody.transform.position, Quaternion.identity);
                musicManager.StartEvoBgm();
            })
            .AppendInterval(0.7f)
            .Append(text.transform.DOScale(maxScale, scaleDuration).SetEase(Ease.OutElastic))
            .AppendInterval(3.5f)
            .OnComplete(() =>
            {
                musicManager.StartIdleBgm();
                FinishEvoMuki();
            });
    }

    void FinishEvoMuki()
    {
        backWall.SetActive(false);
        map3dCamera.SetActive(true);
        evoPlace.SetActive(false);
        evoCam.SetActive(false);
        evoWallMuki.SetActive(false);
        evoBody.SetActive(false);
        evoPanel.SetActive(false);
        if (userDataManager.level.Value == normalLevel)
            evoNormal.SetActive(false);
        else
            evoMukimuki.SetActive(false);
        evoBallMuki.SetActive(false);
        map3dPage.SetActive(true);
    }
}
