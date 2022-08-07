using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FLS;
using FLS.Rules;
using FLS.MembershipFunctions;

public class PredictPlayerType : MonoBehaviour
{
    // used for each result to out put the approprite level of prefrence 
    LinguisticVariable prefrenceResult;
    IMembershipFunction positiveResult;
    IMembershipFunction neutralResult;
    IMembershipFunction negativeResult;

    //_______________________Combat________________________________________________
    double playerCombatEngagment, playerCombatWins, playerCombatAvoidence;
    double combatEngagementScore;
    double combatWinScore;
    double combatAvoidanceScore;

    // for Determining the players level of Combat Engagement 
    private IFuzzyEngine feDetermineCombatEngagement;
    LinguisticVariable cEngagmentLevel;
    IMembershipFunction positiveCEngagment;
    IMembershipFunction neutralCEngagment;
    IMembershipFunction negativeCEngagment;

    // for Determining the players level of Combat wins
    private IFuzzyEngine feDetermineCombatWins;
    LinguisticVariable cWinsLevel;
    IMembershipFunction positiveCWins;
    IMembershipFunction neutralCWins;
    IMembershipFunction negativeCWins;

    // for Determining the players level of Combat avoidance 
    private IFuzzyEngine feDetermineCombatAvoidance;
    LinguisticVariable cAvoidanceLevel;
    IMembershipFunction positiveCAvoidance;
    IMembershipFunction neutralCAvoidance;
    IMembershipFunction negativeCAvoidance;

    //_______________________Card Game________________________________________________
    double playerCardGameEngagment, playerCardGameWins, playerCardGameDraws, playerCardGameAvoidence;
    double cardGameEngagementScore;
    double cardGameWinScore;
    double cardGameDrawScore;
    double cardGameAvoidanceScore;

    // for Determining the players level of Card Game Engagement
    private IFuzzyEngine feDetermineCardGameEngagement;
    LinguisticVariable caEngagmentLevel;
    IMembershipFunction positiveCAEngagment;
    IMembershipFunction neutralCAEngagment;
    IMembershipFunction negativeCAEngagment;

    // for Determining the players level of Card Game wins
    private IFuzzyEngine feDetermineCardGameWins;
    LinguisticVariable caWinsLevel;
    IMembershipFunction positiveCAWins;
    IMembershipFunction neutralCAWins;
    IMembershipFunction negativeCAWins;

    // for Determining the players level of Card Game draws
    private IFuzzyEngine feDetermineCardGameDraws;
    LinguisticVariable caDrawsLevel;
    IMembershipFunction positiveCADraws;
    IMembershipFunction negativeCADraws;

    // for Determining the players level of Card Game avoidance 
    private IFuzzyEngine feDetermineCardGameAvoidance;
    LinguisticVariable caAvoidanceLevel;
    IMembershipFunction positiveCAAvoidance;
    IMembershipFunction neutralCAAvoidance;
    IMembershipFunction negativeCAAvoidance;

    //_______________________Dialogue________________________________________________
    double playerDialogueEngagment, playerDialogueAvoidence;
    double dialogueEngagmentScore;
    double dialogueAvoidenceScore;

    // for Determining the players level of dialogue Engagement 
    private IFuzzyEngine feDetermineDialogueEngagement;
    LinguisticVariable  dEngagmentLevel;
    IMembershipFunction positiveDEngagment;
    IMembershipFunction neutralDEngagment;
    IMembershipFunction negativeDEngagment;

    // for Determining the players level of dialogue avoidance 
    private IFuzzyEngine feDetermineDialogueAvoidance;
    LinguisticVariable dAvoidanceLevel;
    IMembershipFunction positiveDAvoidance;
    IMembershipFunction neutralDAvoidance;
    IMembershipFunction negativeDAvoidance;

    public enum PlayerPreferences { Unassigned, Enthusiastic, Interested, Uninterested, FaildToIdentified };

    public PlayerPreferences playerCombatPreference = PlayerPreferences.Unassigned;
    public PlayerPreferences playerCareGamePreference = PlayerPreferences.Unassigned;
    public PlayerPreferences playerDialoguePreference = PlayerPreferences.Unassigned;

    public enum PlayerTypes{ Unassigned, 

        Completionist /* A player that wants to experiance all the games content no matter if they like it or not*/,
        SpeedRunner /* A player that wants to complete the game the fastest way possible, even if they have to miss out on content they like and do content they do not like*/,
        
