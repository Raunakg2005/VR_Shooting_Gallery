using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRGun : MonoBehaviour
{
    public Transform barrel; 
    public TargetSpawner spawner; 
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;

    void Awake()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        grabInteractable.activated.AddListener(FireGun);
    }

    void OnDestroy() { grabInteractable.activated.RemoveListener(FireGun); }

    void FireGun(ActivateEventArgs args)
    {
        RaycastHit hit;
        if (Physics.Raycast(barrel.position, barrel.forward, out hit, 100f))
        {
            if (hit.collider.CompareTag("Target"))
            {
                Destroy(hit.collider.gameObject); 
                spawner.SpawnNewTarget();         
            }
        }
    }
}