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
        o_max = this.transform.childCount;//子オブジェクトの取得
        childObject = new GameObject[o_max];//インスタンスの作成

        for(int i = 0; i < o_max; i++)
        {
            childObject[i] = transform.GetChild(i).gameObject;//すべての子オブジェクト取得
        }
    }
    void Update()
    {
        //キーが押されたときにオブジェクトの種類を変える
        if (Input.GetKeyDown(KeyCode.LeftControl)||Input.GetKey(KeyCode.RightControl))
        {
            childObject[index].SetActive(false);
            ++index;
            if (index == o_max) { index = 0; }
            childObject[index].SetActive(true);
        }
    }
}
