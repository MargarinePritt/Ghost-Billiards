using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]private float speed=500f;
    [SerializeField]private int playerNo=-1;

    Rigidbody2D rb;

    private bool horizontalMovement=false;
    private bool verticalMovement=false;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

	private void Move()
	{
        if(playerNo==0){
		    if(Input.GetKey(KeyCode.A)){
                horizontalMovement=true;
                rb.drag=0;
                rb.AddRelativeForce(Vector2.left*speed*Time.deltaTime);
            }
            else if(Input.GetKey(KeyCode.D)){
                horizontalMovement=true;
                rb.drag=0;
                rb.AddRelativeForce(Vector2.right*speed*Time.deltaTime);
            }
            else{
                horizontalMovement=false;
            }

            if(Input.GetKey(KeyCode.W)){
                verticalMovement=true;
                rb.drag=0;
                rb.AddRelativeForce(Vector2.up*speed*Time.deltaTime);
            }
            else if(Input.GetKey(KeyCode.S)){
                verticalMovement=true;
                rb.drag=0;
                rb.AddRelativeForce(Vector2.down*speed*Time.deltaTime);
            }
            else{
                verticalMovement=false;
            }
            
        }
        else if(playerNo==1){
            if(Input.GetKey(KeyCode.J)){
                horizontalMovement=true;
                rb.drag=0;
                rb.AddRelativeForce(Vector2.left*speed*Time.deltaTime);
            }
            else if(Input.GetKey(KeyCode.L)){
                horizontalMovement=true;
                rb.drag=0;
                rb.AddRelativeForce(Vector2.right*speed*Time.deltaTime);
            }
            else{
                horizontalMovement=false;
            }

            if(Input.GetKey(KeyCode.I)){
                verticalMovement=true;
                rb.drag=0;
                rb.AddRelativeForce(Vector2.up*speed*Time.deltaTime);
            }
            else if(Input.GetKey(KeyCode.K)){
                verticalMovement=true;
                rb.drag=0;
                rb.AddRelativeForce(Vector2.down*speed*Time.deltaTime);
            }
            else{
                verticalMovement=false;
            }
        }

        if(!horizontalMovement&&!verticalMovement){
            rb.drag=10;
        }
	}
}
