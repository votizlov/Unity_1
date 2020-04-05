using System;
using Core;
using UnityEngine;

namespace Objects
{
    public class Baloon : MonoBehaviour
    {
        public int score = 10;
        public int clicksToDestroy = 1;
        public GameProxy gameProxy;
        [Header("Scale per frame")] public float k = 1.0001f;
        [Header("Scale k when destroyed")] public float kDestroy = 2;
        public event Action DieEvent;
        public event Action HitEvent;
        [Header("Explosion stuff")] public Explodable explodable;

        private bool _isFreezed = false;

        private void OnEnable()
        {
            gameProxy.AddObject(gameObject);
            gameProxy.TimerEndEvent += Freeze;
        }

        private void OnDisable()
        {
            gameProxy.RemoveObject(gameObject);
        }

        private void Update()
        {
            if (!_isFreezed)
            {
                gameObject.transform.localScale *= k;
                if (gameObject.transform.localScale.x > kDestroy)
                    Destroy(gameObject);
            }
        }

        private void OnMouseDown()
        {
            if (!_isFreezed)
            {
                clicksToDestroy--;
                HitEvent?.Invoke();
                if (clicksToDestroy <= 0)
                {
                    gameProxy.AddScore(score);
                    DieEvent?.Invoke();
                    explodable.generateFragments();
                    foreach (var fragment in explodable.fragments)
                    {
                        fragment.AddComponent<ObjectCleaner>();
                    }
                    gameProxy.ShakeCam();
                    gameProxy.ExplosionForce.doExplosion(transform.position);
                    explodable.explode();
                }
            }
        }

        private void Freeze()
        {
            _isFreezed = !_isFreezed;
        }
    }
}