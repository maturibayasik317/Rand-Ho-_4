using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart_catch : MonoBehaviour
{
    public static Heart_catch instance;

    public int maxHearts = 3;
    public GameObject[] hearts; // �n�[�g�I�u�W�F�N�g�̔z��
    public Text heartText; // �n�[�g�̐���\������UI�e�L�X�g

    private int currentHearts = 0; // ���݂̃n�[�g�̐�

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateHeartUI();
    }

    // �n�[�g�����W���邽�߂̃��\�b�h
    public void CollectHeart(GameObject heart)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (hearts[i] == heart)
            {
                currentHearts++;
                Destroy(heart); // �n�[�g��j��
                UpdateHeartUI();
                break;
            }
        }
    }

    private void UpdateHeartUI()
    {
        heartText.text = "Hearts: " + new string('?', currentHearts) + new string('?', maxHearts - currentHearts);
    }
}