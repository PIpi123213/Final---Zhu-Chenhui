using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using static EventOption;

public class eventDetect : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefabToSpawn; // ��Inspector��������Ҫ���ɵ�Ԥ����
    public Inventory[] keyboard;
    public char keyname;
    //public string event1;//Kick Jump
    public characterController characterController;
    private bool a = false;
    
    public EventOptions event2;

    public Canvas targetCanvas;
    void OnTriggerEnter(Collider other)
    {
        // �����ײ�������Ƿ��� "Player" ��ǩ
        if (other.CompareTag("Player"))
        {
            if (!a)
            {
                characterController.SetIsEscaped(false);
                characterController.escapeEvent = event2.ToString();
                a = true;
                characterController.isTrigger = true;
                


                // ����Ԥ���岢������Canvas��
                if (characterController.isTrigger)
                {
                    SpawnPrefabOnCanvas();
                }

            }
            // �ڿ���̨���������Ϣ
          
            
        }
    }

    void SpawnPrefabOnCanvas()
    {
        // ����Ƿ�������Ԥ����
        if (prefabToSpawn != null)
        {
            // ��ȡCanvas����
            Inventory selectedInventory = keyboard[Random.Range(0, keyboard.Length)];
            
            keyname = selectedInventory.letter;
            Canvas canvas = targetCanvas;
            

            // ����ҵ�Canvas������Ԥ���岢������Canvas��
            if (canvas != null)
            {
                // ʵ����Ԥ����
                GameObject spawnedPrefab = Instantiate(selectedInventory.prefab, canvas.transform);

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
