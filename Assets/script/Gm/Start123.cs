using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start123 : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.isStart = true;
            this.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (GameManager.isStart)
        {
            this.gameObject.SetActive(false);
        }
    }
}
