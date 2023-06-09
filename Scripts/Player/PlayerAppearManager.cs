/**************************************
 *** Designer:AL21115
 *** Date:2023.5.23
 *** プレイヤーの見た目及びアニメーション
 *** Last Editor:AL21115
 *** Last Edited:2023.6.27
 **************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.TextCore.Text;

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
        userDataManager.level
        .Where(value => value == 10)
            .Subscribe(_ =>
            {
                playerModels[0].SetActive(false);
                playerModels[1].SetActive(true);
                animator = playerModels[1].GetComponent<Animator>();
            })
            .AddTo(this);

        userDataManager.level
        .Where(value => value == 20)
            .Subscribe(_ =>
            {
                playerModels[1].SetActive(false);
                playerModels[2].SetActive(true);
                animator = playerModels[2].GetComponent<Animator>();
            })
            .AddTo(this);
    }

    //1フレームごとに実行されるメソッド
    void Update()
    {
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
}
