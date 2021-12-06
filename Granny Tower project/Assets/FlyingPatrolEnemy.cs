using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPatrolEnemy : MonoBehaviour
{
    private GameManager gameManager;
    private int life = 3;
    public Transform detector;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D rayFrontal = Physics2D.Raycast(detector.position, Vector2.left, 0.1f);

        if (rayFrontal.collider == true && !rayFrontal.collider.CompareTag("Player") && !rayFrontal.collider.CompareTag("PlayerProjectile"))
        {
            transform.Rotate(new Vector2(0, 180));
        }

        transform.Translate(Vector2.left * 3 * Time.deltaTime);

        if (life <= 0)
        {
            gameManager.playerPoints = gameManager.playerPoints + 10;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            gameManager.ReduceLifepoints(1);
        }

        if (collision.collider.CompareTag("PlayerProjectile"))
        {
            life--;
        }
    }

}
