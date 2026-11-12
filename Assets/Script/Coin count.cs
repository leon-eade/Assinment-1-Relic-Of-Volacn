using TMPro;
using UnityEngine;

public class Coincount : MonoBehaviour
{
    public TextMeshProUGUI output;
    int coincount=0;
    string outp;
    public Playerscript ps;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        coincount = ps.Coincountp;
        outp = coincount.ToString();
        output.text = outp;  
    }
}
