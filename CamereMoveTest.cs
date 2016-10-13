using UnityEngine;
using System.Collections;

public class CamereMoveTest : MonoBehaviour {


    public float xAxisRotateMin = -30f;//绕X轴旋转的最小度数限制
    public float xAxisRotateMax = 30f;//            最大

    public float xRotateSpeed = 30f; //绕X轴旋转的速度
    public float yRotateSpeed = 50f;  //绕Y轴旋转的速度


    float yRotateAngle;
    float xRotateAngle;

	// Use this for initialization
	void Start () {
	
	}

    void Update()
    {
        //if (Input.GetMouseButton(0))
        //{
            yRotateAngle += Input.GetAxis("Mouse X") * Time.deltaTime * yRotateSpeed;
            xRotateAngle += Input.GetAxis("Mouse Y") * Time.deltaTime * xRotateSpeed;
            if (xRotateAngle < xAxisRotateMin)
            {
                xRotateAngle = xAxisRotateMin;
            }
            if (xRotateAngle > xAxisRotateMax)
            {
                xRotateAngle = xAxisRotateMax;
            }


            transform.rotation = Quaternion.Euler(new Vector3(-xRotateAngle, yRotateAngle, 0));//设置绕Z轴旋转为0，保证了垂直方向的不倾斜
        //}
    }
}
