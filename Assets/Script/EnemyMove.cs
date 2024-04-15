using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMove : MonoBehaviour
{
    private float minForce = 10f;
    private float maxForce = 20f;
    private Rigidbody2D rb;

    //private float x;
    //private float y;
    //private float rotationSpeed = 5f;

    Bullet bullet;
    public GameObject boom1;

    private int enemyHP = 100;
    private int playerAttack = 30;
    public bool isAlive = true;

    int ranNum1;
    int ranNum2;
    //private float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Bullet>();
        rb = GetComponent<Rigidbody2D>();
        float rotationAmount = Random.Range(0, 1);
        transform.Rotate(0f, 0f, rotationAmount);

        ranNum1 = Random.Range(0, 2);
        ranNum2 = Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        Col();
        //StartCoroutine("EnemyRandomMove");

        //StartCoroutine(RandomMove());
        //ApplyRandomForce();
    }

    void Col()
    {
        //x = Input.GetAxis("Horizontal");
        //y = Input.GetAxis("Vertical");

        //if (x > 0)
        //    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -90), rotationSpeed * Time.deltaTime);

        //if (x < 0)
        //    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 90), rotationSpeed * Time.deltaTime);

        //if (y > 0)
        //    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), rotationSpeed * Time.deltaTime);

        //if (y < 0)
        //    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 180), rotationSpeed * Time.deltaTime);

        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x); //x값을 0이상, 1이하로 제한한다.
        viewPos.y = Mathf.Clamp01(viewPos.y); //y값을 0이상, 1이하로 제한한다.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);//다시월드좌표로 변환
        transform.position = worldPos; //좌표를 적용한다.
    }

    void ApplyRandomForce()
    {

        Vector2 randomDirection = Random.insideUnitCircle.normalized;

        float randomForce = Random.Range(minForce, maxForce);

        rb.AddForce(randomDirection * randomForce, ForceMode2D.Impulse);
    }

    //IEnumerator RandomMove()
    //{
    //    while (isAlive)
    //    {
    //        float dir1 = Random.Range(-1f, 1f);
    //        float dir2 = Random.Range(-1f, 1f);

    //        transform.position = new Vector3(Mathf.Lerp(transform.position.x, transform.position.x + dir1, 0.1f), transform.position.y, transform.position.z);
    //        //gameObject.transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + dir1, transform.position.y, transform.position.z), 0.3f);
    //        //gameObject.transform.position = new Vector3(transform.position.x + dir1, transform.position.y, transform.position.z);
    //        yield return new WaitForSeconds(1);
    //        transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, transform.position.y + dir2, 0.1f), transform.position.z);
    //        //gameObject.transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y + dir2, transform.position.z), 0.3f);
    //        //gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + dir2, transform.position.z);
    //    }
    //}

    IEnumerator EnemyRandomMove()
    {
        //if (Mathf.Abs(rb.velocity.x) < 0.1f)
        //{
        //    rb.AddForce(new Vector2(speed * ranNum1, rb.velocity.y));
        //    yield return new WaitForSeconds(1);
        //}

        //else if (Mathf.Abs(rb.velocity.x) > 1f)
        //{
        //    rb.AddForce(new Vector2(speed * -ranNum1, rb.velocity.y));
        //    yield return new WaitForSeconds(1);
        //}

        //else if (Mathf.Abs(rb.velocity.y) < 0.1f)
        //{
        //    rb.AddForce(new Vector2(rb.velocity.x, speed * -ranNum1));
        //    yield return new WaitForSeconds(1);
        //}

        //else
        //{
        //    rb.AddForce(new Vector2(rb.velocity.x, speed * ranNum1));
        //    yield return new WaitForSeconds(1);
        //}
        while (isAlive)
        {
            switch (ranNum1, ranNum2)
            {
                case (0, 0):
                    transform.position = Vector2.up/*(transform.position.x, transform.position.x + ranNum1, 0.5f)*/;
                    yield return new WaitForSeconds(1);
                    break;
                case (1, 0):
                    transform.position = Vector2.down;
                    yield return new WaitForSeconds(1);
                    break;
                case (0, 1):
                    transform.position = Vector2.right;
                    yield return new WaitForSeconds(1);
                    break;
                case (1, 1):
                    transform.position = Vector2.left;
                    yield return new WaitForSeconds(1);
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PBullet")
        {
            StartCoroutine(ChangeColor());
            Damage();

            Destroy(collision.gameObject);
        }
    }

    void Damage()
    {
        enemyHP -= playerAttack;

        if (enemyHP <= 0)
        {
            isAlive = false;
            gameObject.SetActive(false);
            GameObject go = Instantiate(boom1, transform.position, Quaternion.identity);
            Destroy(go, 0.5f);
        }
        Debug.Log($"enemyHP : {enemyHP}");
    }

    IEnumerator ChangeColor()
    {
        SpriteRenderer body = GetComponent<SpriteRenderer>();
        SpriteRenderer turret = GetComponentInChildren<SpriteRenderer>();
        body.color = Color.gray;
        turret.color = Color.gray;
        yield return new WaitForSeconds(0.3f);
        body.color = Color.white;
        turret.color = Color.white;

    }
}
