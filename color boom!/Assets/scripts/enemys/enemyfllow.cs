using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyfllow : MonoBehaviour
{
    public float speed;
    public float speedRot;
    public float rotationModifier;
    public Transform target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        Vector3 vectorToTarget = target.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speedRot);
    }

}
