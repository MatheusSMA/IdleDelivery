using UnityEngine;


[CreateAssetMenu(fileName = "Turret", menuName = "IdleDelivery/Turret", order = 0)]
public class TurretSO : ScriptableObject
{
    [SerializeField] private string _nameTorret;
    [SerializeField] private int _power;
    [SerializeField] private GameObject prefab;

    public string NameTorret { get => _nameTorret; set => _nameTorret = value; }
    public int Power { get => _power; set => _power = value; }
    public GameObject Prefab { get => prefab; set => prefab = value; }

}
