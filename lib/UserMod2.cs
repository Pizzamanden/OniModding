// Decompiled with JetBrains decompiler
// Type: KMod.UserMod2
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E519DD73-DA90-48A8-894A-B7F073F3EAD7
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using HarmonyLib;
using System.Collections.Generic;
using System.Reflection;

namespace KMod
{
  public class UserMod2
  {
    public Assembly assembly { get; set; }

    public string path { get; set; }

    public Mod mod { get; set; }

    public virtual void OnLoad(Harmony harmony) => harmony.PatchAll(this.assembly);

    public virtual void OnAllModsLoaded(Harmony harmony, IReadOnlyList<Mod> mods)
    {
    }
  }
}
