using UnityEngine;
using System.Collections;

public class CollisionTest : MonoBehaviour {

    private string show = "";

	// Use this for initialization
	void Start () {
        show = "未发生碰撞";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        GUI.Label(new Rect(100, 0, 300, 40), show);
    }

    void OnCollisionEnter(Collision collision)
    {
        show = "进入碰撞，碰撞名称：" + collision.gameObject.name;
    }

    void OnCollisionStay(Collision collision)
    {
        show = "碰撞中，碰撞名称：" + collision.gameObject.name;
    }

    void OnCollisionExit(Collision collision)
    {
        show = "碰撞结束，碰撞名称：" + collision.gameObject.name;
        collision.gameObject.GetComponent<Rigidbody>().Sleep();
    }
}
