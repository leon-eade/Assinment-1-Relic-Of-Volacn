using UnityEngine;

public class Loot : MonoBehaviour
{
    public Transform player;
    public Playerscript ps;
    public GameObject Loot1;
    public GameObject Loot2;
    public GameObject Loot3;
    public GameObject LootF;
    bool canSpawn=true;
    public bool looted = false;
    int loot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ps.dugLoot)
        {
            SpawnLoot();
            looted = true;
        }
    }
    void SpawnLoot()
    {
        loot = Random.Range(1, 100);
        if (canSpawn)
        {
            if (ps.finalDig)
            {
                GameObject clone;
                clone = Instantiate(LootF, player.position, transform.rotation);
                Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
                canSpawn = false;
                Invoke("unloot", 1.1f);
            }
            else if (loot <= 60)
            {
                GameObject clone;
                clone = Instantiate(Loot1, player.position, transform.rotation);
                Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
                canSpawn = false;
                Invoke("unloot",1.1f);
            }
            else if (loot > 60 && loot<=90)
            {
                GameObject clone;
                clone = Instantiate(Loot2, player.position, transform.rotation);
                Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
                canSpawn = false;
                Invoke("unloot", 1);
            }
            else
            {
                GameObject clone;
                clone = Instantiate(Loot3, player.position, transform.rotation);
                Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
                canSpawn = false;
                Invoke("unloot", 1.1f);
            }

        }
    }
    void unloot()
    {
        looted = false;
        canSpawn = true;
    }
}