        Combat_CardGame_Enthusiast /* A player who is enthusiastic about both the games combat and card game events*/,
        Combat_Dialogue_Enthusiast /* A player who is enthusiastic about both the games combat and dialogue events*/,
        CardGame_Dialogue_Enthusiast /* A player who is enthusiastic about both the games card game and dialogue events*/,

        Combat_Enthusiast_with_CardGame_Dialogue_Interest /* A player enthusiastic about combat and intrested in card game and dialogue events*/,
        CardGame_Enthusiast_with_Combat_Dialogue_Interest /* A player enthusiastic about card game and intrested in combat and dialogue events*/,
        Dialogue_Enthusiast_with_Combat_CardGame_Interest /* A player enthusiastic about dialogue and intrested in combat and card game events*/,

        Combat_Enthusiast_with_CardGame_Intrest /* A player enthusiastic about combat and intrested in card game events*/,
        Combat_Enthusiast_with_Dialogue_Intrest /* A player enthusiastic about combat and intrested in Dialogue events*/,

        CardGame_Enthusiast_with_Combat_Intrest /* A player enthusiastic about card game and intrested in combat events*/,
        CardGame_Enthusiast_with_Dialogue_Intrest /* A player enthusiastic about card game and intrested in dialogue events*/,

        Dialogue_Enthusiast_with_Combat_Intrest /* A player enthusiastic about dialogue and intrested in combat events*/,
        Dialogue_Enthusiast_with_CardGame_Intrest /* A player enthusiastic about dialogue and intrested in card game events*/,

        Combat_Enthusiast /* A player who is enthusiastic about Combat events*/,
        CardGame_Enthusiast /* A player who is enthusiastic about Card Game events*/,
        Dialogue_Enthusiast /* A player who is enthusiastic about Dialogue events*/,

        Combat_CardGame_Dialogue_Intrested,

        Combat_Intrested /* A player who is intrested in Combat events*/,
        CardGame_Intrested /* A player who is intrested in Card Game events*/,
        Dialogue_Intrested /* A player who is intrested in Dialogue events*/,

        Disinterested /* A player who did not like any aspect of the game*/,

        Unidentified /* A player who this system faild to predict a player type for*/
    };

    // the determind type of player to be used in determning content for the second half of the game
    public PlayerTypes playerType;

    bool CompletionistOrSpeedRunnerFound = false;

    public PlayerModel playerModelToAssess;

    private void Start()
    {
        InitFuzzyResults();
        // set up combats
        InitFuzzyCombatEngagement();
        InitFuzzyCombatWins();
        InitFuzzyCombatAvoidance();

        // set up card game
        InitFuzzyCardGameEngagement();
        InitFuzzyCardGameWins();
        InitFuzzyCardGameDraws();
        InitFuzzyCardGameAvoidance();

        // set up dialogues
        InitFuzzyDialogueEngagement();
        InitFuzzyDialogueAvoidance();
    }

    public void MakePrediction()
    {
        ResetPreferencesAndType();
        CalculatePlayerLikeScores();

        if(CompletionistOrSpeedRunnerFound == true)
        {
            // as Completionist and SpeedRunner player types can be detected easly without the fuzzy logic portion of the application the player 
            // type can be assigned and then returned early 
            return;
        }

        EstablishPlayerPreferences();
        PridictionPlayerType();
    }

    private void ResetPreferencesAndType()
    {
        CompletionistOrSpeedRunnerFound = false;
        playerCombatPreference = PlayerPreferences.Unassigned;
        playerCareGamePreference = PlayerPreferences.Unassigned;
        playerDialoguePreference = PlayerPreferences.Unassigned;

        playerType = PlayerTypes.Unassigned;
    }

