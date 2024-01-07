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
    public float delayBeforeMove = 1.0f; // �����ӳ�ʱ��
    public float jumpHeight = 2.0f; // ������Ծ�ĸ߶�
    public float forwardDistance = 5.0f;
    private bool isJump = false;
    public static string escapeEvent;




    void Update()
    {
        // ��鵱ǰ���ŵĶ���״̬��Ϣ
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (isDead)
        {
            PlayDeathAnimation();
            GameManager.isgameover = true;
        }
        // �����ǰ����Ϊ "walking"
        if (stateInfo.IsName("Walk"))
        {
            // ִ����Ӧ�Ĳ������������� a Ϊ 0
            // ������������������߼�
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
            // �ȴ�һ��ʱ��
            yield return new WaitForSeconds(delayBeforeMove);
            isJump = true;
            // �� y �����ƶ�һ������
            transform.position += new Vector3(0f, jumpHeight, 0f);

            // �� z �����ƶ�һ�����루�ɸ�����Ҫ��������
            transform.position += transform.forward * forwardDistance;
        }

    }
    public void PlayDeathAnimation()
    {
        // ȷ�� Animator ��Ϊ��
        if (animator != null)
        {

            string escapeStateName = "Death";
            animator.Play(escapeStateName, -1, 0f);
            isDead = false;
        }
    }
    public void PlayEscapeAnimation()
    {
        // ȷ�� Animator ��Ϊ��
        if (animator != null)
        {
            Debug.Log("1");
            string escapeStateName = escapeEvent;


            // ����ָ���Ķ���״̬
            animator.Play(escapeStateName, -1, 0f);

            
            SetIsEscaped(true);
            // ���һ�������� normalizedTime������������Ϊ 0 ��ʾ�Ӷ����Ŀ�ʼλ�ÿ�ʼ����
        }
        else
        {
            Debug.LogWarning("Animator component is not assigned.");
        }
    }
    public void PlayEscapeAnimation2()
    {
        // ȷ�� Animator ��Ϊ��
        if (animator != null)
        {
            // ָ������״̬�����֣�ע�������Ƕ���״̬�����ֶ����ǲ�������
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
        // ȷ�� Animator ��Ϊ��
        if (animator != null)
        {
            // ͨ������ Animator �еĲ���������ֵ
            animator.SetBool("isEscaped", value);
        }
        else
        {
            Debug.LogWarning("Animator component is not assigned.");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        // �����ײ�������Ƿ��� "Player" ��ǩ
        if (other.CompareTag("Win"))
        {
            GameManager.isWin = true;
            // �ڿ���̨���������Ϣ


        }
    }




}
