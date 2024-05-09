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
        //ƒL[‚ğ‰Ÿ‚·‚²‚Æ‚É45‹‰ñ“]‚·‚é
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.RightShift))
        {
            transform.Rotate(new Vector3(0, 0, 45));
        }
    }
}
