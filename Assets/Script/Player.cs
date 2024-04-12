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

        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * moveSpeed); // 3�������� ����
        //transform.Rotate(new Vector3(transform.position.x, transform.position.y, rotationSpeed * 50) * Time.deltaTime, Space.World); // �ѹ������� ����
        //Vector2 _dir = target.position - this.transform.position; // ������
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


        //ĳ������ ���� ��ǥ�� ����Ʈ ��ǥ��� ��ȯ���ش�.
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x); //x���� 0�̻�, 1���Ϸ� �����Ѵ�.
        viewPos.y = Mathf.Clamp01(viewPos.y); //y���� 0�̻�, 1���Ϸ� �����Ѵ�.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);//�ٽÿ�����ǥ�� ��ȯ
        transform.position = worldPos; //��ǥ�� �����Ѵ�.

        //LookAtSlowly(target);

        //Vector3 eulerAngle = new Vector3 (x, y, 10);
        //transform.Rotate(eulerAngle, Space.Self);
        //transform.localRotation *= Quaternion.Euler(eulerAngle);

        //if (Input.GetKey(KeyCode.W))
        //    transform.rotation = Quaternion.Euler(Vector2.up);//������
        //else if (Input.GetKey(KeyCode.S))
        //    transform.rotation = Quaternion.Euler(Vector2.down);//�ڷ�
        //else if (Input.GetKey(KeyCode.A))
        //    transform.rotation = Quaternion.Euler(Vector2.left);//����
        //else if (Input.GetKey(KeyCode.D))
        //    transform.rotation = Quaternion.Euler(Vector2.right);//������
    }

    //private void LookAtSlowly(Transform target, float speed = 1f)
    //{
    //    if (target == null) return;

    //    Vector3 dir = target.position - transform.position;
    //    var nextRot = Quaternion.LookRotation(dir);
    //    transform.rotation = Quaternion.Slerp(transform.rotation, nextRot, Time.deltaTime * speed);
    //}
}
//public static class LookAtExtension // �̳� ���� ����
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
