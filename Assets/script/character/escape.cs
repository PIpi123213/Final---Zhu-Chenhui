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
    public float timeLimit = 10f; // 时间限制
    public float currentProgress = 0.3f;
    public Slider progressBar;

    void Start()
    {
        isEscaped = false;
        progressBar.value = Mathf.Clamp01(currentProgress);
        progressBar.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (characterController.isTrigger)
        {
            if (eventDetect.event2.ToString()!="Defence")
            {
                
                if (Input.anyKeyDown && Input.inputString.Length > 0 && Input.inputString[0] == eventDetect.keyname)
                {

                    isEscaped = true;
                    characterController.PlayEscapeAnimation();
                    characterController.isTrigger = false;
                    
                    


                }

            }
            else if(eventDetect.event2.ToString() == "Defence")
            {
                
                progressBar.value = Mathf.MoveTowards(progressBar.value, 0f, decreaseSpeed * Time.deltaTime);
                
                if (Input.anyKeyDown && Input.inputString.Length > 0 && Input.inputString[0] == eventDetect.keyname)
                {
                    progressBar.gameObject.SetActive(true);
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
                    progressBar.gameObject.SetActive(false);

                    characterController.SetIsEscaped(true);

                }
                else if (progressBar.value <= 0f)
                {
                    progressBar.gameObject.SetActive(false);
                    carmove carmove = GetComponent<carmove>();
                    if (carmove != null)
                    {
                        carmove.moveSpeed = 5.0f;

                    }
                }


            }     
        }
        if (characterController.isDead)
        {
           
            characterController.isTrigger = false;
            
        }


    }
    

}
