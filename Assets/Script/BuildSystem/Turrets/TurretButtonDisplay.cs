using UnityEngine;
using TMPro;

public class TurretButtonDisplay : MonoBehaviour
{
    [SerializeField] private Turret turret;
    private TextMeshProUGUI buttonText;

    private void OnEnable()
    {
        GetReferences();
        UpdateButton();
    }
    private void GetReferences()
    {
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void UpdateButton()
    {
        buttonText.text = turret.NameTorret;
    }

}