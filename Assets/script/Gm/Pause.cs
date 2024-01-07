using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenuUI; // 用于存储暂停界面的游戏对象
    
    public static bool isPaused = false;
        // "Quit" 按钮
    
    void Start()
    {
        // 添加 "Continue" 按钮的点击事件处理
    }
    void Update()
    {
        // 检测按下"Esc"键
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
            Time.timeScale = 0f; // 时间缩放为0，游戏暂停
            pauseMenuUI.SetActive(true); // 显示暂停界面
        }
        else
        {
            Time.timeScale = 1f; // 恢复正常时间流逝
            pauseMenuUI.SetActive(false); // 隐藏暂停界面
        }
    }
    public void ContinueGame()
    {
        
        isPaused = false;
        Time.timeScale = 1f; // 恢复正常时间流逝
        pauseMenuUI.SetActive(false); // 隐藏暂停界面
    }
    public void QuitGame()
    {
        Application.Quit(); // 退出游戏
    }
  

}






