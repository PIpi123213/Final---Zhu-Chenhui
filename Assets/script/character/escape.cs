using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static EventOption;
using UnityEngine.UI;


public class escape : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public bool isEscaped ;
    public float explosionForce = 10.0f;
    public characterController characterController;
    public eventDetect eventDetect;

    public float decreaseSpeed = 0.1f; // 进度条减少速度
    public float maxProgress = 1f; // 进度条最大值
    
    public float currentProgress = 0.3f;
    public Slider progressBar;
    private bool isProgressBarCreated = false;

    public float delayInSeconds = 5.0f;
    void Start()
    {
        isEscaped = false;
        
        progressBar.value = Mathf.Clamp01(currentProgress);
        //progressBar.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isEscaped)
        {

            Invoke("DestroyObject", delayInSeconds);


        }
        if (eventDetect.b)
        {
            if (characterController.isTrigger)
            {

                if (eventDetect.event2.ToString() != "Defence")
                {
                    Debug.Log(eventDetect.event2 + gameObject.name);

                    if (Input.anyKeyDown && Input.inputString.Length > 0 && Input.inputString[0] == eventDetect.keyname)
                    {

                        isEscaped = true;
                        characterController.PlayEscapeAnimation();
                        characterController.isTrigger = false;




                    }

                }

                else if (eventDetect.event2.ToString() == "Defence")
                {
                    Debug.Log(eventDetect.event2 + gameObject.name);
                    Canvas mainCanvas = GameObject.Find("MainCanvas").GetComponent<Canvas>();


                    if (Input.anyKeyDown && Input.inputString.Length > 0 && Input.inputString[0] == eventDetect.keyname)
                    {
                        if (!isProgressBarCreated)
                        {
                            progressBar = Instantiate(progressBar, mainCanvas.transform);
                            progressBar.value = Mathf.Clamp01(currentProgress);
                            isProgressBarCreated = true;
                        }



                        //progressBar.gameObject.SetActive(true);
                        carmove carmove = GetComponent<carmove>();
                        if (carmove != null)
                        {
                            carmove.moveSpeed = 0.0f;

                        }
                        progressBar.value += 0.1f;

                        characterController.PlayEscapeAnimation2();


                        // 减少进度条


                        // 如果时间超过限制，显示失败文本


                    }
                    if (progressBar.value >= maxProgress)
                    {
                        isEscaped = true;
                        characterController.isTrigger = false;
                        //progressBar.gameObject.SetActive(false);
                        DestroyImmediate(progressBar.gameObject);
                        isProgressBarCreated = false;
                        characterController.SetIsEscaped(true);

                    }
                    else if (progressBar.value <= 0f)
                    {
                        //progressBar.gameObject.SetActive(false);
                        DestroyImmediate(progressBar.gameObject);
                        isProgressBarCreated = false;
                        carmove carmove = GetComponent<carmove>();
                        if (carmove != null && carmove.start.isstart)
                        {
                            carmove.moveSpeed = carmove.speed;
                        }

                    }

                    progressBar.value = Mathf.MoveTowards(progressBar.value, 0f, decreaseSpeed * Time.deltaTime);
                }
            }
        }
        
        if (characterController.isDead)
        {
           
            characterController.isTrigger = false;
            
        }


    }
    void DestroyObject()
    {
        // 销毁物体
        Destroy(gameObject);
    }

}
