using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpSpeed = 2f;
    public GameObject square;
    public Rigidbody2D rb;
    public bool inair = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            square.transform.position += new Vector3(moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), 0, 0);
            if (Input.GetAxis("Horizontal") < 0)
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        if (Input.GetButton("Jump") && inair == false)
        {
            rb.AddForce(new Vector2(0f, jumpSpeed));
            inair = true;

        }
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            inair = false;
        }
    }
}