    void CalculatePlayerLikeScores()
    {

        // setting combat stats
        playerCombatEngagment = playerModelToAssess.combatsEngagedIn;
        playerCombatWins = playerModelToAssess.combatWins;
        playerCombatAvoidence = playerModelToAssess.combatsAvoided;

        // setting card gamestats
        playerCardGameEngagment = playerModelToAssess.cardGamesEngagedIn;
        playerCardGameWins = playerModelToAssess.cardGameWins;
        playerCardGameDraws = playerModelToAssess.cardGameDraws;
        playerCardGameAvoidence = playerModelToAssess.cardGamesAvoided;

        // setting dialogue stats
        playerDialogueEngagment = playerModelToAssess.dialogueEngagedIn;
        playerDialogueAvoidence = playerModelToAssess.dialogueAvoided;

        // check for Completionists
        if (playerCombatEngagment == 2.0 && playerCardGameEngagment == 2.0 && playerDialogueEngagment == 2.0)
        {
            playerType = PlayerTypes.Completionist;
            CompletionistOrSpeedRunnerFound = true;
        }
        else if(playerCombatEngagment == 0.0 && playerCombatAvoidence == 0.0 && playerCombatEngagment == 0.0 && playerCardGameEngagment == 2.0 && playerDialogueEngagment == 1.0)
        {
            playerType = PlayerTypes.SpeedRunner;
            CompletionistOrSpeedRunnerFound = true;
        }
    }

    void EstablishPlayerPreferences()
    {
        // combat
        combatEngagementScore = feDetermineCombatEngagement.Defuzzify(new { cEngagmentLevel = playerCombatEngagment });
        combatWinScore = feDetermineCombatWins.Defuzzify(new { cWinsLevel = playerCombatWins });
        combatAvoidanceScore = feDetermineCombatAvoidance.Defuzzify(new { cAvoidanceLevel = playerCombatAvoidence });

        //Debug.Log("Combat Engagment Score " + ((int)combatEngagementScore) + " Combat win Score " + ((int)combatWinScore) + " Combat avoidance Score " + ((int)combatAvoidanceScore));

        // card Game
        cardGameEngagementScore = feDetermineCardGameEngagement.Defuzzify(new { caEngagmentLevel = playerCardGameEngagment });
        cardGameWinScore = feDetermineCardGameWins.Defuzzify(new { caWinsLevel = playerCardGameWins });
        cardGameDrawScore = feDetermineCardGameDraws.Defuzzify(new { caDrawsLevel = playerCardGameDraws });
        cardGameAvoidanceScore = feDetermineCardGameAvoidance.Defuzzify(new { caAvoidanceLevel = playerCardGameAvoidence });

       // Debug.Log("Card Game Engagment Score " + ((int)cardGameEngagementScore) + " Card Game win Score " + ((int)cardGameWinScore) + " Card Game draw Score " + ((int)cardGameDrawScore) + " Card Game avoidance Score " + ((int)cardGameAvoidanceScore));

        // dialogue
        dialogueEngagmentScore = feDetermineDialogueEngagement.Defuzzify(new { dEngagmentLevel = playerDialogueEngagment });
        dialogueAvoidenceScore = feDetermineDialogueAvoidance.Defuzzify(new { dAvoidanceLevel = playerDialogueAvoidence });

        // Debug.Log("Dialogue Engagment Score " + ((int)dialogueEngagmentScore) + " Dialogue avoidance Score " + ((int)dialogueAvoidenceScore));

        // combat
        if (((int)combatEngagementScore) == 1 && ((int)combatWinScore) <= 3 && ((int)combatAvoidanceScore) <= 2)
        {
            //Debug.Log("Combat Enthusiast");
            playerCombatPreference = PlayerPreferences.Enthusiastic;
        }
        else if (((int)combatEngagementScore) <= 2 && ((int)combatWinScore) <= 3 && ((int)combatAvoidanceScore) <= 2)
        {
            // Debug.Log("Combat Intrested");
            playerCombatPreference = PlayerPreferences.Interested;
        }
        else if (((int)combatEngagementScore) >= 0 && ((int)combatWinScore) >= 0 && ((int)combatAvoidanceScore) >= 2)
        {
            // Debug.Log("Combat Unintrested");
            playerCombatPreference = PlayerPreferences.Uninterested;
        }
        else if (((int)combatEngagementScore) == 3)
        {
            //Debug.Log("Combat Unintrested 2");
            playerCombatPreference = PlayerPreferences.Uninterested;
        }
        else
        {
            // Debug.Log("Faild to identify");
            playerCombatPreference = PlayerPreferences.FaildToIdentified;
        }
        // card game
        if (((int)cardGameEngagementScore) == 1 && ((int)cardGameWinScore) <= 3 && ((int)cardGameDrawScore) == 1 && ((int)cardGameAvoidanceScore) <= 2)
        {
            //Debug.Log("Card Game Enthusiast");
            playerCareGamePreference = PlayerPreferences.Enthusiastic;
        }
        else if (((int)cardGameEngagementScore) <= 2 && ((int)cardGameWinScore) <= 3 && ((int)cardGameDrawScore) <= 3 && ((int)cardGameAvoidanceScore) <= 2)
        {
            // Debug.Log("Card Game Intrested");
            playerCareGamePreference = PlayerPreferences.Interested;
        }
        else if (((int)cardGameEngagementScore) >= 2 && ((int)cardGameWinScore) >= 2 && ((int)cardGameDrawScore) >= 1 && ((int)cardGameAvoidanceScore) >= 2)
        {
            // Debug.Log("Card Game Unintrested");
            playerCareGamePreference = PlayerPreferences.Uninterested;
        }
        else if (((int)cardGameEngagementScore) == 3)
        {
            // Debug.Log("Card Game Unintrested 2");
            playerCareGamePreference = PlayerPreferences.Uninterested;
        }
        else
        {
            // Debug.Log("Faild to identify");
            playerCareGamePreference = PlayerPreferences.FaildToIdentified;
        }
        // dialogue
        if (((int)dialogueEngagmentScore) == 1 && ((int)dialogueAvoidenceScore) <= 2)
        {
            // Debug.Log("Dialogue Enthusiast");
            playerDialoguePreference = PlayerPreferences.Enthusiastic;
        }
        else if (((int)dialogueEngagmentScore) <= 2 && ((int)dialogueAvoidenceScore) <= 2)
        {
            //Debug.Log("Dialogue Intrested");
            playerDialoguePreference = PlayerPreferences.Interested;
        }
        else if (((int)dialogueEngagmentScore) <= 3 && ((int)dialogueAvoidenceScore) >= 0)
        {
            //Debug.Log("Dialogue Unintrested");
            playerDialoguePreference = PlayerPreferences.Uninterested;
        }
        else if (((int)dialogueEngagmentScore) == 3)
        {
            //Debug.Log("Dialogue Unintrested");
            playerDialoguePreference = PlayerPreferences.Uninterested;
        }
        else
        {
            // Debug.Log("Faild to identify");
            playerDialoguePreference = PlayerPreferences.FaildToIdentified;
        }
    }


