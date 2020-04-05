using System;
using System.Collections;
using UnityEngine;

namespace Core
{
    public class Timer : MonoBehaviour
    {
        public GameProxy gameProxy;
        public float timeLeft = 100;
        public float tickInterval = 1;

        private void Start()
        {
            StartCoroutine(SpawnObject());
        }
        
        IEnumerator SpawnObject()
        {
            while (true)
            {
                timeLeft -= tickInterval;
                if (timeLeft <= 0)
                {
                    gameProxy.OnTimerEnd();
                    Destroy(gameObject);
                }
                else
                    gameProxy.OnTimerTick(timeLeft);
                yield return new WaitForSeconds(tickInterval);
            }
        }
    }
}