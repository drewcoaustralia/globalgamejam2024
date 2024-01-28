using UnityEngine;
using UnityEngine.Events;

public class ChildRuleStates : MonoBehaviour
{
    public UnityEvent onRuleBroken;
    public UnityEvent onRuleNoLongerBroken;

    private RuleManager _ruleManager;
    private bool _hasBrokenARule;
    private bool _isSwimming;
    private bool _isDrowning;
    private bool _isRunning;
    private bool _isFlipping;
    private bool _isEatingOrDrinking;
    private bool _isSmiling;
    private bool _isDiving;
    private bool _isWalking;
    private bool _hasPhone;
    private bool _hasFlipPhone;
    private bool _hasFlipFlops;
    private bool _hasFerret;
    private bool _hasTrenchcoat;
    private bool _isPrimeMinister;
    private bool _isSwearing;
    private bool _isBackstroking;
    private bool _hasScubaGear;
    private bool _isAlien;
    private bool _isGinger;
    private bool _isSmoking;
    private bool _isVaping;
    private bool _hasBeard;
    private bool _isStreaking;
    private bool _isDaydreaming;
    private bool _hasNoodle;
    private bool _isParking;
    private bool _hasTowel;
    private bool _isContemplatingTheMeaningOfLife;
    private bool _isUrinating;
    private bool _isCooking;
    private bool _isOverthrowingGovernment;
    private bool _hasBoombox;
    private bool _isBeatboxing;
    private bool _isBoxing;
    private bool _hasToaster;
    private bool _isFishing;
    private bool _isLaughing;
    private bool _isLittering;
    private bool _isFighting;
    private bool _hasBike;
    private bool _hasScooter;
    private bool _hasSkateboard;
    private bool _hasBallGame;

    public bool HasBrokenARule
    {
        get { return _hasBrokenARule; }
        private set
        {
            if (_hasBrokenARule != value)
            {
                _hasBrokenARule = value;

                if (_hasBrokenARule)
                {
                    onRuleBroken.Invoke();
                }
                else onRuleNoLongerBroken.Invoke();
            }
        }
    }

    public bool IsSwimming
    {
        get { return _isSwimming; }
        set { SetProperty(ref _isSwimming, value); }
    }

    public bool IsDrowning
    {
        get { return _isDrowning; }
        set { SetProperty(ref _isDrowning, value); }
    }

    public bool IsRunning
    {
        get { return _isRunning; }
        set { SetProperty(ref _isRunning, value); }
    }

    public bool IsFlipping
    {
        get { return _isFlipping; }
        set { SetProperty(ref _isFlipping, value); }
    }

    public bool IsEatingOrDrinking
    {
        get { return _isEatingOrDrinking; }
        set { SetProperty(ref _isEatingOrDrinking, value); }
    }

    public bool IsSmiling
    {
        get { return _isSmiling; }
        set { SetProperty(ref _isSmiling, value); }
    }

    public bool IsDiving
    {
        get { return _isDiving; }
        set { SetProperty(ref _isDiving, value); }
    }

    public bool IsWalking
    {
        get { return _isWalking; }
        set { SetProperty(ref _isWalking, value); }
    }

    public bool HasPhone
    {
        get { return _hasPhone; }
        set { SetProperty(ref _hasPhone, value); }
    }

    public bool HasFlipPhone
    {
        get { return _hasFlipPhone; }
        set { SetProperty(ref _hasFlipPhone, value); }
    }

    public bool HasFlipFlops
    {
        get { return _hasFlipFlops; }
        set { SetProperty(ref _hasFlipFlops, value); }
    }

    public bool HasFerret
    {
        get { return _hasFerret; }
        set { SetProperty(ref _hasFerret, value); }
    }

    public bool HasTrenchcoat
    {
        get { return _hasTrenchcoat; }
        set { SetProperty(ref _hasTrenchcoat, value); }
    }

    public bool IsPrimeMinister
    {
        get { return _isPrimeMinister; }
        set { SetProperty(ref _isPrimeMinister, value); }
    }

    public bool IsSwearing
    {
        get { return _isSwearing; }
        set { SetProperty(ref _isSwearing, value); }
    }

    public bool IsBackstroking
    {
        get { return _isBackstroking; }
        set { SetProperty(ref _isBackstroking, value); }
    }

    public bool HasScubaGear
    {
        get { return _hasScubaGear; }
        set { SetProperty(ref _hasScubaGear, value); }
    }

    public bool IsAlien
    {
        get { return _isAlien; }
        set { SetProperty(ref _isAlien, value); }
    }

