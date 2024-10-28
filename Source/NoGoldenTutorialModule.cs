using System;

namespace Celeste.Mod.NoGoldenTutorial;

public class NoGoldenTutorialModule : EverestModule
{
  public static NoGoldenTutorialModule Instance { get; private set; }

  public override Type SettingsType => typeof(NoGoldenTutorialModuleSettings);
  public static NoGoldenTutorialModuleSettings Settings => (NoGoldenTutorialModuleSettings)Instance._Settings;

  public NoGoldenTutorialModule()
  {
    Instance = this;
#if DEBUG
    // debug builds use verbose logging
    Logger.SetLogLevel(nameof(NoGoldenTutorialModule), LogLevel.Verbose);
#else
    // release builds use info logging to reduce spam in log files
    Logger.SetLogLevel(nameof(NoGoldenTutorialModule), LogLevel.Info);
#endif
  }

  public override void Load()
  {
    Everest.Events.Level.OnLoadEntity += NoGoldenTutorialEvents.OnLoadEntity;
  }

  public override void Unload()
  {
    // TODO: unapply any hooks applied in Load()
  }
}