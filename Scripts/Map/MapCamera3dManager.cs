using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCamera3dManager : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float angle = 5f;
    // スワイプの方向
    private Vector2 swipeDirection;

    // スワイプの開始地点
    private Vector2 swipeStartPos;

    private void Update()
    {
        // タッチまたはマウスの入力を監視
        if (Input.GetMouseButtonDown(0))
        {
            // 入力の開始地点を記録
            swipeStartPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            //押された時の移動地点
            Vector2 swipeEndPos = Input.mousePosition;
            //x軸方向のスワイプ距離を求める
            float swipeDistance = swipeStartPos.x - swipeEndPos.x;
            if (swipeDistance > 5f)
            {
                transform.RotateAround(player.position, Vector3.up, angle);
            }
            else if (swipeDistance < -5f)
            {
                transform.RotateAround(player.position, Vector3.up, -angle);
            }
            // 入力の開始地点を記録
            swipeStartPos = Input.mousePosition;
        }
    }
}
