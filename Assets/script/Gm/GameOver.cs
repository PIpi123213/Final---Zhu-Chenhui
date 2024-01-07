using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GameoverUI; // 用于存储暂停界面的游戏对象
    public GameObject GamewinUI;
    public static bool isPaused = false;
    // "Quit" 按钮

    void Start()
    {
        // 添加 "Continue" 按钮的点击事件处理
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
       
           Time.timeScale = 0f; // 时间缩放为0，游戏暂停
        GameoverUI.SetActive(true); // 显示暂停界面
    }
    public void RetryGame()
    {
        LoadScene();
        
    }
    public void QuitGame()
    {
        Application.Quit(); // 退出游戏
    }
    private void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
