using UnityEngine;

public class DraggableItem : MonoBehaviour
{
    [SerializeField] Transform player; 
    //[SerializeField] float grabDistance = 2f; // ��������� �������
    [SerializeField] float followSpeed = 18f; 
    [SerializeField] Vector3 offset = new Vector3(0, 0.5f, 1.5f);
    [SerializeField] MouseLock _mouseLock;


    private bool isGrabbed = false;
    private Rigidbody rb;

    public bool DragTrigUse = false;  


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && DragTrigUse == true /* && _mouseLock._isUse == false */ /* && Vector3.Distance(transform.position, player.position) <= grabDistance */ )
        {
            isGrabbed = !isGrabbed;
            if (isGrabbed && rb != null)
            {
                rb.isKinematic = true;
                _mouseLock._isUse = true;
            }
            else if (rb != null)
            {
                rb.isKinematic = false;
                _mouseLock._isUse = false;
            }
        }
        if (isGrabbed)
        {
            Vector3 targetPosition = player.position + player.forward * offset.z + player.up * offset.y;
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }

}
