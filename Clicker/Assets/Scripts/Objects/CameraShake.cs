using System.Collections;
using UnityEngine;

namespace Objects
{
    public class CameraShake : MonoBehaviour
    {
        // Transform of the camera to shake. Grabs the gameObject's transform
        // if null.
        public Transform camTransform;

        // How long the object should shake for.
        public float shakeDuration = 0f;

        // Amplitude of the shake. A larger value shakes the camera harder.
        public float shakeAmount = 0.7f;
        public float decreaseFactor = 1.0f;

        Vector3 _originalPos;
        float _currentShake;

        private void Awake()
        {
            if (camTransform == null)
            {
                camTransform = GetComponent(typeof(Transform)) as Transform;
            }
        }

        public void Shake()
        {
            _currentShake += shakeAmount;
        }

        void OnEnable()
        {
            _originalPos = camTransform.localPosition;
        }

        void Update()
        {
            if (_currentShake > 0)
            {
                camTransform.localPosition = _originalPos + Random.insideUnitSphere * shakeAmount;

                _currentShake -= Time.deltaTime * decreaseFactor;
            }
            else
            {
                _currentShake = 0f;
                camTransform.localPosition = _originalPos;
            }
        }
    }
}