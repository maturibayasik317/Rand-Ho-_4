using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCheck : MonoBehaviour
{
    public GameObject wall; // �ǂ̃I�u�W�F�N�g

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Destroy(wall);//�ǂ�j��
            Debug.Log("�ǔj��");
        }
    }
}
