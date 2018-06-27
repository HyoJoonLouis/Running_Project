using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float playerSpeed = 0.1f;
    private Rigidbody rb;
    [SerializeField]
    private float jumpPower = 10;
    private float preY;

	void Awake () {
        rb = this.GetComponent<Rigidbody>();
	}

    private void Update()
    {
        transform.Translate(Vector3.forward * playerSpeed);
        if (Input.touchCount >0)
        {
            if(Input.GetTouch(0).position.x < this.transform.position.x)
            {
                transform.position = transform.position - transform.right;
            }
            if(Input.GetTouch(0).position.x> this.transform.position.x)
            {
                transform.position = transform.position + transform.right;
            }
        }
        
    }

    void LateUpdate () {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                preY = Input.GetTouch(0).position.y;
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                float currY = Input.GetTouch(0).position.y;
                if (currY - preY > 0)
                {
                    StartCoroutine("PlayerJump");
                }
            }
        }
     
        

	}
    IEnumerator PlayerJump()
    {
        if(Physics.Raycast(transform.position,-transform.up, 0.5f))
        rb.AddForce(transform.up * jumpPower, ForceMode.Impulse);
        yield return null;
    }
    
}
