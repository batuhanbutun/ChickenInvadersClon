using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float _fireballSpeed = 10f;

    void Update()
    {
        FireMovement();
        DestroyFire();
    }
    private void DestroyFire()
    {
        if (transform.position.y > 3f)
            Destroy(gameObject);
    }
    private void FireMovement()
    {
        transform.Translate(Vector2.up * Time.deltaTime * _fireballSpeed, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bird")
        {
            Destroy(gameObject);
        }
            
    }
}
