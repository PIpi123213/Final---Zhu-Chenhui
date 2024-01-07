using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using static EventOption;

public class eventDetect : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefabToSpawn; // 在Inspector中设置需要生成的预制体
    public Inventory[] keyboard;
    public char keyname;
    //public string event1;//Kick Jump
    public characterController characterController;
    private bool a = false;
    
    public EventOptions event2;

    public Canvas targetCanvas;
    void OnTriggerEnter(Collider other)
    {
        // 检测碰撞的物体是否有 "Player" 标签
        if (other.CompareTag("Player"))
        {
            if (!a)
            {
                characterController.SetIsEscaped(false);
                characterController.escapeEvent = event2.ToString();
                a = true;
                characterController.isTrigger = true;
                


                // 生成预制体并放置在Canvas上
                if (characterController.isTrigger)
                {
                    SpawnPrefabOnCanvas();
                }

            }
            // 在控制台输出调试信息
          
            
        }
    }

    void SpawnPrefabOnCanvas()
    {
        // 检查是否设置了预制体
        if (prefabToSpawn != null)
        {
            // 获取Canvas对象
            Inventory selectedInventory = keyboard[Random.Range(0, keyboard.Length)];
            
            keyname = selectedInventory.letter;
            Canvas canvas = targetCanvas;
            

            // 如果找到Canvas，生成预制体并放置在Canvas上
            if (canvas != null)
            {
                // 实例化预制体
                GameObject spawnedPrefab = Instantiate(selectedInventory.prefab, canvas.transform);

                // 可以在这里对生成的预制体进行进一步的设置
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
