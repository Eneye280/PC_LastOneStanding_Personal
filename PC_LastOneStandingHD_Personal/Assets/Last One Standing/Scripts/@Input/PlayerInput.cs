using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private InputPlayerActions controls;

    [SerializeField] internal ManagerPlayer managerPlayer;

    private void Awake()
    {
        controls = new InputPlayerActions();

        controls.Player.Movement.performed += ctx => managerPlayer.scriptablePlayer.directionPlayer = ctx.ReadValue<Vector2>();
    }

    private void OnDisable() => controls.Disable();
    private void OnEnable() => controls.Enable();
}
