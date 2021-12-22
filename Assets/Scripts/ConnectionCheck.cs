using UnityEngine;

public class ConnectionCheck : MonoBehaviour
{
    public bool isConnected = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "touch")
        {
            isConnected = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "touch")
        {
            isConnected = false;
        }
    }
}
