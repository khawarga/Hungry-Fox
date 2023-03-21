using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    [SerializeField] private Transform tujuan;

    public Transform GetTujuan()
    {
        return tujuan;
    }
}
