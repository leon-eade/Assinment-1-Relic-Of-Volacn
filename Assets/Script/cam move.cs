using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Playerscript ps;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.transform.position = new Vector3(ps.camPlace2, ps.camPlace,-10);
    }
}
