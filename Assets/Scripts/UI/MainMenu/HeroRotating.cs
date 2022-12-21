using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroRotating : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;


    private void Update()
    {
        transform.Rotate(Vector3.up, _rotateSpeed * Time.deltaTime);
    }
}
