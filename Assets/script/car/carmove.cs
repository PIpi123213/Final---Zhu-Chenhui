using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carmove : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 0f; // �ƶ��ٶȣ�������Inspector������
    public float speed = 5.0f;
    //public static bool isstrike = false;
    public start start;
    private bool hasStarted = false;
    private escape escape1;
    void Start()
    {
        escape1 = GetComponent<escape>();

    }
    void Update()
    {
        if (start.isstart && !characterController.isDead)
        {
            
            if (!hasStarted)
            {
                // ��һ������������ִ�в���
                moveSpeed = speed;
                hasStarted = true;
                
                
                // ����־����Ϊ true����ֹ�ٴ�ִ��
            }
        }

        if (escape1.isEscaped)
        {

            moveSpeed = 0f;
        }
        // ��ȡ�����Transform���
        Transform objectTransform = transform;

        // �����ƶ����������ǰ������
        Vector3 moveDirection = objectTransform.forward;


        // ���ƶ������׼�����������ٶ�
        Vector3 moveAmount = moveDirection.normalized * moveSpeed;

        // ʹ��Translate�����ƶ�����
        objectTransform.Translate(moveAmount * Time.deltaTime, Space.World);
    }
    void OnCollisionEnter(Collision collision)
    {

        // �����ײ�������Ƿ��� "car" ��ǩ
        if (collision.gameObject.CompareTag("Player"))
        {
            
            
            characterController.isDead = true;
            enabled = false;
        }
    }
}
