using UnityEngine;



public class Goat : MonoBehaviour
{
    public string goatName = "Baby Goat";
    public int goatValue = 1;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInteraction player = other.GetComponent<PlayerInteraction>();
            if (player != null)
            {
                player.CollectGoat(this);
            }

            // Optionally add a sound effect before destroying the goat
            Destroy(gameObject);
        }
    }
}
