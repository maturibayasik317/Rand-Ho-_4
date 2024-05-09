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
        o_max = this.transform.childCount;//子オブジェクトの個数取得
        childObject = new GameObject[o_max];//インスタンス作成

        for (int i = 0; i < o_max; i++)
        {
            childObject[i] = transform.GetChild(i).gameObject;//すべての子オブジェクト取得
        }
        //すべての子オブジェクトを非アクティブ
        foreach (GameObject gamObj in childObject)
        {
            gamObj.SetActive(false);
        }
        //最初はひとつだけアクティブ化しておく
        childObject[index].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            //現在のアクティブな子オブジェクトを非アクティブ
            childObject[index].SetActive(false);
            index++;

            //子オブジェクトをすべて切り替えたらまた最初のオブジェクトに戻る
            if (index == o_max) { index = 0; }

            //次のオブジェクトをアクティブ化
            childObject[index].SetActive(true);
        }
    }
}
