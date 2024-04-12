using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurretMove : MonoBehaviour
{
    public GameObject player;

    private float rotateDegree;
    Vector3 pPosition;

    void Update()
    {
        pPosition = player.transform.position;
        PointLook();
    }

    public void PointLook()
    {
        Vector3 oPosition = transform.position; //게임 오브젝트 좌표 저장

        pPosition.z = oPosition.z - Camera.main.transform.position.z;

        Vector3 target = Camera.main.ScreenToWorldPoint(pPosition);

        float dy = target.y - oPosition.y;
        float dx = target.x - oPosition.x;

        rotateDegree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotateDegree);
    }
}
