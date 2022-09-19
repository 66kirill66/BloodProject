import { UiData, AbstractEntity, PropertyValuesDictionary } from "plethora-lib" // GENERATED
import { DataTypeState, DataTypeLocation } from "../GeneratedClasses/GeneratedDataTypes" // GENERATED
import { GeneratedEnzyme } from "../GeneratedClasses/GeneratedEnzyme" // GENERATED

export class Enzyme extends GeneratedEnzyme {
  constructor(id: number, propertyValues: PropertyValuesDictionary, uiData: UiData) {
    super(id, propertyValues)

    // YOUR CREATE CODE HERE
    const data = { id: this.id , newProperty: this.getState()}  
    gameInstance.SendMessage("Manager", "AddEnzime", JSON.stringify(data))
    
    //gameInstance.SendMessage("Manager", "AddEnzime", this.id)
  }

  public onDelete(uiData: UiData): void /* GENERATED */ {
    super.onDelete(uiData)
    // YOUR CODE HERE
  }

  public onDestory(): void /* GENERATED */ {
    super.onDestory()
    gameInstance.SendMessage("Manager", "ResetEnzimeSimulation", "")
    // YOUR CODE HERE
  }

  public onSetHighlight(highlight: boolean): void /* GENERATED */ {
    super.onSetHighlight(highlight)
    // YOUR CODE HERE
  }

  protected onStateUpdate(newValue: DataTypeState, oldValue: DataTypeState, uiData: UiData): void /* GENERATED */ {
    const data = { newProperty: newValue, oldProperty: oldValue,id :this.id }
   // gameInstance.SendMessage("Manager", "EnzimeStateUpdate", JSON.stringify(data))
  }

  protected onMeet(isActivator: boolean, otherEntity: AbstractEntity, uiData: UiData): void /* GENERATED */ {
    // YOUR CODE HERE
  }

  protected onDeconstruct(isActivator: boolean, otherEntity: AbstractEntity, uiData: UiData): void /* GENERATED */ {
    // YOUR CODE HERE

  }
}
