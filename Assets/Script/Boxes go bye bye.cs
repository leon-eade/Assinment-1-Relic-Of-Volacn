using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;
public class Boxesgobyebye : MonoBehaviour
{
    public Playerscript ps;
    InputAction interactAction;
    int loot;
    public GameObject Loot1;
    bool bebroken;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactAction = InputSystem.actions.FindAction("Open");
    }

    // Update is called once per frame
    void Update()
    {
        ByeBye();
    }
    void ByeBye()
    {
        if (interactAction.WasPressedThisFrame())
        {
            if (ps.boxBreaker && bebroken)
            {
                Destroy(gameObject);
                loot = Random.Range(1, 10);
                if (loot == 1)
                {
                    GameObject clone;
                    clone = Instantiate(Loot1, transform.position, transform.rotation);
                    Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();

                }
            }
        }
    }
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bebroken = true;
        }
    }
    private void OnTriggerExit2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bebroken = false;
        }
    }
}