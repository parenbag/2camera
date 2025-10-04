using UnityEngine;

public class DraggableItem : MonoBehaviour
{
    [SerializeField] Transform player; // Ссылка на персонажа
    //[SerializeField] float grabDistance = 2f; // Дистанция захвата
    [SerializeField] float followSpeed = 18f; // Скорость следования
    [SerializeField] Vector3 offset = new Vector3(0, 0.5f, 1.5f); // Смещение от персонажа

    private bool isGrabbed = false;
    private Rigidbody rb;

    public bool DragTrigUse = false;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Проверяем нажатие клавиши и дистанцию
        if (Input.GetKeyDown(KeyCode.E) && DragTrigUse== true/* && Vector3.Distance(transform.position, player.position) <= grabDistance */ )
        {
            isGrabbed = !isGrabbed;
            if (isGrabbed && rb != null)
            {
                rb.isKinematic = true;
            }
            else if (rb != null)
            {
                rb.isKinematic = false;
            }
        }

        // Движение
        if (isGrabbed)
        {
            Vector3 targetPosition = player.position + player.forward * offset.z + player.up * offset.y;
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }

}
