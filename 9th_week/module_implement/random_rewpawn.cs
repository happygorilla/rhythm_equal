using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator : MonoBehaviour
{
    public Camera mainCamera; // ī�޶� ���� ����
    public GameObject[] shapes; // ���� ������ 

    private GameObject shapeObject1; // ù ��° ���� 
    private GameObject shapeObject2; // �� ��° ���� 
    private bool isShape1Active = true; // Ȱ��ȭ�� ���� ���� ����

    // Start �Լ����� 1�ʸ��� SpawnRandomShapes() �Լ��� ȣ���Ͽ� ������ ���� �Ǵ� ����
    void Start()
    {
        InvokeRepeating("SpawnOrDestroyShape", 0f, 1f);
    }

    // 1�ʸ��� ȣ��Ǵ� �Լ���, ������ �����ϰų� ������
    void SpawnOrDestroyShape()
    {
        // ī�޶��� �þ� ���� ��������
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        // ���� Ȱ��ȭ�� ���� ����
        if (isShape1Active && shapeObject1 != null)
        {
            Destroy(shapeObject1);
        }
        else if (!isShape1Active && shapeObject2 != null)
        {
            Destroy(shapeObject2);
        }

        // ���ο� ���� ���� ��ġ ���
        float randomX = Random.Range(-cameraWidth / 2f, cameraWidth / 2f);
        float randomY = Random.Range(-cameraHeight / 2f, cameraHeight / 2f);
        Vector3 randomPosition = new Vector3(randomX, randomY, 0);

        // ������ ���� ����
        GameObject randomShape = shapes[Random.Range(0, shapes.Length)];

        // ���� ����
        if (isShape1Active)
        {
            shapeObject1 = Instantiate(randomShape, randomPosition, Quaternion.identity);
        }
        else
        {
            shapeObject2 = Instantiate(randomShape, randomPosition, Quaternion.identity);
        }

        // ������ ������ ������ ����
        isShape1Active = !isShape1Active;
    }
}
