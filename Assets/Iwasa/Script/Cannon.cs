using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float launchForce = 10f; // 発射力
    public Vector2 launchDirection = new Vector2(1, 1); // 発射方向
    public float preparationTime = 1f; // 準備時間
    private bool isPlayerInCannon = false;
    private GameObject player;
    private Rigidbody2D playerRigidbody;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player3")
        {
            player = collision.gameObject;
            playerRigidbody = player.GetComponent<Rigidbody2D>();
            if (playerRigidbody != null)
            {
                isPlayerInCannon = true;
                playerRigidbody.velocity = Vector2.zero; // プレイヤーの動きを止める
                playerRigidbody.isKinematic = true; // プレイヤーを固定する
                StartCoroutine(LaunchPlayer());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player3")
        {
            isPlayerInCannon = false;
            StopCoroutine(LaunchPlayer());
        }
    }

    //発射処理
    private IEnumerator LaunchPlayer()
    {
        yield return new WaitForSeconds(preparationTime); // 準備時間待機
        if (isPlayerInCannon && playerRigidbody != null)
        {
            playerRigidbody.isKinematic = false; // プレイヤーの固定を解除
            Vector2 force = transform.right * launchForce;//大砲の向きに合わせて発射
            playerRigidbody.AddForce(force, ForceMode2D.Impulse); // プレイヤーを発射
        }
    }

    //シーン画面では発射方向をわかるようにする
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;//線の色を赤にする
        Vector3 startPosition = transform.position;//大砲から線が伸びる
        Vector3 endPosition = 
            startPosition + (Vector3)(launchDirection.normalized * launchForce);

        Gizmos.DrawLine(startPosition, endPosition);//始まりから終わりまで線を描く
        Gizmos.DrawSphere(endPosition, 0.2f);
    }
}