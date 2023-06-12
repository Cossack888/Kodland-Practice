using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform rifleStart;
    [SerializeField] float speed, abilityDistanceFromEnemy;
    CharacterController controller;
    GameStateManager manager;
    Vector3 move;
    float yVelocity = 0;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        manager = FindObjectOfType<GameStateManager>();
    }
    void Update()
    {
        move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        if (controller.isGrounded)
        {
            yVelocity = 0;
        }
        yVelocity -= Mathf.Abs(Physics.gravity.y * Time.deltaTime);
        move.y = yVelocity;
        if (Input.GetMouseButtonDown(0))
        {
            GameObject buf = Instantiate(bullet);
            buf.transform.position = rifleStart.position;
            buf.GetComponent<Bullet>().SetDirection(transform.forward);
            buf.transform.rotation = transform.rotation;
        }
        if (Input.GetMouseButtonDown(1))
        {
            Collider[] tar = Physics.OverlapSphere(transform.position,abilityDistanceFromEnemy);
            foreach (var item in tar)
            {
                if (item.CompareTag("Enemy"))
                {
                    Destroy(item.gameObject);
                    manager.KilledAnEnemy();
                }
            }
        }
    }
    void FixedUpdate()
    {
        controller.Move(speed * Time.fixedDeltaTime * move);
    }
}
