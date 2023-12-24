using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escape : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public static bool isEscaped = false;
    public float explosionForce = 10.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (characterController.isTrigger)
        {
            // 如果检测到 istrigger 为 true，则传递给 Animator 并设置 isescaped 为 true
            if (Input.GetKeyDown(KeyCode.S))
            {
                
                PlayEscapeAnimation();
                isEscaped = true;


            }
            if (carmove.isstrike)
            {
                PlayDeathAnimation();

            }
        }
        


    }
    void PlayDeathAnimation()
    {
        // 确保 Animator 不为空
        if (animator != null)
        {

            string escapeStateName = "Death";
            animator.Play(escapeStateName, -1, 0f);

        }
    }
    void PlayEscapeAnimation()
    {
        // 确保 Animator 不为空
        if (animator != null)
        {
            // 指定动画状态的名字，注意这里是动画状态的名字而不是参数名字
            string escapeStateName = "Escape";
            
            // 播放指定的动画状态
            animator.Play(escapeStateName, -1, 0f);
            SetIsEscaped(true);// 最后一个参数是 normalizedTime，在这里设置为 0 表示从动画的开始位置开始播放
        }
        else
        {
            Debug.LogWarning("Animator component is not assigned.");
        }
    }


    IEnumerator ReturnToDefaultAnimation()
    {
        yield return new WaitForSeconds(1.0f); // 延迟1秒钟，可以根据需要调整时间

        // 指定默认走路动画的名字
        string walkStateName = "Walk";

        // 播放默认的走路动画
        animator.Play(walkStateName, -1, 0f);
    }
    void SetIsEscaped(bool value)
    {
        // 确保 Animator 不为空
        if (animator != null)
        {
            // 通过设置 Animator 中的参数来传递值
            animator.SetBool("isEscaped", value);
        }
        else
        {
            Debug.LogWarning("Animator component is not assigned.");
        }
    }
    
}
