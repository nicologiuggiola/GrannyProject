using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadShooter : MonoBehaviour
{
    private GameManager gameManager;
    public int headLife = 3;
    public Transform castPoint;
    public GameObject fireball;
    public float speed;
    private float castCD = 2;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        castCD -= Time.deltaTime;

        if (castCD <= 0)
        {
            LaunchFireball();
            castCD = 2;
        }

        if (headLife <= 0)
        {
            gameManager.playerPoints = gameManager.playerPoints + 10;
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("PlayerProjectile"))
        {
            headLife--;
        }
    }

    private void LaunchFireball()
    {
        GameObject summonFireball = Instantiate(fireball, castPoint.position, castPoint.rotation);
        Vector3 direction = transform.right + Vector3.up;
        summonFireball.GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
    }
}
