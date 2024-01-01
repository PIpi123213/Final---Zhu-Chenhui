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
        // 计算起点到终点的总距离
        float totalDistance = Vector3.Distance(startPoint.position, endPoint.position);

        // 计算起点到角色当前位置的距离
        float currentDistance = Vector3.Distance(startPoint.position, player.position);

        // 计算百分比
        float relativeDistancePercentage = (currentDistance / totalDistance);

        // 更新 Slider 的值
        distanceSlider.value = relativeDistancePercentage;

        // 当达到百分之百时，说明角色抵达终点

    }
}
