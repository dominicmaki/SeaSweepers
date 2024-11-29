using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] float trashSpeed = 5f;
    [SerializeField] float sharkSpeed = 5f;
    [SerializeField] float tunaSpeed = 5f;
    [SerializeField] GameObject sharkPrefab;
    [SerializeField] GameObject trashPrefab;
    [SerializeField] GameObject tunaPrefab;
    [SerializeField] Transform spawnTransform;
    [SerializeField] public float minY = -6f;          // Minimum Y position
    [SerializeField] public float maxY = 6f;           // Maximum Y position
    [SerializeField] public float minSeparation = 3f; // Minimum separation between the objects on the Y-axis
    [SerializeField] float spawnTime = 4f;
    [SerializeField] float despawnTime = 4f;

    // Start is called before the first frame update
    void Start()
    {
        Launch();
    }

    // Class-level variables to track the number of spawned objects
private int trashCount = 0;
private int sharkCount = 0;
private int tunaCount = 0;

public void SpawnProjectile()
{
    // Generate a random Y position between minY and maxY for the first object (trash)
    if (trashCount < 3) // Check if we can spawn more trash objects
    {
        float randomY1 = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(5f, randomY1, 0f); // Fixed X on the right, random Y
        GameObject trashObject = Instantiate(trashPrefab, spawnPosition, Quaternion.identity);
        trashObject.GetComponent<Rigidbody2D>().velocity = -transform.right * trashSpeed; // Move to the left
        tunaCount++;
        Destroy(trashObject, despawnTime);
        tunaCount--; // Increment the trash counter
    }

    // Spawn the second object (shark) if allowed
    if (sharkCount < 3)
    {
        float randomY2;
        do
        {
            randomY2 = Random.Range(minY, maxY);
        } while (Mathf.Abs(randomY2 - minY) < minSeparation); // Ensure proper separation

        Vector3 spawnPosition2 = new Vector3(5f, randomY2, 0f); // Fixed X on the right, random Y
        GameObject sharkObject = Instantiate(sharkPrefab, spawnPosition2, Quaternion.identity);
        sharkObject.GetComponent<Rigidbody2D>().velocity = -transform.right * sharkSpeed; // Move to the left
        sharkCount++;
        Destroy(sharkObject, despawnTime);
        sharkCount--; // Increment the shark counter
    }

    // Spawn the third object (tuna) if allowed
    if (tunaCount < 3)
    {
        float randomY3;
        do
        {
            randomY3 = Random.Range(minY, maxY);
        } while (Mathf.Abs(randomY3 - minY) < minSeparation); // Ensure proper separation

        Vector3 spawnPosition3 = new Vector3(5f, randomY3, 0f); // Fixed X on the right, random Y
        GameObject tunaObject = Instantiate(tunaPrefab, spawnPosition3, Quaternion.identity);
        tunaObject.GetComponent<Rigidbody2D>().velocity = -transform.right * tunaSpeed; // Move to the left
        tunaCount++;
        Destroy(tunaObject, despawnTime);
        tunaCount--; // Increment the tuna counter
    }
}




    public void Launch()
    {
        StartCoroutine(Wait());
        IEnumerator Wait()
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnTime);

                // Safety check to avoid spamming
                if (minSeparation >= (maxY - minY))
                {
                    Debug.LogError("minSeparation is too large compared to the range of minY and maxY!");
                    yield break; // Stop the coroutine
                }

                SpawnProjectile();
            }
        }
    }

}