    public bool IsGinger
    {
        get { return _isGinger; }
        set { SetProperty(ref _isGinger, value); }
    }

    public bool IsSmoking
    {
        get { return _isSmoking; }
        set { SetProperty(ref _isSmoking, value); }
    }

    public bool IsVaping
    {
        get { return _isVaping; }
        set { SetProperty(ref _isVaping, value); }
    }

    public bool HasBeard
    {
        get { return _hasBeard; }
        set { SetProperty(ref _hasBeard, value); }
    }

    public bool IsStreaking
    {
        get { return _isStreaking; }
        set { SetProperty(ref _isStreaking, value); }
    }

    public bool IsDaydreaming
    {
        get { return _isDaydreaming; }
        set { SetProperty(ref _isDaydreaming, value); }
    }

    public bool HasNoodle
    {
        get { return _hasNoodle; }
        set { SetProperty(ref _hasNoodle, value); }
    }

    public bool IsParking
    {
        get { return _isParking; }
        set { SetProperty(ref _isParking, value); }
    }

    public bool HasTowel
    {
        get { return _hasTowel; }
        set { SetProperty(ref _hasTowel, value); }
    }

    public bool IsContemplatingTheMeaningOfLife
    {
        get { return _isContemplatingTheMeaningOfLife; }
        set { SetProperty(ref _isContemplatingTheMeaningOfLife, value); }
    }

    public bool IsUrinating
    {
        get { return _isUrinating; }
        set { SetProperty(ref _isUrinating, value); }
    }

    public bool IsCooking
    {
        get { return _isCooking; }
        set { SetProperty(ref _isCooking, value); }
    }

    public bool IsOverthrowingGovernment
    {
        get { return _isOverthrowingGovernment; }
        set { SetProperty(ref _isOverthrowingGovernment, value); }
    }

    public bool HasBoombox
    {
        get { return _hasBoombox; }
        set { SetProperty(ref _hasBoombox, value); }
    }

    public bool IsBeatboxing
    {
        get { return _isBeatboxing; }
        set { SetProperty(ref _isBeatboxing, value); }
    }

    public bool IsBoxing
    {
        get { return _isBoxing; }
        set { SetProperty(ref _isBoxing, value); }
    }

    public bool HasToaster
    {
        get { return _hasToaster; }
        set { SetProperty(ref _hasToaster, value); }
    }

    public bool IsFishing
    {
        get { return _isFishing; }
        set { SetProperty(ref _isFishing, value); }
    }

    public bool IsLaughing
    {
        get { return _isLaughing; }
        set { SetProperty(ref _isLaughing, value); }
    }

    public bool IsLittering
    {
        get { return _isLittering; }
        set { SetProperty(ref _isLittering, value); }
    }

    public bool IsFighting
    {
        get { return _isFighting; }
        set { SetProperty(ref _isFighting, value); }
    }

    public bool HasBike
    {
        get { return _hasBike; }
        set { SetProperty(ref _hasBike, value); }
    }

    public bool HasScooter
    {
        get { return _hasScooter; }
        set { SetProperty(ref _hasScooter, value); }
    }

    public bool HasSkateboard
    {
        get { return _hasSkateboard; }
        set { SetProperty(ref _hasSkateboard, value); }
    }

    public bool HasBallGame
    {
        get { return _hasBallGame; }
        set { SetProperty(ref _hasBallGame, value); }
    }

    private void SetProperty(ref bool field, bool value)
    {
        if (field != value)
        {
            field = value;
            CheckForRuleViolation();
        }
    }

    private void Start()
    {
        _ruleManager = RuleManager.Instance;
        _ruleManager.RuleChanged += OnRuleChanged;
    }

    private void OnDestroy()
    {
        _ruleManager.RuleChanged -= OnRuleChanged;
    }

    private void OnRuleChanged(string ruleName, bool isActive)
    {
        CheckForRuleViolation();
    }

