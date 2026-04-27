using UnityEngine;

public class CardManager : MonoBehaviour
{
    [Header("설정")]
    [Tooltip("생성할 카드의 페어(쌍) 개수입니다.")]
    [SerializeField] private int pairCount = 10;

    [Header("프리팹")]
    [SerializeField] private GameObject cardPrefab; // 생성할 카드 프리팹
    [SerializeField] private Transform cardParent;  // 카드가 생성될 부모 위치 (Canvas 등)

    void Start()
    {
        GenerateCards();
    }

    public void GenerateCards()
    {
        // 기존에 생성된 카드가 있다면 삭제 (초기화용)
        foreach (Transform child in cardParent)
        {
            Destroy(child.gameObject);
        }

        // 조건 1: 페어 개수의 2배만큼 카드 출력
        int totalCards = pairCount * 2;

        for (int i = 0; i < totalCards; i++)
        {
            // 카드 프리팹을 부모 오브젝트 하위에 생성
            GameObject newCard = Instantiate(cardPrefab, cardParent);

            // 오브젝트 이름 구분 (선택 사항)
            newCard.name = $"Card_{i}";
        }

        Debug.Log($"총 {totalCards}개의 카드가 생성되었습니다. (페어: {pairCount})");
    }
}