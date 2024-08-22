using UnityEngine;

public class SpawnerControlPoint : MonoBehaviour
{
    [SerializeField] private ZombieSpawner _spawner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInChildren<Player>())
            _spawner.SpawnControlPoint();
    }
}