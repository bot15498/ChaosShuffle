using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool useArrowKeys = false;
    public bool canControlMove = true;
    public bool mirrored = false;
    public bool icyFloor = false;
    public bool snakeMovement = false;
    public float speed;
    public float icySpeed = 3.5f;
    public Transform CursorDirection;
    public SpriteRenderer WeaponSprite;
    bool facingRight;
    Rigidbody2D playerRigidbody;
    private SpriteRenderer sr;
    private float lastValidH = 1f;
    private float lastValidV = 1f;
    private bool isKnockback = false;
    private Vector2 currPos;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        facingRight = true;
        currPos = transform.GetChild(0).GetChild(0).GetChild(0).localPosition;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isKnockback)
        {
            Move();
        }
        WeaponFlipping();
    }


    void Move()
    {
        float h = 0f;
        float v = 0f;
        if (!useArrowKeys)
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");
            if (h != 0 || v != 0)
            {
                anim.SetBool("IsWalking", true);
            }else if (h == 0 && v == 0)
            {
                anim.SetBool("IsWalking", false);
            }
        }
        else
        {
            h = Input.GetAxisRaw("Horizontal2");
            v = Input.GetAxisRaw("Vertical2");
            if (h != 0 || v != 0)
            {
                anim.SetBool("IsWalking", true);
            }
            else if (h == 0 && v == 0)
            {
                anim.SetBool("IsWalking", false);
            }
        }

        if (mirrored)
        {
            h = h * -1;
            v = v * -1;
        }

        if (snakeMovement && Mathf.Abs(h) < 0.01f && Mathf.Abs(v) < 0.01f)
        {
            h = lastValidH;
            v = lastValidV;
        }
        if (canControlMove)
        {
            if (icyFloor)
            {
                playerRigidbody.drag = 0.5f;
                Vector2 PlayerMove = new Vector2(h, v);
                playerRigidbody.AddForce(PlayerMove.normalized * icySpeed);
            }
            else
            {
                playerRigidbody.velocity = new Vector2(h * speed, v * speed);
            }
        }
        lastValidH = playerRigidbody.velocity.x / speed;
        lastValidV = playerRigidbody.velocity.y / speed;
    }

    public void StopMoving()
    {
        playerRigidbody.velocity = Vector2.zero;
        playerRigidbody.angularVelocity = 0f;
    }

    void WeaponFlipping()
    {
        //current mouse position
        var mousePos = Input.mousePosition;
        mousePos.z = 10;
        var delta = Camera.main.ScreenToWorldPoint(mousePos) - transform.position;

        //CharacterFlipping
        if (delta.x >= 0 && !facingRight)
        { // mouse is on right side of player

            Vector3 newScale = transform.localScale;
            newScale.x = 1;
            transform.localScale = newScale;
            CursorDirection.transform.localScale = newScale;
            // sr.flipX = false;
            WeaponSprite.flipY = false;
            facingRight = true;

            transform.GetChild(0).GetChild(0).GetChild(0).localPosition = new Vector2(currPos.x, currPos.y);

        }
        else if (delta.x < 0 && facingRight)
        { // mouse is on left side
            Vector3 newScale = transform.localScale;
            newScale.x = -1;
            transform.localScale = newScale;
            CursorDirection.transform.localScale = newScale;
            //sr.flipX = true;
            WeaponSprite.flipY = true;

            //fix shooting at pistol hole
            transform.GetChild(0).GetChild(0).GetChild(0).localPosition = new Vector2(currPos.x, -currPos.y);

            facingRight = false;
        }
    }

    public void AddKnockback(Vector2 direction, float force, float duration)
    {
        isKnockback = true;
        StopMoving();
        playerRigidbody.AddForce(direction.normalized * force);
        StartCoroutine(StopMoving(duration));
    }

    private IEnumerator StopMoving(float duration)
    {
        yield return new WaitForSecondsRealtime(duration);
        isKnockback = false;
        lastValidH = playerRigidbody.velocity.x / speed;
        lastValidV = playerRigidbody.velocity.y / speed;
        if (!canControlMove)
        {
            StopMoving();
        }
        yield return null;
    }


}
