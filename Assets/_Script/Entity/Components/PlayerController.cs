using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public partial class PlayerController
{
    [Serializable]
    private struct ControllerSettings
    {
        public SlopeSettings slopeSettings;
        public SnapSettings snapSettings;

        [Serializable]
        public struct SlopeSettings
        {
            public float groundCheckRadius;
            public float groundCheckDistance;
            public Vector3 groundCheckOffset;

            public float directionCheckDistance;

            public float maxAngle;
        }
        [Serializable]
        public struct SnapSettings
        {
            public float maxHeight;
            public float snapSpeed;
        }
    }
}
public partial class PlayerController : EntityComponentBase<Player>
{
    [Header("Controller Settings")]
    [SerializeField] private ControllerSettings controller;
    private ControllerSettings.SlopeSettings GetSlopeSetting => controller.slopeSettings;
    private ControllerSettings.SnapSettings GetSnapSetting => controller.snapSettings;


    [Header("Speed Settings")]
    [SerializeField] private float speedWalk;
    [SerializeField] private float speedRun;
    [SerializeField] private float speedCrouch;

    [Header("Gravitiy Settings")]
    [SerializeField] private float gravitiy = 9.81f;
    [SerializeField] private float gravitiyOnGround = 1f;

    private float _yVal;

    #region Components
    private Rigidbody rigidBody;
    #endregion

    private void Awake()
    {
        //init
        rigidBody = GetComponent<Rigidbody>();
    }
    ///missing features
    ///1. Slope Movement / Slope Limit
    ///2. Stair Up & Down snap / limit
    ///3. collide and slide
    ///4. gravitiy?
    public void Move(Vector3 direction, float speed = 1)
    {
        speed = speedRun;

        bool isOnGround = IsOnGround(out RaycastHit hit);
        
        if (isOnGround)
        {
            _yVal = gravitiyOnGround;

        }
        else _yVal += gravitiy * Time.deltaTime;
        void ClampYVal()
        {
            //value doesnt include direction. no negative value
            int maxFallGravitiyValue = default;
            _yVal = Mathf.Clamp(_yVal, 0, maxFallGravitiyValue);
        }
        //ClampYVal();

        Vector3 gravityVector = Vector3.down;
        gravityVector *= _yVal;

        Vector3 result = speed * direction;
        Debug.DrawRay(transform.position + Vector3.up, result, Color.red);

        Vector3 r = result;

        result.y += gravityVector.y;

        rigidBody.velocity = result;

        Debug.DrawRay(transform.position + Vector3.up + r, result - r, Color.blue);
        Debug.DrawRay(transform.position + Vector3.up, result, Color.yellow);
        //PlayerUIDEBUG.Instance.list[0].text = IsOnGround().ToString();
        //PlayerUIDEBUG.Instance.list[1].text = _yVal.ToString();
    }
    private bool IsOnGround()
    {
        LayerMask lmPlayer = Player.Cache_LayerMask.lmPLayer;
        var SlopeSetting = GetSlopeSetting;
        Ray ray = new Ray(transform.position + SlopeSetting.groundCheckOffset, Vector3.down);
        return Physics.SphereCast(ray, SlopeSetting.groundCheckRadius, SlopeSetting.groundCheckDistance, lmPlayer);
    }
    private bool IsOnGround(out RaycastHit hit)
    {
        LayerMask lmPlayer = Player.Cache_LayerMask.lmPLayer;
        var SlopeSetting = GetSlopeSetting;
        Ray ray = new Ray(transform.position + SlopeSetting.groundCheckOffset, Vector3.down);
        return Physics.SphereCast(ray, SlopeSetting.groundCheckRadius, out hit, SlopeSetting.groundCheckDistance, lmPlayer);
    }
    private bool IsSlope(Vector3 hitNormal)
    {
        return default;//hitNormal != Vector3.up;
    }
    private void OnDrawGizmos()
    {
        var slope = GetSlopeSetting;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + slope.groundCheckOffset, slope.groundCheckRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + Vector3.down * slope.groundCheckDistance + slope.groundCheckOffset, slope.groundCheckRadius);
    }
}
