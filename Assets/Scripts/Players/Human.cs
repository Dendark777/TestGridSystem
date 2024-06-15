using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Players
{

    public class Human : MonoBehaviour
    {
        public int maxHealth = 4; // ������������ ���������� ������
        public int currentHealth; // ������� ���������� ������
        public bool isConscious = true; // �������� ��������

        public bool isCarrying = false; // ��������� �� ������� ��������
        public GameObject carriedHuman; // ������� �������, ������� �����������

        public int numActions = 2; // ���������� �������� �� ���

        private void Start()
        {
            currentHealth = maxHealth;
        }

        // ����� ��� ����������� ��������
        public void Move(Vector3 newPosition)
        {
            transform.position = newPosition;
        }

        // ����� ��� ����� �����
        public void AttackZombie()
        {
            // ���������� ����� �����
        }

        // ����� ��� ������
        public void Search()
        {
            // ���������� ������
        }

        // ����� ��� ��������� ���������
        public void SetBarricade()
        {
            // ���������� ��������� ���������
        }

        // ����� ��� �������� �������� ������� ������
        public void PassItem(GameObject otherPlayer)
        {
            // ���������� �������� ��������
        }

        // ����� ��� ������������� ��������
        public void UseItem()
        {
            // ���������� ������������� ��������
        }
    }
}
