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
    [SerializeField] private GameObject[] playerModels;
    [SerializeField] private Animator animator;
    //userdatamanagerのための変数
    private UserDataManager userDataManager;
    [SerializeField] private GameObject userDataManagerObject;
    //level
    [SerializeField] private int level = 1;

    private Vector3 previousPosition; // 前フレームのposition
    void Start()
    {
        previousPosition = transform.position;
        userDataManager = userDataManagerObject.GetComponent<UserDataManager>();
        animator = GetComponent<Animator>();
        LevelUp();
    }

    // Update is called once per frame
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
