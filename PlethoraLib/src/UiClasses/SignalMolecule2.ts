import { UiData, AbstractEntity, PropertyValuesDictionary } from "plethora-lib" // GENERATED
import { DataTypeState, DataTypeLocation } from "../GeneratedClasses/GeneratedDataTypes" // GENERATED
import { GeneratedSignalMolecule2 } from "../GeneratedClasses/GeneratedSignalMolecule2" // GENERATED

export class SignalMolecule2 extends GeneratedSignalMolecule2 {
  constructor(id: number, propertyValues: PropertyValuesDictionary, uiData: UiData) {
    super(id, propertyValues)

    // YOUR CREATE CODE HERE
    const data = {
      id: this.id,
      receptorId: uiData ? uiData.receptorId : -1,
    }
    gameInstance.SendMessage("Manager", "AddSignalMoleculeTo", JSON.stringify(data))
    console.log(uiData)
    console.log(id)
  }

  public onDelete(uiData: UiData): void /* GENERATED */ {
    super.onDelete(uiData)
    // YOUR CODE HERE
  }

  public onDestory(): void /* GENERATED */ {
    super.onDestory()
    // YOUR CODE HERE
    gameInstance.SendMessage("Manager", "ResetSignalMToSimulation", "")
  }

  public onSetHighlight(highlight: boolean): void /* GENERATED */ {
    super.onSetHighlight(highlight)
    // YOUR CODE HERE
  }

  protected onAttachedToReceptorUpdate(newValue: boolean, oldValue: boolean, uiData: UiData): void /* GENERATED */ {
    // YOUR CODE HERE
  }

  protected onMeet(isActivator: boolean, otherEntity: AbstractEntity, uiData: UiData): void /* GENERATED */ {
    // YOUR CODE HERE
  }
}
