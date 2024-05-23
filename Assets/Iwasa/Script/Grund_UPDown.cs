using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ground_UPDown : MonoBehaviour
{
    public float moveSpeed = 3f; // �ړ����x
    public float moveDistance = 5f; // �ړ�����
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
        // onlyMoveWithPlayer��true�̏ꍇ�A�v���C���[���G��Ă��Ȃ��Ɠ����Ȃ�
        if (onlyMoveWithPlayer && !playerOnPlatform)
        {
            return;
        }

        // �ړ��͈͂𒴂����ꍇ�̕����]��
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
        // �V�[���r���[�Ɉړ��͈͂�\��
        Gizmos.color = Color.green;
        Gizmos.DrawLine(startPosition - Vector3.up * moveDistance, startPosition + Vector3.up * moveDistance);
    }
}
