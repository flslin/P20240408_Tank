using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    EnemyTurretMove turretMove;

    [SerializeField] private bool isFire;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject bulletPrefab;

    void Start()
    {
        turretMove = GetComponent<EnemyTurretMove>();
        Invoke("EnemyShooting", 3f);
    }

    void Update()
    {
        
    }

    void EnemyShooting()
    {
        if (turretMove.isPlayerDetected())
        {
            isFire = true;
            anim.SetBool("isFire", isFire);
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            Invoke("EnemyShooting", 3f);
        }
    }

    public void ShootingOver()
    {
        isFire = false;
        anim.SetBool("isFire", isFire);
    }
}
