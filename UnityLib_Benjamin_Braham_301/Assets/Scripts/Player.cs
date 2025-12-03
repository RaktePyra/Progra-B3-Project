using PrograB3Project.Events;
using PrograB3Project.Interfaces;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public IEventManager _eventManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(IEventManager eventManager)
    {
        _eventManager = eventManager;
        _eventManager.RegisterEvent<PrograB3Project.Events.PlayerMovedEvent>(OnPlayerMove);
    }

    public void OnPlayerMove(PrograB3Project.Events.Event player_move_event)
    {
        Debug.LogError("PLAYER MOVED");
        PlayerMovedEvent moveEvent = player_move_event as PlayerMovedEvent;
        transform.position = new Vector3(moveEvent.newPlayerPositionX,transform.position.y,moveEvent.newPlayerPositionY);
    }
}
