using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCheck : MonoBehaviour
{
    public GameObject wall; // 壁のオブジェクト

    private bool isButtonPressed = false; // ボタンが押されたかどうかのフラグ

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // プレイヤーがボタンに触れた場合
        {
            isButtonPressed = true;
            wall.SetActive(false); // ボタンが押されたので壁を非表示にする
        }
    }
}
