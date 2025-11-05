using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class collitioncamera : MonoBehaviour {
    private Transform _cam;

    [SerializeField] private LayerMask mask;
    private Vector3 originalCamPosition;

    private void Start() {
        _cam = Camera.main.transform;
        originalCamPosition = _cam.localPosition;
    }

    private void LateUpdate() {
        Vector3 dirToTarget = transform.position - _cam.position;
        _cam.rotation = Quaternion.LookRotation(dirToTarget, transform.up);
    }

    private void FixedUpdate() {
        Vector3 rayOrigin = transform.position + Vector3.up;
        Vector3 desiredCamPosition = transform.position + transform.rotation * originalCamPosition;

        Vector3 directionToCamera = desiredCamPosition - rayOrigin;

        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, directionToCamera.normalized, out hit, directionToCamera.magnitude, mask)) {
            _cam.position = hit.point;
        } else {
            _cam.position = desiredCamPosition;
        }
    }

}