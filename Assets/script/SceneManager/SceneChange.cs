using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ������Ϊ "SampleScene" �ĳ���
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void Back()
    {
        SceneManager.LoadScene("Start");
    }
        
    
}
