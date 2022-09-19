import { UiData, AbstractEntity, PropertyValuesDictionary } from "plethora-lib" // GENERATED
import { DataTypeState, DataTypeLocation } from "../GeneratedClasses/GeneratedDataTypes" // GENERATED
import { GeneratedCell } from "../GeneratedClasses/GeneratedCell" // GENERATED

export class Cell extends GeneratedCell {
  constructor(id: number, propertyValues: PropertyValuesDictionary, uiData: UiData) {
    super(id, propertyValues)

    // YOUR CREATE CODE HERE
  }

  public onDelete(uiData: UiData): void /* GENERATED */ {
    super.onDelete(uiData)
    // YOUR CODE HERE
  }

  public onDestory(): void /* GENERATED */ {
    super.onDestory()
    // YOUR CODE HERE
  }

  public onSetHighlight(highlight: boolean): void /* GENERATED */ {
    super.onSetHighlight(highlight)
    // YOUR CODE HERE
  }

  protected onSugarLevelUpdate(newValue: number, oldValue: number, uiData: UiData): void /* GENERATED */ {
    // YOUR CODE HERE
  }
}
