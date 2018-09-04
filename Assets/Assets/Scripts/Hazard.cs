using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Hazard : MonoBehaviour
{
    private Collider2D myCollider;
    private object myRigidbody;

    [SerializeField]
    private float resistance = 1F;
    private float spinTime = 1F;

    protected int damage = 1;

    public int Damage
    {
        get
        {
            return damage;
        }

        set
        {
            damage = value;
        }
    }

    // Use this for initialization
    protected void Start()
    {
        myCollider = GetComponent<Collider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            //TODO: Make this to reduce damage using Bullet.damage attribute
            resistance -= Bullet.damage;

            if (resistance == 0)
            {
                OnHazardDestroyed();
            }
        }
    }

    protected void OnHazardDestroyed()
    {
        //TODO: GameObject should spin for 'spinTime' secs. then disappear
        StartCoroutine(SpinAndDie());
    }

    IEnumerator SpinAndDie() {
        transform.rotation *= new Quaternion(3*Time.deltaTime,0,0,0);
        yield return new WaitForSeconds(spinTime);
        Destroy(gameObject);
    }

}