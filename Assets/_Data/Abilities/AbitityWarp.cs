using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbitityWarp : ActiveAbility
{
    [Header("Warp")]
    [SerializeField] protected Spawner spawner;
    [SerializeField] protected bool isWarping = false;
    [SerializeField] protected bool keyDirection = false;
    [SerializeField] protected float warpSpeed = 1f;
    [SerializeField] protected float warpDistance = 5f;
    protected Vector3 targetPosition; 

    AudioManager audioManager;

    protected override void Awake()
    {
        base.Awake();
        audioManager = GameObject.FindWithTag("Audio").GetComponent<AudioManager>();
    }

    protected override void Update()
    {
        base.Update();
        this.CheckWarpInput();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Warping();
    }

    protected virtual void CheckWarpInput()
    {
        if (keyDirection && isReady)
        {
            Vector3 directionToMouse = (InputManager.Instance.MouseWorldPos - transform.position).normalized;

            this.SetWarpTarget(directionToMouse);
            this.isWarping = true;
        }
    }

    protected virtual void SetWarpTarget(Vector3 directionToMouse)
    {
        this.targetPosition = transform.position + directionToMouse * warpDistance;
        this.targetPosition.z = 0f;
    }

    protected virtual void Warping()
    {
        if (!isWarping) return;

        audioManager.PlaySFX(audioManager.warpClip);
        Invoke(nameof(this.WarpFinish), warpSpeed);
    }

    protected virtual void WarpFinish()
    {
        this.MoveObj();
        this.isWarping = false;
        this.Active();
    }

    protected virtual void MoveObj()
    {
        Transform obj = this.abilities.AbilityObjectCtrl.transform;
        SpawnWarpEffect(obj.position);
        obj.position = targetPosition; 
        
    }

    protected virtual void SpawnWarpEffect(Vector3 position)
    {
        Quaternion fxRot = Quaternion.identity;
        Transform fx = FXSpawner.Instance.Spawn(FXSpawner.warp, position, fxRot);
        fx.gameObject.SetActive(true);
    }
}
