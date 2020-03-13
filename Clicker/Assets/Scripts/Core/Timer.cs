using UnityEngine;

namespace Core
{
    public class Timer : MonoBehaviour
    {
        public GameProxy gameProxy;
        public float timeLeft = 100;

        void Update()
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                gameProxy.OnTimerEnd();
                Destroy(gameObject);
            }
            else
                gameProxy.OnTimerTick(timeLeft);
        }
    }
}