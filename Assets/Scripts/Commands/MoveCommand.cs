using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{
    private Vector3 _direction;
    private float _speed;
    IEntity entity;  

    public MoveCommand(IEntity entity, Vector3 direction, float speed): base (entity)
    {
        this.entity = entity;  
        _direction = direction;
        _speed = speed; 
    }

    public override void Execute() 
    {
        this.entity.transform.position += _direction * Time.deltaTime * _speed;  
    }
}

