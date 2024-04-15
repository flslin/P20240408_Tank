using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private GameObject boom;
    public int playerAttack = 10;

    Vector2 dir;
    Vector2 dirNo;
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        dir = player.transform.position - transform.position;
        dirNo = dir.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(dirNo * speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Wall")
        {
            GameObject go = Instantiate(boom, transform.position, Quaternion.identity);
            Destroy(go, 0.5f);

            Destroy(gameObject);
        }

        if (collision.tag == "Player")
        {
            GameObject go = Instantiate(boom, transform.position, Quaternion.identity);
            Destroy(go, 0.5f);

            //Destroy(gameObject);
        }
    }
}
