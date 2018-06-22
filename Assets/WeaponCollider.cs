using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollider : MonoBehaviour {

    public static event Delegat WeaponCollided;
    public delegate void Delegat(int a);
	void Start () {
		
	}
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        WeaponCollided(1);
    }
    void OnTriggerExit(Collider other)
    {
        WeaponCollided(0);
    }
    void OnTriggerStay(Collider other)
    {
        WeaponCollided(1);
    }
}
