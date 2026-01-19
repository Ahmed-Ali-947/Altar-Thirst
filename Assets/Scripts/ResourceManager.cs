using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResourceManager : MonoBehaviour
{
    public int wood;
    public int crystal;
    public int blood;
    public TMP_Text bloodText;
    public TMP_Text woodText;
    public TMP_Text crystalText;
    public int startingWood;
    public int startingBlood;
    public int startingCrystal;

    public static ResourceManager instance=null;

    public TMP_Text sacWorkerText;
    public int sacGoal;

    public int sacrificedWorkers;
    public GameObject bloodSac;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        sacrificedWorkers = 0;
        addResource("crystal", startingCrystal);
        addResource("blood", startingBlood);
        addResource("wood", startingWood);
    }

    // Update is called once per frame
    void Update()
    {
        sacWorkerText.text = sacrificedWorkers + "/" + sacGoal;

    }

    public void addResource(string resourceType,int ammount)
    {
        if(resourceType == "wood")
        {
            wood += ammount;
            woodText.text = wood.ToString();
        }
        else if (resourceType == "crystal")
        {
            crystal += ammount;
            crystalText.text = crystal.ToString();
        }
        else if (resourceType == "blood")
        {
            blood += ammount;
            bloodText.text = blood.ToString();
        }

    }

    void IncSacWorkers(int amount)
    {
        sacrificedWorkers += amount;
        sacWorkerText.text = sacrificedWorkers + "/" + sacGoal;
    }

    public void OnWorkerSac()
    {
        IncSacWorkers(1);
        Instantiate(bloodSac, Vector3.zero,Quaternion.identity);
    }
    public void OnEnemyAttackAltar(GameObject enemy,GameObject altar)
    {
        if(sacrificedWorkers == 0)
        {
            Destroy(altar);
            GameManager.instance.Defeated();

        }
        else
        {
            IncSacWorkers(-1);
            Destroy(enemy);
        }
    }
}
