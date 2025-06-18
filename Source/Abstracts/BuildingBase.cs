using Source.Models;
using System;
using WCSharp.Api;

namespace Source.Abstracts
{
  /// <summary>
  /// Represents the base functionality for a building in the game, including unit creation, event handling, and
  /// cleanup.
  /// </summary>
  /// <remarks>The <see cref="BuildingBase"/> class provides core functionality for managing buildings in the
  /// game. It includes methods for creating units, handling unit death events, and cleaning up resources. Derived
  /// classes can extend this functionality to implement specific building behaviors.</remarks>
  public abstract class BuildingBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="BuildingBase"/> class, creating a unit at the specified location.
    /// </summary>
    /// <remarks>This constructor creates a unit of the specified type at the center of the given area. The
    /// unit is owned by the specified computer player.</remarks>
    /// <param name="computer">The computer player that owns the building. Cannot be null.</param>
    /// <param name="unitTypeId">The unique identifier for the type of unit to create.</param>
    /// <param name="creationArea">The area where the unit will be created. Cannot be null.</param>
    public BuildingBase(ComputerPlayer computer, int unitTypeId, Area creationArea)
    {
      Computer = computer;
      Wc3Unit = Common.CreateUnitAtLoc(computer.Wc3Player, unitTypeId, creationArea.Wc3CenterLocation, 0f);
    }

    /// <summary>
    /// Gets the Warcraft III unit associated with this instance.
    /// </summary>
    public unit Wc3Unit { get; init; }

    /// <summary>
    /// Gets the computer player instance used in the game.
    /// </summary>
    public ComputerPlayer Computer { get; init; }

    /// <summary>
    /// Gets or sets the Warcraft III death trigger.
    /// </summary>
    private trigger Wc3DeathTrigger { get; set; }

    /// <summary>
    /// Registers an event handler to be invoked when the unit dies.
    /// </summary>
    /// <remarks>This method sets up a death event trigger for the unit and associates the specified  event
    /// handler with the trigger. The event handler will be executed when the unit dies.</remarks>
    /// <param name="eventHandler">The action to execute when the unit's death event is triggered.  This parameter cannot be null.</param>
    public void RegisterOnDies(Action eventHandler)
    {
      Wc3DeathTrigger = trigger.Create();
      Wc3DeathTrigger.RegisterUnitEvent(Wc3Unit, unitevent.Death);
      Wc3DeathTrigger.AddAction(eventHandler);
    }

    /// <summary>
    /// Deregisters the death trigger, disabling and disposing of any associated resources.
    /// </summary>
    /// <remarks>This method ensures that the death trigger is properly disabled and its resources are
    /// released. It should be called when the death trigger is no longer needed to prevent resource leaks.</remarks>
    private void DeRegisterOnDies()
    {
      if (Wc3DeathTrigger == null)
        return;

      Wc3DeathTrigger.Disable();
      Wc3DeathTrigger.Dispose();
      Wc3DeathTrigger = null;
    }

    /// <summary>
    /// Destroys the associated unit, ensuring proper cleanup and removal from the game.
    /// </summary>
    /// <remarks>This method handles deregistration of the unit and ensures that the unit is killed if it is
    /// still alive. It may be invoked in scenarios where the unit is removed due to game events, such as team loss or
    /// player removal.</remarks>
    public virtual void Destroy()
    {
      DeRegisterOnDies();

      if (Wc3Unit.Alive)
      {
        // Da diese Funktion auch beim Tod des Gebäudes ausgelöst werden kann,
        // töte Gebäude bei Bedarf, d.h. wenn Team verliert und Spieler entfernt werden.
        Wc3Unit.Kill();
      }
    }
  }
}
