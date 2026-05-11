using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public PlayerInteraction playerInteraction;


    public GameObject investigationPanel;

    public static GameManager Instance;

    public int totalEvidence = 6;
    private int foundEvidence = 0;

    public TextMeshProUGUI evidenceText;

    public GameObject endingBackground;

    public GameObject interactPrompt;
    public GameObject cluePanel;
    
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateUI();
    }

    public void AddEvidence()
    {
        foundEvidence++;

        UpdateUI();

        if(foundEvidence >= totalEvidence)
        
        {

            endingBackground.SetActive(true);

            investigationPanel.SetActive(true);

            playerInteraction.enabled = false;

            interactPrompt.SetActive(false);
            cluePanel.SetActive(false);


            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Debug.Log("All Evidence Found");
        }
    }

    void UpdateUI()
    {
        evidenceText.text =
            "Evidence Found: " +
            foundEvidence +
            "/" +
            totalEvidence;
    }
}
