using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField] private BirdStats _birdStats;
    [SerializeField] private PlayerController _playerController;
    void Start()
    {
        _playerController = GameObject.Find("PlayerShip").GetComponent<PlayerController>();
    }

    
    void Update()
    {
        Movement();
        IsPass();
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("fire") )
            Die();
        if (collision.CompareTag("ship"))
        {
            _playerController.GetDamage(20f);
            Die();
        }
            
    }

     private void IsPass()
    {
        if (gameObject.transform.position.y < -3f)
        {
            Die();
            _playerController.GetDamage(10f);
        }
        if (_playerController.isDead == true)
        {
            Die();
        }
    }

    private void Movement()
    {
        transform.Translate(Vector2.down * Time.deltaTime * _birdStats.Speed, Space.World);
    }

}
