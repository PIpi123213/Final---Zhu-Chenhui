using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GameoverUI; // ���ڴ洢��ͣ�������Ϸ����
    public GameObject GamewinUI;
    public static bool isPaused = false;
    // "Quit" ��ť

    void Start()
    {
        // ��� "Continue" ��ť�ĵ���¼�����
    }
    void Update()
    {
        
        if (GameManager.isgameover)
        {
            
            Invoke("TogglePauseGame", 1.0f);
        }
        if (GameManager.isWin)
        {
            Time.timeScale = 0f;
            GamewinUI.SetActive(true);
        }

    }
    void TogglePauseGame()
    {
       
           Time.timeScale = 0f; // ʱ������Ϊ0����Ϸ��ͣ
        GameoverUI.SetActive(true); // ��ʾ��ͣ����
    }
    public void RetryGame()
    {
        LoadScene();
        
    }
    public void QuitGame()
    {
        Application.Quit(); // �˳���Ϸ
    }
    private void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
