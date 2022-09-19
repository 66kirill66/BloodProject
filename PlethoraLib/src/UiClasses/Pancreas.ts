import { UiData, AbstractEntity, PropertyValuesDictionary } from "plethora-lib" // GENERATED
import { DataTypeState, DataTypeLocation } from "../GeneratedClasses/GeneratedDataTypes" // GENERATED
import { GeneratedPancreas } from "../GeneratedClasses/GeneratedPancreas" // GENERATED

export class Pancreas extends GeneratedPancreas {
  constructor(id: number, propertyValues: PropertyValuesDictionary, uiData: UiData) {
    super(id, propertyValues)

    // YOUR CREATE CODE HERE
    gameInstance.SendMessage("Manager", "AddPancreas", this.id)
  }

  public onDelete(uiData: UiData): void /* GENERATED */ {
    super.onDelete(uiData)
    // YOUR CODE HERE
  }

  public onDestory(): void /* GENERATED */ {
    super.onDestory()
    // YOUR CODE HERE
    gameInstance.SendMessage("Manager", "ResetPancreasSimulation", "")
  }

  public onSetHighlight(highlight: boolean): void /* GENERATED */ {
    super.onSetHighlight(highlight)
    // YOUR CODE HERE
  }
}
