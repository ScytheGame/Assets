using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class LifetimeController : MonoBehaviour
{
    [SerializeField] float Lifetime;
    void Start()
    {
        Destroy(gameObject,  Lifetime);
    }
}
