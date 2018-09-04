using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private float movementFactor;
    private bool canFire = true;
    private float coolDownTime = 0.5F;
    private Collider2D myCollider;

    [SerializeField]
    private Object[] bullets;

    protected bool InsideCamera(bool positive)
    {
        float direction = positive ? 1F : -1F;
        Vector3 cameraPoint = Camera.main.WorldToViewportPoint(
            new Vector3(
                myCollider.bounds.center.x + myCollider.bounds.extents.x * direction,
                0F,
                0F));
        return cameraPoint.x >= 0F && cameraPoint.x <= 1F;
    }

    private void Start()
    {
        myCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        movementFactor = Input.GetAxis("Horizontal");

        if (InsideCamera(movementFactor > 0F) && movementFactor != 0F)
        {
            transform.position += new Vector3(movementFactor * speed * Time.deltaTime, 0F, 0F);
        }

        if (bullets[0] != null && Input.GetAxis("Fire1") != 0 && canFire)
        {
            Instantiate(bullets[0], transform.position + (transform.up * 0.5F), Quaternion.identity);
            print("Fiyah!");
            StartCoroutine("FireCR");
        }
        if (bullets[1] != null && Input.GetAxis("Fire2") != 0 && canFire)
        {
            Instantiate(bullets[1], transform.position + (transform.up * 0.5F), Quaternion.identity);
            print("Fiyah!");
            StartCoroutine("FireCR");
        }
    }

    private void OnDestroy()
    {
        StopCoroutine("FireCR");
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Hazard>() != null)
        {
            Time.timeScale = 0F;
            print("Game Over");
        }
    }

    private IEnumerator FireCR()
    {
        canFire = false;
        yield return new WaitForSeconds(coolDownTime);
        canFire = true;
    }
}