using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCamera : MonoBehaviour
{
    public Transform playerTrans;
    private void LateUpdate() {
        transform.position = playerTrans.TransformPoint(new Vector3(0, 100f,0));
    }
}
