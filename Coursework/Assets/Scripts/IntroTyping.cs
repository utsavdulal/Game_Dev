using UnityEngine;
using TMPro;
using System.Collections;

public class IntroTyping : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI introText;

    [TextArea(10, 20)]
    public string fullText;

    [Header("Typing Settings")]
    public float typingSpeed = 0.07f;

    [Header("Player")]
    public GameObject player;

    [Header("Audio")]
    public AudioSource typingAudio;

    // Controls how often typing sound can play
    private float soundTimer = 0f;

    // Bigger number = slower sound frequency
    public float soundDelay = 0.30f;

    private bool finishedTyping = false;

    void Start()
    {
        // Disable player during intro
        if (player != null)
        {
            player.SetActive(false);
        }

        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        introText.text = "";

        foreach (char letter in fullText)
        {
            introText.text += letter;

            // Play typing sound occasionally
            if (typingAudio != null && letter != ' ')
            {
                if (Time.time > soundTimer && Random.Range(0, 4) == 0)
                {
                    // Slight random pitch variation
                    typingAudio.pitch = Random.Range(0.95f, 1.05f);

                    // Very low volume
                    typingAudio.PlayOneShot(typingAudio.clip, 0.04f);

                    // Delay before next sound allowed
                    soundTimer = Time.time + soundDelay;
                }
            }

            yield return new WaitForSeconds(typingSpeed);
        }

        finishedTyping = true;
    }

    void Update()
    {
        // Allow continue only after typing finishes
        if (finishedTyping && Input.anyKeyDown)
        {
            // Enable player
            if (player != null)
            {
                player.SetActive(true);
            }

            // Hide intro screen
            gameObject.SetActive(false);
        }
    }
}