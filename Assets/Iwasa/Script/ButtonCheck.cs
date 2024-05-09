using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCheck : MonoBehaviour
{
    public GameObject wall; // 壁のオブジェクト

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Destroy(wall);//壁を破壊
            Debug.Log("壁破壊");
        }
    }
}
