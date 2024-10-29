using System.Linq;
using Microsoft.Xna.Framework;

namespace Celeste.Mod.NGT;

class NGTEvents
{
  public static bool OnLoadEntity(Level level, LevelData levelData, Vector2 offset, EntityData entityData)
  {
    if (NGT.Settings.Active)
    {
      Player player = level.Tracker.GetEntity<Player>();

      if ((NGT.Settings.HideWithoutBerry || IsHoldingDeathlessBerry(player)) && (entityData.Name == "playbackTutorial" || entityData.Name == "VivHelper/CPP"))
      {
        return true; // if this returns true, it means that the entity was succesfully loaded, but if we pretend to have loaded it without doing anything
      }
    }

    return false;
  }

  // Credits viddie in consistency tracker
  private static bool IsHoldingDeathlessBerry(Player player)
  {
    if (player == null || player.Leader == null || player.Leader.Followers == null || player.Leader.Followers.Count == 0)
    {
      return false;
    }

    return player.Leader.Followers.Any((f) =>
    {
      if (f.Entity.GetType().Name == "PlatinumBerry")
      {
        return true;
      }
      else if (f.Entity.GetType().Name == "SpeedBerry")
      {
        return false;
      }

      if (!(f.Entity is Strawberry))
      {
        return false;
      }

      Strawberry berry = (Strawberry)f.Entity;

      if (!berry.Golden || berry.Winged)
      {
        return false;
      }

      return true;
    });
  }
}