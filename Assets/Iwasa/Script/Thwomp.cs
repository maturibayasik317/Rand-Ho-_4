using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thwomp : MonoBehaviour
{
    public float detectionRange = 5f;// �v���C���[�̌��o�͈�
    public float fallSpeed = 10f; // �������x
    public float returnSpeed = 5f; // �����ʒu�ɖ߂�ۂ̑��x
    public float delayBeforeReturn = 2f;
    public LayerMask playerLayer;

    private Vector3 initialPosition;
    private bool isReturning = false;
    private bool playerDetected = false;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (!isReturning)
        {
            DetectPlayer();
            if (playerDetected)
            {
                Fall();
            }
        }
        else
        {
            ReturnToInitialPosition();
        }
    }

    void DetectPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, detectionRange, playerLayer);
        if (hit.collider != null)
        {
            playerDetected = true;
        }
    }

    void Fall()
    {
        if (transform.position.y > initialPosition.y - detectionRange)
        {
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;
        }
        else
        {
            playerDetected = false;
            isReturning = true;
            Invoke("ResetPosition", delayBeforeReturn);
        }
    }

    void ReturnToInitialPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, initialPosition, returnSpeed * Time.deltaTime);
        if (transform.position == initialPosition)
        {
            isReturning = false;
        }
    }

    void ResetPosition()
    {
        isReturning = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);  // �v���C���[��j��
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * detectionRange);
    }
}
