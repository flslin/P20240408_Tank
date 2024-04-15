using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    EnemyTurretMove turretMove;

    [SerializeField] private bool isFire;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject ShootingPoint;
    void Start()
    {
        turretMove = GetComponent<EnemyTurretMove>();
    }

    void Update()
    {
        StartCoroutine(Shooting());
    }

    IEnumerator Shooting()
    {
        if (turretMove.isPlayerDetected())
        {
            isFire = true;
            anim.SetBool("isFire", isFire);
            Instantiate(bulletPrefab, new Vector3(ShootingPoint.transform.position.x, ShootingPoint.transform.position.y, ShootingPoint.transform.position.z), Quaternion.identity);
            yield return new WaitForSeconds(1);
        }
    }

    public void ShootingOver()
    {
        isFire = false;
        anim.SetBool("isFire", isFire);
    }
}