    void PridictionPlayerType()
    {
        // Completionist = playerCombatPreference is Enthusiastic, playerCareGamePreference Enthusiastic, is playerDialoguePreference is Enthusiastic
        if (playerCombatPreference == PlayerPreferences.Enthusiastic && playerCareGamePreference == PlayerPreferences.Enthusiastic && playerDialoguePreference == PlayerPreferences.Enthusiastic)
        {
            playerType = PlayerTypes.Completionist;
        }

        // Combat_CardGame_Enthusiast = playerCombatPreference is Enthusiastic, playerCareGamePreference Enthusiastic
        if (playerCombatPreference == PlayerPreferences.Enthusiastic && playerCareGamePreference == PlayerPreferences.Enthusiastic)
        {
            playerType = PlayerTypes.Combat_CardGame_Enthusiast;
        }
        // Combat_Dialogue_Enthusiast = playerCombatPreference is Enthusiastic, is playerDialoguePreference is Enthusiastic
        else if (playerCombatPreference == PlayerPreferences.Enthusiastic && playerDialoguePreference == PlayerPreferences.Enthusiastic)
        {
            playerType = PlayerTypes.Combat_Dialogue_Enthusiast;
        }
        // CardGame_Dialogue_Enthusiast = playerCareGamePreference Enthusiastic, is playerDialoguePreference is Enthusiastic
        else if (playerCareGamePreference == PlayerPreferences.Enthusiastic &&  playerDialoguePreference == PlayerPreferences.Enthusiastic)
        {
            playerType = PlayerTypes.CardGame_Dialogue_Enthusiast; 
        }
        // Combat_Enthusiast_with_CardGame_Dialogue_Intrest = playerCombatPreference is Enthusiastic, playerCareGamePreference Interested
        else if (playerCombatPreference == PlayerPreferences.Enthusiastic && playerCareGamePreference == PlayerPreferences.Interested && playerDialoguePreference == PlayerPreferences.Interested)
        {
            playerType = PlayerTypes.Combat_Enthusiast_with_CardGame_Dialogue_Interest;
        }
        // CardGame_Enthusiast_with_Combat_Dialogue_Intrest = playerCombatPreference is Enthusiastic, playerCareGamePreference Interested, is playerDialoguePreference is Uninterested
        else if (playerCareGamePreference == PlayerPreferences.Enthusiastic && playerCombatPreference == PlayerPreferences.Interested && playerDialoguePreference == PlayerPreferences.Interested)
        {
            playerType = PlayerTypes.CardGame_Enthusiast_with_Combat_Dialogue_Interest;
        }        
        // Dialogue_Enthusiast_with_Combat_CardGame_Intrest = playerCombatPreference is Enthusiastic, playerCareGamePreference Interested, is playerDialoguePreference is Uninterested
        else if (playerDialoguePreference == PlayerPreferences.Enthusiastic && playerCareGamePreference == PlayerPreferences.Interested && playerCombatPreference == PlayerPreferences.Interested)
        {
            playerType = PlayerTypes.Dialogue_Enthusiast_with_Combat_CardGame_Interest;
        }
        
        // Combat_Enthusiast_with_CardGame_Intrest = playerCombatPreference is Enthusiastic, playerCareGamePreference Interested, is playerDialoguePreference is Uninterested
        else if (playerCombatPreference == PlayerPreferences.Enthusiastic && playerCareGamePreference == PlayerPreferences.Interested)
        {
            playerType = PlayerTypes.Combat_Enthusiast_with_CardGame_Intrest;
        }
        //Combat_Enthusiast_with_Dialogue_Intrest = playerCombatPreference is Enthusiastic, playerCareGamePreference Interested, is playerDialoguePreference is Uninterested
        else if (playerCombatPreference == PlayerPreferences.Enthusiastic && playerDialoguePreference == PlayerPreferences.Interested)
        {
            playerType = PlayerTypes.Combat_Enthusiast_with_Dialogue_Intrest;
        }
        // CardGame_Enthusiast_with_Combat_Intrest = playerCombatPreference is Enthusiastic, playerCareGamePreference Interested, is playerDialoguePreference is Uninterested
        else if (playerCareGamePreference == PlayerPreferences.Enthusiastic && playerCombatPreference == PlayerPreferences.Interested)
        {
            playerType = PlayerTypes.CardGame_Enthusiast_with_Combat_Intrest;
        } 
        // CardGame_Enthusiast_with_dialogue_Intrest = playerCombatPreference is Enthusiastic, playerCareGamePreference Interested, is playerDialoguePreference is Uninterested
        else if (playerCareGamePreference == PlayerPreferences.Enthusiastic && playerDialoguePreference == PlayerPreferences.Interested)
        {
            playerType = PlayerTypes.CardGame_Enthusiast_with_Dialogue_Intrest;
        }
        // Dialogue_Enthusiast_with_Combat_Intrest = playerCombatPreference is Enthusiastic, playerCareGamePreference Interested, is playerDialoguePreference is Uninterested
        else if (playerDialoguePreference == PlayerPreferences.Enthusiastic && playerCombatPreference == PlayerPreferences.Interested)
        {
            playerType = PlayerTypes.Dialogue_Enthusiast_with_Combat_Intrest;
        }
        // Dialogue_Enthusiast_with_CardGame_Intrest = playerCombatPreference is Enthusiastic, playerCareGamePreference Interested, is playerDialoguePreference is Uninterested
        else if (playerDialoguePreference == PlayerPreferences.Enthusiastic && playerCareGamePreference == PlayerPreferences.Interested)
        {
            playerType = PlayerTypes.Dialogue_Enthusiast_with_CardGame_Intrest;
        }
        // Combat_Enthusiast = playerCombatPreference is Enthusiastic
        else if (playerCombatPreference == PlayerPreferences.Enthusiastic)
        {
            playerType = PlayerTypes.Combat_Enthusiast;
        }
        // CardGame_Enthusiast = playerCareGamePreference is Enthusiastic
        else if (playerCareGamePreference == PlayerPreferences.Enthusiastic)
        {
            playerType = PlayerTypes.CardGame_Enthusiast;
        }
        // Dialogue_Enthusiast = playerDialoguePreference is Enthusiastic
        else if (playerDialoguePreference == PlayerPreferences.Enthusiastic )
        {
            playerType = PlayerTypes.Dialogue_Enthusiast;
        }
        // Combat_Intrested = playerCombatPreference is Interested, playerCareGamePreference is Interested, playerDialoguePreference is Interested
        else if (playerCombatPreference == PlayerPreferences.Interested && playerCareGamePreference == PlayerPreferences.Interested && playerDialoguePreference == PlayerPreferences.Interested)
        {
            playerType = PlayerTypes.Combat_CardGame_Dialogue_Intrested;
        }
        // Combat_Intrested = playerCombatPreference is Interested
        else if (playerCombatPreference  == PlayerPreferences.Interested)
        {
            playerType = PlayerTypes.Combat_Intrested;
        }
        // CardGame_Intrested = playerCareGamePreference Interested
        else if (playerCareGamePreference == PlayerPreferences.Interested)
        {
            playerType = PlayerTypes.CardGame_Intrested;
        }
        // Dialogue_Intrested = playerDialoguePreference is Interested
        else if (playerDialoguePreference == PlayerPreferences.Interested)
        {
            playerType = PlayerTypes.Dialogue_Intrested;
        }
        // unimpressed = playerCombatPreference is Uninterested, playerCareGamePreference Uninterested, is playerDialoguePreference is Uninterested
        else if (playerCombatPreference == PlayerPreferences.Uninterested && playerCareGamePreference == PlayerPreferences.Uninterested && playerDialoguePreference == PlayerPreferences.Uninterested)
        {
            playerType = PlayerTypes.Disinterested;
        }
        else
        {
           // if all fails then the player type is marked as Unidentified
           playerType = PlayerTypes.Unidentified;
        }     
    }

