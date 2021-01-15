using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankData : MonoBehaviour
{
    [Header("Components")]
    public TankMover mover;
    public TankShooter shooter;
    public TankHealth health;
    public TankShields shield;
    public TankPowerUp powerUps;
    public AudioSource audioSource;

    [Header("Parts")]
    public GameObject gun;

    [Header("Stats")]
    public float damage;

    [Header("Audio Clips")]
    public AudioClip startRotateGun;
    public AudioClip rotateGun;
    public AudioClip stopRotateGun;


}
