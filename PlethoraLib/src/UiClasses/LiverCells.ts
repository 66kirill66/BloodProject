import { UiData, AbstractEntity, PropertyValuesDictionary } from "plethora-lib" // GENERATED
import { DataTypeState, DataTypeLocation } from "../GeneratedClasses/GeneratedDataTypes" // GENERATED
import { GeneratedLiverCells } from "../GeneratedClasses/GeneratedLiverCells" // GENERATED

export class LiverCells extends GeneratedLiverCells {
  constructor(id: number, propertyValues: PropertyValuesDictionary, uiData: UiData) {
    super(id, propertyValues)

    // YOUR CREATE CODE HERE
    gameInstance.SendMessage("Manager", "Addliver", this.id)
  }

  public onDelete(uiData: UiData): void /* GENERATED */ {
    super.onDelete(uiData)
    // YOUR CODE HERE
  }

  public onDestory(): void /* GENERATED */ {
    super.onDestory()
    // YOUR CODE HERE
    gameInstance.SendMessage("Manager", "ResetLiverSimulation", "")
  }

  public onSetHighlight(highlight: boolean): void /* GENERATED */ {
    super.onSetHighlight(highlight)
    // YOUR CODE HERE
  }

  protected onSugarLevelUpdate(newValue: number, oldValue: number, uiData: UiData): void /* GENERATED */ {
    // YOUR CODE HERE
  }
}
