using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2 : MonoBehaviour
{
    public float speed = 10;
    public Joystick joyStick;
    public Transform firePoint;
    public GameObject bulletPrefab;

    private CharacterController controller;

    private GameObject focusEnemy;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // �}�l�@���g���� Coroutine �禡
        StartCoroutine(KeepShooting());
    }

    void Update()
    {
        // ���̪񪺤@�ӥؼ� Enemy ������
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        float miniDist = 9999;
        foreach (GameObject enemy in enemys)
        {
            // �p��Z��
            float d = Vector3.Distance(transform.position, enemy.transform.position);

            // ��W�@�ӳ̪񪺤���A������p�N�O���U��
            if (d < miniDist)
            {
                miniDist = d;
                focusEnemy = enemy;
            }
        }



        // ���o��V���J
        // float h = Input.GetAxis("Horizontal");
        // float v = Input.GetAxis("Vertical");

        // ���o�����n���J
        float h = joyStick.Horizontal;
        float v = joyStick.Vertical;

        // �X����V�V�q
        Vector3 dir = new Vector3(h, 0, v);

        // �վ㨤�⭱���V
        // �P�_��V�V�q���׬O�_�j�� 0.1�]�N����J�^
        if (dir.magnitude > 0.1f)
        {
            // �N��V�V�q�ର����
            float faceAngle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;

            // �ϥ� Lerp ������V
            Quaternion targetRotation = Quaternion.Euler(0, faceAngle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.3f);
        }
        else
        {
            // �S�����ʿ�J�A�åB����w���ĤH�A�������V�ĤH
            if (focusEnemy)
            {
                var targetRotation = Quaternion.LookRotation(focusEnemy.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 20 * Time.deltaTime);
            }
        }

        // �a�ߤޤO (y)
        if (!controller.isGrounded)
        {
            dir.y = -9.8f * 30 * Time.deltaTime;
        }

        // ���ʨ����m
        controller.Move(dir * speed * Time.deltaTime);


    }

    void Fire()
    {
        // ���ͥX�l�u
        Instantiate(bulletPrefab, firePoint.transform.position, transform.rotation);
    }


    // �@���g���� Coroutine �禡
    IEnumerator KeepShooting()
    {
        while (true)
        {
            // �g��
            Fire();

            // �Ȱ� 0.5 ��
            yield return new WaitForSeconds(0.5f);
        }
    }
}
