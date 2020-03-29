using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    private Rigidbody rb;
    private SpriteRenderer sr;
    private Animator anim;

    public SliderValueChange sliderVal;
    public SliderValueChange dashSlider;

    private bool forward = true, backward = false, right = false, left = false;
    private bool moving = false;
    private bool fire = false; 

    private Vector3 world_pos;

    public int health = 5;

    //related to Dashing
    public float BaseSpeed;
    public float DashSpeed = 10;
    public bool CanDash = true;

    public bool CanGetHurt;

    // Start is called before the first frame update
    void Start()
    {
        //Base Speed Before Dashing
        BaseSpeed = speed;

        Debug.Log("Script running!");
        rb = GetComponent<Rigidbody>();
        sr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();

        sliderVal = GameObject.FindGameObjectWithTag("HealthSlider").GetComponent<SliderValueChange>();
        dashSlider = GameObject.FindGameObjectWithTag("DashSlider").GetComponent<SliderValueChange>();

        anim.Play("face_forward", 0, 0); // Default animation the player has

       
    }

    // Update is called once per frame
   void Update()
    {

        DashInput();
        Moving();
        Animate();
        
    }

    public void Moving()
    {

        Vector3 mouse_pos = Input.mousePosition;
        mouse_pos.z = Camera.main.nearClipPlane;
        world_pos = Camera.main.ScreenToWorldPoint(mouse_pos);
        //Debug.Log(transform.position);
        //Debug.Log(world_pos);
        if (Input.GetMouseButtonDown(0))
        {

            fire = true;
            moving = false;

        }

        if (!fire)
        {

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {

                transform.Translate(Vector3.left * speed * Time.deltaTime);

                left = true;
                right = false;
                forward = false;
                backward = false;

                moving = true;

            }

            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);

                left = false;
                right = true;
                forward = false;
                backward = false;

                moving = true;
            }

            else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {

                transform.Translate(Vector3.forward * speed * Time.deltaTime);

                left = false;
                right = false;
                forward = false;
                backward = true;

                moving = true;
            }

            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {

                transform.Translate(Vector3.back * speed * Time.deltaTime);

                left = false;
                right = false;
                forward = true;
                backward = false;

                moving = true;

            }

            else
            {

                moving = false;

            }

        }

    }

    public void Animate()
    {

        if (!fire)
        {

            if (moving)
            {

                if (forward)
                {

                    if (anim.GetCurrentAnimatorStateInfo(0).IsName("walk_forward"))
                    {

                        return;

                    }

                    anim.Play("walk_forward", 0, 0);

                }

                if (backward)
                {

                    if (anim.GetCurrentAnimatorStateInfo(0).IsName("walk_backward"))
                    {

                        return;

                    }

                    anim.Play("walk_backward", 0, 0);

                }

                if (right)
                {

                    if (anim.GetCurrentAnimatorStateInfo(0).IsName("walk_right"))
                    {

                        return;

                    }
                    anim.Play("walk_right", 0, 0);

                }

                if (left)
                {

                    if (anim.GetCurrentAnimatorStateInfo(0).IsName("walk_left"))
                    {

                        return;

                    }

                    anim.Play("walk_left", 0, 0);

                }

            }

            else
            {

                if (forward)
                {

                    anim.Play("face_forward", 0, 0);

                }

                if (backward)
                {

                    anim.Play("face_backward", 0, 0);

                }

                if (right)
                {

                    anim.Play("face_right", 0, 0);

                }

                if (left)
                {

                    anim.Play("face_left", 0, 0);

                }

            }

        }

        else
        {

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("shoot_forward"))
            {
                
                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {

                    forward = true;

                    fire = false;

                }

                return; 

            }

            anim.Play("shoot_forward", 0, 0);

        }
    }

    public void DashInput()
    {
      

        //Dashing Input
        if (Input.GetKey(KeyCode.LeftShift) && CanDash == true)
        {
            CanDash = false;
            CanGetHurt = false;
            DashX();
            dashSlider.MinusOne();
            StartCoroutine(CoolDown());
        }
    }

    public void DashX()
    {

        StartCoroutine(Dash());
    }

    IEnumerator Dash()
    {
       

        speed = DashSpeed;
        yield return new WaitForSeconds(0.05f);
        speed = BaseSpeed;
        CanGetHurt = true;
        yield break;
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(5f);
        CanDash = true;
        dashSlider.RestoreTotal(1);

        yield break;
    }

    private void OnCollisionEnter(Collision other)
    {
      
        if (other.gameObject.tag == "Enemy" && CanGetHurt == true)
        {

            health -= 1;
            sliderVal.MinusOne();

        }

    }

}
