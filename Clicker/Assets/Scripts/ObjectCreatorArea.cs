using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Gameplay/Object Creator Area")]
[RequireComponent(typeof(BoxCollider2D))]
public class ObjectCreatorArea : Action
{
    [Header("Object creation")]

    // The object to spawn
    // WARNING: take if from the Project panel, NOT the Scene/Hierarchy!
    public GameObject prefabToSpawn;

    [Header("Other options")]

    // Configure the spawning pattern
    public float spawnInterval = 1;

    private BoxCollider2D _boxCollider2D;
    private bool isActive = true;

    void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();

        StartCoroutine(SpawnObject());
    }

    // This will spawn an object, and then wait some time, then spawn another...
    IEnumerator SpawnObject()
    {
        while (isActive)
        {
            // Create some random numbers
            var size = _boxCollider2D.size;
            float randomX = Random.Range(-size.x, size.x) * .5f;
            var size1 = _boxCollider2D.size;
            float randomY = Random.Range(-size1.y, size1.y) * .5f;

            // Generate the new object
            GameObject newObject = Instantiate<GameObject>(prefabToSpawn, new Vector3(2, 2, 2), Quaternion.identity);
            var position = this.transform.position;
            newObject.transform.position = new Vector2(randomX + position.x + 1f, randomY + position.y);

            // Wait for some time before spawning another object
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public override bool ExecuteAction(GameObject otherObject)
    {
        isActive = !isActive;
        return true;
    }
}