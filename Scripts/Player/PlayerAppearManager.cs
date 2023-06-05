/**************************************
 *** Designer:AL21115
 *** Date:2023.5.23
 *** プレイヤーの見た目及びアニメーション
 **************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAppearManager : MonoBehaviour
{
    //プレイヤーのモデルを格納する配列
    [SerializeField] private GameObject[] playerModels;
    //アニメーションをコントロール
    [SerializeField] private Animator animator;
    //userdatamanager
    private UserDataManager userDataManager;
    //userdatamanagerをアタッチするためのゲームオブジェクト
    [SerializeField] private GameObject userDataManagerObject;
    //プレイヤーのレベル
    [SerializeField] private int level = 1;
    //前フレームのposition
    private Vector3 previousPosition;
    void Start()
    {
        previousPosition = transform.position;
        userDataManager = userDataManagerObject.GetComponent<UserDataManager>();
        animator = GetComponent<Animator>();
        LevelUp();
    }

    void Update()
    {
        //LevelUp();
        Animation();
    }

    void Animation()
    {
        if (transform.position.Equals(previousPosition))
        {
            animator.SetBool("isWalk", false);
        }
        else
        {
            animator.SetBool("isWalk", true);
        }
        previousPosition = transform.position;
    }

    void LevelUp()
    {
        double nowDistance = userDataManager.GetDistanceTraveled();
        if (nowDistance > 1d)
        {
            level = 2;
            playerModels[0].SetActive(false);
            playerModels[1].SetActive(true);
            animator = playerModels[1].GetComponent<Animator>();
        }
        else if (nowDistance > 50d)
        {
            level = 3;
            playerModels[0].SetActive(false);
            playerModels[1].SetActive(true);
            animator = playerModels[1].GetComponent<Animator>();
        }
        else
        {
            level = 1;
            playerModels[0].SetActive(true);
            playerModels[1].SetActive(false);
            animator = playerModels[0].GetComponent<Animator>();
        }
    }
}
