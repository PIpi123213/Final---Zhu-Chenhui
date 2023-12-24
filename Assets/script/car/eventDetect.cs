using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventDetect : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefabToSpawn; // 在Inspector中设置需要生成的预制体

    void OnTriggerEnter(Collider other)
    {
        // 检测碰撞的物体是否有 "Player" 标签
        if (other.CompareTag("Player"))
        {
            // 在控制台输出调试信息
            Debug.Log("Debug1");
            characterController.isTrigger = true;
            // 生成预制体并放置在Canvas上
            if (characterController.isTrigger)
            {
                SpawnPrefabOnCanvas();
            }
            
        }
    }

    void SpawnPrefabOnCanvas()
    {
        // 检查是否设置了预制体
        if (prefabToSpawn != null)
        {
            // 获取Canvas对象
            Canvas canvas = FindObjectOfType<Canvas>();

            // 如果找到Canvas，生成预制体并放置在Canvas上
            if (canvas != null)
            {
                // 实例化预制体
                GameObject spawnedPrefab = Instantiate(prefabToSpawn, canvas.transform);

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
