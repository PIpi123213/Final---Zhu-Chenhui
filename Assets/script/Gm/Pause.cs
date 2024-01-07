using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenuUI; // ���ڴ洢��ͣ�������Ϸ����
    
    public static bool isPaused = false;
        // "Quit" ��ť
    
    void Start()
    {
        // ��� "Continue" ��ť�ĵ���¼�����
    }
    void Update()
    {
        // ��ⰴ��"Esc"��
        if (Input.GetKeyDown(KeyCode.Escape)&&!GameManager.isgameover)
        {
            TogglePauseGame();
        }
       
    }

    void TogglePauseGame()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // ʱ������Ϊ0����Ϸ��ͣ
            pauseMenuUI.SetActive(true); // ��ʾ��ͣ����
        }
        else
        {
            Time.timeScale = 1f; // �ָ�����ʱ������
            pauseMenuUI.SetActive(false); // ������ͣ����
        }
    }
    public void ContinueGame()
    {
        
        isPaused = false;
        Time.timeScale = 1f; // �ָ�����ʱ������
        pauseMenuUI.SetActive(false); // ������ͣ����
    }
    public void QuitGame()
    {
        Application.Quit(); // �˳���Ϸ
    }
  

}






