using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject ShootingPoint;

    public GameObject bulletPrefab;
    public Animator anim;
    bool isFire;

    void Update()
    {
        Shooting();
    }

    public void Shooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isFire = true;
            anim.SetBool("isFire", isFire);
            Instantiate(bulletPrefab, new Vector3(ShootingPoint.transform.position.x, ShootingPoint.transform.position.y, ShootingPoint.transform.position.z), Quaternion.identity);
        }

    }

    public void ShootingOver()
    {
        isFire = false;
        anim.SetBool("isFire", isFire);
    }
}
