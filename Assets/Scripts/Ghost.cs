using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{

    public int bloodCost;
    public int crystalCost;
    public int woodCost;

    public GameObject objectToSpawn;
    public GameObject buildParticles;
    // Start is called before the first frame update
    private void Awake()
    {
        followMouse();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        followMouse();
        if (Input.GetMouseButtonDown(0))
        {
            ResourceManager.instance.addResource("wood", -woodCost);
            ResourceManager.instance.addResource("blood", -bloodCost);
            ResourceManager.instance.addResource("crystal", -crystalCost);
            Instantiate(objectToSpawn,transform.position,Quaternion.identity);
            Instantiate(buildParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void followMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;
    }
}
