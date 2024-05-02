using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCheck : MonoBehaviour
{
    public GameObject wall; // �ǂ̃I�u�W�F�N�g

    private bool isButtonPressed = false; // �{�^���������ꂽ���ǂ����̃t���O

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �v���C���[���{�^���ɐG�ꂽ�ꍇ
        {
            isButtonPressed = true;
            wall.SetActive(false); // �{�^���������ꂽ�̂ŕǂ��\���ɂ���
        }
    }
}
