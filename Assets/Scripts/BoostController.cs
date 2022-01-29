using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostController : MonoBehaviour
{
    private float boostSpeed = 2f;
    private GameManager _gameManager;
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * boostSpeed, Space.World);
        IsPass();
    }

   private void Die()
    {
        Destroy(gameObject);
    }
   private void IsPass()
    {
        if (gameObject.transform.position.y < -3f)
        {
            Die();
        }
        if (_gameManager.isGameActive == false)
        {
            Die();
        }
    }

}
