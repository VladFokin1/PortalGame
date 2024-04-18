using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform playerCamera;
    [SerializeField] Transform portal;
    [SerializeField] Transform anotherPortal;

    // Update is called once per frame
    void Update()
    {
        Vector3 playerOffsetFromPortal = playerCamera.position - anotherPortal.position;
        transform.position = portal.position + playerOffsetFromPortal;
        
        float angularDiffBetweenPortals = Quaternion.Angle(portal.rotation, anotherPortal.rotation);

        Quaternion portalRotationalDiff = Quaternion.AngleAxis(angularDiffBetweenPortals, Vector3.up);
        Vector3 newCameraDir = portalRotationalDiff * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDir, Vector3.up);
    }
}
