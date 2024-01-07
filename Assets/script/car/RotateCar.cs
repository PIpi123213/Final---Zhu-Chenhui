using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCar : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target; // Ŀ���Transform���
    public float rotationSpeed = 8.0f;
    public RotateHappen rotateHappen;
    void Update()
    {
        // ����Ƿ���Ŀ��

        if (rotateHappen.isrotate)
        {
            if (target != null)
            {
                // ��ȡĿ�귽��
                Vector3 targetDirection = target.position - transform.position;

                // ������ת�Ƕȣ�ֻ����ˮƽ����
                float angle = Mathf.Atan2(targetDirection.x, targetDirection.y) * Mathf.Rad2Deg;

                // ʹ��Quaternion.Euler����ֻ��y���ϵ���ת
                Quaternion targetRotation = Quaternion.Euler(0, angle, 0);

                // Ӧ����ת
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }

        }
       
    }
}
