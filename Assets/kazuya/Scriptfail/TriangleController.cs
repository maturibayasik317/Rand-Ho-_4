using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //キーを押すごとに45°回転する
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Rotate(new Vector3(0, 0, 45));
        }
    }
}
