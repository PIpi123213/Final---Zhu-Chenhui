using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool isTrigger = false;
    public Animator animator;
    public static bool isDead = false;
    public static bool isEscaped = false;
    public Rigidbody rb;
    public float delayBeforeMove = 1.0f; // 设置延迟时间
    public float jumpHeight = 2.0f; // 设置跳跃的高度
    public float forwardDistance = 5.0f;
    private bool isJump = false;
    public static string escapeEvent;




    void Update()
    {
        // 检查当前播放的动画状态信息
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (isDead)
        {
            PlayDeathAnimation();
            GameManager.isgameover = true;
        }
        // 如果当前动画为 "walking"
        if (stateInfo.IsName("Walk"))
        {
            // 执行相应的操作，例如设置 a 为 0
            // 在这里你可以添加你的逻辑
            movedirection.movementSpeed = 1.0f;
            isJump = false;
            //SetIsEscaped(false);
        }
        else
        {
            movedirection.movementSpeed = 0.0f;
            //carmove.moveSpeed = 0.0f;
            if (stateInfo.IsName("Jump"))
            {
                if (isJump == false)
                {
                    StartCoroutine(MoveAfterDelay());
                }

            }
               
            

        }

        IEnumerator MoveAfterDelay()
        {
            // 等待一段时间
            yield return new WaitForSeconds(delayBeforeMove);
            isJump = true;
            // 在 y 轴上移动一定距离
            transform.position += new Vector3(0f, jumpHeight, 0f);

            // 在 z 轴上移动一定距离（可根据需要调整方向）
            transform.position += transform.forward * forwardDistance;
        }

    }
    public void PlayDeathAnimation()
    {
        // 确保 Animator 不为空
        if (animator != null)
        {

            string escapeStateName = "Death";
            animator.Play(escapeStateName, -1, 0f);
            isDead = false;
        }
    }
    public void PlayEscapeAnimation()
    {
        // 确保 Animator 不为空
        if (animator != null)
        {
            Debug.Log("1");
            string escapeStateName = escapeEvent;


            // 播放指定的动画状态
            animator.Play(escapeStateName, -1, 0f);

            
            SetIsEscaped(true);
            // 最后一个参数是 normalizedTime，在这里设置为 0 表示从动画的开始位置开始播放
        }
        else
        {
            Debug.LogWarning("Animator component is not assigned.");
        }
    }
    public void PlayEscapeAnimation2()
    {
        // 确保 Animator 不为空
        if (animator != null)
        {
            // 指定动画状态的名字，注意这里是动画状态的名字而不是参数名字
            string escapeStateName = escapeEvent;


            
            animator.Play(escapeStateName, -1, 0f);

           
            
            
        }
        else
        {
            Debug.LogWarning("Animator component is not assigned.");
        }
    }


    public void SetIsEscaped(bool value)
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
    void OnTriggerEnter(Collider other)
    {
        // 检测碰撞的物体是否有 "Player" 标签
        if (other.CompareTag("Win"))
        {
            GameManager.isWin = true;
            // 在控制台输出调试信息


        }
    }




}
