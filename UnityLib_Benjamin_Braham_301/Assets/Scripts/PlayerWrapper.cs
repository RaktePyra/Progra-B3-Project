using UnityEngine;
using PrograB3Project.Events;
using System;
using PrograB3Project.Interfaces;
using System.Collections;
public class PlayerWrapper : MonoBehaviour
{   
    [SerializeField]
    private GameManagerWrapper gameManager;
    private IEventManager _eventManager;
    [SerializeField]
    private GameObject _playerPrefab;
    void Start()
    {
        StartCoroutine(Init());
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayerCreated(PrograB3Project.Events.Event event_triggered)
    {
        Debug.Log("Player Created");
        PrograB3Project.Events.PlayerCreatedEvent player_created_event = event_triggered as PrograB3Project.Events.PlayerCreatedEvent;
        GameObject player =Instantiate(_playerPrefab);
        player.GetComponent<Player>().Init(_eventManager);
        player.transform.position = new Vector3(player_created_event._position.X, 1, player_created_event._position.Y);

    }

    public IEnumerator Init()
    {
        while (_eventManager == null)
        {
            _eventManager = gameManager.GetEventManager();
            yield return null;
        }
        _eventManager.RegisterEvent<PlayerCreatedEvent>(OnPlayerCreated);
    }
}
