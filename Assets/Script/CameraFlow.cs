using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;   // arraste o Player aqui no Inspector
    public Vector3 offset = new Vector3(5, 3, 10); // ajuste o que quiser

    void LateUpdate()
    {
        if (target == null) return;

        transform.position = target.position + offset;
    }
}
