using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetectorRaycast : MonoBehaviour
{
    [SerializeField] private InputAsset inputAsset;
    [SerializeField] private LayerMask layerMask;
    private void FixedUpdate() {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100f, layerMask)){
            inputAsset.objectDetected = hit.transform.gameObject;
        }else{
            inputAsset.objectDetected = null;
        }
    }
}
