using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// One repository for all scriptable objects. Create your query methods here to keep your business logic clean.
/// I make this a MonoBehaviour as sometimes I add some debug/development references in the editor.
/// If you don't feel free to make this a standard class
/// </summary>
public class ResourceSystem : PersistentSingleton<ResourceSystem> {
    // public List<ScriptableHero>  Heroes { get; private set; }
    // private Dictionary<HeroType, ScriptableHero> HerosDict;

    protected override void Awake() {
        base.Awake();
        AssembleResources();
        Application.targetFrameRate = 60;
    }

    private void AssembleResources() {
        // Heroes = Resources.LoadAll<ScriptableHero>("Heroes").ToList();
        // Heroes.Sort((h1,h2) => ((int)h1.heroType).CompareTo(((int)h2.heroType)));
        // HerosDict = Heroes.ToDictionary(r => r.heroType, r => r);
    }
}   