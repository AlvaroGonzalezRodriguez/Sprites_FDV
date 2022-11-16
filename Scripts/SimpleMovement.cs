using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    
    private Rigidbody2D rigidbody2d;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if(h == -1.0f)
        {
            spriteRenderer.flipX = true;
            rigidbody2d.AddForce(new Vector3(h,0,0));
        } else if (h == 1.0f){
            spriteRenderer.flipX = false;
            rigidbody2d.AddForce(new Vector3(h,0,0));
        }
    }
}
