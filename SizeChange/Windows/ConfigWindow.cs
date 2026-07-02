using System;
using System.Numerics;
using Dalamud.Bindings.ImGui;
using Dalamud.Interface.Windowing;

namespace SizeChange.Windows;

public class ConfigWindow : Window, IDisposable
{
    private readonly Configuration configuration;
    
    public ConfigWindow(Plugin plugin) : base("SizeChange Config")
    {

        Size = new Vector2(350, 180);
        SizeCondition = ImGuiCond.Always;

        configuration = plugin.Configuration;
    }

    public void Dispose() { }

    public override void Draw()
    {
        var speed = configuration.Speed;
        var minScale = configuration.MinScale;
        var shrinkParty = configuration.ShrinkParty;

        if (ImGui.DragFloat("Minimum Size", ref minScale, 0.01F, 0.01F, 1.00F))
        {
            if (minScale > 1.00F){ minScale = 1.00F; }
            configuration.MinScale = minScale;
            configuration.Save();
        }

        if (ImGui.DragFloat("Shrink Speed", ref speed, 0.1F, 0.1F, 100.0F))
        {
            configuration.Speed = speed;
            configuration.Save();
        }
        
        if (ImGui.Checkbox("Shrink Party", ref shrinkParty))
        {
            configuration.ShrinkParty = shrinkParty;
            configuration.Save();
        }
        

        if (ImGui.Button("Default"))
        {
            configuration.ShrinkParty = true;
            configuration.MinScale = 0.1f;
            configuration.Speed = 2.0f;
            configuration.Save();
        }
        
        ImGui.Text("This plugin is disabled in PVP");
    }
}
