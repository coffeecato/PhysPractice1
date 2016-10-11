using UnityEngine;
using System.Collections;

public class AddForcePractice : MonoBehaviour {

    private GameObject addForceObj = null;
    private GameObject addPosObj = null;
    private GameObject cubeObj = null;



	// Use this for initialization
	void Start () {
        addForceObj = GameObject.Find("Sphere0");
        addPosObj = GameObject.Find("Sphere1");
        cubeObj = GameObject.Find("Cube");


	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnGUI()
    {
        if (GUILayout.Button("普通力", GUILayout.Height(50)))
        {
            addForceObj.GetComponent<Rigidbody>().AddForce(1000, 0, 1000);
        }
        if (GUILayout.Button("位置力", GUILayout.Height(50)))
        {
            Vector3 force = cubeObj.GetComponent<Transform>().position - addPosObj.GetComponent<Transform>().position;
            addPosObj.GetComponent<Rigidbody>().AddForceAtPosition(force, addPosObj.GetComponent<Transform>().position, ForceMode.Impulse);
        }


    }


}
