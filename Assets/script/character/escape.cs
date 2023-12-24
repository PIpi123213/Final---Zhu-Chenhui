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
            
        }
        if (carmove.isstrike)
        {
            PlayDeathAnimation();
            movedirection.movementSpeed = 0;
            characterController.isTrigger = false;
            Explode();
        }


    }
    void PlayDeathAnimation()
    {
        // 确保 Animator 不为空
        if (animator != null)
        {

            string escapeStateName = "Death";
            animator.Play(escapeStateName, -1, 0f);
            carmove.isstrike = false;
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
    void Explode()
    {
        // 获取物体上的 Rigidbody 组件
        Rigidbody rb = GetComponent<Rigidbody>();

        // 如果 Rigidbody 组件不为空，给物体施加爆炸力
        if (rb != null)
        {
            // 使用 AddExplosionForce 方法给物体施加爆炸力
            rb.AddExplosionForce(explosionForce, transform.position, 0f);
        }
        else
        {
            Debug.LogWarning("Rigidbody component not found on the object.");
        }
    }

}
