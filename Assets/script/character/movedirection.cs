using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class movedirection : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target; // ��־���Transform
    public float movementSpeed = 1.0f; // ��ɫ�ƶ��ٶ�
    public Animator animator; // ��ɫ��Animator���

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("Target not assigned to CharacterController!");
        }

        if (animator == null)
        {
            Debug.LogError("Animator not assigned to CharacterController!");
        }
    }

    void Update()
    {
        if (carmove.isstrike)
        {
            movementSpeed = 0f;

        }
        // ���㳯��Ŀ��ķ���
        Vector3 directionToTarget = (target.position - transform.position).normalized;

        // ʹ��LookAt����ֱ�ӳ���Ŀ��
        transform.LookAt(target);

        // �ƶ���ɫ
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);

        // �������߶������ٶ�
        float moveSpeed = movementSpeed / 1.0f; // �������ֵ��ƥ�䶯���Ĳ����ٶ�
        animator.SetFloat("MoveSpeed", moveSpeed);
    }
}
