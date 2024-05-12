using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    private  Vector2 sample;
    public  Vector2 GetSetProperty
    {
        get { return sample; }
        set { sample = value; }
    }
}
