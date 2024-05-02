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
        //すべての子オブジェクトを非表示
        foreach(GameObject gamObj in childObject)
        {
            gameObject.SetActive(false);
        }
        //最初の一つをアクティブ化
        childObject[index].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            childObject[index].SetActive(false);
            index = 0;
            childObject[index].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            childObject[index].SetActive(false);
            index = 1;
            childObject[index].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            childObject[index].SetActive(false);
            index = 2;
            childObject[index].SetActive(true);
        }
    }
}
