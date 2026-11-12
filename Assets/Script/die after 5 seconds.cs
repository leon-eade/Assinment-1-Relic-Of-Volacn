using UnityEngine;

public class dieafter5seconds : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("die", 5);
    }

    // Update is called once per frame
    void Update()
    { 
    }
    void die()
    {
        Destroy(gameObject);
    }
}