    private void CheckForRuleViolation()
    {
        bool swimmingRule = _ruleManager.GetRule("No Swimming");
        bool runningRule = _ruleManager.GetRule("No Running");
        bool drowningRule = _ruleManager.GetRule("No Drowning");
        bool flippingRule = _ruleManager.GetRule("No Flips");
        bool eatingOrDrinkingRule = _ruleManager.GetRule("No Food Or Drink");
        bool smilingRule = _ruleManager.GetRule("No Smiling");
        bool divingRule = _ruleManager.GetRule("No Diving");
        bool walkingRule = _ruleManager.GetRule("No Walking");
        bool phoneRule = _ruleManager.GetRule("No Phones");
        bool flipPhoneRule = _ruleManager.GetRule("No Flip Phones");
        bool flipFlopRule = _ruleManager.GetRule("No Flip Flops");
        bool ferretRule = _ruleManager.GetRule("No Ferrets");
        bool trenchcoatRule = _ruleManager.GetRule("No Trenchcoats");
        bool primeMinisterRule = _ruleManager.GetRule("No Prime Ministers");
        bool swearingRule = _ruleManager.GetRule("No Swearing");
        bool backstrokeRule = _ruleManager.GetRule("No Backstroke");
        bool scubaGearRule = _ruleManager.GetRule("No SCUBA Gear");
        bool alienRule = _ruleManager.GetRule("No Aliens");
        bool gingerRule = _ruleManager.GetRule("No Gingers");
        bool smokingRule = _ruleManager.GetRule("No Smoking");
        bool vapingRule = _ruleManager.GetRule("No Vaping");
        bool beardRule = _ruleManager.GetRule("No Beards");
        bool streakingRule = _ruleManager.GetRule("No Streaking");
        bool daydreamingRule = _ruleManager.GetRule("No Daydreaming");
        bool noodleRule = _ruleManager.GetRule("No Noodles");
        bool parkingRule = _ruleManager.GetRule("No Parking");
        bool towelRule = _ruleManager.GetRule("No Towels");
        bool contemplatingRule = _ruleManager.GetRule("No Contemplating The Meaning Of Life");
        bool urinatingRule = _ruleManager.GetRule("No Urinating");
        bool cookingRule = _ruleManager.GetRule("No Cooking");
        bool overthrowingRule = _ruleManager.GetRule("No Overthrowing The Government");
        bool boomboxRule = _ruleManager.GetRule("No Boomboxes");
        bool beatboxingRule = _ruleManager.GetRule("No Beatboxing");
        bool boxingRule = _ruleManager.GetRule("No Boxing");
        bool toasterRule = _ruleManager.GetRule("No Toasters");
        bool fishingRule = _ruleManager.GetRule("No Fishing");
        bool laughingRule = _ruleManager.GetRule("No Laughing");
        bool litteringRule = _ruleManager.GetRule("No Littering");
        bool fightingRule = _ruleManager.GetRule("No Fighting");
        bool bikeRule = _ruleManager.GetRule("No Bikes");
        bool scooterRule = _ruleManager.GetRule("No Scooters");
        bool skateboardingRule = _ruleManager.GetRule("No Skateboards");
        bool ballGameRule = _ruleManager.GetRule("No Ball Games");

        if ((swimmingRule && IsSwimming) ||
            (runningRule && IsRunning) ||
            (drowningRule && IsDrowning) ||
            (flippingRule && IsFlipping) ||
            (eatingOrDrinkingRule && IsEatingOrDrinking) ||
            (smilingRule && IsSmiling) ||
            (divingRule && IsDiving) ||
            (walkingRule && IsWalking) ||
            (phoneRule && HasPhone) ||
            (flipPhoneRule && HasFlipPhone) ||
            (flipFlopRule && HasFlipFlops) ||
            (ferretRule && HasFerret) ||
            (trenchcoatRule && HasTrenchcoat) ||
            (primeMinisterRule && IsPrimeMinister) ||
            (swearingRule && IsSwearing) ||
            (backstrokeRule && IsBackstroking) ||
            (scubaGearRule && HasScubaGear) ||
            (alienRule && IsAlien) ||
            (gingerRule && IsGinger) ||
            (smokingRule && IsSmoking) ||
            (vapingRule && IsVaping) ||
            (beardRule && HasBeard) ||
            (streakingRule && IsStreaking) ||
            (daydreamingRule && IsDaydreaming) ||
            (noodleRule && HasNoodle) ||
            (parkingRule && IsParking) ||
            (towelRule && HasTowel) ||
            (contemplatingRule && IsContemplatingTheMeaningOfLife) ||
            (urinatingRule && IsUrinating) ||
            (cookingRule && IsCooking) ||
            (overthrowingRule && IsOverthrowingGovernment) ||
            (boomboxRule && HasBoombox) ||
            (beatboxingRule && IsBeatboxing) ||
            (boxingRule && IsBoxing) ||
            (toasterRule && HasToaster) ||
            (fishingRule && IsFishing) ||
            (laughingRule && IsLaughing) ||
            (litteringRule && IsLittering) ||
            (fightingRule && IsFighting) ||
            (bikeRule && HasBike) ||
            (scooterRule && HasScooter) ||
            (skateboardingRule && HasSkateboard) ||
            (ballGameRule && HasBallGame))
        {
            HasBrokenARule = true;
        }
    }
}
