// using UnityEngine;

// public class Balloon : MonoBehaviour
// {
//     void OnMouseDown()
//     {
//         // Add or subtract score based on BalloonFloat script
//         BalloonFloat bf = GetComponent<BalloonFloat>();
//         if (bf != null)
//         {
//             GameManager.score += bf.scoreValue;
//         }

//         Debug.Log("Score: " + GameManager.score);

//         Destroy(gameObject);
//     }

// }

using UnityEngine;

public class Balloon : MonoBehaviour
{
    public AudioClip popSound;
    public GameObject popEffectPrefab;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        Pop();
    }

    // void Pop()
    // {
    //     // Play sound
    //     if (popSound != null && audioSource != null)
    //     {
    //         audioSource.PlayOneShot(popSound);
    //     }

    //     // Visual pop effect (attached to balloon)
    //     if (popEffectPrefab != null)
    //     {
    //         GameObject effect = Instantiate(popEffectPrefab, transform.position, Quaternion.identity);
    //         Destroy(effect, 1f); // destroy effect after 1 second
    //     }

    //     // Add/Subtract score
    //     BalloonFloat bf = GetComponent<BalloonFloat>();
    //     if (bf != null)
    //     {
    //         GameManager.score += bf.scoreValue;
    //     }

    //     // Destroy the balloon
    //     Destroy(gameObject);
    // }

    void Pop()
    {
        // Play sound
        if (popSound != null && audioSource != null)
        {   
            Debug.Log("Playing Pop Sound");
            audioSource.PlayOneShot(popSound);
        }

        // Visual pop effect (play manually)
        if (popEffectPrefab != null)
        {
            GameObject effect = Instantiate(popEffectPrefab, transform.position, Quaternion.identity);
            
            ParticleSystem ps = effect.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                ps.Play(); // manually start the burst
            }

            Destroy(effect, 1f); // destroy effect after 1 second
        }

        // Add/Subtract score
        BalloonFloat bf = GetComponent<BalloonFloat>();
        if (bf != null)
        {
            GameManager.score += bf.scoreValue;
        }

        // Destroy the balloon
        Destroy(gameObject);
    }

}

