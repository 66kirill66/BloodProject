import { UiData, AbstractEntity, PropertyValuesDictionary } from "plethora-lib" // GENERATED
import { DataTypeState, DataTypeLocation } from "../GeneratedClasses/GeneratedDataTypes" // GENERATED
import { GeneratedGlucagonReceptor } from "../GeneratedClasses/GeneratedGlucagonReceptor" // GENERATED

export class GlucagonReceptor extends GeneratedGlucagonReceptor {
  constructor(id: number, propertyValues: PropertyValuesDictionary, uiData: UiData) {
    super(id, propertyValues)

    // YOUR CREATE CODE HERE
    gameInstance.SendMessage("Manager", "AddGlucagonReceptor", this.id)
  }

  public onDelete(uiData: UiData): void /* GENERATED */ {
    super.onDelete(uiData)
    // YOUR CODE HERE
  }

  public onDestory(): void /* GENERATED */ {
    super.onDestory()
    // YOUR CODE HERE
    gameInstance.SendMessage("Manager", "ResetGlucagonReceptorSimulation", "")
  }

  public onSetHighlight(highlight: boolean): void /* GENERATED */ {
    super.onSetHighlight(highlight)
    // YOUR CODE HERE
  }

  protected onReleasesSignalMolecule(uiData: UiData): void /* GENERATED */ {
    // YOUR CODE HERE
    console.log("--------------" + this.id + "--------------")
    gameInstance.SendMessage("Manager", "OnReleasesSignalMoleculeToWeb", this.id)
  }

  protected onMeet(isActivator: boolean, otherEntity: AbstractEntity, uiData: UiData): void /* GENERATED */ {
    // YOUR CODE HERE
  }
}
