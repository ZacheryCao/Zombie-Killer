using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
    public GameObject bullet;
    public GameObject bulletHole;
    public GameObject player;
    public float delayTime = 0.9f;

    private float counter=0;
    private Animator ani;
	// Use this for initialization
	void Start () {
        ani = player.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float lefttrigger = Input.GetAxis("Left_Trigger");
        if (lefttrigger!=0)
        {
            ani.enabled = true;
            if(counter>delayTime)
            {
                Instantiate(bullet, transform.position, transform.rotation);
                GetComponent<AudioSource>().Play();
                counter = 0;

                RaycastHit hit;
                Ray ray = new Ray(transform.position, transform.forward);
                if (Physics.Raycast(ray, out hit, 200f))
                {
                    Instantiate(bulletHole,hit.point,Quaternion.FromToRotation(Vector3.up,hit.normal));
                }
            }

        }
        else
        {
            ani.enabled = false;
        }
        counter += Time.deltaTime;
	}
}

