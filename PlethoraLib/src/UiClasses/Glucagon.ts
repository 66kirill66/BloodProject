import { UiData, AbstractEntity, PropertyValuesDictionary } from "plethora-lib" // GENERATED
import { DataTypeState, DataTypeLocation } from "../GeneratedClasses/GeneratedDataTypes" // GENERATED
import { GeneratedGlucagon } from "../GeneratedClasses/GeneratedGlucagon" // GENERATED

export class Glucagon extends GeneratedGlucagon {
  constructor(id: number, propertyValues: PropertyValuesDictionary, uiData: UiData) {
    super(id, propertyValues)

    // YOUR CREATE CODE HERE
    gameInstance.SendMessage("Manager", "AddGlucagon", this.id)
  }

  public onDelete(uiData: UiData): void /* GENERATED */ {
    super.onDelete(uiData)
    // YOUR CODE HERE
  }

  public onDestory(): void /* GENERATED */ {
    super.onDestory()
    // YOUR CODE HERE
    gameInstance.SendMessage("Manager", "ResetGlucagonSimulation", "")
  }

  public onSetHighlight(highlight: boolean): void /* GENERATED */ {
    super.onSetHighlight(highlight)
    // YOUR CODE HERE
  }

  protected onChangeLocation(from: DataTypeLocation, to: DataTypeLocation, uiData: UiData): void /* GENERATED */ {
    // YOUR CODE HERE
    console.log("-------Start----------")
    console.log(from, to)
    const data = { oldPlace: from, newPlace: to }
    gameInstance.SendMessage("Manager", "GlucagonTransformPlace", JSON.stringify(data))
  }

  protected onMeet(isActivator: boolean, otherEntity: AbstractEntity, uiData: UiData): void /* GENERATED */ {
    // YOUR CODE HERE
  }
}