    void InitFuzzyResults()
    {
        // level of preference used in Defuzzify outputs to indicate the level of player prefrence determined in each case
        prefrenceResult = new LinguisticVariable("prefrenceResult");
        positiveResult = prefrenceResult.MembershipFunctions.AddRectangle("dPositiveResult", 0, 2);
        neutralResult = prefrenceResult.MembershipFunctions.AddRectangle("dNeutralResult", 1, 3);
        negativeResult = prefrenceResult.MembershipFunctions.AddRectangle("dNegativeResult", 2, 4);
    }

    // fuzzy combat set up
    void InitFuzzyCombatEngagement()
    {
        // fuzzy logic Preference
        feDetermineCombatEngagement = new FuzzyEngineFactory().Default();

        // for checking the players level of prefrence for event types 
        cEngagmentLevel = new LinguisticVariable("cEngagmentLevel");
        positiveCEngagment = cEngagmentLevel.MembershipFunctions.AddRectangle("dPositive", 2, 2);
        neutralCEngagment = cEngagmentLevel.MembershipFunctions.AddRectangle("dNeutral", 1, 1);
        negativeCEngagment = cEngagmentLevel.MembershipFunctions.AddRectangle("dNegative", 0, 0);

        // add rules to system
        var rulePositive = Rule.If(cEngagmentLevel.Is(positiveCEngagment)).Then(prefrenceResult.Is(positiveResult));
        var ruleNeutral = Rule.If(cEngagmentLevel.Is(neutralCEngagment)).Then(prefrenceResult.Is(neutralResult));
        var ruleNegative = Rule.If(cEngagmentLevel.Is(negativeCEngagment)).Then(prefrenceResult.Is(negativeResult));
        feDetermineCombatEngagement.Rules.Add(rulePositive, ruleNeutral, ruleNegative);
    }

