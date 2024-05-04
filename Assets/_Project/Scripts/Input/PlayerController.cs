using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  [Header("Refarences")]
  [SerializeField] private CharacterController controller;
  [SerializeField] private Animator animator;
  [SerializeField] private InputReader inputReader;

  [Header("Settings")]
  [SerializeField] private float initSpeed = 5;
  [SerializeField] private float smoothTime = 0.1f;

  [SerializeField] private float currentSpeed = 5;

  private static readonly int Speed = Animator.StringToHash("Speed");

  private void Awake()
  {
    currentSpeed = initSpeed;
  }

  private void Update()
  {
    HandleMovement();
    UpdadeteAnimator();
  }

  private void UpdadeteAnimator()
  {
    animator.SetFloat(Speed, currentSpeed);
  }

  private void HandleMovement()
  {
    var movementDirections = new Vector3(inputReader.Directions.x, 0, inputReader.Directions.z).normalized;

    var adjustedMovement = Vector3.forward * currentSpeed * Time.deltaTime;
    controller.Move(adjustedMovement);
  }
}
