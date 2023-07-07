using UnityEngine;
/// <summary>
/// Don't specifically need anything here other than the fact it's persistent.
/// I like to keep one main object which is never killed, with sub-systems as children.
/// </summary>
public class Systems : PersistentSingleton<Systems>
{
    protected override void Awake()
    {
        base.Awake();
        Application.targetFrameRate = 60;
    }
}
