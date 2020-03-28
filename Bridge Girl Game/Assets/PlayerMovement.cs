using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float x;
    public float z;
    public float speed;
    public Rigidbody Rigid;
    public float Rotation;
    public bool isOnGround;
    public float jumpForce;
    public int health = 20;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Script running!");
        Rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        moving();
        Jumping();
        Debug.Log(health);
    }

    public void moving()
    {
        z = Input.GetAxis("Vertical") * speed;
       

        z *= Time.deltaTime;
       

        Vector3 mouvment = new Vector3(x, 0, z);

        Rigid.AddForce(mouvment * speed * Time.deltaTime);

        //Go left
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) )
        {
            Debug.Log("Left?");
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        //Go right
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) )
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        // Movement of translation along the object's z-axis
        transform.Translate(x, 0, z);

     
    }

    public void Jumping()
    {

        if (Input.GetKey(KeyCode.Space) && isOnGround)
        {
            Rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            Debug.Log("jump");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = true;

        }
    }
}
