using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventDetect : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefabToSpawn; // ��Inspector��������Ҫ���ɵ�Ԥ����

    void OnTriggerEnter(Collider other)
    {
        // �����ײ�������Ƿ��� "Player" ��ǩ
        if (other.CompareTag("Player"))
        {
            // �ڿ���̨���������Ϣ
            Debug.Log("Debug1");
            characterController.isTrigger = true;
            // ����Ԥ���岢������Canvas��
            if (characterController.isTrigger)
            {
                SpawnPrefabOnCanvas();
            }
            
        }
    }

    void SpawnPrefabOnCanvas()
    {
        // ����Ƿ�������Ԥ����
        if (prefabToSpawn != null)
        {
            // ��ȡCanvas����
            Canvas canvas = FindObjectOfType<Canvas>();

            // ����ҵ�Canvas������Ԥ���岢������Canvas��
            if (canvas != null)
            {
                // ʵ����Ԥ����
                GameObject spawnedPrefab = Instantiate(prefabToSpawn, canvas.transform);

                // ��������������ɵ�Ԥ������н�һ��������
            }
            else
            {
                Debug.LogWarning("Canvas not found in the scene.");
            }
        }
        else
        {
            Debug.LogWarning("Prefab to spawn is not assigned.");
        }
    }
}
