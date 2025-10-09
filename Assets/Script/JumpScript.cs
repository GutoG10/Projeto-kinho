using JetBrains.Annotations;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    public bool allowJump = true;
    void OnTriggerEnter(Collider other)
    {
        allowJump = true;
    }

    void OnTriggerExit(Collider other)
    {
        allowJump = false;
        
    }
}
