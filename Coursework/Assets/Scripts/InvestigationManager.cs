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
        "Correct.\n\nDaniel Hayes was murdered by a corrupt politician after discovering secret corruption files and illegal financial transactions.";
    }

    public void ChooseFisherman()
    {
        resultText.text =
        "Incorrect.\n\nNo evidence connects the fisherman to the crime scene.";
    }

    public void ChooseBeggar()
    {
        resultText.text =
        "Incorrect.\n\nThe evidence suggests the murder was connected to political corruption.";
    }
}