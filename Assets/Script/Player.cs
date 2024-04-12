using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    public Rigidbody2D _base;
    private float moveSpeed = 3.0f;
    private float rotationSpeed = 3.0f;
    float x;
    float y;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TankMove();

        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * moveSpeed); // 3차원에서 돌음
        //transform.Rotate(new Vector3(transform.position.x, transform.position.y, rotationSpeed * 50) * Time.deltaTime, Space.World); // 한방향으로 돌음
        //Vector2 _dir = target.position - this.transform.position; // 돌았음
        //this.transform.LookAt2DLerp(_dir);
    }

    private void TankMove()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(x, y);
        _base.velocity = dir * moveSpeed;
        Rotation();
    }

    private void Rotation()
    {
        if (x > 0)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -90), rotationSpeed * Time.deltaTime);
        
        if (x < 0)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 90), rotationSpeed * Time.deltaTime);

        if (y > 0)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), rotationSpeed * Time.deltaTime);

        if (y < 0)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 180), rotationSpeed * Time.deltaTime);


        //캐릭터의 월드 좌표를 뷰포트 좌표계로 변환해준다.
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x); //x값을 0이상, 1이하로 제한한다.
        viewPos.y = Mathf.Clamp01(viewPos.y); //y값을 0이상, 1이하로 제한한다.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);//다시월드좌표로 변환
        transform.position = worldPos; //좌표를 적용한다.

        //LookAtSlowly(target);

        //Vector3 eulerAngle = new Vector3 (x, y, 10);
        //transform.Rotate(eulerAngle, Space.Self);
        //transform.localRotation *= Quaternion.Euler(eulerAngle);

        //if (Input.GetKey(KeyCode.W))
        //    transform.rotation = Quaternion.Euler(Vector2.up);//앞으로
        //else if (Input.GetKey(KeyCode.S))
        //    transform.rotation = Quaternion.Euler(Vector2.down);//뒤로
        //else if (Input.GetKey(KeyCode.A))
        //    transform.rotation = Quaternion.Euler(Vector2.left);//왼쪽
        //else if (Input.GetKey(KeyCode.D))
        //    transform.rotation = Quaternion.Euler(Vector2.right);//오른쪽
    }

    //private void LookAtSlowly(Transform target, float speed = 1f)
    //{
    //    if (target == null) return;

    //    Vector3 dir = target.position - transform.position;
    //    var nextRot = Quaternion.LookRotation(dir);
    //    transform.rotation = Quaternion.Slerp(transform.rotation, nextRot, Time.deltaTime * speed);
    //}
}
//public static class LookAtExtension // 겁나 빨리 돌음
//{
//    public static void LookAt2DLerp(this Transform transform, Vector2 dir, float lerpPercent = 0.05f)
//    {
//        float rotationZ = Mathf.Acos(dir.x / dir.magnitude)
//            * 180 / Mathf.PI
//            * Mathf.Sign(dir.y);

//        transform.rotation = Quaternion.Lerp(
//            transform.rotation,
//            Quaternion.Euler(0, 0, rotationZ),
//            lerpPercent
//        );
//    }
//}
