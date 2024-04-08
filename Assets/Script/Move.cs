using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Move : MonoBehaviour
{
    public Rigidbody2D _base;
    public float moveSpeed = 3.0f;
    public float rotationSpeed = 3.0f;
    float x;
    float y;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(x, y);
        _base.velocity = dir * moveSpeed;

        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * moveSpeed); // 3�������� ����
        //transform.Rotate(new Vector3(transform.position.x, transform.position.y, rotationSpeed * 50) * Time.deltaTime, Space.World); // �ѹ������� ����
        Vector2 _dir = target.position - this.transform.position; // ������
        this.transform.LookAt2DLerp(_dir);
    }

}
public static class LookAtExtension // �̳� ���� ����
{
    public static void LookAt2DLerp(this Transform transform, Vector2 dir, float lerpPercent = 0.05f)
    {
        float rotationZ = Mathf.Acos(dir.x / dir.magnitude)
            * 180 / Mathf.PI
            * Mathf.Sign(dir.y);

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.Euler(0, 0, rotationZ),
            lerpPercent
        );
    }
}
