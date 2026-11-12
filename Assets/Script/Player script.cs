using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playerscript : MonoBehaviour
{
    public int room;
    public int room2;
    InputAction interactAction;
    InputAction rightAction;
    InputAction leftAction;
    InputAction fowardAction;
    InputAction backAction;
    InputAction digAction;
    Animator anim;
    Rigidbody2D rb;
    string lastDirection = "f";
    public GameObject dug;
    public bool dugLoot;
    public bool finalDig;
    int diggy = 200;
    bool digspot;
    public int camPlace = 0;
    public int camPlace2 = 0;
    int posP=-2;
    int posP2=0;
    bool canClimb=false;
    public int Coincountp = 0;
    bool climbdown = false;
    bool shop1 = false;
    bool shop2 = false;
    bool shop3 = false;
    public bool gloves = false;
    public bool boxBreaker = false;
    public bool Shovel = false;
    public bool Relic = false;
    bool canDttwu;
    bool canDttwd;
    bool canwin;
    bool canleave = false;
    public bool won=false;
    public bool loss=false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        room = 1;
        room2 = 1;
        interactAction = InputSystem.actions.FindAction("Open");
        anim = GetComponent<Animator>();
        rightAction = InputSystem.actions.FindAction("Right");
        digAction = InputSystem.actions.FindAction("Dig");
        leftAction = InputSystem.actions.FindAction("Left");
        fowardAction = InputSystem.actions.FindAction("Foward");
        backAction = InputSystem.actions.FindAction("Back");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Dig();
        climbup();
        climbD();
        buy();
        DigThrough();
        GetRelic();
        win();
    }
    void win()
    {
        if (interactAction.WasPressedThisFrame() && Relic && canleave)
        {
            camPlace2 -= 20;
            won = true;
            Destroy(gameObject);
        }
        if (interactAction.WasPressedThisFrame() && !Relic && canleave)
        {
            camPlace2 -= 40;
            loss = true;
            Destroy(gameObject);
        }
    }
    void GetRelic()
    {
        if (interactAction.WasPressedThisFrame() && canwin)
        {
            Relic = true;
        }
    }
    void DigThrough()
    {
        if (interactAction.WasPressedThisFrame() && canDttwu && Shovel)
        {
            posP += 11;
            room += 1;
            transform.position = new Vector2(posP2, posP);
            camPlace += 11;
        }
        if (interactAction.WasPressedThisFrame() && canDttwd)
        {
            posP -= 11;
            room -= 1;
            transform.position = new Vector2(posP2, posP + 5);
            camPlace -= 11;
        }
    }
    void climbup()
    {
        if (interactAction.WasPressedThisFrame() && canClimb&& gloves)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y+1.5f);
        }
    }
    void buy()
    {
        if (interactAction.WasPressedThisFrame() && shop1&& Coincountp>=10)
        {
            Coincountp -= 10;
            gloves = true;
        }
        if (interactAction.WasPressedThisFrame() && shop2&& Coincountp>=25)
        {
            Coincountp -= 25;
            boxBreaker = true;
        }
        if (interactAction.WasPressedThisFrame() && shop3&& Coincountp>=50)
        {
            Coincountp -= 50;
            Shovel = true;
        }
    }
    void climbD()
    {
        if (interactAction.WasPressedThisFrame() && climbdown)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y-1.5f);
        }
    }
    void Dig()
    {
        if (digAction.WasPressedThisFrame())
        {
            if (diggy >= 500)
            {
                if (!digspot)
                {
                    GameObject clone;
                    clone = Instantiate(dug, transform.position, transform.rotation);
                    Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
                    diggy = 0;
                }
                else
                {
                    dugLoot = true;
                    Invoke("no", 1);
                }
            }
        }
        diggy += 1;
    }
    void no()
    {
        dugLoot = false;
    }
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        
        if (collision.gameObject.tag == "dig spot")
        {
            digspot = true;
        }
        if (collision.gameObject.tag == "Coin 1")
        {
            Coincountp += 1;
        }
        if (collision.gameObject.tag == "Coin 5")
        {
            Coincountp += 5;
        }
        if (collision.gameObject.tag == "Coin 10")
        {
            Coincountp += 10;
        }
        if (collision.gameObject.tag == "dig spot f")
        {
            digspot = true;
            finalDig = true;
        }
        if (collision.gameObject.tag == "Path up")
        {
            posP += 11;
            room += 1;
            transform.position = new Vector2(posP2, posP);
            camPlace += 11;
        }
        if (collision.gameObject.tag == "Path down")
        {
            posP -= 11;
            room -= 1;
            transform.position = new Vector2(posP2, posP+5);
            camPlace -= 11;
        }
        if (collision.gameObject.tag == "Path right")
        {
            posP2 += 10;
            room2 += 1;
            transform.position = new Vector2(posP2-5, posP+2);
            camPlace2 += 10;
        }
        if (collision.gameObject.tag == "Path left")
        {
            posP2 -= 10;
            room2 -= 1;
            transform.position = new Vector2(posP2+5, posP+2);
            camPlace2 -= 10;
        }
        if (collision.gameObject.tag == "Rock climb")
        {
            canClimb = true;
        }
        if (collision.gameObject.tag == "Get down")
        {
            climbdown = true;
        }
        if (collision.gameObject.tag == "SI1")
        {
            shop1 = true;
        }
        if (collision.gameObject.tag == "SI2")
        {
            shop2 = true;
        }
        if (collision.gameObject.tag == "SI3")
        {
            shop3 = true;
        }
        if (collision.gameObject.tag == "Dttwu")
        {
            canDttwu = true;
        }
        if (collision.gameObject.tag == "Dttwd")
        {
            canDttwd = true;
        }
        if (collision.gameObject.tag == "TFR")
        {
            canwin = true;
        }
        if (collision.gameObject.tag == "Exit")
        {
            canleave = true;
        }
        
    }
    private void OnTriggerExit2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.tag == "dig spot f")
        {
            digspot = false;
            finalDig = false;
        }
        if (collision.gameObject.tag == "dig spot")
        {
            digspot = false;
        }
        if (collision.gameObject.tag == "Rock climb")
        {
            canClimb = false;
        }
        if (collision.gameObject.tag == "Get down")
        {
            climbdown = false;
        }
        if (collision.gameObject.tag == "SI1")
        {
            shop1 = false;
        }
        if (collision.gameObject.tag == "SI2")
        {
            shop2 = false;
        }
        if (collision.gameObject.tag == "SI3")
        {
            shop3 = false;
        }
        if (collision.gameObject.tag == "Dttwu")
        {
            canDttwu = false;
        }
        if (collision.gameObject.tag == "Dttwd")
        {
            canDttwd = false;
        }
        if (collision.gameObject.tag == "TFR")
        {
            canwin = false;
        }
        if (collision.gameObject.tag == "Exit")
        {
        canleave = false;
        }
    }
    void Movement()
    {
        if (rightAction.IsPressed())
        {
            rb.linearVelocity = new Vector2(5, 0);
            lastDirection = "r";
            anim.SetBool("rm", true);
            anim.SetBool("lm", false);
            anim.SetBool("bm", false);
            anim.SetBool("fm", false);

            anim.SetBool("right", false);
            anim.SetBool("left", false);
            anim.SetBool("back", false);
            anim.SetBool("foward", false);
        }
        else if (leftAction.IsPressed())
        {
            rb.linearVelocity = new Vector2(-5, 0);
            lastDirection = "l";
            anim.SetBool("rm", false);
            anim.SetBool("lm", true);
            anim.SetBool("bm", false);
            anim.SetBool("fm", false);

            anim.SetBool("right", false);
            anim.SetBool("left", false);
            anim.SetBool("back", false);
            anim.SetBool("foward", false);
        }
        else if (backAction.IsPressed())
        {
            rb.linearVelocity = new Vector2(0, -5);
            lastDirection = "b";
            anim.SetBool("rm", false);
            anim.SetBool("lm", false);
            anim.SetBool("bm", true);
            anim.SetBool("fm", false);

            anim.SetBool("right", false);
            anim.SetBool("left", false);
            anim.SetBool("back", false);
            anim.SetBool("foward", false);
        }
        else if (fowardAction.IsPressed())
        {
            rb.linearVelocity = new Vector2(0, 5);
            lastDirection = "f";
            anim.SetBool("rm", false);
            anim.SetBool("lm", false);
            anim.SetBool("bm", false);
            anim.SetBool("fm", true);

            anim.SetBool("right", false);
            anim.SetBool("left", false);
            anim.SetBool("back", false);
            anim.SetBool("foward", false);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, 0);
            if (lastDirection == "r")
            {
                anim.SetBool("right", true);
                anim.SetBool("left", false);
                anim.SetBool("back", false);
                anim.SetBool("foward", false);

                anim.SetBool("rm", false);
                anim.SetBool("lm", false);
                anim.SetBool("bm", false);
                anim.SetBool("fm", false);
            }
            else if (lastDirection == "f")
            {
                anim.SetBool("right", false);
                anim.SetBool("left", false);
                anim.SetBool("back", false);
                anim.SetBool("foward", true);

                anim.SetBool("rm", false);
                anim.SetBool("lm", false);
                anim.SetBool("bm", false);
                anim.SetBool("fm", false);
            }
            else if (lastDirection == "b")
            {
                anim.SetBool("right", false);
                anim.SetBool("left", false);
                anim.SetBool("back", true);
                anim.SetBool("foward", false);

                anim.SetBool("rm", false);
                anim.SetBool("lm", false);
                anim.SetBool("bm", false);
                anim.SetBool("fm", false);
            }
            else if (lastDirection == "l")
            {
                anim.SetBool("right", false);
                anim.SetBool("left", true);
                anim.SetBool("back", false);
                anim.SetBool("foward", false);

                anim.SetBool("rm", false);
                anim.SetBool("lm", false);
                anim.SetBool("bm", false);
                anim.SetBool("fm", false);
            }
        }
    }

}
