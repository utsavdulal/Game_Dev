using UnityEngine;
using TMPro;

public class InvestigationManager : MonoBehaviour
{
    public TextMeshProUGUI resultText;

    public void ChooseMurder()
    {
        resultText.text =
            "Correct! The victim was murdered.";
    }

    public void ChooseSuicide()
    {
        resultText.text =
            "Incorrect conclusion.";
    }

    public void ChoosePoison()
    {
        resultText.text =
            "Incorrect conclusion.";
    }
}
