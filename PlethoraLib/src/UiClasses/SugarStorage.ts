import { UiData, AbstractEntity, PropertyValuesDictionary } from "plethora-lib" // GENERATED
import { DataTypeState, DataTypeLocation } from "../GeneratedClasses/GeneratedDataTypes" // GENERATED
import { GeneratedSugarStorage } from "../GeneratedClasses/GeneratedSugarStorage" // GENERATED

export class SugarStorage extends GeneratedSugarStorage {
  constructor(id: number, propertyValues: PropertyValuesDictionary, uiData: UiData) {
    super(id, propertyValues)

    // YOUR CREATE CODE HERE
    const data = {
      id: this.id,
      storagePlaceCount : uiData ? uiData.storagePlaceCount : -1,}
    gameInstance.SendMessage("Manager", "AddSugarStorage", JSON.stringify(data))
   // gameInstance.SendMessage("Manager", "AddSugarStorage", this.id)
  }

  public onDelete(uiData: UiData): void /* GENERATED */ {
    super.onDelete(uiData)
    // YOUR CODE HERE
  }

  public onDestory(): void /* GENERATED */ {
    super.onDestory()
    gameInstance.SendMessage("Manager", "ResetSugarStorageSimulation", "")
    // YOUR CODE HERE
  }

  public onSetHighlight(highlight: boolean): void /* GENERATED */ {
    super.onSetHighlight(highlight)
    // YOUR CODE HERE
  }

  protected onMeet(isActivator: boolean, otherEntity: AbstractEntity, uiData: UiData): void /* GENERATED */ {
    // YOUR CODE HERE
  }

  protected onDeconstruct(isActivator: boolean, otherEntity: AbstractEntity, uiData: UiData): void /* GENERATED */ {
    // YOUR CODE HERE
    gameInstance.SendMessage("Manager","StorageBroke",this.id)
  }
}
