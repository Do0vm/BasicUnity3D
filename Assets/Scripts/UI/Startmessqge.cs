using UnityEngine;
using TMPro;

public class StartMessage : MonoBehaviour
{
    [Header("UI Reference")]
    // Assign your TextMeshProUGUI element in the Inspector.
    public TMP_Text messageText;

    [Header("Message Settings")]
    public float displayTime = 3f; // How long the message will be visible (in seconds)
    public string welcomeMessage = "Welcome to the Game!";

    private void Start()
    {
        if (messageText != null)
        {
            // Set and display the welcome message.
            messageText.text = welcomeMessage;
            messageText.gameObject.SetActive(true);

            // Hide the message after the specified time.
            Invoke(nameof(HideMessage), displayTime);
        }
    }

    // This method hides the message.
    void HideMessage()
    {
        if (messageText != null)
        {
            messageText.gameObject.SetActive(false);
        }
    }
}
