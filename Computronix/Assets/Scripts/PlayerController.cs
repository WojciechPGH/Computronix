using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rgbd2d;
    SpriteRenderer sR;
    CameraMovement cameraMovementScript;
    [SerializeField]
    Transform lightPos;
    Vector3 lightOffset;
    [SerializeField]
    LifeController lifeController;
    float horSpeed = 1f;
    float vertSpeed = 0.33f;
    float hitTimer = 0f;
    float horizontalMovement = 0f;
    float verticalMovement = 0f;

    public static int life = 5;
    int ANIM_STATE_WALKING;
    const float MAX_Y = 0.3f;
    const float MIN_Y = -0.04f;
    const float MAX_WIDTH = 100f;

    void Start()
    {
        animator = GetComponent<Animator>();
        rgbd2d = GetComponent<Rigidbody2D>();
        sR = GetComponent<SpriteRenderer>();
        cameraMovementScript = Camera.main.GetComponent<CameraMovement>();
        ANIM_STATE_WALKING = Animator.StringToHash("isWalking");
        lightOffset = lightPos.localPosition;
        life = 5;
    }

    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * horSpeed;
        verticalMovement = Input.GetAxis("Vertical") * vertSpeed;
    }

    private void LateUpdate()
    {
        if (horizontalMovement < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        if (horizontalMovement > 0)
        {
            transform.localScale = Vector3.one;
        }
        if (hitTimer > 0f)
        {
            hitTimer -= Time.deltaTime;
            sR.color = new Color(1f, 0.5f, 0.5f, 1f);
        }
        else
        {
            hitTimer = 0f;
            sR.color = Color.white;
        }
    }

    void FixedUpdate()
    {

        Vector2 movVector = new Vector2(horizontalMovement, verticalMovement) * Time.deltaTime;
        if (movVector != Vector2.zero)
        {
            Vector2 prevPosition = rgbd2d.position;
            Vector2 finalPosition = prevPosition + movVector;


            finalPosition = IsInBounds(finalPosition, 0f, MAX_WIDTH, MAX_Y, MIN_Y);
            if (prevPosition != finalPosition)
            {
                animator.SetBool(ANIM_STATE_WALKING, true);
            }
            else
            {
                animator.SetBool(ANIM_STATE_WALKING, false);
            }

            rgbd2d.MovePosition(finalPosition);
        }
        else
        {
            animator.SetBool(ANIM_STATE_WALKING, false);
        }
    }

    public static Vector2 SnapToGrid(Vector2 vector, float gridSize)
    {
        return new Vector2(Mathf.Round(vector.x / gridSize) * gridSize, Mathf.Round(vector.y / gridSize) * gridSize);
    }

    private void FlipLight(bool flipX)
    {
        if (flipX)
        {
            lightPos.localPosition = new Vector3(-lightOffset.x, lightOffset.y, lightOffset.z);
        }
        else
        {
            lightPos.localPosition = new Vector3(lightOffset.x, lightOffset.y, lightOffset.z);
        }
    }

    private Vector2 IsInBounds(Vector2 pos, float left, float right, float top, float bottom)
    {
        if (pos.x < left)
            pos.x = left;
        else
        if (pos.x > right)
            pos.x = right;
        if (pos.y < bottom)
            pos.y = bottom;
        if (pos.y > top)
            pos.y = top;
        return pos;
    }

    public void Injure()
    {
        if (life > 1 && hitTimer < 0.001f)
        {
            hitTimer = 3f;
            life--;
            lifeController.RemoveLife();
        }
        else
        if(life <= 1)
        {
            RestartScene();
        }
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
