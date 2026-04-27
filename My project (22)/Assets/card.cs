using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [Header("회전 설정")]
    public float rotateSpeed = 10f; 
    public bool isFront = false;    

    [Header("이미지 설정")]
    public Sprite backSprite;       
    private Sprite frontSprite;     
    private Image cardImage;      

    [Header("데이터")]
    public int number;
    public TextMeshProUGUI text;
    public CardGame cardGame;
    public bool isMatched = false;

    private Quaternion flipRotation = Quaternion.Euler(0, 180f, 0);
    private Quaternion originRotation = Quaternion.Euler(0, 0, 0);

    void Awake()
    {
       
        cardImage = GetComponent<Image>();
        if (text == null) text = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
       
        TargetRotation();

        
        UpdateCardFace();
    }

    void TargetRotation()
    {
        if (isFront)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, originRotation, rotateSpeed * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, flipRotation, rotateSpeed * Time.deltaTime);
        }
    }

    void UpdateCardFace()
    {

        float currentY = transform.eulerAngles.y;


        if (currentY > 90f && currentY < 270f)
        {
            cardImage.sprite = backSprite;
            if (text != null) text.gameObject.SetActive(false); 
        }
        else
        {
            cardImage.sprite = frontSprite;
            if (text != null) text.gameObject.SetActive(true);  
        }
    }

    public void ClickCard()
    {
        if (isMatched || !isFront) 
        {
            
        }

        cardGame.OnClickCard(this);
    }

    public void Flip(bool isFront)
    {
        this.isFront = isFront;
    }

    public void SetCardNumber(int newNumber)
    {
        number = newNumber;
        if (text != null) text.text = number.ToString();
    }

    public void ChangeColor(Color newColor)
    {
        cardImage.color = newColor;
    }

    

   
    public void SetFrontImage(Sprite sprite)
    {
        
        frontSprite = sprite;

        
        if (cardImage == null) cardImage = GetComponent<Image>();
        cardImage.sprite = backSprite;
    }
}