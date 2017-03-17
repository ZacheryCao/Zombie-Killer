using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRotation : MonoBehaviour {
    float rotationY = 0F;
    public float sensitivityY = 15F;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        rotationY += Input.GetAxis("Horizontal") * sensitivityY;
        transform.localEulerAngles = new Vector3(0, rotationY, 0);
    }
}
