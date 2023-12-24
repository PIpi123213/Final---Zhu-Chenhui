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
            // �����⵽ istrigger Ϊ true���򴫵ݸ� Animator ������ isescaped Ϊ true
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
        // ȷ�� Animator ��Ϊ��
        if (animator != null)
        {

            string escapeStateName = "Death";
            animator.Play(escapeStateName, -1, 0f);
            carmove.isstrike = false;
        }
    }
    void PlayEscapeAnimation()
    {
        // ȷ�� Animator ��Ϊ��
        if (animator != null)
        {
            // ָ������״̬�����֣�ע�������Ƕ���״̬�����ֶ����ǲ�������
            string escapeStateName = "Escape";
            
            // ����ָ���Ķ���״̬
            animator.Play(escapeStateName, -1, 0f);
            SetIsEscaped(true);// ���һ�������� normalizedTime������������Ϊ 0 ��ʾ�Ӷ����Ŀ�ʼλ�ÿ�ʼ����
        }
        else
        {
            Debug.LogWarning("Animator component is not assigned.");
        }
    }


    
    void SetIsEscaped(bool value)
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
    void Explode()
    {
        // ��ȡ�����ϵ� Rigidbody ���
        Rigidbody rb = GetComponent<Rigidbody>();

        // ��� Rigidbody �����Ϊ�գ�������ʩ�ӱ�ը��
        if (rb != null)
        {
            // ʹ�� AddExplosionForce ����������ʩ�ӱ�ը��
            rb.AddExplosionForce(explosionForce, transform.position, 0f);
        }
        else
        {
            Debug.LogWarning("Rigidbody component not found on the object.");
        }
    }

}
