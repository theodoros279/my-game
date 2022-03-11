using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    protected IEntity entity;

    public Command(IEntity entity)
    {
        entity = entity; 
    }

    public abstract void Execute();
}
