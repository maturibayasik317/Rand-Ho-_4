using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float liftSpeed = 5f; // 上昇速度
    public string playerName = "Player"; // 上昇可能なプレイヤーの名前

    private GameObject activePlayer = null; // 上昇可能なプレイヤー

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerName))
        {
            activePlayer = collision.gameObject; // アクティブなプレイヤーがコライダーに入った
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == activePlayer)
        {
            activePlayer = null; // アクティブなプレイヤーがコライダーから出た
        }
    }

    private void Update()
    {
        if (activePlayer != null)
        {
            activePlayer.transform.position += Vector3.up * liftSpeed * Time.deltaTime; // プレイヤーを上昇させる
        }
    }
}
