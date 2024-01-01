using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Distance : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform startPoint;
    public Transform endPoint;
    public Transform player;
    
    public Slider distanceSlider;
    void Update()
    {
        // ������㵽�յ���ܾ���
        float totalDistance = Vector3.Distance(startPoint.position, endPoint.position);

        // ������㵽��ɫ��ǰλ�õľ���
        float currentDistance = Vector3.Distance(startPoint.position, player.position);

        // ����ٷֱ�
        float relativeDistancePercentage = (currentDistance / totalDistance);

        // ���� Slider ��ֵ
        distanceSlider.value = relativeDistancePercentage;

        // ���ﵽ�ٷ�֮��ʱ��˵����ɫ�ִ��յ�

    }
}
