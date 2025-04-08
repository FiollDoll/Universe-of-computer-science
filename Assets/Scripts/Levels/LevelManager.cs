using UnityEngine;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance {get; private set;}

    [SerializeField] private Level[] allLevels = new Level[0];
    private Dictionary<string, Level> _dictAllLevels = new Dictionary<string, Level>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance == this)
            Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        foreach(Level lvl in allLevels)
            _dictAllLevels.Add(lvl.nameOfLevel, lvl);
    }
}
