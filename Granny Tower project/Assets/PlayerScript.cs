using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private GameManager gameManager;
    private CanvasControl canvasC;
    public GameObject umbrella;
    public GameObject storm;
    public Transform castPoint;


    private float speed = 4;
    private float jumpSpeed = 16000;

    private bool activateJump;
    private bool isJumping;
    private bool umbrellaUsed = false;
    public bool canBuy = false;

    private bool m_FacingRight;
    private Vector2 GameObRot;
    private float GameObRot2;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        canvasC = FindObjectOfType<CanvasControl>();

        activateJump = false;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && canBuy)
        {
            canvasC.SetMerchantPanel();
        }

        if (Input.GetKey(KeyCode.X) && !isGrounded() && gameManager.umbrellaNumber > 0)
        {
            umbrellaUsed = true;
            rb2d.drag = 12f;
            umbrella.SetActive(true);
        }
        else
        {
            rb2d.drag = 0f;
            umbrella.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            LaunchStorm();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            activateJump = true;
        }

        float x = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(x * speed, rb2d.velocity.y);

        GameObRot = new Vector2(x, rb2d.transform.position.y);
        GameObRot2 = GameObRot.x;

        if (GameObRot2 < 0 && !m_FacingRight)
        {
            Flip();
        }
        else if (GameObRot2 > 0 && m_FacingRight)
        {
            Flip();
        }

        if (isGrounded())
        {
            if (umbrellaUsed)
            {
                gameManager.RemoveUmbrella();
                umbrellaUsed = false;
            }
            
            isJumping = false;
        }

        if (gameManager.playerLifepoints <= 0)
        {
            gameManager.playerDead = true;
            Selfdestroy();
        }
    }

    private void FixedUpdate()
    {
        if (activateJump)
        {
            Vector2 forzaDiSalto = Vector2.up * jumpSpeed * Time.fixedDeltaTime;
            rb2d.AddForce(forzaDiSalto);
            activateJump = false;
            isJumping = true;
        }
    }

    private void Flip()
    {
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    private void LaunchStorm()
    {
       GameObject summonStorm = Instantiate(storm, castPoint.position, castPoint.rotation);
       Vector3 direction = transform.right + Vector3.up;
       summonStorm.GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Merchant"))
        {
            canBuy = true;
        }

        if (collision.CompareTag("GoldenUmbrella"))
        {
            if (gameManager.umbrellaNumber < 3)
            {
                gameManager.umbrellaNumber = 3;
            }
            else
            {
                //suono negativo
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Merchant"))
        {
            canBuy = false;
        }
    }

    private bool isGrounded()
    {
        return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;
    }

    public void Selfdestroy()
    {
        Destroy(gameObject);
    }
}
