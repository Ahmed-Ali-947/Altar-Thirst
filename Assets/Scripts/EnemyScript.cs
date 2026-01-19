using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyScript : MonoBehaviour
{
    public float minX,minY, maxX, maxY;
    public float speed;
    public GameObject bloodPrefab;
    public GameObject bloodSplashSound;
    Vector2 nextPos;
    Animator cameraAnim;
    // Start is called before the first frame update
    void Start()
    {
        cameraAnim = Camera.main.GetComponent<Animator>();
        nextPos = GetNewPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(nextPos,transform.position) < 0.5f)
        {
            nextPos = GetNewPosition();
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos,speed * Time.deltaTime);
    }

    Vector2 GetNewPosition()
    {
        return new Vector2(Random.Range(minX,maxX), Random.Range(minY,maxY));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Altar"))
        {
            ResourceManager.instance.OnEnemyAttackAltar(gameObject, collision.gameObject);
        }
        if (collision.CompareTag("Trap"))
        {
            Instantiate(bloodSplashSound).GetComponent<AudioSource>().Play();
            cameraAnim.SetTrigger("shake");
            Instantiate(bloodPrefab, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }

    
}
