using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class WeightedRandom<T>
{
    private struct Item
    {
        public T Value;
        public float Weight;
    }

    private List<Item> items = new List<Item>();
    private float totalWeight;

    public void AddItem(T value, float weight)
    {
        if (weight <= 0)
            throw new System.ArgumentException("Weight must be greater than zero");

        items.Add(new Item { Value = value, Weight = weight });
        totalWeight += weight;
    }

    public T GetRandom()
    {
        float randomValue = UnityEngine.Random.Range(0, totalWeight);
        float cumulativeWeight = 0f;

        foreach (var item in items)
        {
            cumulativeWeight += item.Weight;
            if (randomValue < cumulativeWeight)
            {
                return item.Value;
            }
        }

        return default(T); // На случай если что-то пойдет не так
    }
}

public class DiceRoll : MonoBehaviour
{
    [SerializeField]
    private SpriteAtlas spriteAtlas;
    [SerializeField]
    private Image uiImage;
    private float spinTime = 3f;
    private float rotationSpeed = 100f;
    private WeightedRandom<int> weightedRandom;
    private void Start()
    {
        // Пример получения спрайта по имени
        Sprite mySprite = spriteAtlas.GetSprite("1");
        if (mySprite != null)
        {
            // Пример использования спрайта в SpriteRenderer
            uiImage.sprite = mySprite;
        }
        else
        {
            Debug.Log("Sprite not found");
        }
        weightedRandom = new WeightedRandom<int>();
        // Пример настройки вероятностей для граней кубика
        weightedRandom.AddItem(1, 1f); // Грань 1: вес 1
        weightedRandom.AddItem(2, 1f); // Грань 2: вес 1
        weightedRandom.AddItem(3, 1f); // Грань 3: вес 1
        weightedRandom.AddItem(4, 1f); // Грань 4: вес 1
        weightedRandom.AddItem(5, 3f); // Грань 5: вес 3 (в 3 раза выше вероятность выпадения)
        weightedRandom.AddItem(6, 1f); // Грань 6: вес 1
    }

    public void StartSpine()
    {
        StartCoroutine(SpinDice());
    }
    private IEnumerator SpinDice()
    {
        float timer = spinTime;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            SetRandomDiceFace();
            yield return null; // Ждем следующего кадра
        }

        uiImage.rectTransform.rotation = Quaternion.identity;
    }

    void SetRandomDiceFace()
    {
        int faceNumber = weightedRandom.GetRandom();
        Sprite newFace = spriteAtlas.GetSprite($"{faceNumber}");
        if (newFace != null)
        {
            uiImage.sprite = newFace;
        }
    }
}
