using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCheck : MonoBehaviour
{
    //�ǂƃ{�^���n
    public GameObject button ;//�{�^���I�u�W�F�N�g
    public GameObject wall; // �ǂ̃I�u�W�F�N�g

    private void OnTriggerEnter2D(Collider2D other)//�{�^���ƕǂɂ���
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject,1.0f);
            Destroy(wall, 1.0f);//�ǂ�j��
            Debug.Log("�ǔj��");
        }
    }
}
