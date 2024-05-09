using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squareController : MonoBehaviour
{
    private int index = 0;
    private int o_max = 0;
    GameObject[] childObject;
    // Start is called before the first frame update
    void Start()
    {
        o_max = this.transform.childCount;//�q�I�u�W�F�N�g�̌��擾
        childObject = new GameObject[o_max];//�C���X�^���X�쐬

        for (int i = 0; i < o_max; i++)
        {
            childObject[i] = transform.GetChild(i).gameObject;//���ׂĂ̎q�I�u�W�F�N�g�擾
        }
        //���ׂĂ̎q�I�u�W�F�N�g���A�N�e�B�u
        foreach (GameObject gamObj in childObject)
        {
            gamObj.SetActive(false);
        }
        //�ŏ��͂ЂƂ����A�N�e�B�u�����Ă���
        childObject[index].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            //���݂̃A�N�e�B�u�Ȏq�I�u�W�F�N�g���A�N�e�B�u
            childObject[index].SetActive(false);
            index++;

            //�q�I�u�W�F�N�g�����ׂĐ؂�ւ�����܂��ŏ��̃I�u�W�F�N�g�ɖ߂�
            if (index == o_max) { index = 0; }

            //���̃I�u�W�F�N�g���A�N�e�B�u��
            childObject[index].SetActive(true);
        }
    }
}
