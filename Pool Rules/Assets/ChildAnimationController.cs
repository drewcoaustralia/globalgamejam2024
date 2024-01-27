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

    public GameObject clothesTrunks;
    private SpriteRenderer clothesTrunksRend;
    private Animator clothesTrunksAnim;

    public GameObject clothesOnePiece;
    private SpriteRenderer clothesOnePieceRend;
    private Animator clothesOnePieceAnim;

    void InitialSetup()
    {
        skinRend = skin.GetComponent<SpriteRenderer>();
        skinAnim = skin.GetComponent<Animator>();

        clothesTrunksRend = clothesTrunks.GetComponent<SpriteRenderer>();
        clothesTrunksAnim = clothesTrunks.GetComponent<Animator>();

        clothesOnePieceRend = clothesOnePiece.GetComponent<SpriteRenderer>();
        clothesOnePieceAnim = clothesOnePiece.GetComponent<Animator>();

        RandomizeCosmetics(true);
    }

    void RandomizeCosmetics(bool randomizeSkin = false)
    {
        if (randomizeSkin) skinRend.color = skinColors[Random.Range(0, skinColors.Count)];
        clothesTrunksRend.color = clothesColors[Random.Range(0, skinColors.Count)];
        clothesOnePieceRend.color = clothesColors[Random.Range(0, skinColors.Count)];

        if (Random.value > 0.5)
        {
            clothesTrunksRend.color = new Color(clothesTrunksRend.color.r, clothesTrunksRend.color.g, clothesTrunksRend.color.b, 0f);
            clothesOnePieceRend.color = new Color(clothesTrunksRend.color.r, clothesTrunksRend.color.g, clothesTrunksRend.color.b, 1f);
        }
        else
        {
            clothesOnePieceRend.color = new Color(clothesTrunksRend.color.r, clothesTrunksRend.color.g, clothesTrunksRend.color.b, 0f);
            clothesTrunksRend.color = new Color(clothesTrunksRend.color.r, clothesTrunksRend.color.g, clothesTrunksRend.color.b, 1f);
        }
    }
    void Start()
    {
        InitialSetup();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) RandomizeCosmetics(true);
    }
}
