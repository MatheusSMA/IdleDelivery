using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Buildsystem _buildSystem;
    [SerializeField] private Camera _mainCamera;
    private Vector3 _lastPosition;


    public Vector3 GetMousePos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = _mainCamera.nearClipPlane;
        Ray ray = _mainCamera.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out RaycastHit hit, 50))
        {
            _lastPosition = hit.point;
        }

        return _lastPosition;
    }




}