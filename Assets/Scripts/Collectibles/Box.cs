using UnityEngine;

public class DestroyOnHitbox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hitbox")) // Ensure the hitbox has the correct tag
        {
            Debug.Log("BoxHit");
            Destroy(gameObject);
        }
    }
}