using UnityEngine;
using PrograB3Project;
using PrograB3Project.Interfaces;
using System;
using System.IO;
using PrograB3Project.Events;
using System.Collections;
using Unity.VisualScripting;

public class GameManagerWrapper : MonoBehaviour
{
    private GameEngine _engine;
    [SerializeField] private Canvas _MainMenuCanvas;
    [SerializeField]
    private IEventManager _eventManager;
    private KeyCode[] inputTable = {
        KeyCode.W,
        // W + 3 = KeyCode.Z
        KeyCode.A,
        // A + 16 = KeyCode.Q,
        KeyCode.D,
        KeyCode.S,
    };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        _engine = new GameEngine();
        _eventManager = _engine.GetEventManager();
        _eventManager.RegisterEvent<PrograB3Project.Events.InitializeGameEvent>(OnGameInitialized);
        StartCoroutine(DelayGameRun());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            foreach (var key in inputTable)
            {
                KeyCode trueCode = key;
                switch(key)
                {
                    case KeyCode.W:
                        {
                            trueCode = KeyCode.Z;
                            break;
                        }
                        case KeyCode.A:
                        {
                            trueCode = KeyCode.Q;
                            break;
                        }
                }
                if (Input.GetKey(key))
                {
                    InputEvent iEvent = new InputEvent(new ConsoleKeyInfo(trueCode.ToString()[0],(ConsoleKey)(trueCode - 32), false, false, false));
                    Debug.Log(trueCode.ToString());
                    Debug.Log(iEvent.GetKeyInfo().Key);
                    _eventManager.TriggerEvent(iEvent);
                }
            }
        }
        _engine.Update(Time.deltaTime);
    }

    private void FixedUpdate()
    {
        _engine.FixedUpdate(Time.fixedDeltaTime);
    }

    public void StartGame()
    {
        ConsoleKeyInfo key = new ConsoleKeyInfo('1',ConsoleKey.NumPad1,false,false,false);
        _engine.ProcessInput(key);
        _MainMenuCanvas.gameObject.SetActive(false);
    }

    private void OnGameInitialized(PrograB3Project.Events.Event game_event)
    {
        PrograB3Project.Events.InitializeGameEvent true_event = game_event as PrograB3Project.Events.InitializeGameEvent;
        true_event.filePaths.dataFilesFolderRelativePath = Application.dataPath + "/Data/";
    }

    private IEnumerator DelayGameRun()
    {
        yield return null;
       _engine.Run();
    }

    public IEventManager GetEventManager()
    {
        return _eventManager;
    }
}
