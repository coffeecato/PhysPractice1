using UnityEngine;
using System.Collections;

public class FirstPersonPractice : MonoBehaviour {

    private Camera myCamera;

    private Quaternion m_CharacterTargetRot; 
    private Quaternion m_CameraTargetRot;
	// Use this for initialization
	void Start () {
        myCamera = GetComponent<Camera>();

        //m_CharacterTargetRot = GetComponent<Transform>().localRotation;
        m_CharacterTargetRot = transform.localRotation;
        Debug.LogWarning("FirstPersonPractice m_CharacterTargetRot: " + m_CharacterTargetRot);
        m_CameraTargetRot = myCamera.GetComponent<Transform>().localRotation;
	}
	
	// Update is called once per frame
	void Update () {
        LookRotation(GetComponent<Transform>(), myCamera.GetComponent<Transform>());
	}

    void LookRotation(Transform character, Transform camera)
    {
        float yRot = Input.GetAxis("Mouse X") * 2.0f;
        float xRot = Input.GetAxis("Mouse Y") * 2.0f;

        //Debug.LogWarning("yRot: " + yRot + ", xRot: " + xRot);

        m_CharacterTargetRot *= Quaternion.Euler(0f, yRot, 0f);
        m_CameraTargetRot *= Quaternion.Euler(-xRot, 0f, 0f);

        m_CameraTargetRot = ClampRotationAroundXAxis(m_CameraTargetRot);

        character.localRotation = m_CharacterTargetRot;
        camera.localRotation = m_CameraTargetRot;
    }

    /*
             float yRot = CrossPlatformInputManager.GetAxis("Mouse X") * XSensitivity;
        float xRot = CrossPlatformInputManager.GetAxis("Mouse Y") * YSensitivity;

        m_CharacterTargetRot *= Quaternion.Euler(0f, yRot, 0f);
        m_CameraTargetRot *= Quaternion.Euler(-xRot, 0f, 0f);

        if (clampVerticalRotation)
            m_CameraTargetRot = ClampRotationAroundXAxis(m_CameraTargetRot);

        if (smooth)
        {
            character.localRotation = Quaternion.Slerp(character.localRotation, m_CharacterTargetRot,
                smoothTime * Time.deltaTime);
            camera.localRotation = Quaternion.Slerp(camera.localRotation, m_CameraTargetRot,
                smoothTime * Time.deltaTime);
        }
        else
        {
            character.localRotation = m_CharacterTargetRot;
            camera.localRotation = m_CameraTargetRot;
        }
     */

    Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

        angleX = Mathf.Clamp(angleX, -90f, 90f);

        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }
}
