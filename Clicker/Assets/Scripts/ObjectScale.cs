using UnityEngine;

public class ObjectScale : MonoBehaviour
{
    [Header("Scale per frame")] public float k = 1.1f;
    [Header("Scale k when destroyed")] public float kDestroy = 2;

    private void Update()
    {
        gameObject.transform.localScale *= k;
        if (gameObject.transform.localScale.x > kDestroy)
            Destroy(gameObject);
    }
}