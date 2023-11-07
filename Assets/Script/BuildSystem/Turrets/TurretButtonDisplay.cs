using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class TurretButtonDisplay : MonoBehaviour
{
    [SerializeField] private TurretSO turretSO;
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
        buttonText.text = turretSO.NameTorret;
    }

}