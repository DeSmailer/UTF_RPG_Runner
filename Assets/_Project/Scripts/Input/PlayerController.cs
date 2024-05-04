using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
  [Header("Refarences")]
  [SerializeField] private CharacterController controller;
  [SerializeField] private Animator animator;
  [SerializeField] private InputReader inputReader;

  [Header("Settings")]
  [SerializeField] private float initSpeed = 5;
  [SerializeField] private float currentSpeed = 5;

  [Header("Track")]
  [SerializeField] private RunningTrack runningTrack;
  [SerializeField] private float trackChangeDuration = 1f;
  private bool canChangeTrack = true;

  private static readonly int Speed = Animator.StringToHash("Speed");

  private void Awake()
  {
    currentSpeed = initSpeed;
    transform.position = new Vector3(runningTrack.GetCurrentTrackXCoordinate(), transform.position.y, transform.position.z);
  }

  private void Update()
  {
    MoveForvard();
    HandleMovement();
    UpdadeteAnimator();
  }

  private void UpdadeteAnimator()
  {
    animator.SetFloat(Speed, currentSpeed);
  }

  private void HandleMovement()
  {
    if (!canChangeTrack)
    {
      return;
    }

    if (inputReader.Directions.x > 0)
    {
      canChangeTrack = false;
      transform.DOMoveX(runningTrack.GetRigtTrackXCoordinate(), trackChangeDuration).OnComplete(() => { canChangeTrack = true; });
    }
    else if (inputReader.Directions.x < 0)
    {
      canChangeTrack = false;
      transform.DOMoveX(runningTrack.GetLeftTrackXCoordinate(), trackChangeDuration).OnComplete(() => { canChangeTrack = true; });
    }
  }

  private void MoveForvard()
  {
    var adjustedMovement = Vector3.forward * currentSpeed * Time.deltaTime;
    controller.Move(adjustedMovement);
  }
}
