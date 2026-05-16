// using UnityEngine;
// using TMPro;

// public class InvestigationManager : MonoBehaviour
// {
//     public TextMeshProUGUI resultText;

//     public void ChooseMurder()
//     {
//         resultText.text =
//             "Correct! The victim was murdered.";
//     }

//     public void ChooseSuicide()
//     {
//         resultText.text =
//             "Incorrect conclusion.";
//     }

//     public void ChoosePoison()
//     {
//         resultText.text =
//             "Incorrect conclusion.";
//     }
// }







using UnityEngine;
using TMPro;

public class InvestigationManager : MonoBehaviour
{
    public TextMeshProUGUI resultText;

    public void ChoosePolitician()
    {
        resultText.text =
        "Correct.\nThe Journalist was murdered after uncovering political corruption.";
    }

    public void ChooseFisherman()
    {
        resultText.text =
        "Incorrect.\nNo evidence connects the fisherman to the crime scene.";
    }

    public void ChooseBeggar()
    {
        resultText.text =
        "Incorrect.\nThe evidence suggests the murder was connected to political corruption.";
    }
}