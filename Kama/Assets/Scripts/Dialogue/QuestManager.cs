using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public int goblinsKilled = 0;

    GameObject Arthur;
    GameObject Lea;
    PlayerComponent player;
    Text questText;
    bool dungeonDoorOpen = false;
    int activeQuest;
    string[] quests = new string[]
    {
        "Trouver le village",
        "Parler à Arthur",
        "Tuer 5 goblins",
        "Aller voir Léa",
        "Trouver le donjon",
        "Vaincre Kragz!"
    };
    public GameObject entrance;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerComponent>();
        questText = GameObject.Find("QuestText").GetComponent<Text>();
        Arthur = GameObject.Find("NPC Arthur");
        Lea = GameObject.Find("NPC Léa");
        entrance = GameObject.Find("Entrance");
        if (player.GetActiveQuest() > 1)
            SetActiveQuest(player.GetActiveQuest());
        else
            SetActiveQuest(1);
        UpdateDungeonDoor();
    }

    private void UpdateDungeonDoor()
    {
        if (dungeonDoorOpen)
        {
            entrance.GetComponent<DoorOpen>().enabled = true;
            entrance.GetComponentInChildren<Canvas>().enabled = true;
        }
        else
        {
            entrance.GetComponent<DoorOpen>().enabled = false;
            entrance.GetComponentInChildren<Canvas>().enabled = false;
        }
    }

    public int GetActiveQuest()
    {
        return activeQuest;
    }

    public void SetActiveQuest(int id)
    {
        if (id == 1) // Si la quete active est "Trouver le village"
        {
            activeQuest = id;
            questText.text = quests[id - 1];
            dungeonDoorOpen = false;
        }
        else if (id == 2) // Si la quete active est "Parler a Arthur"
        {
            activeQuest = id;
            questText.text = quests[id - 1];
            dungeonDoorOpen = false;

            Arthur.GetComponent<DialogueTrigger>().dialogue.sentences = new string[4];
            Arthur.GetComponent<DialogueTrigger>().dialogue.sentences[0] = "Bonjour! Je m'appelle Arthur.";
            Arthur.GetComponent<DialogueTrigger>().dialogue.sentences[1] = "Les goblins ont commencé à menacer les villageois la nuit!";
            Arthur.GetComponent<DialogueTrigger>().dialogue.sentences[2] = "Pourrais-tu nous aider à en éliminer quelques uns?";
            Arthur.GetComponent<DialogueTrigger>().dialogue.sentences[3] = "Vas voir Léa quand ce sera fait.";

            Lea.GetComponent<DialogueTrigger>().dialogue.sentences = new string[1];
            Lea.GetComponent<DialogueTrigger>().dialogue.sentences[0] = "Termine la quête d'Arthur avant de venir me voir.";
        }
        else if (id == 3) // Si la quete active est "Tuer 5 goblins" 
        {
            activeQuest = id;
            questText.text = quests[id - 1];
            dungeonDoorOpen = false;

            Arthur.GetComponent<DialogueTrigger>().dialogue.sentences = new string[1];
            Arthur.GetComponent<DialogueTrigger>().dialogue.sentences[0] = "Complète ma quête ou va voir Léa si c'est déjà fait.";
        }
        else if (id == 4) // Si la quete active est "Aller voir Lea"
        {
            activeQuest = id;
            questText.text = quests[id - 1];
            dungeonDoorOpen = false;

            Arthur.GetComponent<DialogueTrigger>().dialogue.sentences = new string[1];
            Arthur.GetComponent<DialogueTrigger>().dialogue.sentences[0] = "Complète ma quête ou va voir Léa si c'est déjà fait.";

            Lea.GetComponent<DialogueTrigger>().dialogue.sentences = new string[4];
            Lea.GetComponent<DialogueTrigger>().dialogue.sentences[0] = "Bravo! Tu as réussi à éliminer assez de goblins!";
            Lea.GetComponent<DialogueTrigger>().dialogue.sentences[1] = "Cependant, il te reste une terrible épreuve à traverser.";
            Lea.GetComponent<DialogueTrigger>().dialogue.sentences[2] = "Tu dois entrer dans le sombre donjon et vaincre Kragz,\n le chef des goblins.";
            Lea.GetComponent<DialogueTrigger>().dialogue.sentences[3] = "Voici la clé, tu en auras besoin pour ouvrir la porte.\n Bonne chance!";
        }
        else if (id == 5) // Si la quete active est "Trouver le donjon" 
        {
            activeQuest = id;
            questText.text = quests[id - 1];
            dungeonDoorOpen = true;

            Arthur.GetComponent<DialogueTrigger>().dialogue.sentences = new string[1];
            Arthur.GetComponent<DialogueTrigger>().dialogue.sentences[0] = "Merci pour ton aide. Bonne chance au donjon.";

            Lea.GetComponent<DialogueTrigger>().dialogue.sentences = new string[1];
            Lea.GetComponent<DialogueTrigger>().dialogue.sentences[0] = "Tu dois aller vaincre Kragz au donjon!";

            UpdateDungeonDoor();
        }
        else if (id == 6) // Si la quete active est "Vaincre Kragz"
        {
            activeQuest = id;
            questText.text = quests[id - 1];
            dungeonDoorOpen = true;

            Arthur.GetComponent<DialogueTrigger>().dialogue.sentences = new string[1];
            Arthur.GetComponent<DialogueTrigger>().dialogue.sentences[0] = "Merci pour ton aide. Bonne chance au donjon.";

            Lea.GetComponent<DialogueTrigger>().dialogue.sentences = new string[1];
            Lea.GetComponent<DialogueTrigger>().dialogue.sentences[0] = "Tu dois aller vaincre Kragz au donjon!";
        }
    }
}