    void InitFuzzyCombatWins()
    {
        // fuzzy logic Preference
        feDetermineCombatWins = new FuzzyEngineFactory().Default();

        // for checking the players level of prefrence for event types 
        cWinsLevel = new LinguisticVariable("cWinsLevel");
        positiveCWins = cWinsLevel.MembershipFunctions.AddRectangle("dPositive", 2, 2);
        neutralCWins = cWinsLevel.MembershipFunctions.AddRectangle("dNeutral ", 1, 1);
        negativeCWins = cWinsLevel.MembershipFunctions.AddRectangle("dNegative", 0, 0);

        //// add rules to system
        var rulePositive = Rule.If(cWinsLevel.Is(positiveCWins)).Then(prefrenceResult.Is(positiveResult));
        var ruleNeutral = Rule.If(cWinsLevel.Is(neutralCWins)).Then(prefrenceResult.Is(neutralResult));
        var ruleNegative = Rule.If(cWinsLevel.Is(negativeCWins)).Then(prefrenceResult.Is(negativeResult));
        feDetermineCombatWins.Rules.Add(rulePositive, ruleNeutral, ruleNegative);
    }

    void InitFuzzyCombatAvoidance()
    {
        // fuzzy logic Preference
        feDetermineCombatAvoidance = new FuzzyEngineFactory().Default();

        // for checking the players level of prefrence for event types 
        cAvoidanceLevel = new LinguisticVariable("cAvoidanceLevel");
        positiveCAvoidance = cAvoidanceLevel.MembershipFunctions.AddRectangle("dPositive", 0, 0);
        neutralCAvoidance = cAvoidanceLevel.MembershipFunctions.AddRectangle("dNeutral", 1, 2);
        negativeCAvoidance = cAvoidanceLevel.MembershipFunctions.AddRectangle("dNegative", 3, 6);

        //// add rules to system
        var rulePositive = Rule.If(cAvoidanceLevel.Is(positiveCAvoidance)).Then(prefrenceResult.Is(positiveResult));
        var ruleNeutral = Rule.If(cAvoidanceLevel.Is(neutralCAvoidance)).Then(prefrenceResult.Is(neutralResult));
        var ruleNegative = Rule.If(cAvoidanceLevel.Is(negativeCAvoidance)).Then(prefrenceResult.Is(negativeResult));
        feDetermineCombatAvoidance.Rules.Add(rulePositive, ruleNeutral, ruleNegative);
    }

