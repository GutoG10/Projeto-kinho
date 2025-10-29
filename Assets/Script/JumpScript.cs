using JetBrains.Annotations;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    public bool allowJump = true;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entrou em contato com: " + other.name);
        allowJump = true;
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Saiu de contato com: " + other.name);
        allowJump = false;
    }
}
