using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Butncrick : MonoBehaviour
{
    void Update()
    {
     
    }
    public void OnRetry()
    {
        SceneManager.LoadScene("kazuyaScenes");
    }
}
