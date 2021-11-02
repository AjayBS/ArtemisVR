using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public List<QuestEvent> questEvents = new List<QuestEvent>();
    List<QuestEvent> pathList = new List<QuestEvent>();

    public Quest() { }

    public QuestEvent AddQuestEvent(string i_name, string i_description)
    {
        QuestEvent questEvent = new QuestEvent(i_name, i_description);
        questEvents.Add(questEvent);
        return questEvent;
    }

    public void AddPath(byte[] fromQuestEvent, byte[] toQuestEvent)
    {
        QuestEvent from = FindQuestEvent(fromQuestEvent);
        QuestEvent to = FindQuestEvent(toQuestEvent);

        if(from != null && to != null)
        {
            QuestPath p = new QuestPath(from, to);
            from.pathList.Add(p);
        }
    }

    QuestEvent FindQuestEvent(byte[] id)
    {
        foreach(QuestEvent n in questEvents)
        {
            if(n.GetId() == id)
            {
                return n;
            }
        }

        return null;
    }

    public void BFS(byte[] id, int orderNumber = 1)
    {
        QuestEvent thisEvent = FindQuestEvent(id);
        thisEvent.order = orderNumber;

        foreach(QuestPath path in thisEvent.pathList)
        {
            if (path.endEvent.order == -1)
                BFS(path.endEvent.GetId(), orderNumber + 1);
        }
    }

    public void PrintPath()
    {
        foreach(QuestEvent n in questEvents)
        {
            Debug.Log(n.name + " " + n.order);
        }
    }
}
