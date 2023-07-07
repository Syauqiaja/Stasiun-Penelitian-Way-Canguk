using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDetector : MonoBehaviour
{
    [SerializeField] private PlayerControl playerControl;
    private bool touchingGrass = false;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Grass")){
            playerControl.detectedPlatform = SteppingPlatform.PLATFORM_GRASS;
            touchingGrass = true;
        }
        if(touchingGrass) return;

        if(other.CompareTag("Water")){
            playerControl.detectedPlatform = SteppingPlatform.PLATFORM_WATER;
        }else if(other.CompareTag("Terrain")){
            playerControl.detectedPlatform = SteppingPlatform.PLATFORM_DIRT;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Grass")){
            touchingGrass = false;
            playerControl.detectedPlatform = SteppingPlatform.PLATFORM_DIRT;
        }else if(other.CompareTag("Water")){
            playerControl.detectedPlatform = SteppingPlatform.PLATFORM_DIRT;
        }
    }
}
