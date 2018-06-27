using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private float Z = 4.25f;
    [SerializeField]
    private float Y = 2.25f;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }


    private void LateUpdate()
    {
        this.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + Y, Player.transform.position.z- Z);
        this.transform.LookAt(Player.transform);
    }
}
