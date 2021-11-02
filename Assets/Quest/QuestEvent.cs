using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestEvent 
{
    public enum EventStatus { WAITING, CURRENT, DONE };
    // WAITING - not yet completed, but cant be worked on cause there's a prerequisite event
    // CURRENT - the one the player should be trying to achieve
    // DONE - has been achieved

    public string name;
    public string description;
    public byte[] id;
    public EventStatus status;

    public List<QuestPath> pathList = new List<QuestPath>();

    public QuestEvent(string i_name, string i_description)
    {
        id = Guid.NewGuid().ToByteArray();
        name = i_name;
        description = i_description;
        status = EventStatus.WAITING;
    }

    public void UpdateQuestEvent(EventStatus eventStatus)
    {
        status = eventStatus;
    }

    public byte[] GetId()
    {
        return id;
    }
}
