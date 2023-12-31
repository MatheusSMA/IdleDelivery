using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class Buildsystem : MonoBehaviour
{
    #region Variables
    private TurretPlacement _currentTurret;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private Grid _grid;
    private Material _normalMaterial;
    private bool _canPlace;

    public bool CanPlace { get => _canPlace; set => _canPlace = value; }
    #endregion


    public void BeginSelect(TurretSO turretSO)
    {
        TurretPlacement newTurret = Instantiate(turretSO.Prefab, transform).GetComponent<TurretPlacement>();
        _currentTurret = newTurret;
        _normalMaterial = _currentTurret.GetComponent<MeshRenderer>().material;
    }

    public void DragSelect()
    {
        Vector3 mousePos = _inputManager.GetMousePos();
        Vector3Int gridPosition = _grid.WorldToCell(mousePos);
        _currentTurret.transform.position = new Vector3(_grid.CellToWorld(gridPosition).x, _currentTurret.transform.localScale.y / 2, _grid.CellToWorld(gridPosition).z);
    }

    public void EndSelect()
    {
        if (_canPlace)
        {
            _currentTurret.GetComponent<MeshRenderer>().material = _normalMaterial;
            _currentTurret.Placed = true;
        }
        else
        {
            _currentTurret.Placed = false;
            Destroy(_currentTurret.gameObject);
        }
    }
}