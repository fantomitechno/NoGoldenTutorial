using System;

namespace Celeste.Mod.NGT;

public class NGT : EverestModule
{
  public static NGT Instance { get; private set; }

  public override Type SettingsType => typeof(NGTSettings);
  public static NGTSettings Settings => (NGTSettings)Instance._Settings;

  public NGT()
  {
    Instance = this;
#if DEBUG
    // debug builds use verbose logging
    Logger.SetLogLevel(nameof(NGT), LogLevel.Verbose);
#else
    // release builds use info logging to reduce spam in log files
    Logger.SetLogLevel(nameof(NGT), LogLevel.Info);
#endif
  }

  public override void Load()
  {
    Everest.Events.Level.OnLoadEntity += NGTEvents.OnLoadEntity;
  }

  public override void Unload()
  {
    // TODO: unapply any hooks applied in Load()
  }
}