using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    Vector2 Mouse;
    Vector2 Look;
    Vector2 Move;
    bool Sprint = false;
    bool CanJump = true;
    Rigidbody Body;
    void Start () {
        Body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Mouse = new Vector2(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));
        Look += Mouse;
        transform.rotation = Quaternion.EulerAngles(0,Look.y/20,0);
        Move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if(Input.GetKey(KeyCode.LeftShift))
        {
        transform.Translate(Move.x / 5, 0, Move.y / 5);
        }
        else
        {
        transform.Translate(Move.x / 10, 0, Move.y / 10);
        }


        if(Input.GetKeyDown(KeyCode.Space) && CanJump)
        {
            Body.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            CanJump = false;
        }

        
        
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ground")
        {
            CanJump = true;
        }
    }
}
