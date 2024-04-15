using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurretMove : MonoBehaviour
{
    [SerializeField] private int rotateSpeed;
    public GameObject player;

    [SerializeField] public Transform playerCheck;
    [SerializeField] private LayerMask whatIsPlayer;
    private float playerCheckDistance;

    void Update()
    {
        if(player != null)
        {
            Vector2 direction = new Vector2(transform.position.x - player.transform.position.x, transform.position.y - player.transform.position.y);

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion angleAxis = Quaternion.AngleAxis(angle + 90f, Vector3.forward);
            Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, rotateSpeed * Time.deltaTime);
            transform.rotation = rotation;
        }
        //Vector3 vec = player.transform.position - transform.position;
        //vec.Normalize();
        //Quaternion q = Quaternion.LookRotation(vec);
        //transform.rotation = q; // 3D
    }

    public bool isPlayerDetected() => Physics2D.Raycast(playerCheck.position, transform.position, playerCheckDistance);

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(playerCheck.position, player.transform.position);
    }
}
