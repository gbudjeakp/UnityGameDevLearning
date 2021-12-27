using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Fuel":
                Debug.Log("Got more Fuel");
                break;
            case "Friendly":
                Debug.Log("On Launch Pad");
                break;
            case "Finish":
                Debug.Log("Landing Successful");
                break;
            default:
                Debug.Log("Player Died");
                break;
        }
    }
}
