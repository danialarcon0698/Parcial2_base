using UnityEngine;
using System.Collections;

public class Shelter : MonoBehaviour
{
    [SerializeField]
    private int maxResistance = 5;

    private float regenTime = 3f;

    private int contador = 0;

    public int MaxResistance
    {
        get
        {
            return maxResistance;
        }
        protected set
        {
            maxResistance = value;
        }
    }

    public void Damage(int damage)
    {
        maxResistance -= damage;

        if (maxResistance < 0) {
            Destroy(gameObject);
        }
    }

    IEnumerator Regen() {
        while (maxResistance < 5) {
            yield return new WaitForSeconds(regenTime);
            maxResistance++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Hazard>() != null) {
            Hazard hazard = collision.gameObject.GetComponent<Hazard>();
            Damage(hazard.Damage);
            contador++;
            StartCoroutine(Regen());
            if (contador == 2) {
                StopCoroutine(Regen());
                contador = 0;
            }
            Destroy(collision.gameObject);

        }
    }
}