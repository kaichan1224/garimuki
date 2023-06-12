/**************************************
 *** Designer:AL21115
 *** Date:2023.5.23
 *** プレイヤーの見た目及びアニメーション
 *** Last Editor:AL21115
 *** Last Edited:2023.6.8
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
    [SerializeField] private UserDataManager userDataManager;
    //前フレームのposition
    [SerializeField] private Vector3 previousPosition;
    void Start()
    {
        previousPosition = transform.position;
        animator = playerModels[0].GetComponent<Animator>();
        LevelUp();
    }

    //1フレームごとに実行されるメソッド
    void Update()
    {
        //LevelUp();
        Animation();
    }

    //プレイヤーが歩いている時とそうでない時を判定し、それに応じてアニメーションを変更するメソッド
    void Animation()
    {
        //ゲームシーン上の座標が変化しなかったら
        if (transform.position.Equals(previousPosition))
        {
            //歩くアニメーションのオフに
            animator.SetBool("isWalk", false);
        }
        //ゲームシーン上の座標が変化したら
        else
        {
            //歩くアニメーションに
            animator.SetBool("isWalk", true);
        }
        //判定ように直前の場所を取得する
        previousPosition = transform.position;
    }

    //キャラクターの見た目が変更するメソッド
    //playerModelsに格納した順番をそのままindex直接指定した方がいい
    // TODO モデルが出来次第作業にとりかかる
    void LevelUp()
    {
        /*
        //今現在の累積距離をユーザデータ管理部から取得
        double nowDistance = userDataManager.GetDistanceTraveled();
        //累積距離が1km超えたら
        if (nowDistance > 1d)
        {
            level = 2;
            playerModels[0].SetActive(false);
            playerModels[1].SetActive(true);
            animator = playerModels[1].GetComponent<Animator>();
        }
        //50km超えたら
        else if (nowDistance > 50d)
        {
            level = 3;
            playerModels[0].SetActive(false);
            playerModels[1].SetActive(true);
            animator = playerModels[1].GetComponent<Animator>();
        }
        //そうでない時
        else
        {
            level = 1;
            playerModels[0].SetActive(true);
            playerModels[1].SetActive(false);
            animator = playerModels[0].GetComponent<Animator>();
        }
        */
    }
}
