using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private GameObject _fireball;
    [SerializeField] private Slider healthbarSlider;
    [SerializeField] private  GameManager _gamemanager;
    private float fireballOffsetY = 0.59f;
    public bool isDead = false;

    void Start()
    {
        _playerStats.Speed = 6f;
        _playerStats.Health = 100;
        SetMaxHealth(_playerStats.Health);
    }

    void Update()
    {
        SetCurrentHealth(_playerStats.Health);
        movement();
        fire();
    }

    

   private void movement()
    {
        if (isDead == false && _gamemanager.isGameActive)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector2 direction = new Vector2(horizontal, vertical).normalized;
            if (direction.magnitude >= 0.01f)
            {
                transform.Translate(direction * Time.deltaTime * _playerStats.Speed, Space.World);
            }
        }
            
    }
   private void fire()
    {
        if (isDead == false && _gamemanager.isGameActive)
        {
            Vector3 fireballOffSet = new Vector3(0, fireballOffsetY, 0);
            if (Input.GetKeyDown("space"))
            {
                Instantiate(_fireball, transform.position + fireballOffSet, _fireball.transform.rotation);
            }
        }
    }

   private void SetMaxHealth(float health)
    {
        healthbarSlider.maxValue = health;
        healthbarSlider.value = health;
    }
   private void SetCurrentHealth(float health)
    {
        healthbarSlider.value = health;
    }
    public void GetDamage(float damage)
    {
        _playerStats.Health = _playerStats.Health - damage;
        if (_playerStats.Health <= 0)
        {
            _gamemanager.GameOver();
            isDead = true;
        }
            
    }

    IEnumerator SpeedPowerUpBoost()
    {
        yield return new WaitForSeconds(5);
        _playerStats.Speed = 6f;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("speedboost"))
        {
            Destroy(collision.gameObject);
            _playerStats.Speed = 12f;
            StartCoroutine(SpeedPowerUpBoost());
        }
           
    }


}
