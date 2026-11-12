using UnityEngine;

public class Winthegame : MonoBehaviour
{
    public Playerscript ps;
    Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ps.Relic)
        {
            anim.SetBool("RelicTaken", true);
        }
    }
}
