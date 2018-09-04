using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    public static float damage = 1f;

    private Collider2D myCollider;
    private Rigidbody2D myRigidbody;

    [SerializeField]
    protected float force;

    [SerializeField]
    private float autoDestroyTime;

    protected int tipo = 0;

    // Use this for initialization
    protected void Start()
    {
        myCollider = GetComponent<Collider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();

        myRigidbody.AddForce(transform.up * force, ForceMode2D.Impulse);

        Invoke("AutoDestroy", autoDestroyTime);
    }

    private void AutoDestroy()
    {
        Destroy(gameObject);
    }

    private  void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Hazard>() != null && tipo ==1)
        {
            myCollider.isTrigger = true;
            Debug.Log("Tipo 1");
        }
        else {
            Destroy(gameObject);
        }
    }
}