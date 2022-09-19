import { UiData, AbstractEntity, PropertyValuesDictionary } from "plethora-lib" // GENERATED
import { DataTypeState, DataTypeLocation } from "../GeneratedClasses/GeneratedDataTypes" // GENERATED
import { GeneratedChannel } from "../GeneratedClasses/GeneratedChannel" // GENERATED
import { DataType } from "plethora-lib/utilities/enums"

export class Channel extends GeneratedChannel {
  constructor(id: number, propertyValues: PropertyValuesDictionary, uiData: UiData) {
    super(id, propertyValues)

    const data = { id: this.id , property: this.getLocation()}
    
    gameInstance.SendMessage("Manager", "AddChannals", JSON.stringify(data))

    // YOUR CREATE CODE HERE
  }

  public onDelete(uiData: UiData): void /* GENERATED */ {
    super.onDelete(uiData)
    // YOUR CODE HERE
  }

  public onDestory(): void /* GENERATED */ {
    super.onDestory()
    // YOUR CODE HERE
    gameInstance.SendMessage("Manager", "ResetChannelSimulation", "")
  }

  public onSetHighlight(highlight: boolean): void /* GENERATED */ {
    super.onSetHighlight(highlight)
    // YOUR CODE HERE
  }

  protected onLocationUpdate(
    newValue: DataTypeLocation,
    oldValue: DataTypeLocation,
    uiData: UiData
  ): void /* GENERATED */ {
    // YOUR CODE HERE
    //const data = { newPlace: newValue, id: this.id }
    // gameInstance.SendMessage("Manager", "SetChannelLocData", JSON.stringify(data))
  }

  protected onChangeLocation(from: DataTypeLocation, to: DataTypeLocation, uiData: UiData): void /* GENERATED */ {
    const data = { oldPlace: from, newPlace: to, id: this.id }
    console.log(uiData)
    gameInstance.SendMessage("Manager", "ChannelTransformPlace", JSON.stringify(data))
    // YOUR CODE HERE
  }

  protected onMeet(isActivator: boolean, otherEntity: AbstractEntity, uiData: UiData): void /* GENERATED */ {
    // YOUR CODE HERE
  }

  protected onGoThrough(isActivator: boolean, otherEntity: AbstractEntity, uiData: UiData): void /* GENERATED */ {
    gameInstance.SendMessage("Manager", "SugarGoThrough", this.id)
  }
}
