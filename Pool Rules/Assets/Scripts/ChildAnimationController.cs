using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class AnimationBundle
{
    public string name;
    public AudioClip sfx;
    public bool audioLoops = false;
    public RuntimeAnimatorController animSkin;
    public RuntimeAnimatorController animClothesTrunks;
    public RuntimeAnimatorController animClothesOnePiece;
}

public class ChildAnimationController : MonoBehaviour
{
    public bool isLifeguard = false;
    public float minHeight = 0.75f;
    public float maxHeight = 1.25f;
    public List<Color> skinColors = new List<Color> {
                                     new Color32(0xFF, 0xDF, 0xC4, 1),
                                     new Color32(0xE7, 0xBC, 0x91, 1),
                                     new Color32(0xB2, 0x6A, 0x49, 1),
                                     new Color32(0xEA, 0xCB, 0xA8, 1),
                                     new Color32(0xEC, 0xBF, 0x83, 1),
                                     new Color32(0xAE, 0x70, 0x3A, 1),
                                     new Color32(0xF7, 0xE2, 0xAB, 1),
                                     new Color32(0xCF, 0x9E, 0x7C, 1),
                                     new Color32(0x99, 0x64, 0x4D, 1),
                                     new Color32(0xDC, 0xB9, 0x91, 1),
                                     new Color32(0xAC, 0x8B, 0x64, 1),
                                     new Color32(0x62, 0x3A, 0x18, 1),
                                     new Color32(0xF0, 0xC0, 0x8A, 1),
                                     new Color32(0x94, 0x61, 0x3C, 1),
                                     new Color32(0x3F, 0x28, 0x18, 1)
                                     };
    public List<Color> clothesColors = new List<Color> {
                                     new Color32(0x1D, 0xC0, 0x7D, 1),
                                     new Color32(0xC5, 0x94, 0xD0, 1),
                                     new Color32(0xE4, 0x7C, 0x1F, 1),
                                     new Color32(0x55, 0xAB, 0xD8, 1),
                                     new Color32(0x2B, 0x80, 0x43, 1),
                                     new Color32(0xDA, 0x6E, 0x99, 1),
                                     new Color32(0x2C, 0x37, 0x7B, 1),
                                     new Color32(0x68, 0x18, 0x18, 1),
                                     new Color32(0x9D, 0xC7, 0x2B, 1),
                                     new Color32(0x6D, 0x34, 0x18, 1)
                                     };

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

    private Color tempColor;

    public List<AnimationBundle> animations = new List<AnimationBundle>();
    private Dictionary<string, AnimationBundle> animationsDictionary = new Dictionary<string, AnimationBundle>();
    private AudioSource _audioSource;
    public string currentAnimationStateForIdling = "idle";
    public string currentAnimationState = "idle";

    void InitialSetup()
    {
        foreach(AnimationBundle bundle in animations) { animationsDictionary[bundle.name] = bundle; }
        _audioSource = GetComponent<AudioSource>();

        skinRend = skin.GetComponent<SpriteRenderer>();
        skinAnim = skin.GetComponent<Animator>();

        clothesTrunksRendFront = clothesTrunksFront.GetComponent<SpriteRenderer>();
        clothesTrunksAnimFront = clothesTrunksFront.GetComponent<Animator>();
        clothesTrunksRendBack = clothesTrunksBack.GetComponent<SpriteRenderer>();
        clothesTrunksAnimBack = clothesTrunksBack.GetComponent<Animator>();

        if (!isLifeguard)
        {
            clothesOnePieceRendFront = clothesOnePieceFront.GetComponent<SpriteRenderer>();
            clothesOnePieceAnimFront = clothesOnePieceFront.GetComponent<Animator>();
            clothesOnePieceRendBack = clothesOnePieceBack.GetComponent<SpriteRenderer>();
            clothesOnePieceAnimBack = clothesOnePieceBack.GetComponent<Animator>();
            float height = Random.Range(minHeight, maxHeight);
            transform.localScale = new Vector3(height, height, height);
            transform.localPosition = new Vector3(transform.localPosition.x, height, transform.localPosition.z);
        }

        SetAnimation(currentAnimationState);

        RandomizeCosmetics(true);
    }

    void RandomizeCosmetics(bool randomizeSkin = false)
    {
        if (randomizeSkin) skinRend.color = skinColors[Random.Range(0, skinColors.Count)];
        tempColor = skinRend.color;
        if (!isLifeguard)
        {

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
    }

    public void SetAnimation(string name)
    {
        Debug.Log("Attempting to set animation for " + gameObject.name + " to " + name);
        if (currentAnimationState == name)
        {
            Debug.LogWarning("Already in animation state " + name);
            return;
        }
        if (!animationsDictionary.TryGetValue(name, out AnimationBundle bundle))
        {
            Debug.LogWarning("Animation " + name + " doesn't exist!");
            return;
        }

        currentAnimationState = name;
        _audioSource.Stop();
        _audioSource.loop = bundle.audioLoops;
        _audioSource.clip = bundle.sfx;
        if (bundle.sfx != null)
        {
            _audioSource.Play();
        }
        skinAnim.runtimeAnimatorController = bundle.animSkin;
        clothesTrunksAnimFront.runtimeAnimatorController = bundle.animClothesTrunks;
        clothesTrunksAnimBack.runtimeAnimatorController = bundle.animClothesTrunks;
        if (!isLifeguard)
        {
            clothesOnePieceAnimFront.runtimeAnimatorController = bundle.animClothesOnePiece;
            clothesOnePieceAnimBack.runtimeAnimatorController = bundle.animClothesOnePiece;
        }
    }

    public void SetIdling()
    {
        SetAnimation(currentAnimationStateForIdling);
    }

    public void ChangeIdlingState(string state)
    {
        if (!animationsDictionary.TryGetValue(name, out AnimationBundle bundle))
        {
            Debug.LogWarning("Animation " + name + " doesn't exist!");
            return;
        }
        currentAnimationStateForIdling = state;
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

    public void DisableBrains()
    {
        SetSelected(false);
        // TODO check if naughty first for victory condition
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        GetComponent<NavMeshAgentDebugger>().enabled = false;
        GetComponent<ChildRuleStates>().enabled = false;
        GetComponent<ChildMovementType>().enabled = false;
        GetComponent<ColliderEventInvoker>().enabled = false;
        GetComponent<DebugLogger>().enabled = false;
        GetComponent<AlbedoChanger>().enabled = false;
    }

    void Start()
    {
        InitialSetup();

    }
}
