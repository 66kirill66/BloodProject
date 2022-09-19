import { UiData, AbstractEntity, PropertyValuesDictionary } from "plethora-lib" // GENERATED
import { DataTypeState, DataTypeLocation } from "../GeneratedClasses/GeneratedDataTypes" // GENERATED
import { GeneratedInsulin } from "../GeneratedClasses/GeneratedInsulin" // GENERATED

export class Insulin extends GeneratedInsulin {
  constructor(id: number, propertyValues: PropertyValuesDictionary, uiData: UiData) {
    super(id, propertyValues)

    gameInstance.SendMessage("Manager", "AddInsulin", this.id)
  }

  public onDelete(uiData: UiData): void /* GENERATED */ {
    super.onDelete(uiData)
    // YOUR CODE HERE
  }

  public onDestory(): void /* GENERATED */ {
    super.onDestory()
    // YOUR CODE HERE
    gameInstance.SendMessage("Manager", "ResetInsulinSimulation", "")
  }

  public onSetHighlight(highlight: boolean): void /* GENERATED */ {
    super.onSetHighlight(highlight)
    // YOUR CODE HERE
  }

  protected onChangeLocation(from: DataTypeLocation, to: DataTypeLocation, uiData: UiData): void /* GENERATED */ {
    // YOUR CODE HERE
    console.log(from, to)
    const data = { oldPlace: from, newPlace: to }
    gameInstance.SendMessage("Manager", "InsulinTransformPlace", JSON.stringify(data))
  }

  protected onMeet(isActivator: boolean, otherEntity: AbstractEntity, uiData: UiData): void /* GENERATED */ {
    // YOUR CODE HERE
  }
}
