using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{
    public int index = 0;//��������鏇��
    private float DeatTime;
    public GameObject[] Player;//�v���C���[�̃C���X�^���X
    public new GameObject gameObject;//�V�������������v���C���[�I�u�W�F�N�g
    [SerializeField] GameObject PlayerObj;//�����Ă���v���C���[�I�u�W�F�N�g
    private  Vector2 player;//���݂̃v���C���[���W
    public Vector2 dfPlayer = new Vector2();//�f�t�H���g�̐����ʒu
    public bool Alive = true;//��������
    SquareController squareController;
    public static Vector2 CheckPoint = new Vector2();//�v���C���[�̃`�F�b�N�|�C���g�̍��W
    public bool CheckPlayer = false;//�v���C���[�̃Z�[�u�𔻒�
    public bool CHG = true;

    void Start()
    {
        //���ԍ��W���ݒ肳��Ă���΂��̍��W�Ő���
        if(CheckPoint != Vector2.zero)
        {
            gameObject = Instantiate(Player[0], CheckPoint, Quaternion.identity);
        }
        else//����ȊO�Ȃ珉���ʒu�Ő���
        {
            gameObject = Instantiate(Player[0], dfPlayer, Quaternion.identity);
        }
        
        squareController = GetComponent<SquareController>();
    }

    void Update()
    {
        
            gameObject = squareController.childObject;
            PlayerObj = gameObject;
        if (Alive)
        {
            if (CHG)
            {
                //�L�[�������ꂽ�Ƃ��ɃI�u�W�F�N�g�̎�ނ�ς���
                if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
                {
                    player = PlayerObj.transform.position;
                    Destroy(gameObject);
                    ++index;
                    if (index == Player.Length) { index = 0; }
                    gameObject = Instantiate(Player[index], player, Quaternion.identity);
                }
                //�v���C���[���`�F�b�N�|�C���g���ӂꂽ�Ƃ����̍��W���L�^����
                if (CheckPlayer == true)
                {
                    CheckPoint = PlayerObj.transform.position;
                    CheckPlayer = false;
                }
                if (Input.GetKeyDown(KeyCode.K))
                {
                    SceneManager.LoadScene("sss", LoadSceneMode.Single);
                }
            }
        }
        else
        {
            //�v���C���[�����S����ɂȂ����Ƃ��Ɉ�莞�ԑ҂��āA
            ++DeatTime;
            if (DeatTime == 200.0f)
            {//�v���C���[�������ăQ�[���I�[�o�[�V�[����
                Destroy(gameObject);
                SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
            }
        }
        
    }
}
