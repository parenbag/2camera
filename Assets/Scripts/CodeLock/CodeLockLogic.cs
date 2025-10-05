using UnityEngine;
using TMPro;

public class CodeLockLogic : MonoBehaviour
{
    private int[] Code = {0, 1, 2};

    private int CodeKey = 1;

    [SerializeField] Transform CodeOneCount;
    [SerializeField] Transform CodeTwoCount;
    [SerializeField] Transform CodeTreeCount;



    [SerializeField] private float rotationSpeed = 90f;
    private float[] targetRotations = { 0f, 0f, 0f };
    private bool isRotating = false;   

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !isRotating)
        {
            Code[CodeKey] -= 1;
            targetRotations[CodeKey] -= 36f;
            isRotating = true;

        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && !isRotating)
        {
            Code[CodeKey] += 1;
            targetRotations[CodeKey] += 36f;
            isRotating = true;
        }

        if (Code[CodeKey] <= -1)
        {
            Code[CodeKey] = 9;
        }
        if (Code[CodeKey] >= 10)
        {
            Code[CodeKey] = 0;
        }


        
        if (Input.GetKeyDown(KeyCode.UpArrow) && CodeKey != 0 )
        {
            CodeKey -= 1;
        }


        if (Input.GetKeyDown(KeyCode.DownArrow) && CodeKey != 2)
        {
            CodeKey += 1;   
        }

        

        switch (CodeKey)
        {
            case 0:
                RotateManger(CodeOneCount,0);
                break;
            case 1:
                RotateManger(CodeTwoCount,1);
                break;
            case 2:
                RotateManger(CodeTreeCount,2);
                break;

        }

        void RotateManger(Transform obj, int index)
        {
            if (obj == null) return;

            float currentAngle = obj.localEulerAngles.z; // Теперь по оси Z
            float targetRotation = targetRotations[index];

            // Если вращение активно, плавно поворачиваем
            if (isRotating && index == CodeKey)
            {
                float newAngle = Mathf.MoveTowardsAngle(currentAngle, targetRotation, rotationSpeed * Time.deltaTime);
                obj.localEulerAngles = new Vector3(0, 0, newAngle); // Вращение по оси Z

                // Проверяем достижение цели
                if (Mathf.Abs(Mathf.DeltaAngle(newAngle, targetRotation)) < 0.1f)
                {
                    isRotating = false;
                }
            }
            else
            {
                // Поддерживаем текущую позицию для неактивных объектов
                obj.localEulerAngles = new Vector3(0, 0, targetRotation);
            }
        }

        // -+ 36
        



    }
}
