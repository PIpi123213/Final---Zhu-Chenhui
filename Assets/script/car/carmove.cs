using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carmove : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5.0f; // �ƶ��ٶȣ�������Inspector������
    public static bool isstrike = false;
    void Update()
    {
        // ��ȡ�����Transform���
        Transform objectTransform = transform;

        // �����ƶ����������ǰ������
        Vector3 moveDirection = objectTransform.forward;

        // ���ƶ������׼�����������ٶ�
        Vector3 moveAmount = moveDirection.normalized * moveSpeed;

        // ʹ��Translate�����ƶ�����
        objectTransform.Translate(-moveAmount * Time.deltaTime);
    }
    void OnCollisionEnter(Collision collision)
    {

        // �����ײ�������Ƿ��� "car" ��ǩ
        if (collision.gameObject.CompareTag("Player"))
        {
            moveSpeed = 0f;
            isstrike = true;
            /*Collider myCollider = GetComponent<Collider>();
            if (myCollider != null)
            {
                myCollider.enabled = false;
            }*/
        }
    }
}
