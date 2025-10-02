using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // O objeto que a câmera vai seguir
    public Vector3 offset;   // Distância da câmera em relação ao alvo

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }
}
