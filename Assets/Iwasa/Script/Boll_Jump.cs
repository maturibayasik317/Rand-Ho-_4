using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boll_Jump : MonoBehaviour
{
    public float jumpMultiplier = 1f; // �W�����v�͂̏㏸�{��
    private float originalJumpPower; // ���̃W�����v�͂�ۑ�

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player3")
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                originalJumpPower = playerController.xSpeed; // ���̃W�����v�͂�ۑ�
                playerController.xSpeed *= jumpMultiplier; // �W�����v�͂��グ��
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player3")
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.xSpeed = originalJumpPower; // �W�����v�͂����ɖ߂�
            }
        }
    }
}
