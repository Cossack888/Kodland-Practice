using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 3;
    Vector3 direction;
    float timer;
    GameStateManager manager;
    void Start()
    {
        manager = FindObjectOfType<GameStateManager>();
    }
    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 4)
        {
            Destroy(gameObject);
        }
        transform.position += speed * Time.deltaTime * direction;
        speed += 1f;

        Collider[] targets = Physics.OverlapSphere(transform.position, 1);
        foreach (var item in targets)
        {
            if (item.CompareTag("Enemy"))
            {
                if (manager)
                {
                    manager.KilledAnEnemy();
                }
                Destroy(item.gameObject);
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
