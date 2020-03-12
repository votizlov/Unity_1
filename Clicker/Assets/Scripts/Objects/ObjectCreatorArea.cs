using System;
using UnityEngine;
using System.Collections;
using Core;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

[AddComponentMenu("Playground/Gameplay/Object Creator Area")]
[RequireComponent(typeof(BoxCollider2D))]
public class ObjectCreatorArea : MonoBehaviour
{
    [Header("Object creation")]

    // The object to spawn
    // WARNING: take if from the Project panel, NOT the Scene/Hierarchy!
    public GameObject prefabToSpawn;

    [Header("Other options")]

    // Configure the spawning pattern
    public float spawnInterval = 1;

    public BoxCollider2D _spawnArea;
    public GameProxy gameProxy;
    private bool isActive = true;

    void Start()
    {
        StartCoroutine(SpawnObject());
    }

    private void Awake()
    {
        gameProxy.TimerEndEvent += toggleSpawn;
    }

    // This will spawn an object, and then wait some time, then spawn another...
    IEnumerator SpawnObject()
    {
        while (isActive)
        {
            // Create some random numbers
            var size = _spawnArea.size;
            float randomX = Random.Range(-size.x, size.x) * .5f;
            var size1 = _spawnArea.size;
            float randomY = Random.Range(-size1.y, size1.y) * .5f;

            // Generate the new object
            GameObject newObject = Instantiate<GameObject>(prefabToSpawn, new Vector3(2, 2, 2), Quaternion.identity);
            var position = this.transform.position;
            newObject.transform.position = new Vector2(randomX + position.x + 1f, randomY + position.y);

            // Wait for some time before spawning another object
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void toggleSpawn()
    {
        isActive = !isActive;
    }
}