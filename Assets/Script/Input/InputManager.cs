using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] LayerMask _placementLayerMask;
    private Vector3 _lastPosition;

    public Vector3 GetMousePos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = _mainCamera.nearClipPlane;
        Ray ray = _mainCamera.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, _placementLayerMask))
        {
            _lastPosition = hit.point;
        }

        return _lastPosition;
    }
}