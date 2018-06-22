using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    Vector2 Mouse;
    Vector2 Look;
    Vector2 Move;
    public GameObject RayShootPosition;
    float Distance = 10;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Mouse = new Vector2(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));
        Look += Mouse;
        transform.localRotation = Quaternion.EulerAngles(Look.x/20,0,0);

        if(Input.GetMouseButtonDown(0))
        {
            Ray();
        }
        Debug.DrawRay(RayShootPosition.transform.position, transform.forward, Color.green);
    }

    void Ray()
    {
        RaycastHit hit;
        if(Physics.Raycast(RayShootPosition.transform.position, transform.forward, out hit, Distance))
        {
            Debug.Log(hit.transform.tag);
            Destroy(hit.transform.gameObject);
        }
    }
}
