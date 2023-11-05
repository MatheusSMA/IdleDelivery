using UnityEngine;

public class TurretManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);

        if (other.tag == "CannotPlace")
            Buildsystem.Instance.SetMaterial(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "CannotPlace")
            Buildsystem.Instance.SetMaterial(true);
    }


}