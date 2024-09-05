using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class cameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float speed;
    [SerializeField] Vector3 offset;

    void Update()
    {
        Vector3 desiredPos = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPos, speed * Time.deltaTime);
    }
}
