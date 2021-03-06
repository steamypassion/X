﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X.ModernDesktop.SimTower.Models.Item
{
  enum IconNumbers
  {
    ICON_LOBBY = 0,
    ICON_FLOOR = 1,
    ICON_STAIRS = 2,
    ICON_ELEVATOR = 3,
    ICON_ELEVATOR_SERVICE = 5,
    ICON_OFFICE = 7,
    ICON_FASTFOOD = 11,
    ICON_RESTAURANT = 12,
    ICON_CINEMA = 14,
    ICON_PARTYHALL = 15,
    ICON_METRO = 19,
    ICON_CONDO = 24,
  };

  class Factory
  {
    public List<IPrototype> prototypes;
    public Dictionary<string, IPrototype> prototypesById;
    private Board _board;

    public Factory(Board board) {
      _board = board;
      prototypes = new List<IPrototype>();
      prototypesById = new Dictionary<string, IPrototype>();
      LoadPrototypes();
    }

    private void LoadPrototypes() {

      prototypes.Add(Elevator.makePrototype<Elevator>());
      prototypes.Add(Floor.makePrototype<Floor>());
      prototypes.Add(Lobby.makePrototype<Lobby>());
      prototypes.Add(Office.makePrototype<Office>());

      foreach (var prototype in prototypes)
      {
        prototypesById.Add(prototype.Id, prototype);
      }
    }

    public IPrototype Make(IPrototype prototype, Slot position) {
      return Make(prototype, position, null);
    }

    public IPrototype Make(string prototypeId, Slot position) {
      IPrototype prototype = prototypesById[prototypeId];
      return Make(prototype, position);
    }

    public IPrototype Make(IPrototype prototype, Slot position, Slot size) {
      IPrototype item = prototype.Make(_board);
      item.Position = position;
      if (size != null) {
        ((IPrototype)item).Size = size;
      }
      item.Init();
      return item;
    }
  }
}
