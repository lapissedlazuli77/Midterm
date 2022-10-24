using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<string> phaseZeroDialogue;
    public List<string> phaseOneDialogue;
    public List<string> phaseTwoDialogue;
    public List<string> phaseThreeDialogue;
    public List<string> phaseFourDialogue;
    public List<string> phaseFiveDialogue;
    public List<string> phaseSixDialogue;
    public List<string> phaseSevenDialogue;
    public List<string> phaseEightDialogue;
    public List<string> phaseNineDialogue;
    public List<string> phaseTenDialogue;
    public List<string> phaseElevenDialogue;
    public List<string> phaseTwelveDialogue;
    public List<string> phaseThirteenDialogue;
    public List<string> phaseFourteenDialogue;
    public List<string> phaseFifteenDialogue;
    public List<string> phaseSixteenDialogue;
    public List<string> phaseSeventeenDialogue;
    public List<string> phaseEighteenDialogue;
    public List<string> phaseNineteenDialogue;
    List<string> currentDialogue;

    int phaseIndex = 0;
    int dialogueIndex = 0;
    int correctpath = 0;

    int whichchoice = 0;
    public TMP_Text dialogueBox;

    public GameObject LeftSpeaker;
    public GameObject RightSpeaker;
    public GameObject choiceOne;
    public GameObject choiceTwo;
    public GameObject choiceThree;
    public GameObject nextButton;
    public GameObject Background;

    public TextMeshProUGUI choiceOneText;
    public TextMeshProUGUI choiceTwoText;
    public TextMeshProUGUI choiceThreeText;

    public Animator LeftAnim;
    public Animator RightAnim;
    public Animator HUDAnim;
    public SpriteRenderer leftRenderer;
    public SpriteRenderer rightRenderer;
    public SpriteRenderer backgroundRenderer;

    public Sprite Akira;
    public Sprite Allison;
    public Sprite Ashley;
    public Sprite Adrien;
    public Sprite Sydney;
    public Sprite Nicole;
    public Sprite Jack;
    public Sprite Earl;
    public Sprite Ren;

    public Sprite restaurant;
    public Sprite forest;
    public Sprite tunnel;

    // Start is called before the first frame update
    void Start()
    {
        choiceOne.SetActive(false);
        choiceTwo.SetActive(false);
        choiceThree.SetActive(false);

        currentDialogue = phaseZeroDialogue;
        dialogueBox.text = currentDialogue[dialogueIndex];

        choiceOneText = choiceOne.GetComponentInChildren<TextMeshProUGUI>();
        choiceTwoText = choiceTwo.GetComponentInChildren<TextMeshProUGUI>();
        choiceThreeText = choiceThree.GetComponentInChildren<TextMeshProUGUI>();

        leftRenderer = LeftSpeaker.GetComponent<SpriteRenderer>();
        rightRenderer = RightSpeaker.GetComponent<SpriteRenderer>();
        backgroundRenderer = Background.GetComponent<SpriteRenderer>();

        backgroundRenderer.sprite = restaurant;

        choiceSetWord();
    }

    public void choiceSetWord()
    {
        switch (phaseIndex)
        {
            case 0:
                choiceTwoText.text = "Continue";
                break;
            case 1:
                choiceOneText.text = "Pick it up";
                choiceThreeText.text = "It's probably nothing";
                break;
            case 2:
                choiceOneText.text = "Pick it up";
                choiceThreeText.text = "Leave it";
                break;
            case 3:
                choiceTwoText.text = "Continue";
                break;
            case 4:
                choiceOneText.text = "Go with Akira";
                choiceTwoText.text = "Go with Ren";
                choiceThreeText.text = "Stay here";
                break;
            case 5:
                choiceOneText.text = "The one on the left";
                choiceTwoText.text = "Straight ahead";
                choiceThreeText.text = "The one on the right";
                break;
            case 6:
                choiceOneText.text = "Hell yeah!";
                choiceTwoText.text = "Maybe?";
                choiceThreeText.text = "I guess...";
                break;
            case 7:
                choiceOneText.text = "Turn back";
                choiceTwoText.text = "Call Adrien to help";
                choiceThreeText.text = "Nah, we're right";
                break;
            case 8:
                choiceOneText.text = "What was that!?";
                choiceTwoText.text = "Huh!?";
                choiceThreeText.text = "It's behind us, isn't it?";
                break;
            case 9:
                choiceOneText.text = "What was that!?";
                choiceTwoText.text = "Huh!?";
                choiceThreeText.text = "It's behind us, isn't it?";
                break;
            case 10:
                choiceOneText.text = "Best to be sure";
                choiceThreeText.text = "Nah, it's probably dead";
                break;
            case 11:
                choiceTwoText.text = "End";
                break;
            case 12:
                choiceTwoText.text = "End";
                break;
            case 13:
                choiceTwoText.text = "End";
                break;
            case 14:
                choiceOneText.text = "Go look";
                choiceThreeText.text = "GO BACK";
                break;
            case 15:
                choiceTwoText.text = "RUN";
                break;
            case 16:
                choiceTwoText.text = "End";
                break;
            case 17:
                choiceTwoText.text = "Nothing to do but listen...";
                break;
            case 18:
                choiceTwoText.text = "End";
                break;
        }
    }
    void SetDialogueText()
    {
        dialogueBox.text = currentDialogue[dialogueIndex];
    }
    public void AdvanceDialog()
    {
        dialogueIndex++;
        SetDialogueText();
        if (phaseIndex == 14 && dialogueIndex == 3)
        {
            leftRenderer.sprite = null;
            rightRenderer.sprite = null;
        } else if (phaseIndex == 17 && dialogueIndex == 3)
        {
            leftRenderer.sprite = null;
            rightRenderer.sprite = null;
        }
        WhoIsTalking();
        if (dialogueIndex == currentDialogue.Count - 1)
        {
            SetupChoices();
        }
    }
    void SetupChoices()
    {
        nextButton.SetActive(false);
        if (phaseIndex == 0 || phaseIndex == 3 || phaseIndex >= 15)
        {
            choiceOne.SetActive(false);
            choiceThree.SetActive(false);
        } else if(phaseIndex >= 11 && phaseIndex <= 13)
        {
            choiceOne.SetActive(false);
            choiceThree.SetActive(false);
        } else 
        {
            choiceOne.SetActive(true);
            choiceThree.SetActive(true);
        }
        if (phaseIndex == 1 || phaseIndex == 2 || phaseIndex == 10 || phaseIndex == 14)
        {
            choiceTwo.SetActive(false);
        } else
        {
            choiceTwo.SetActive(true);
        }
    }
    public void CorrectChoice()
    {
        correctpath += 2;
        if (phaseIndex == 4 || phaseIndex == 7 || phaseIndex == 10 || phaseIndex == 14)
        {
            whichchoice = 1;
        }
        GoToNextPhase();
    }

    public void NeutralChoice()
    {
        if (phaseIndex == 4 || phaseIndex == 7)
        {
            whichchoice = 2;
        }
        GoToNextPhase();
    }

    public void WrongChoice()
    {
        correctpath += -1;
        if (phaseIndex == 4)
        {
            whichchoice = 3;
        } else if (phaseIndex == 7)
        {
            whichchoice = 1;
        }
        else if (phaseIndex == 10 || phaseIndex == 14)
        {
            whichchoice = 2;
        }
        GoToNextPhase();
    }
    void GoToNextPhase()
    {
        //turn on the next button and turn off the choice buttons
        nextButton.SetActive(true);
        choiceOne.SetActive(false);
        choiceTwo.SetActive(false);
        choiceThree.SetActive(false);
        dialogueIndex = 0;
        switch (phaseIndex)
        {
            case 0:
                currentDialogue = phaseOneDialogue;
                leftRenderer.sprite = Jack;
                LeftAnim.SetTrigger("isTalking");
                phaseIndex = 1;
                choiceSetWord();
                break;
            case 1:
                if (correctpath >= 1)
                {
                    currentDialogue = phaseThreeDialogue;
                    RightAnim.SetTrigger("isTalking");
                    phaseIndex = 3;
                } else
                {
                    currentDialogue = phaseTwoDialogue;
                    leftRenderer.sprite = Earl;
                    LeftAnim.SetTrigger("isTalking");
                    correctpath = 0;
                    phaseIndex = 2;
                }
                LeftAnim.SetTrigger("isTalking");
                choiceSetWord();
                break;
            case 2:
                if (correctpath >= 1)
                {
                    currentDialogue = phaseThreeDialogue;
                    RightAnim.SetTrigger("isTalking");
                    phaseIndex = 3;
                }
                else
                {
                    currentDialogue = phaseTwoDialogue;
                    leftRenderer.sprite = Earl;
                    LeftAnim.SetTrigger("isTalking");
                    correctpath = 0;
                    phaseIndex = 2;
                }
                choiceSetWord();
                break;
            case 3:
                currentDialogue = phaseFourDialogue;
                leftRenderer.sprite = null;
                rightRenderer.sprite = null;
                backgroundRenderer.sprite = forest;
                phaseIndex = 4;
                choiceSetWord();
                break;
            case 4:
                if (whichchoice == 1)
                {
                    currentDialogue = phaseFiveDialogue;
                    leftRenderer.sprite = null;
                    rightRenderer.sprite = null;
                    backgroundRenderer.sprite = tunnel;
                    phaseIndex = 5;
                } else if (whichchoice == 2)
                {
                    currentDialogue = phaseFourteenDialogue;
                    rightRenderer.sprite = Ren;
                    RightAnim.SetTrigger("isTalking");
                    phaseIndex = 14;
                } else if (whichchoice == 3)
                {
                    currentDialogue = phaseSeventeenDialogue;
                    rightRenderer.sprite = Ren;
                    RightAnim.SetTrigger("isTalking");
                    phaseIndex = 17;
                }
                whichchoice = 0;
                choiceSetWord();
                break;
            case 5:
                currentDialogue = phaseSixDialogue;
                RightAnim.SetTrigger("isTalking");
                phaseIndex = 6;
                choiceSetWord();
                break;
            case 6:
                currentDialogue = phaseSevenDialogue;
                LeftAnim.SetTrigger("isTalking");
                phaseIndex = 7;
                choiceSetWord();
                break;
            case 7:
                if (whichchoice == 1)
                {
                    currentDialogue = phaseEightDialogue;
                    RightAnim.SetTrigger("isTalking");
                    phaseIndex = 8;
                } else if (whichchoice == 2)
                {
                    currentDialogue = phaseNineDialogue;
                    rightRenderer.sprite = Adrien;
                    RightAnim.SetTrigger("isTalking");
                    phaseIndex = 9;
                }
                choiceSetWord();
                break;
            case 8:
                currentDialogue = phaseTenDialogue;
                HUDAnim.SetTrigger("SFX");
                phaseIndex = 10;
                choiceSetWord();
                break;
            case 9:
                currentDialogue = phaseTenDialogue;
                HUDAnim.SetTrigger("SFX");
                phaseIndex = 10;
                choiceSetWord();
                break;
            case 10:
                if (whichchoice == 1)
                {
                    currentDialogue = phaseElevenDialogue;
                    HUDAnim.SetTrigger("SFX");
                    phaseIndex = 11;
                }
                else if (whichchoice == 2)
                {
                    currentDialogue = phaseTwelveDialogue;
                    RightAnim.SetTrigger("isTalking");
                    phaseIndex = 12;
                }
                whichchoice = 0;
                choiceSetWord();
                break;
            case 11:
                if (correctpath >= 8)
                {
                    SceneManager.LoadScene("Start");
                }
                else
                {
                    currentDialogue = phaseThirteenDialogue;
                    rightRenderer.sprite = Adrien;
                    RightAnim.SetTrigger("isTalking");
                    phaseIndex = 13;
                    choiceSetWord();
                }
                break;
            case 12:
                SceneManager.LoadScene("Start");
                break;
            case 13:
                SceneManager.LoadScene("Start");
                break;
            case 14:
                if (whichchoice == 1)
                {
                    currentDialogue = phaseFifteenDialogue;
                    HUDAnim.SetTrigger("SFX");
                    phaseIndex = 15;
                }
                else if (whichchoice == 2)
                {
                    currentDialogue = phaseSixteenDialogue;
                    leftRenderer.sprite = null;
                    rightRenderer.sprite = null;
                    phaseIndex = 16;
                }
                whichchoice = 0;
                choiceSetWord();
                break;
            case 15:
                currentDialogue = phaseSixteenDialogue;
                leftRenderer.sprite = null;
                rightRenderer.sprite = null;
                phaseIndex = 16;
                choiceSetWord();
                break;
            case 16:
                SceneManager.LoadScene("Start");
                break;
            case 17:
                currentDialogue = phaseEighteenDialogue;
                leftRenderer.sprite = null;
                rightRenderer.sprite = null;
                phaseIndex = 18;
                choiceSetWord();
                break;
            case 18:
                SceneManager.LoadScene("Start");
                break;
        }
        SetDialogueText();
    }
    void WhoIsTalking()
    {
        if (currentDialogue[dialogueIndex].Contains("Akira: "))
        {
            rightRenderer.sprite = Akira;
            RightAnim.SetTrigger("isTalking");
        } else if (currentDialogue[dialogueIndex].Contains("Adrien: "))
        {
            rightRenderer.sprite = Adrien;
            RightAnim.SetTrigger("isTalking");
        } else if (currentDialogue[dialogueIndex].Contains("Nicole: "))
        {
            rightRenderer.sprite = Nicole;
            RightAnim.SetTrigger("isTalking");
        } else if (currentDialogue[dialogueIndex].Contains("Ren: "))
        {
            rightRenderer.sprite = Ren;
            RightAnim.SetTrigger("isTalking");
        }

        if (currentDialogue[dialogueIndex].Contains("Allison: "))
        {
            leftRenderer.sprite = Allison;
            LeftAnim.SetTrigger("isTalking");
        } else if (currentDialogue[dialogueIndex].Contains("Ashley: "))
        {
            leftRenderer.sprite = Ashley;
            LeftAnim.SetTrigger("isTalking");
        } else if (currentDialogue[dialogueIndex].Contains("Sydney: "))
        {
            leftRenderer.sprite = Sydney;
            LeftAnim.SetTrigger("isTalking");
        } else if (currentDialogue[dialogueIndex].Contains("Jack: "))
        {
            leftRenderer.sprite = Jack;
            LeftAnim.SetTrigger("isTalking");
        } else if (currentDialogue[dialogueIndex].Contains("Earl: "))
        {
            leftRenderer.sprite = Earl;
            LeftAnim.SetTrigger("isTalking");
        }
        if (currentDialogue[dialogueIndex].Contains("Akira's phone: ") || currentDialogue[dialogueIndex].Contains("Monster: "))
        {
            HUDAnim.SetTrigger("SFX");
        }
        if (currentDialogue[dialogueIndex].Contains("Akira: GEAGH—") || currentDialogue[dialogueIndex].Contains("BANG!") || currentDialogue[dialogueIndex].Contains("Jack: AAAAAAAAAAAA"))
        {
            HUDAnim.SetTrigger("SFX");
        }
        if (currentDialogue[dialogueIndex].Contains("Monsters: ") || currentDialogue[dialogueIndex].Contains("SCRTCH "))
        {
            HUDAnim.SetTrigger("SFX");
        }
    }
}
