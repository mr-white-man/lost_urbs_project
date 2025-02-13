using UnityEngine;

public class AreaCollider : MonoBehaviour
{
    public GameObject textObject; // Assign the text GameObject in the Inspector
    public GameObject textObject2;

    void Start()
    {
        textObject.SetActive(false); // Hide text initially
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            textObject.SetActive(true);
            textObject2.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            textObject.SetActive(false);
            textObject2.SetActive(false);
    }
}