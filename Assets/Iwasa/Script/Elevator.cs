using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float liftSpeed = 5f; // �㏸���x
    public string playerName = "Player"; // �㏸�\�ȃv���C���[�̖��O

    private GameObject activePlayer = null; // �㏸�\�ȃv���C���[

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerName))
        {
            activePlayer = collision.gameObject; // �A�N�e�B�u�ȃv���C���[���R���C�_�[�ɓ�����
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == activePlayer)
        {
            activePlayer = null; // �A�N�e�B�u�ȃv���C���[���R���C�_�[����o��
        }
    }

    private void Update()
    {
        if (activePlayer != null)
        {
            activePlayer.transform.position += Vector3.up * liftSpeed * Time.deltaTime; // �v���C���[���㏸������
        }
    }
}
