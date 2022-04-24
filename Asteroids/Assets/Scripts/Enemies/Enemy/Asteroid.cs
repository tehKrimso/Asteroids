﻿using Enemies.Infrastructure;
using Enemies.Movement;
using UnityEngine;

namespace Enemies.Enemy
{
    public class Asteroid : MonoBehaviour, IEnemy
    {
        public float MoveSpeed;
        public Transform Player { get; set;  }
        public IEnemyMovement MovementLogic { get; set; }

        private void Start()
        {
            MovementLogic = new AsteroidMovement(Player, transform,MoveSpeed);
            MovementLogic.Move();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if(col.CompareTag("Player"))
                Destroy(gameObject);
        }
    }
}