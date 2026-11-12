using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class Chests : MonoBehaviour
{
    Animator anim;
    InputAction openAction;
    bool open = false;
    bool canOpen = false;
    int loot;
    public GameObject Loot1;
    public GameObject Loot2;
    public GameObject Loot3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        openAction = InputSystem.actions.FindAction("Open");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (openAction.WasPressedThisFrame())
        {
            if (!open&&canOpen)
            {
                anim.SetBool("Open", true);
                Invoke("Permopen", 1f);
                open = true;
            }
        }

    }
    void Permopen()
    {
        anim.SetBool("Open", false);
        anim.SetBool("Opened", true);
        Invoke("spawn", 0.25f);
    }
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canOpen = true;
        }
    }
    private void OnTriggerExit2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canOpen = false;
        }
    }
    void spawn()
    {
        loot = Random.Range(1, 100);
        if (loot <= 60)
        {
            GameObject clone;
            clone = Instantiate(Loot1, transform.position, transform.rotation);
            Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();

        }
        else if (loot > 60 && loot <= 95)
        {
            GameObject clone;
            clone = Instantiate(Loot2, transform.position, transform.rotation);
            Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();

        }
        else
        {
            GameObject clone;
            clone = Instantiate(Loot3, transform.position, transform.rotation);
            Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();

        }
    }
}
