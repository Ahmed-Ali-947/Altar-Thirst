using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    public int bloodCost;
    public int crystalCost;
    public int woodCost;

    Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ResourceManager.instance.blood < bloodCost || ResourceManager.instance.crystal < crystalCost || ResourceManager.instance.wood < woodCost)
        {
            btn.interactable = false;
        }
        else { btn.interactable = true; }
    }

}