    void InitFuzzyCardGameEngagement()
    {
        // fuzzy logic Preference
        feDetermineCardGameEngagement = new FuzzyEngineFactory().Default();

        // for checking the players level of prefrence for event types 
        caEngagmentLevel = new LinguisticVariable("caEngagmentLevel");
        positiveCAEngagment = caEngagmentLevel.MembershipFunctions.AddRectangle("dPositive", 2, 2);
        neutralCAEngagment = caEngagmentLevel.MembershipFunctions.AddRectangle("dNeutral", 1, 1);
        negativeCAEngagment = caEngagmentLevel.MembershipFunctions.AddRectangle("dNegative", 0, 0);

        // add rules to system
        var rulePositive = Rule.If(caEngagmentLevel.Is(positiveCAEngagment)).Then(prefrenceResult.Is(positiveResult));
        var ruleNeutral = Rule.If(caEngagmentLevel.Is(neutralCAEngagment)).Then(prefrenceResult.Is(neutralResult));
        var ruleNegative = Rule.If(caEngagmentLevel.Is(negativeCAEngagment)).Then(prefrenceResult.Is(negativeResult));
        feDetermineCardGameEngagement.Rules.Add(rulePositive, ruleNeutral, ruleNegative);
    }

    void InitFuzzyCardGameWins()
    {
        // fuzzy logic Preference
        feDetermineCardGameWins = new FuzzyEngineFactory().Default();

        // for checking the players level of prefrence for event types 
        caWinsLevel = new LinguisticVariable("caWinsLevel");
        positiveCAWins = caWinsLevel.MembershipFunctions.AddRectangle("dPositive", 2, 2);
        neutralCAWins = caWinsLevel.MembershipFunctions.AddRectangle("dNeutral ", 1, 1);
        negativeCAWins = caWinsLevel.MembershipFunctions.AddRectangle("dNegative", 0, 0);

        //// add rules to system
        var rulePositive = Rule.If(caWinsLevel.Is(positiveCAWins)).Then(prefrenceResult.Is(positiveResult));
        var ruleNeutral = Rule.If(caWinsLevel.Is(neutralCAWins)).Then(prefrenceResult.Is(neutralResult));
        var ruleNegative = Rule.If(caWinsLevel.Is(negativeCAWins)).Then(prefrenceResult.Is(negativeResult));
        feDetermineCardGameWins.Rules.Add(rulePositive, ruleNeutral, ruleNegative);
    }

    void InitFuzzyCardGameDraws()
    {
        // fuzzy logic Preference
        feDetermineCardGameDraws = new FuzzyEngineFactory().Default();

        // for checking the players level of prefrence for event types 
        caDrawsLevel = new LinguisticVariable("caDrawsLevel");
        positiveCADraws = caDrawsLevel.MembershipFunctions.AddRectangle("dPositive", 0, 1);
        negativeCADraws = caDrawsLevel.MembershipFunctions.AddRectangle("dNegative", 2, 2);

        //// add rules to system
        var rulePositive = Rule.If(caDrawsLevel.Is(positiveCADraws)).Then(prefrenceResult.Is(positiveResult)); 
        var ruleNegative = Rule.If(caDrawsLevel.Is(negativeCADraws)).Then(prefrenceResult.Is(negativeResult));
        feDetermineCardGameDraws.Rules.Add(rulePositive, ruleNegative);
    }

