using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    [SerializeField] bool isLeft = false;
    [SerializeField] int angle = 40;
    [SerializeField] Rigidbody rigid;
    public float speed = 8f;
    public bool isHit = false;
    Vector3 currentVelocity;
    Vector3 dir = Vector3.zero;
    Vector3 originalPosition;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        originalPosition = transform.position;
        rigid = GetComponent<Rigidbody>();
        transform.GetChild(0).localRotation = Quaternion.Euler(0, angle, 0);
        dir = Vector3.right;
        isLeft = true;
    }

    void Update()
    {
        if (!GameManager.Instance.isPlaying) return;

        if (isHit)
        {
            transform.position -= new Vector3(0, 0, Time.deltaTime * speed);
        }
        else 
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 0, originalPosition.z), Time.deltaTime * 2f);
        }

        rigid.velocity = dir * speed;
        //if (Input.touchCount > 0)
        if (Input.GetMouseButtonDown(0))
        {
            if (GameManager.Instance.isPaused) return;
            //Touch touch = Input.GetTouch(0);
            //if (touch.phase == TouchPhase.Began) 
            //{
                if (isLeft)
                {
                    transform.GetChild(0).localRotation = Quaternion.Euler(0, -angle, 0);
                    dir = Vector3.left;
                    isLeft = false;
                }
                else
                {
                    transform.GetChild(0).localRotation = Quaternion.Euler(0, angle, 0);
                    dir = Vector3.right;
                    isLeft = true;
                }
                Debug.Log("Tap");
            //}
        }
        CheckOutOfScreen();
    }

    public void SetSpeed()
    {
        speed += 0.5f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null) 
        {
            if (other.name == "ScoredPoint")
            {
                ScoreManager.instance.GetScore();
                Destroy(other.gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            if (collision.collider.name == "Obstacle")
            {
                AudioManager.instance.Play_Hit();
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision != null)
        {
            if (collision.collider.name == "Obstacle")
            {
                isHit = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision != null)
        {
            if (collision.collider.name == "Obstacle")
            {
                isHit = false;
            }
        }
    }

    void CheckOutOfScreen() 
    {
        if (!GameManager.Instance.isPlaying) return;
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);

        if (viewportPos.y > 1f)
        {
            Debug.Log("GameObject is outside the top of the screen");
            GameManager.Instance.GameOver();
        }
        else
        {
            Debug.Log("GameObject is inside or at the top of the screen");
        }
    }
    public void SaveVelocity()
    {
        currentVelocity = rigid.velocity;
        rigid.velocity = Vector3.zero;
    }
    public IEnumerator SetCurrentVelocity()
    {
        yield return new WaitForSeconds(0.2f);
        rigid.velocity = currentVelocity;
    }
}
