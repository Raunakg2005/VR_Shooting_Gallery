using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;
    public Transform[] spawnLocations;

    void Start()
    {
        // Spawns the very first target when the game loads
        SpawnNewTarget();
    }

    public void SpawnNewTarget()
    {
        // Pick a random number between 0 and your total number of spawn points
        int randomIndex = Random.Range(0, spawnLocations.Length);
        Transform chosenLocation = spawnLocations[randomIndex];
        
        // Create the target at that chosen point
        Instantiate(targetPrefab, chosenLocation.position, chosenLocation.rotation);
    }
}