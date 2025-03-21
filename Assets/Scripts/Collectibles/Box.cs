using UnityEngine;

public class Cage : MonoBehaviour
{
    [Header("Cage Settings")]
    public bool isOpen = false; 
    [Header("Spawn Settings")]
    public GameObject goatPrefab; 
    public Transform spawnPoint;  
    public int numberOfGoats = 3; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hitbox") || other.CompareTag("Player"))
        {
            OpenCage();
        }
    }

    public void OpenCage()
    {
    
        gameObject.SetActive(false); 

        // Spawn the goats
        if (goatPrefab != null && spawnPoint != null)
        {
            for (int i = 0; i < numberOfGoats; i++)
            {
                Vector3 randomOffset = new Vector3(Random.Range(-0.5f, 0.5f), 0, Random.Range(-0.5f, 0.5f));
                Instantiate(goatPrefab, spawnPoint.position + randomOffset, spawnPoint.rotation);
            }
        }
    }
}
