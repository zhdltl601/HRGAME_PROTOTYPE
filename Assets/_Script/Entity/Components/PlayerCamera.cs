using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : EntityComponentBase<Player>
{
    [SerializeField] private Transform cam;
    private readonly List<Transform> listLayer = new();
    public Transform GetCameraTransform
    {
        get => cam;
    }
    public void Init()
    {

    }
    public void SetCameraLayer(int layerIndex, float xRotation, float yRotation, float zRotation)
    {
        Vector3 value = new(xRotation, yRotation, zRotation);
        listLayer[layerIndex].position = value;
    }
    public void SetCameraLayer(int layerIndex, Vector3 value)
    {
        listLayer[layerIndex].position = value;
    }
    public void SetCameraRotation(float xRotation, float yRotation, float zRotation = 0)
    {
        cam.rotation = Quaternion.Euler(xRotation, yRotation, zRotation);
    }
}
