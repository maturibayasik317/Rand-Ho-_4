using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float launchForce = 10f; // ���˗�
    public Vector2 launchDirection = new Vector2(1, 1); // ���˕���
    public float preparationTime = 1f; // ��������
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
                playerRigidbody.velocity = Vector2.zero; // �v���C���[�̓������~�߂�
                playerRigidbody.isKinematic = true; // �v���C���[���Œ肷��
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

    //���ˏ���
    private IEnumerator LaunchPlayer()
    {
        yield return new WaitForSeconds(preparationTime); // �������ԑҋ@
        if (isPlayerInCannon && playerRigidbody != null)
        {
            playerRigidbody.isKinematic = false; // �v���C���[�̌Œ������
            Vector2 force = transform.right * launchForce;//��C�̌����ɍ��킹�Ĕ���
            playerRigidbody.AddForce(force, ForceMode2D.Impulse); // �v���C���[�𔭎�
        }
    }

    //�V�[����ʂł͔��˕������킩��悤�ɂ���
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;//���̐F��Ԃɂ���
        Vector3 startPosition = transform.position;//��C��������L�т�
        Vector3 endPosition = 
            startPosition + (Vector3)(launchDirection.normalized * launchForce);

        Gizmos.DrawLine(startPosition, endPosition);//�n�܂肩��I���܂Ő���`��
        Gizmos.DrawSphere(endPosition, 0.2f);
    }
}