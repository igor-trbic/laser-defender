using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceMe : MonoBehaviour
{

    public GameObject board;
 
    public float MoveSpeed = 40.0F;
 
    private bool turn = false;
 
    private Rigidbody2D mRigidbody2D;
 
    private float mMovementX = 0;
    private float mMovementY = 0;


    void Awake()
    {
        mRigidbody2D = this.GetComponent<Rigidbody2D>();
 
        mMovementX = UnityEngine.Random.RandomRange(10F, 20F);
        mMovementY = UnityEngine.Random.RandomRange(10F, 20F);
 
        mRigidbody2D.velocity = new Vector2(mMovementX, mMovementY);
    }


    void OnTriggerExit2D(Collider2D other)
    {
        Vector3 normal = (board.transform.position - transform.position).normalized;
       
        mRigidbody2D.velocity = Vector2.Reflect(mRigidbody2D.velocity, normal);
        Debug.Log("HELLO!");
    }
}
