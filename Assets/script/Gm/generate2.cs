using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generate2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] spawnPoints; // ˢ�µ�����

    void Start()
    {
        // �ڿ�ʼʱ���ѡ������ˢ�µ�
        List<GameObject> selectedSpawnPoints = new List<GameObject>(RandomSelectSpawnPoints(4));
        DeactivateAllItems();
        // ��ѡ���ˢ�µ���ʾ��Ʒ
        foreach (GameObject spawnPoint in selectedSpawnPoints)
        {
            // �ڸ�ˢ�µ���������������ѡ��һ����ʾ
            GameObject selectedItem = spawnPoint.transform.GetChild(Random.Range(0, spawnPoint.transform.childCount)).gameObject;

            // ����ѡ������Ϊ����״̬�������������
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
    // �Ӹ������������ѡ��ָ��������Ԫ��
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

    // ��ˢ�µ����������ѡ��ָ��������ˢ�µ�
    List<GameObject> RandomSelectSpawnPoints(int count)
    {
        return RandomSelect(spawnPoints, count);
    }
}
