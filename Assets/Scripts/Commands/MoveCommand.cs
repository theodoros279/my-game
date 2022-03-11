using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{
    private Vector3 _direction;
    private float _distance;

    public MoveCommand(IEntity entity, Vector3 direction, float distance): base (entity)
    {
        _direction = direction;
        _distance = distance;
    }

    public override void Execute()
    {
        entity.transform.Translate(_distance * _direction);  
    }
    
}
