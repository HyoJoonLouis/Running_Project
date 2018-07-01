using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float playerSpeed = 0.1f;
    private Rigidbody rb;
    [SerializeField]
    private float jumpPower = 10;
    private float preY;
    private bool isJump;
    [SerializeField]
    private Camera camera;
    private int buttonClicked;

    void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        buttonClicked = 0;
    }



    private void Update()
    {
        transform.Translate(Vector3.forward * playerSpeed);
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.x > camera.WorldToScreenPoint(this.transform.position).x && buttonClicked < 1)
            {
                this.transform.position = this.transform.position + transform.right;
                buttonClicked++;
            }
            if((Input.mousePosition.x < camera.WorldToScreenPoint(this.transform.position).x && buttonClicked > -1))
            {
                this.transform.position = this.transform.position - transform.right;
                buttonClicked--;
            }
        }
          

    }

    void LateUpdate()
    {
            if (isJump == true)
            {
                StartCoroutine("PlayerJump");
            }        
    }

    IEnumerator PlayerJump()
    {
        if (Physics.Raycast(transform.position, -transform.up, 0.5f))
        {
            rb.AddForce(transform.up * jumpPower, ForceMode.Impulse);
            isJump = false;
        }
        yield return null;
    }
}