    void InitFuzzyCardGameAvoidance() {
        // fuzzy logic Preference
        feDetermineCardGameAvoidance = new FuzzyEngineFactory().Default();

        // for checking the players level of prefrence for event types 
        caAvoidanceLevel = new LinguisticVariable("caAvoidanceLevel");
        positiveCAAvoidance = caAvoidanceLevel.MembershipFunctions.AddRectangle("dPositive", 0, 1);
        neutralCAAvoidance = caAvoidanceLevel.MembershipFunctions.AddRectangle("dNeutral", 2, 3);
        negativeCAAvoidance = caAvoidanceLevel.MembershipFunctions.AddRectangle("dNegative", 4, 6);

        //// add rules to system
        var rulePositive = Rule.If(caAvoidanceLevel.Is(positiveCAAvoidance)).Then(prefrenceResult.Is(positiveResult));
        var ruleNeutral = Rule.If(caAvoidanceLevel.Is(neutralCAAvoidance)).Then(prefrenceResult.Is(neutralResult));
        var ruleNegative = Rule.If(caAvoidanceLevel.Is(negativeCAAvoidance)).Then(prefrenceResult.Is(negativeResult));
        feDetermineCardGameAvoidance.Rules.Add(rulePositive, ruleNeutral, ruleNegative);
    }

    //__________________________ fuzzy dialogue set up___________________________________
    void InitFuzzyDialogueEngagement()
    {
        // fuzzy logic Preference
        feDetermineDialogueEngagement = new FuzzyEngineFactory().Default();

        // for checking the players level of prefrence for event types 
        dEngagmentLevel = new LinguisticVariable("dEngagmentLevel");
        positiveDEngagment = dEngagmentLevel.MembershipFunctions.AddRectangle("dPositive", 2, 2);
        neutralDEngagment = dEngagmentLevel.MembershipFunctions.AddRectangle("dNeutral", 1, 1);
        negativeDEngagment = dEngagmentLevel.MembershipFunctions.AddRectangle("dNegative", 0, 0);

        //// add rules to system
        var rulePositive = Rule.If(dEngagmentLevel.Is(positiveDEngagment)).Then(prefrenceResult.Is(positiveResult));
        var ruleNeutral = Rule.If(dEngagmentLevel.Is(neutralDEngagment)).Then(prefrenceResult.Is(neutralResult));
        var ruleNegative = Rule.If(dEngagmentLevel.Is(negativeDEngagment)).Then(prefrenceResult.Is(negativeResult));
        feDetermineDialogueEngagement.Rules.Add(rulePositive, ruleNeutral, ruleNegative);
    }

    void InitFuzzyDialogueAvoidance()
    {
        // fuzzy logic Preference
        feDetermineDialogueAvoidance = new FuzzyEngineFactory().Default();

        // for checking the players level of prefrence for event types 
        dAvoidanceLevel = new LinguisticVariable("dAvoidanceLevel");
        positiveDAvoidance = dAvoidanceLevel.MembershipFunctions.AddRectangle("dPositive", 0, 0);
        neutralDAvoidance = dAvoidanceLevel.MembershipFunctions.AddRectangle("dNeutral", 1, 2);
        negativeDAvoidance = dAvoidanceLevel.MembershipFunctions.AddRectangle("dNegative", 3, 6);

        //// add rules to system
        var rulePositive = Rule.If(dAvoidanceLevel.Is(positiveDAvoidance)).Then(prefrenceResult.Is(positiveResult));
        var ruleNeutral = Rule.If(dAvoidanceLevel.Is(neutralDAvoidance)).Then(prefrenceResult.Is(neutralResult));
        var ruleNegative = Rule.If(dAvoidanceLevel.Is(negativeDAvoidance)).Then(prefrenceResult.Is(negativeResult));
        feDetermineDialogueAvoidance.Rules.Add(rulePositive, ruleNeutral, ruleNegative);
    }
}
