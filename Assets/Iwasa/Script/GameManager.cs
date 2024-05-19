using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //�������Ԍn
    public TextMeshProUGUI timerText;
    public float timeRemaining = 180; //��������
    public GameObject PlayerObuject;
    private bool isTimeLow = false; // ���Ԃ����Ȃ����ǂ������m�F����

    //�V�[���ړ����L�^����
    public static string previousScene;

    void Start()
    {
        Debug.LogError("Timer Text is not assigned!");
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)//�������Ԃ̏���
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else
        {
            Destroy(PlayerObuject);//�v���C���[�̔j��
            timerText.text = "TIME UP!!";//�^�C���A�b�v�̃��b�Z�[�W
            this.enabled = false; //�^�C�}�[���~
            Debug.Log("TIME UP!!");
        }

        // �c�莞�Ԃ�1�������ɂȂ�����e�L�X�g�̐F��ԂɕύX
        if (!isTimeLow && timeRemaining <= 60)
        {
            timerText.color = Color.red;
            isTimeLow = true; 
        }
    }

    void DisplayTime(float timeToDisplay)//�c�莞�Ԃ̕\��
    {
        if (timerText == null)
        {
            Debug.LogError("Timer Text is not assigned!");
            return;
        }

        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format(" {0:00}:{1:00}", minutes, seconds);
    }
}
