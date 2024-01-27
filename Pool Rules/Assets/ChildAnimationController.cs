using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildAnimationController : MonoBehaviour
{
    public List<Color> skinColors;
    public List<Color> clothesColors;

    public GameObject skin;
    private SpriteRenderer skinRend;
    private Animator skinAnim;

    public GameObject clothesTrunksFront;
    private SpriteRenderer clothesTrunksRendFront;
    private Animator clothesTrunksAnimFront;

    public GameObject clothesTrunksBack;
    private SpriteRenderer clothesTrunksRendBack;
    private Animator clothesTrunksAnimBack;

    public GameObject clothesOnePieceFront;
    private SpriteRenderer clothesOnePieceRendFront;
    private Animator clothesOnePieceAnimFront;

    public GameObject clothesOnePieceBack;
    private SpriteRenderer clothesOnePieceRendBack;
    private Animator clothesOnePieceAnimBack;

    [SerializeField] private Color tempColor;

    void InitialSetup()
    {
        skinRend = skin.GetComponent<SpriteRenderer>();
        skinAnim = skin.GetComponent<Animator>();

        clothesTrunksRendFront = clothesTrunksFront.GetComponent<SpriteRenderer>();
        clothesTrunksAnimFront = clothesTrunksFront.GetComponent<Animator>();
        clothesTrunksRendBack = clothesTrunksBack.GetComponent<SpriteRenderer>();
        clothesTrunksAnimBack = clothesTrunksBack.GetComponent<Animator>();

        clothesOnePieceRendFront = clothesOnePieceFront.GetComponent<SpriteRenderer>();
        clothesOnePieceAnimFront = clothesOnePieceFront.GetComponent<Animator>();
        clothesOnePieceRendBack = clothesOnePieceBack.GetComponent<SpriteRenderer>();
        clothesOnePieceAnimBack = clothesOnePieceBack.GetComponent<Animator>();

        RandomizeCosmetics(true);
    }

    void RandomizeCosmetics(bool randomizeSkin = false)
    {
        if (randomizeSkin) skinRend.color = skinColors[Random.Range(0, skinColors.Count)];
        tempColor = skinRend.color;
        Color clothingColor = clothesColors[Random.Range(0, skinColors.Count)];
        clothesTrunksRendFront.color = clothingColor;
        clothesTrunksRendBack.color = clothingColor;
        clothesOnePieceRendFront.color = clothingColor;
        clothesOnePieceRendBack.color = clothingColor;

        // turning renderer to transparent instead of turning off the clothing to not break animations
        // just in case we want to swap clothes on same kid for some reason
        if (Random.value > 0.5)
        {
            clothesTrunksRendFront.color = new Color(clothesTrunksRendFront.color.r, clothesTrunksRendFront.color.g, clothesTrunksRendFront.color.b, 0f);
            clothesTrunksRendBack.color = new Color(clothesTrunksRendBack.color.r, clothesTrunksRendBack.color.g, clothesTrunksRendBack.color.b, 0f);
            clothesOnePieceRendFront.color = new Color(clothesTrunksRendFront.color.r, clothesTrunksRendFront.color.g, clothesTrunksRendFront.color.b, 1f);
            clothesOnePieceRendBack.color = new Color(clothesTrunksRendBack.color.r, clothesTrunksRendBack.color.g, clothesTrunksRendBack.color.b, 1f);
        }
        else
        {
            clothesOnePieceRendFront.color = new Color(clothesTrunksRendFront.color.r, clothesTrunksRendFront.color.g, clothesTrunksRendFront.color.b, 0f);
            clothesOnePieceRendBack.color = new Color(clothesTrunksRendBack.color.r, clothesTrunksRendBack.color.g, clothesTrunksRendBack.color.b, 0f);
            clothesTrunksRendFront.color = new Color(clothesTrunksRendFront.color.r, clothesTrunksRendFront.color.g, clothesTrunksRendFront.color.b, 1f);
            clothesTrunksRendBack.color = new Color(clothesTrunksRendBack.color.r, clothesTrunksRendBack.color.g, clothesTrunksRendBack.color.b, 1f);
        }
    }

    public void StartAnimating(bool start = true)
    {
        skinAnim.enabled = start;
        clothesTrunksAnimFront.enabled = start;
        clothesTrunksAnimBack.enabled = start;
        clothesOnePieceAnimFront.enabled = start;
        clothesOnePieceAnimBack.enabled = start;
    }

    public void SetSelected(bool selected = true)
    {
        if (selected)
        {
            if (skinRend.color != Color.magenta) tempColor = skinRend.color;
            skinRend.color = Color.magenta;
        }
        else
        {
            skinRend.color = tempColor;
        }
    }

    void Start()
    {
        InitialSetup();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) RandomizeCosmetics(true);
        if (Input.GetKeyDown(KeyCode.P)) StartAnimating(true);
    }
}
