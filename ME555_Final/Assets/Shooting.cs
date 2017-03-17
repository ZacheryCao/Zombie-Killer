using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
    public GameObject bullet;
    public GameObject player;
    private Animator ani;
	// Use this for initialization
	void Start () {
        ani = player.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float lefttrigger = Input.GetAxis("Left_Trigger");
        if (lefttrigger!=0)
        {
            ani.enabled = true;
        }
        else
        {
            ani.enabled = false;
        }
	}
}

