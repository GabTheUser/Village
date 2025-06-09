using UnityEngine;

public class FlyCamera : MonoBehaviour
{
    public float moveSpeed = 10f; // скорость движения камеры
    public float sensitivity = 2f; // чувствительность мыши

    private float rotationX = 0f;
    private float rotationY = 0f;

    void Update()
    {
        // Получение данных с мыши для вращения камеры
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = -Input.GetAxis("Mouse Y") * sensitivity;

        // Обновление углов поворота камеры
        rotationX += mouseX;
        rotationY += mouseY;

        // Ограничение вертикального вращения камеры
        rotationY = Mathf.Clamp(rotationY, -90f, 90f);

        // Поворот камеры
        transform.rotation = Quaternion.Euler(rotationY, rotationX, 0f);

        // Движение камеры с помощью клавиш WASD
        float moveForwardBackward = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float moveLeftRight = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        // Перемещение камеры по осям
        transform.Translate(moveLeftRight, 0f, moveForwardBackward);
    }
}
