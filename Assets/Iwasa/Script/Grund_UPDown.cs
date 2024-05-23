using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ground_UPDown : MonoBehaviour
{
    public float moveSpeed = 3f; // 移動速度
    public float moveDistance = 5f; // 移動距離
    public bool onlyMoveWithPlayer = false;

    private Vector3 startPosition;
    private bool movingUp = true;
    private bool playerOnPlatform = false;
    private Transform playerTransform;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // onlyMoveWithPlayerがtrueの場合、プレイヤーが触れていないと動かない
        if (onlyMoveWithPlayer && !playerOnPlatform)
        {
            return;
        }

        // 移動範囲を超えた場合の方向転換
        if (movingUp)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            if (transform.position.y >= startPosition.y + moveDistance)
            {
                movingUp = false;
            }
        }
        else
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
            if (transform.position.y <= startPosition.y - moveDistance)
            {
                movingUp = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = true;
            playerTransform = collision.transform;
            playerTransform.SetParent(transform); 
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = false;
            playerTransform.SetParent(null); 
        }
    }

    private void OnDrawGizmosSelected()
    {
        // シーンビューに移動範囲を表示
        Gizmos.color = Color.green;
        Gizmos.DrawLine(startPosition - Vector3.up * moveDistance, startPosition + Vector3.up * moveDistance);
    }
}
