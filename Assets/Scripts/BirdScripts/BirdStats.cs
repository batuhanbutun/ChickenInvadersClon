using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Bird/BirdStats")]
public class BirdStats : ScriptableObject
{
    [SerializeField] private float _speed = 1f;
    
    public float Speed { get { return _speed; } set { _speed = value; } }
   


}
