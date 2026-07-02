using Dalamud.Configuration;
using System;

namespace Shrinkage;

[Serializable]
public class Configuration : IPluginConfiguration
{
    public int Version { get; set; } = 0;
    
    // if true will shrink all members in the party, false will only shrink the player
    public bool ShrinkParty { get; set; } = true;
    // the speed at which the model scales, higher is faster
    public float Speed { get; set; } = 2.0f;
    // the minimum size of the model
    public float MinScale { get; set; } = 0.1f;
    
    public void Save()
    {
        if (MinScale < 0.01f){ MinScale = 0.01f; }
        
        Plugin.PluginInterface.SavePluginConfig(this);
    }
}
