using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target; // The object to follow
    public Vector3 offset = new Vector3(0f, 5f, -10f); // Offset from the target
    public float smoothSpeed = 5f; // Smoothness factor

    private void LateUpdate()
    {
        if (target == null) return;

        // Desired position
        Vector3 desiredPosition = target.position + offset;

        // Smoothly interpolate to the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Optionally, look at the target
        transform.LookAt(target);
    }
}
