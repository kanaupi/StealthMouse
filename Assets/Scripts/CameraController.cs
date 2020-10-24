using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject targetObj;
    Vector3 targetPos;

    float angleV;
    void Start()
    {
        
        targetPos = targetObj.transform.position;

    }

    void Update()
    {
        // targetの移動量分、自分（カメラ）も移動する
        transform.position += targetObj.transform.position - targetPos;
        targetPos = targetObj.transform.position;

        
        // マウスの右クリックを押している間
        if (Input.GetMouseButton(1))
        {
            // マウスの移動量
            float mouseInputX = Input.GetAxis("Mouse X");
            float mouseInputY = Input.GetAxis("Mouse Y");

            float deltaAngleH = mouseInputX * Time.deltaTime * 200f;
            float deltaAngleV = -mouseInputY * Time.deltaTime * 200f;


            angleV += deltaAngleV;

            float clampedAngleV = Mathf.Clamp(angleV, 0, 30);

            float overshootV = angleV - clampedAngleV;

            deltaAngleV -= overshootV;
     
            angleV = clampedAngleV;
            // targetの位置のY軸を中心に、回転（公転）する
            transform.RotateAround(targetPos, Vector3.up, deltaAngleH);
            // カメラの垂直移動
            transform.RotateAround(targetPos, transform.right, deltaAngleV);

            
        }

    }

}