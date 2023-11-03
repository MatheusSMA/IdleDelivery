using UnityEngine;

public class Buildsystem : MonoBehaviour
{
    [SerializeField] private GameObject _squadIndicator;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private Grid _grid;

    private void Update()
    {
        Vector3 mousePos = _inputManager.GetMousePos();
        Vector3Int gridPosition = _grid.WorldToCell(mousePos);
        _squadIndicator.transform.position = new Vector3(_grid.CellToWorld(gridPosition).x, .01f, _grid.CellToWorld(gridPosition).z);
    }

}