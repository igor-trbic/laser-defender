using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spinner : MonoBehaviour
{

    [SerializeField] float spinSpeed = 30f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, spinSpeed * Time.deltaTime);
    }
}
