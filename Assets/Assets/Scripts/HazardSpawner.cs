using UnityEngine;

public static class SpawnerExtensions
{
    public static Vector3 GetPointInVolume(this Collider2D collider)
    {
        Vector3 result = Vector3.zero;
        result = new Vector3(Random.Range(collider.bounds.min.x, collider.bounds.max.x), collider.transform.position.y, 0F);

        return result;
    }
}

[RequireComponent(typeof(Collider2D))]
public class HazardSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemiesTemplate;

    private Collider2D myCollider;

    [SerializeField]
    private float spawnFrequency = 1F;

    // Use this for initialization
    private void Start()
    {
        myCollider = GetComponent<Collider2D>();

        InvokeRepeating("SpawnEnemy", 0.2F, spawnFrequency);
    }

    private void SpawnEnemy()
    {
        int randomASpawn = Random.Range(0, enemiesTemplate.Length);
        if (enemiesTemplate == null)
        {
            CancelInvoke();
        }
        else
        {
            Instantiate(EnemyToSpawn(randomASpawn), myCollider.GetPointInVolume(), transform.rotation);
        }
    }

    private GameObject EnemyToSpawn(int _position) {
        GameObject enemy = null;

        switch (_position) {
            case 0:
                return enemiesTemplate[_position];
            case 1:
                return enemiesTemplate[_position];
            case 2:
                return enemiesTemplate[_position];
            default:
                break;
        }
        return enemy;
    }
}