using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class playerCTRL : MonoBehaviour
{   
    public GameObject player;

    // movimiento variables
    public float moveSpeed;
    [SerializeField] float speedX, speedY;
    public Rigidbody2D rb2D;

    // shoot
    [SerializeField] GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    public float timer;
    public float timeBetweenFire;
    void Update()
    {
        //movement
        speedX = Input.GetAxisRaw("Horizontal") * moveSpeed ;
        speedY = Input.GetAxisRaw("Vertical") * moveSpeed ;
        rb2D.velocity = new Vector2 (speedX, speedY);

        //fire set-up
        if(!canFire)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenFire)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButtonDown(0)&& canFire)
        {
            canFire = false;
            Instantiate(bullet, bulletTransform.position, quaternion.identity);
        }

             // Rotación hacia el mouse
        RotateTowardsMouse();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("enemy")){
            Destroy(player);
        }
    }

    void RotateTowardsMouse()
    {
        // Obtén la posición del mouse en el espacio del mundo
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calcula la dirección hacia el mouse
        Vector2 direction = (mousePosition - transform.position).normalized;

        // Calcula el ángulo de rotación en radianes
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rota el objeto hacia el ángulo calculado
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}

