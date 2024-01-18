using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generate2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] spawnPoints; // 刷新点数组

    void Start()
    {
        // 在开始时随机选择两个刷新点
        List<GameObject> selectedSpawnPoints = new List<GameObject>(RandomSelectSpawnPoints(4));
        DeactivateAllItems();
        // 在选择的刷新点显示物品
        foreach (GameObject spawnPoint in selectedSpawnPoints)
        {
            // 在该刷新点的所有物体中随机选择一个显示
            GameObject selectedItem = spawnPoint.transform.GetChild(Random.Range(0, spawnPoint.transform.childCount)).gameObject;

            // 设置选中物体为激活状态，其他物体禁用
            foreach (Transform child in spawnPoint.transform)
            {
                child.gameObject.SetActive(child.gameObject == selectedItem);
            }
        }
    }
    void DeactivateAllItems()
    {
        foreach (GameObject spawnPoint in spawnPoints)
        {
            foreach (Transform child in spawnPoint.transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
    // 从给定数组中随机选择指定数量的元素
    List<T> RandomSelect<T>(T[] array, int count)
    {
        List<T> selectedItems = new List<T>();
        List<int> selectedIndices = new List<int>();

        for (int i = 0; i < count; i++)
        {
            int randomIndex;
            do
            {
                randomIndex = Random.Range(0, array.Length);
            } while (selectedIndices.Contains(randomIndex));

            selectedItems.Add(array[randomIndex]);
            selectedIndices.Add(randomIndex);
        }

        return selectedItems;
    }

    // 从刷新点数组中随机选择指定数量的刷新点
    List<GameObject> RandomSelectSpawnPoints(int count)
    {
        return RandomSelect(spawnPoints, count);
    }
}
