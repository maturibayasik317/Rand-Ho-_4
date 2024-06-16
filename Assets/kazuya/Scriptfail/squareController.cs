using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SquareController : MonoBehaviour
{
    private int index = 0;
    [SerializeField] public GameObject[] Player;//�������ƂȂ�I�u�W�F�N�g
    public GameObject childObject;// ����ւ���ƂȂ�I�u�W�F�N�g
    [SerializeField] GameObject Square;//���삷��I�u�W�F�N�g
    private Vector2 player;//�v���C���[�̍��W��ۑ�����
    Spawn spawn;

    void Start()
    {
        spawn = GetComponent<Spawn>();
    }

    void Update()
    {

        childObject = spawn.gameObject;//
        Square = childObject;
        //�w��̃L�[�������ꂽ�Ƃ�
        if (Input.GetKeyDown(KeyCode.Q))
        {//�l�p�̌`�ł����
            if (GameObject.Find("Player(Clone)") || GameObject.Find("Player1(Clone)"))
            {
                //�v���C���[�̍��W��ۑ�
                player = Square.transform.position;
                Destroy(Square);//������I�u�W�F�N�g���폜
                ++index;//�J�E���g��ǉ�
                if (index == Player.Length) { index = 0; }
                //�V�����I�u�W�F�N�g��O�̃I�u�W�F�N�g���W�ɐ���
                childObject = Instantiate(Player[index], player, Quaternion.identity);
            } 
        }
    }
}
