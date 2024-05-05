using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChg : MonoBehaviour
{
    public int index = 0;
    private int o_max = 0;
    GameObject[] childObject;
    void Start()
    {
        o_max = this.transform.childCount;//�q�I�u�W�F�N�g�̎擾
        childObject = new GameObject[o_max];//�C���X�^���X�̍쐬

        for(int i = 0; i < o_max; i++)
        {
            childObject[i] = transform.GetChild(i).gameObject;//���ׂĂ̎q�I�u�W�F�N�g�擾
        }
    }
    void Update()
    {
        //�L�[�������ꂽ�Ƃ��ɃI�u�W�F�N�g�̎�ނ�ς���
        if (Input.GetKeyDown(KeyCode.LeftControl)||Input.GetKey(KeyCode.RightControl))
        {
            childObject[index].SetActive(false);
            ++index;
            if (index == o_max) { index = 0; }
            childObject[index].SetActive(true);
        }
    }
}
