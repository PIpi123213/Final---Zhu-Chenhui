using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isStart : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject walkman;
    public GameObject standman;
    void Start()
    {
       



    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isStart&&!GameManager.isFirst)
        {
            walkman.SetActive(true);
            standman.SetActive(false);


        }
    }
}
