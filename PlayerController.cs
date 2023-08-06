using UnityEngine;
using static Unity.VisualScripting.Member;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float sprintSpeed = 10f;
    public float mouseSensitivity = 3f;
    public Camera playerCamera;
    public CharacterController characterController;
    private float verticalRotation = 0f;
    private float upDownRange = 60f;
    private bool isSprinting = false;
    public float gravity = 9.81f; // Ускорение свободного падения
    private Vector3 fallVelocity = Vector3.zero;
    public AudioSource _source;
    public AudioSource _source1;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Проверка на зажатие клавиши Shift для ускорения
        isSprinting = Input.GetKey(KeyCode.LeftShift);

        // Поворот игрока
        float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, rotLeftRight, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        // Передвижение игрока
        float moveSpeed = isSprinting ? sprintSpeed : walkSpeed;
        float forwardSpeed = Input.GetAxis("Vertical") * moveSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * moveSpeed;

        Vector3 speed = new Vector3(sideSpeed, 0, forwardSpeed);
        speed = transform.rotation * speed;
        characterController.SimpleMove(speed);

        if (!characterController.isGrounded) // Проверяем, находится ли персонаж на земле
        {
            // Увеличиваем скорость падения с учетом времени
            fallVelocity.y -= gravity * Time.deltaTime;
            // Применяем падение к контроллеру персонажа
            characterController.Move(fallVelocity * Time.deltaTime);
        }
        else
        {
            // Если персонаж на земле, сбрасываем скорость падения
            fallVelocity = Vector3.zero;
            if (forwardSpeed > 5f || sideSpeed > 5f)
            {
                if (!_source.isPlaying)
                {
                    _source.pitch = 1f;
                    _source.Play();
                }
                if (isSprinting)
                {
                    _source.pitch = 1.5f;
                }
            }

        }

    }
}