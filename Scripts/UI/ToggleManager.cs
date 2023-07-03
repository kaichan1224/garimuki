using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// OnOffスイッチ(設定画面)の動作を管理するモジュール
/// </summary>
public class ToggleManager : MonoBehaviour
{
    //スイッチ
    [SerializeField] private RectTransform _handle;
    [SerializeField] private Toggle _toggle;
    //背景の画像
    [SerializeField] private Image _backgroundImage;
    //背景の色
    [SerializeField] private Color _backgroundOnColor, _backgroundOffColor;
    [SerializeField] private UserDataManager userDataManager;
    [SerializeField] private PlayerMoveManager playerMoveManager;
    //オン・オフの切り替え時に実行されるメソッド
    public void ToggleChanged()
    {
        //スイッチのオンオフに合わせてボタンの位置を変える
        _handle.anchoredPosition *= -1.0f;
        //背景色を変える
        if (_toggle.isOn)
        {
            playerMoveManager.isOperateMode = true;
            userDataManager.isOperate = true;
            _backgroundImage.color = _backgroundOnColor;
        }
        else
        {
            playerMoveManager.isOperateMode = false;
            userDataManager.isOperate = false;
            _backgroundImage.color = _backgroundOffColor;
        }
    }
}
