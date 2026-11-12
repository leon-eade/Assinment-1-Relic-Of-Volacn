using UnityEngine;

public class GlovesGoByeBye : MonoBehaviour
{
    public Playerscript ps;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ByeBye();
    }
    void ByeBye()
    {
        if (ps.gloves)
        {
            Destroy(gameObject);
        }
    }
}
