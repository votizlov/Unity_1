using UnityEngine;

namespace Objects
{
    public class HitImageController : MonoBehaviour
    {
        public float appearanceTime;

        // Update is called once per frame
        void Update()
        {
            appearanceTime -= Time.deltaTime;
            if(appearanceTime<=0)
                Destroy(gameObject);
        }
    }
}
