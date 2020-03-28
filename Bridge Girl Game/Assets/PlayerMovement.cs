using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{

    public float speed;
    private Rigidbody rb;
    private SpriteRenderer sr;
    private Sprite[] sprites;
    private string path = "";
    private int currentSprite = 0;
    public bool isOnGround;
    public float jumpForce;
    public int health = 20;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Script running!");
        rb = GetComponent<Rigidbody>();
        sr = GetComponent<SpriteRenderer>();

        sprites = Resources.LoadAll<Sprite>(path);
    }

    // Update is called once per frame
    public void Update()
    {

        Moving();
        Jumping();

    }

    public void Moving()
    {

        //Go left
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {

            transform.Translate(Vector3.left * speed * Time.deltaTime);
            currentSprite += 1;
        }

        //Go right
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {

            transform.Translate(Vector3.forward * speed * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {

            transform.Translate(Vector3.back * speed * Time.deltaTime);

        }

        sr.sprite = sprites[currentSprite];


    }

    public void Jumping()
    {

        if (Input.GetKey(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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
