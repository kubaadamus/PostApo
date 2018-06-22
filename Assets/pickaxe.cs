using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickaxe : MonoBehaviour {

    bool Pickaxe_Hit = false;
    float pickaxe_x_rotation = 0;
    public GameObject PickaxeDefaultPosition;
    public GameObject PickaxeHiddenPosition;
    bool WeaponHidden = false;

    void Start () {
        WeaponCollider.WeaponCollided += WeaponCollisionEventHandler;
    }
	
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Pickaxe_Hit = true;
            pickaxe_x_rotation = 0;
        }
        if(Pickaxe_Hit)
        {
            Pickaxe_Hit_Animation();
        }
        if(WeaponHidden)
        {
            transform.position += (PickaxeHiddenPosition.transform.position - transform.position)/5;
        }
        if (!WeaponHidden)
        {
            transform.position += (PickaxeDefaultPosition.transform.position - transform.position)/5;
        }
    }

    void Pickaxe_Hit_Animation()
    {
        transform.localRotation = Quaternion.Euler(Mathf.Sin(pickaxe_x_rotation)*90,-10,-20);
        pickaxe_x_rotation += 0.3f;
        if(pickaxe_x_rotation >= Mathf.PI)
        {
            pickaxe_x_rotation = 0;
            Pickaxe_Hit = false;
        }
    }

    void WeaponCollisionEventHandler(int a)
    {

        if(a==1)
        {
            WeaponHidden = true;
        }
        if (a == 0)
        {
            WeaponHidden = false;
        }
    }

}
