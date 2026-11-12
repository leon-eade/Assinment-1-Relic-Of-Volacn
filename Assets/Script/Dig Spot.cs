using UnityEngine;

public class DigSpot : MonoBehaviour
{
    public Loot l;
    public bool tp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (l.looted && tp)
        {
            
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tp = true;
          
        }
    }
    private void OnTriggerExit2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
         
            tp = false;
        }
    }
}
