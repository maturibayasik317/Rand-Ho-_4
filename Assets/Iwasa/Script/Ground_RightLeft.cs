using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_RightLeft : MonoBehaviour
{
    public float moveSpeed = 3f; // �ړ����x
    public float moveDistance = 5f; // �ړ�����
    public bool onlyMoveWithPlayer = false;

    private Vector3 startPosition;
    private bool movingRight = true;
    private bool movingLeft = true;
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
        if (movingRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            if (transform.position.x >= startPosition.x + moveDistance)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            if (transform.position.x <= startPosition.x - moveDistance)
            {
                movingRight = true;
            }
        }
        //�s���͈͂������E�ɍs�����Ƃ�
        if (movingLeft)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            if (transform.position.x >= startPosition.x + moveDistance)
            {
                movingLeft = false;
            }
        }
        else
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            if (transform.position.x <= startPosition.x - moveDistance)
            {
                movingLeft = true;
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
        Gizmos.DrawLine(startPosition - Vector3.right * moveDistance, startPosition + Vector3.right * moveDistance);
    }
}
