using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WorkersScript : MonoBehaviour
{
    public LayerMask resourceLayer;
    public float resourceDistance;
    public int collectRate;
    public float timeBetweenCollects;
    public float sacDistance;
    public GameObject popUp;
    public float popUpOffSet;
    public AudioSource popSound;

    ResourceScript currentResource = null;
    float nextCollectTime=0;
    bool isSelected = false;
    GameObject altar;
    // Start is called before the first frame update
    void Start()
    {
        altar = GameObject.FindGameObjectWithTag("Altar");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSelected)
        {

            Collider2D col = Physics2D.OverlapCircle(transform.position,resourceDistance,resourceLayer);

            if(col != null && currentResource == null)
            {
                currentResource = col.GetComponent<ResourceScript>();
            }
            else
            {
                currentResource = null;
            }

            if(currentResource != null )
            {
                if (Time.time > nextCollectTime)
                {
                    if (currentResource.resourceAmount - collectRate < 0)
                    {
                        ResourceManager.instance.addResource(currentResource.resourceType, currentResource.resourceAmount);
                        currentResource.resourceAmount = 0;

                    }
                    else
                    {
                        currentResource.resourceAmount -= collectRate;
                        ResourceManager.instance.addResource(currentResource.resourceType, collectRate);
                    }
                   
                    GameObject instance = Instantiate(popUp,transform.position + (Vector3.up * popUpOffSet),Quaternion.identity);
                    instance.transform.GetChild(0).GetComponent<TMP_Text>().text = "+" + collectRate;

                    nextCollectTime = Time.time + timeBetweenCollects;
                }
            }

           
        }

    }
    private void OnMouseDown()
    {
        Instantiate(popSound);
    }
    private void OnMouseDrag()
    {
        isSelected = true;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;
    }

    private void OnMouseUp()
    {
        isSelected = false;
        if(altar != null)
        {
            if (Vector2.Distance(transform.position, altar.transform.position) <= sacDistance)
            {
                ResourceManager.instance.OnWorkerSac();
                Destroy(gameObject);
            }
        }
    }

}
