using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knightControl : MonoBehaviour {
    public Animator anim;
    public Rigidbody rbody;
    private float inputH;
    private float inputV;
    private bool run,jump;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>(); // get role of the animator
        rbody = GetComponent<Rigidbody>();
        run = false;
	}

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.Z)) { anim.Play("slash", -1, 0f); }
        run = (Input.GetKey(KeyCode.LeftShift)) ? true : false;
        jump = (Input.GetKey(KeyCode.Space)) ? true : false;

        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);
        anim.SetBool("run", run);
        anim.SetBool("jump", jump);

        float moveX = inputH * 38f * Time.deltaTime;
        float moveZ = inputV * 38f * Time.deltaTime;

        if(moveZ <= 0f)
        {
            moveX = 0f;
        }else if (run)
        {
            moveX *= 3f;
            moveZ *= 3f;
        }

        rbody.velocity = new Vector3(moveX, 0f, moveZ);
    }


}
