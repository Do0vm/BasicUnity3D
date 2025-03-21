using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Raycast Settings")]
    public Camera playerCamera;
    public float interactDistance = 3f;

    [Header("UI References")]
    public TMP_Text interactionText;
    public TMP_Text goatCountText; // Updated to track goats

    private int goatCount = 0;

    private void Start()
    {
        if (interactionText != null)
            interactionText.enabled = false;
        UpdateGoatCount();
    }

    private void Update()
    {
        HandleRaycast();

        if (goatCount >= 4)
        {
            SceneManager.LoadScene("Victory");
        }

    }

    void HandleRaycast()
    {
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            Goat goat = hit.collider.GetComponent<Goat>();
            if (goat != null)
            {
                // Show interaction prompt
                interactionText.text = "Press A or E to collect " + goat.goatName;
                interactionText.enabled = true;

                if (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown(KeyCode.E))
                {
                    CollectGoat(goat);
                }
                return;
            }
        }
        interactionText.enabled = false;
    }

    public void CollectGoat(Goat goat)
    {
        goatCount += goat.goatValue;
        UpdateGoatCount();

        if (goat != null)
        {
            Destroy(goat.gameObject);
        }
    }

    void UpdateGoatCount()
    {
        if (goatCountText != null)
            goatCountText.text = "Baby Goats: " + goatCount;

 
    }
}
