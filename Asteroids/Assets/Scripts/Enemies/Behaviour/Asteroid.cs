﻿using Enemies.DestructionLogic;
using Enemies.Infrastructure;
using Enemies.Movement;
using UnityEngine;

namespace Enemies.Behaviour
{
    public class Asteroid : MonoBehaviour, IEnemy
    {
        public float MoveSpeed;

        public GameObject asteroidPiecePrefab;
        public Transform Player { get; set;  }
        public IEnemyMovement MovementLogic { get; set; }
        public IDestructionLogic DestructionLogic { get; set; }

        public int ScorForDestruction;

        private void Start()
        {
            DestructionLogic = new AsteroidDestructionLogic(transform, asteroidPiecePrefab,ScorForDestruction);
            MovementLogic = new AsteroidMovement(Player, transform,MoveSpeed);
            MovementLogic.Move();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Ammo") || col.CompareTag("Laser"))
            {
                DestructionLogic.HandleDestruction();
            }
        }
    }
}