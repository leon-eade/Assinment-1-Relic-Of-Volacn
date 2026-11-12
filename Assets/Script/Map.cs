using UnityEngine;
using UnityEngine.InputSystem;

public class Map : MonoBehaviour
{
    public Playerscript ps;
    InputAction mapAction;
    Rigidbody2D rb;
    Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        mapAction = InputSystem.actions.FindAction("map");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ps.room2 == 1)
        {
            anim.SetInteger("map2", 1);

            if (ps.room == 1)
            {
                anim.SetInteger("map", 1);
            }
            else if (ps.room == 2)
            {
                anim.SetInteger("map", 2);
            }
            else if (ps.room == 3)
            {
                anim.SetInteger("map", 3);
            }
        }
        else if (ps.room2 == 3)
        {
            anim.SetInteger("map2", 2);
            if (ps.room == 3)
            {
                anim.SetInteger("map", 4);
            }
            if (ps.room == 2)
            {
                anim.SetInteger("map", 5);
            }
            if (ps.room == 1)
            {
                anim.SetInteger("map", 6);
            }
            if (ps.room == 4)
            {
                anim.SetInteger("map", 11);
            }
        }
        else if (ps.room2 == 5)
        {
            anim.SetInteger("map2", 3);
            if (ps.room == 1)
            {
                anim.SetInteger("map", 7);
            }
            if (ps.room == 3)
            {
                anim.SetInteger("map", 10);
            }
        }
        else if (ps.room2 == 7)
        {
            anim.SetInteger("map2", 4);
            if (ps.room == 1)
            {
                anim.SetInteger("map", 8);
            }
            if (ps.room == 2)
            {
                anim.SetInteger("map", 9);
            }
        }
            if (mapAction.IsPressed())
            {
                rb.transform.position = new Vector2(ps.camPlace2, ps.camPlace);
            }
            else
            {
                rb.transform.position = new Vector2(1000, 1000);
            }
    }
}
