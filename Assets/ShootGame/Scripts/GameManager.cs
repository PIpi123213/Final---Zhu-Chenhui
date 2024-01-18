using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // 引入 TextMeshPro 的命名空间
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int score;
    public TextMeshProUGUI scoreText; // 使用 TextMeshProUGUI 而不是 Text
    public static bool isStart = false;
    public GameObject StartPoint;
    public static bool isgameover = false;
    public static bool isFirst = true;
    public static bool isWin = false;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        isgameover = false;
        isWin = false;
        score = 0;
        if (!isFirst)
        {
            
            isStart = true;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();


        if (Text123.isCreate2&&isFirst)
        {

            StartPoint.SetActive(true);


        }
    }

    public void GameOver()
    {
        //Invoke("LoadScene", 3.0f);
    }

    private void LoadScene()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}