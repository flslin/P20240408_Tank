using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private GameObject boom;
    Vector2 dir;

    public int playerAttack = 10;

    // Start is called before the first frame update
    void Start()
    {
        dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir.normalized * speed * Time.deltaTime);
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

        if (collision.tag == "Enemy")
        {
            GameObject go = Instantiate(boom, transform.position, Quaternion.identity);
            Destroy(go, 0.5f);

            //Destroy(gameObject);
        }
    }
}
