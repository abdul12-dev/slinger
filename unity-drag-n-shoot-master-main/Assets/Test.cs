using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private AudioClip testSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource != null && testSound != null)
        {
            audioSource.PlayOneShot(testSound);
            Debug.Log("Test sound played");
        }
        else
        {
            Debug.LogWarning("AudioSource or TestSound not assigned.");
        }
    }
}
