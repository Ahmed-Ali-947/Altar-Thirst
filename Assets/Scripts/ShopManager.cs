using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public Ghost tree;
    public Ghost worker;
    public Ghost crystal;
    public Ghost village;
    public Ghost trap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnShopClick(string whatItem)
    {
        if(whatItem == "tree")
        {
            Instantiate(tree);
        }
        if (whatItem == "crystal")
        {
            Instantiate(crystal);
        }
        if (whatItem == "worker")
        {
            Instantiate(worker);
        }
        if (whatItem == "trap")
        {
            Instantiate(trap);
        }
        if(whatItem == "village")
        {
            Instantiate(village);
        }
    }
}
