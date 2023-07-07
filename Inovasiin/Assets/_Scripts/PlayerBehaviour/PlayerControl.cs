using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerControl : MonoBehaviour
{
    [SerializeField] private InputAsset inputAsset;
    [SerializeField] [Range(0f,1f)] private float moveSpeed=0.5f;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float gravityMultiplier = 1f;
    [SerializeField] private float jumpPower = 1f;
    [Header("Audio System")]
    [SerializeField] private AudioSource audioSource; 
    [SerializeField] private List<AudioClip> dirtFootstepClips;
    [SerializeField] private List<AudioClip> grassFootstepClips;
    [SerializeField] private List<AudioClip> waterFootstepClips;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private float footstepInterval = 0.8f;
    private float _currentFootstep = 0f;
    private float _footstepInterval = 0;

    private float _gravity {get {return gravityMultiplier * -9.8f;}}

    private CharacterController characterController;
    private float cameraPith;
    private float y_velocity = 0;

    [HideInInspector] public SteppingPlatform detectedPlatform = SteppingPlatform.PLATFORM_DIRT;

    private void Awake() {
        characterController = GetComponent<CharacterController>();
        inputAsset.onJump += Jump;
        _footstepInterval = footstepInterval;
    }

    private void OnDestroy() {
        inputAsset.onJump -= Jump;
    }

    private void Jump(){
        if(characterController.isGrounded){
            y_velocity += jumpPower;
            audioSource.PlayOneShot(jumpClip);
        }
    }
    private void Update() {
        if(inputAsset.isLooking){
            LookAround();
        }
        Vector3 direction = inputAsset.GetMoveAxis();
        if(direction.magnitude > 0.1f){
            _footstepInterval = footstepInterval / direction.magnitude;
            if(_currentFootstep >= _footstepInterval){
                _currentFootstep = 0f;
                PlayFootStep(detectedPlatform);
            }
        }
        _currentFootstep += Time.deltaTime;

        if(characterController.isGrounded && y_velocity <= 0.0f){
            y_velocity = -1f;
        }else{
            y_velocity +=  _gravity * Time.deltaTime;
            direction.y = y_velocity;
        }
        if(direction.magnitude > 0){
            characterController.Move(transform.TransformDirection(direction) * moveSpeed);
        }
    }
    void LookAround(){
        cameraPith = Mathf.Clamp(cameraPith - inputAsset.lookInput.y, -90F, 90f);
        cameraTransform.localRotation = Quaternion.Euler(cameraPith, 0,0);

        transform.Rotate(transform.up, inputAsset.lookInput.x);
    }
    void PlayFootStep(SteppingPlatform platform){
        switch(platform){
            case SteppingPlatform.PLATFORM_DIRT:
                audioSource.PlayOneShot(dirtFootstepClips[Random.Range(0,dirtFootstepClips.Count)]);
                break;
            case SteppingPlatform.PLATFORM_WATER:
                audioSource.PlayOneShot(waterFootstepClips[Random.Range(0,waterFootstepClips.Count)]);
                break;
            case SteppingPlatform.PLATFORM_GRASS:
                audioSource.PlayOneShot(grassFootstepClips[Random.Range(0,grassFootstepClips.Count)]);
                break;
            default:
                break;
        }
    }
}

public enum SteppingPlatform{
    PLATFORM_DIRT = 0, PLATFORM_WATER = 1, PLATFORM_GRASS = 2
}