import { UiData, AbstractEntity, PropertyValuesDictionary } from "plethora-lib" // GENERATED
import { DataTypeState, DataTypeLocation } from "../GeneratedClasses/GeneratedDataTypes" // GENERATED
import { GeneratedBlood } from "../GeneratedClasses/GeneratedBlood" // GENERATED

export class Blood extends GeneratedBlood {
  constructor(id: number, propertyValues: PropertyValuesDictionary, uiData: UiData) {
    super(id, propertyValues)

    // YOUR CREATE CODE HERE

    gameInstance.SendMessage("Manager", "AddBlood", this.id)
  }

  public onDelete(uiData: UiData): void /* GENERATED */ {
    super.onDelete(uiData)
    // YOUR CODE HERE
  }

  public onDestory(): void /* GENERATED */ {
    super.onDestory()
    // YOUR CODE HERE
    gameInstance.SendMessage("Manager", "ResetBloodSimulation", "")
  }

  public onSetHighlight(highlight: boolean): void /* GENERATED */ {
    super.onSetHighlight(highlight)
    // YOUR CODE HERE
  }

  protected onSugarLevelUpdate(newValue: number, oldValue: number, uiData: UiData): void /* GENERATED */ {
    // YOUR CODE HERE
    console.log(newValue)
    gameInstance.SendMessage("Manager", "BloodChangeSugarLevel", newValue)
  }

  protected onInsulinLevelUpdate(newValue: number, oldValue: number, uiData: UiData): void /* GENERATED */ {
    // YOUR CODE HERE
  }

  protected onGlucagonLevelUpdate(newValue: number, oldValue: number, uiData: UiData): void /* GENERATED */ {
    // YOUR CODE HERE
  }
}
