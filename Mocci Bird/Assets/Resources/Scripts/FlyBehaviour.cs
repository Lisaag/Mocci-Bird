using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBehaviour : MonoBehaviour
{
    [SerializeField] private float fallingSpeed = 1.2f;
    [SerializeField] private float jumpingSpeed = 1.2f;
    [SerializeField] private float jumpDistance = 2.0f;

    private Touch touch;
    private Animator animator = null;

    private const float minFallSpeed = 3.0f;
    private const float maxFallSpeed = 13.0f;
    private float currentFallSpeed = minFallSpeed;

    float fallStartTime = 0f;

    private float startY = 0.0f;

    private float startJumpPos = 0.0f;
    bool isJumping = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        startY = Camera.main.WorldToScreenPoint(transform.localPosition).y;
        Debug.Log(startY);
    }

    private void Start()
    {
        fallStartTime = Time.time;
    }

    void FixedUpdate()
    {
        if (!GameManager.isGameStarted) return;
        CheckTap();
        if (!isJumping)
        {
            MoveDown();
        }
        else
        {
            MoveUp();
        }
    }

    private void CheckTap()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                animator.Play("MocciFly", 0, 0);
                //animator.SetTrigger("tap");
                Debug.Log("TAp!");
                startJumpPos = transform.localPosition.y;
                isJumping = true;
                fallStartTime = Time.time;
            }
        }
    }


    private void MoveDown()
    {
        currentFallSpeed = Mathf.Clamp(Mathf.Pow(currentFallSpeed, (Time.time - fallStartTime) * fallingSpeed), minFallSpeed, maxFallSpeed);

        float fallDistance = currentFallSpeed * Time.deltaTime;
        transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - fallDistance);

        float t = (Time.time - fallStartTime) / 0.5f;
        transform.localEulerAngles = new Vector3(0, 0, Mathf.SmoothStep(0.0f, -65.0f, t));

        if (Camera.main.WorldToScreenPoint(transform.localPosition).y < 0f)
        {
            currentFallSpeed = minFallSpeed;
            transform.localPosition = new Vector2(transform.localPosition.x, 0f);
            transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            fallStartTime = Time.time;
        }
    }

    private void MoveUp()
    {
        float t = (Time.time - fallStartTime) / 0.5f;
        transform.localEulerAngles = new Vector3(0, 0, Mathf.SmoothStep(-65.0f, 0.0f, t));

        Vector2 targetPosition = new Vector2(transform.localPosition.x, startJumpPos + jumpDistance);

        //Debug.Log($"Current Y = {transform.localPosition.y},    Target y = {targetPosition.y}");

        transform.localPosition = Vector2.MoveTowards(transform.localPosition, targetPosition, jumpingSpeed * Time.deltaTime);

        if (transform.localEulerAngles.z <= 0.2f)
        {
            if(transform.localPosition.y <= targetPosition.y + 0.01f)
            {
                isJumping = false;
                fallStartTime = Time.time;
                currentFallSpeed = minFallSpeed;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SkewerTop"))
        {
            GameManager.GameOver(other.transform.parent.GetComponent<SkewerBehaviour>().skewerIndex, DeathCause.Top, GetComponent<ColorRandomizer>().currentColor);
        }
        else if (other.gameObject.CompareTag("SkewerBottom"))
        {
            GameManager.GameOver(other.transform.parent.GetComponent<SkewerBehaviour>().skewerIndex, DeathCause.Bottom, GetComponent<ColorRandomizer>().currentColor);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SkewerGap"))
        {
            GameManager.Score++;
            UIManager.instance.UpdateScore();
        }
    }
}
