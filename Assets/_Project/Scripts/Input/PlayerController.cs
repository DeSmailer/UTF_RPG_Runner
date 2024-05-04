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
  [SerializeField] private float speed = 5;
  [SerializeField] private float smoothTime = 0.1f;

  [SerializeField] private float currentSpeed = 5;

  private void Update()
  {
    HandleMovement();
  }

  private void HandleMovement()
  {
    var adjustedMovement = Vector3.right * currentSpeed * Time.deltaTime;
    controller.Move(adjustedMovement);
  }
}
