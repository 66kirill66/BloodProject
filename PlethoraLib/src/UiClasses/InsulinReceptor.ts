import { UiData, AbstractEntity, PropertyValuesDictionary } from "plethora-lib" // GENERATED
import { DataTypeState, DataTypeLocation } from "../GeneratedClasses/GeneratedDataTypes" // GENERATED
import { GeneratedInsulinReceptor } from "../GeneratedClasses/GeneratedInsulinReceptor" // GENERATED

export class InsulinReceptor extends GeneratedInsulinReceptor {
  constructor(id: number, propertyValues: PropertyValuesDictionary, uiData: UiData) {
    super(id, propertyValues)

    //const data ={id:this.id}
    gameInstance.SendMessage("Manager", "AddInsulinReceptor", this.id)
  }

  public onDelete(uiData: UiData): void /* GENERATED */ {
    super.onDelete(uiData)
    // YOUR CODE HERE
  }

  public onDestory(): void /* GENERATED */ {
    super.onDestory()
    // YOUR CODE HERE
    gameInstance.SendMessage("Manager", "ResetInsulinReceptorSimulation", "")
  }

  public onSetHighlight(highlight: boolean): void /* GENERATED */ {
    super.onSetHighlight(highlight)
    // YOUR CODE HERE
  }

  protected onReleasesSignalMolecule(uiData: UiData): void /* GENERATED */ {
    gameInstance.SendMessage("Manager", "OnReleasesSignalMoleculeWeb", this.id)
  }

  protected onMeet(isActivator: boolean, otherEntity: AbstractEntity, uiData: UiData): void /* GENERATED */ {
    // YOUR CODE HERE
  }
}
