using UnityEngine;

public class ButtonsUse : MonoBehaviour
{
    [SerializeField] GameObject Stick;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            ButtonInput();
        }
    }

    private void ButtonInput()
    {
        Stick.SetActive(false);
        
    }
}
