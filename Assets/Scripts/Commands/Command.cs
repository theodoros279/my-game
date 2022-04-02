using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command
{
    protected IEntity entity;

    public Command(IEntity entity)
    {
        this.entity = entity;  
    }

    public virtual void Execute(){}  
}
