using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class CharacterChg : MonoBehaviour
{
    public int index = 0;
    private int o_max = 0;

    GameObject[] childObject;
    Sample sample;

    void Start()
    {
        Sample sample = gameObject.AddComponent<Sample>();
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
        if (Input.GetKeyDown(KeyCode.LeftControl)||Input.GetKeyDown(KeyCode.RightControl))
        {
            childObject[index].SetActive(false);

            ++index;//���̂̎�ނ�ς���J�E���g���P�ǉ�
            if (index == o_max) { index = 0; }

            childObject[index].SetActive(true);
        }
    }
}
