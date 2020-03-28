using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    private Rigidbody rb;
    private SpriteRenderer sr;
    private Sprite[] sprites = new Sprite[4];
    private string[] sprite_names = { "proto girl forward", "proto girl backwards", "proto girl right", "proto girl left" };

    public int health = 20;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Script running!");
        rb = GetComponent<Rigidbody>();
        sr = GetComponent<SpriteRenderer>();

        for (int i = 0;i < 4;i++)
        {

            sprites[i] = Resources.Load<Sprite>(sprite_names[i]);

        }
    }

    // Update is called once per frame
    public void Update()
    {

        Moving();

    }

    public void Moving()
    {

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {

            transform.Translate(Vector3.left * speed * Time.deltaTime);

            sr.sprite = sprites[3];
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);

            sr.sprite = sprites[2];
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {

            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            sr.sprite = sprites[1];
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {

            transform.Translate(Vector3.back * speed * Time.deltaTime);

            sr.sprite = sprites[0];

        }


    }

}
