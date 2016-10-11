using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

    public Transform target;
    private float distance = 2.0f;

    float x, y;
    float yMinLimit = -20.0f;
    float yMaxLimit = 80.0f;

    float xSpeed = 250.0f;
    float ySpeed = 120.0f;


	// Use this for initialization
	void Start () {
        Vector2 angles = transform.eulerAngles;
        x = angles.x;
        y = angles.y;

        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
	}

    //float speed = 1.5f;

    //void Update()
    //{
    //    Vector3 data = new Vector3(-Input.GetAxis("Horizontal") * speed * Time.deltaTime, -Input.GetAxis("Vertical") * speed * Time.deltaTime, 0.0f);
    //    transform.Translate(data);
    //}
	
	// Update is called once per frame
    //void Update () {
    //    if (Input.GetKey(KeyCode.RightArrow))
    //    {
    //        //Debug.LogWarning("GetKey(KeyCode.RightArrow): " + Time.deltaTime);
    //        transform.Translate(new Vector3(xSpeed * 1f, 0, 0));
    //    }
    //    if (Input.GetKey(KeyCode.LeftArrow))
    //    {
    //        transform.Translate(new Vector3(-xSpeed * Time.deltaTime, 0, 0));
    //    }
    //    if (Input.GetKey(KeyCode.DownArrow))
    //    {
    //        transform.Translate(new Vector3(0, -xSpeed * Time.deltaTime, 0));
    //    }
    //    if (Input.GetKey(KeyCode.UpArrow))
    //    {
    //        transform.Translate(new Vector3(0, xSpeed * Time.deltaTime, 0));
    //    }
    //}

    void LateUpdate()
    {
        if (target)
        {
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
            y = ClampAngle(y, yMinLimit, yMaxLimit);
            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(0.0f, 0.0f, (-distance)) + target.position;
            transform.rotation = rotation;
            transform.position = position;
        }
    }

    float ClampAngle(float angle, float min, float max)
    {
        
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }

}
