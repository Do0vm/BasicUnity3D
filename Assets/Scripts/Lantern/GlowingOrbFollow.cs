using UnityEngine;

public class GlowingOrbFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 3, 0);
    public float followDelay = 0.5f;

    private Vector3 currentVelocity = Vector3.zero;

    void Update()
    {
        if (player != null)
        {
            Vector3 targetPosition = player.TransformPoint(offset);

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, followDelay);
        }
    }
}
