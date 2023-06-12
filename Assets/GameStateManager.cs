using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] GameObject GameOver;
    [SerializeField] GameObject Victory;
    [SerializeField] float deathDistanceFromEnemy;
    GameObject player;
    GameObject[] enemies;
    int points;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        points = enemies.Length;
    }
    private void Update()
    {
        Collider[] targets = Physics.OverlapSphere(player.transform.position, deathDistanceFromEnemy);
        foreach (var item in targets)
        {
            if (item.CompareTag("Finish"))
            {
                Win();
            }
            if (item.CompareTag("Enemy"))
            {
                Lost();
            }
        }
    }
    public void Win()
    {
        Victory.SetActive(true);
        UnlockCursor();
    }

    public void Lost()
    {
        GameOver.SetActive(true);
        UnlockCursor();

    }
    void UnlockCursor()
    {
        if (player)
        {
            player.GetComponent<PlayerLook>().enabled = false;
        }
        Cursor.lockState = CursorLockMode.None;
    }
    public void KilledAnEnemy()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] == null)
            {
                points--;
            }
        }
        if (points <= 0)
        {
            Win();
        }
    }

}
