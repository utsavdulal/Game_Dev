using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject investigationPanel;

    public static GameManager Instance;

    public int totalEvidence = 6;
    private int foundEvidence = 0;

    public TextMeshProUGUI evidenceText;

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
            investigationPanel.SetActive(true);

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
