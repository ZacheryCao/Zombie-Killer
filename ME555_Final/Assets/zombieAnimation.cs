using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class zombieAnimation : MonoBehaviour {

    public float move=1.0f;
    
    enum State
    {
        Walk, Attack , backFall, leftFall, rightFall
    }
    State currentState = State.Walk;
    Animator anim;


	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {




        if(currentState == State.Walk)
        {
            transform.Translate(0, 0, move);
            anim.SetBool("Attack", false);
            anim.SetBool("backFall", false);
            anim.SetBool("leftFall", false);
            anim.SetBool("rightFall", false);
        }
        else if(currentState == State.Attack)
        {
            anim.SetBool("Attack", true);
            anim.SetBool("backFall", false);
            anim.SetBool("leftFall", false);
            anim.SetBool("rightFall", false);
        }
        else if (currentState == State.backFall)
        {
            anim.SetBool("Attack", false);
            anim.SetBool("backFall", true);
            anim.SetBool("leftFall", false);
            anim.SetBool("rightFall", false);
        }
        else if (currentState == State.leftFall)
        {
            anim.SetBool("Attack", false);
            anim.SetBool("backFall", false);
            anim.SetBool("leftFall", true);
            anim.SetBool("rightFall", false);
        }
        else
        {
            anim.SetBool("Attack", false);
            anim.SetBool("backFall", false);
            anim.SetBool("leftFall", false);
            anim.SetBool("rightFall", true);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            currentState = State.Attack;
        }

        else if(other.gameObject.tag == "bullet")
        {
            Debug.Log("In");
            byte[] randomBytes = new byte[4];
            RNGCryptoServiceProvider rngCrypto = new RNGCryptoServiceProvider();
            rngCrypto.GetBytes(randomBytes);
            int ranNum = System.BitConverter.ToInt32(randomBytes, 0);
            ranNum = Mathf.Abs(ranNum % 3);

            if (ranNum == 0)
            {
                currentState = State.backFall;
            }
            else if(ranNum == 1)
            {
                currentState = State.leftFall;
            }
            else
            {
                currentState = State.rightFall;
            }
        }
            
    }


}
