import {
  UiData,
  ParamsByNames,
  AbstractEntity,
  PropertyValuesDictionary,
  _convertPropertyValuesToArray,
  PlethoraLib,
} from "plethora-lib"
import { AbstractUiEntity } from "../UiClasses/AbstractUiEntity"
import { DataTypeState, DataTypeLocation } from "./GeneratedDataTypes"

export interface ICellPropertiesValues {
  "sugar level": number
}

export abstract class GeneratedCell extends AbstractUiEntity {
  constructor(id: number, propertyValues: PropertyValuesDictionary) {
    super("Cell", id, propertyValues, [])
  }

  public computeFunction(propertyName: string, functionParameters: ParamsByNames): number {
    switch (propertyName) {
      default:
        throw new Error("Error on computeFunction(), unkown computed property name " + propertyName)
    }
  }

  protected onPropertyUpdate(propertyName: string, newValue: any, oldValue: any, uiData: UiData): void {
    super.onPropertyUpdate(propertyName, newValue, oldValue, uiData)
    switch (propertyName) {
      case "sugar level": {
        this.onSugarLevelUpdate(newValue, oldValue, uiData)
        return
      }

      default:
        throw new Error("Unkown property " + propertyName)
    }
  }

  public getSugarLevel(): number {
    return this.getPropertyValue("sugar level") as number
  }

  public setSugarLevel(value: number, uiData: UiData = null): void {
    this.setPropertyValue("sugar level", value, uiData, true)
  }

  protected abstract onSugarLevelUpdate(newValue: number, oldValue: number, uiData: UiData): void

  protected onAction(actionName: string, actionParameters: ParamsByNames, uiData: UiData): void {
    super.onAction(actionName, actionParameters, uiData)
    switch (actionName) {
      default:
        throw new Error("Unkown action " + actionName)
    }
  }

  protected onInteraction(
    interactionName: string,
    reactorEntity: AbstractEntity,
    interactionParameters: ParamsByNames,
    uiData: UiData
  ): void {
    super.onInteraction(interactionName, reactorEntity, interactionParameters, uiData)
    switch (interactionName) {
      default:
        throw new Error("Unkown interaction " + interactionName)
    }
  }

  public static createRequest(
    propertyValues: Partial<ICellPropertiesValues>,
    quantity: number,
    uiData: UiData = null
  ): void {
    PlethoraLib.getInstance()
      .getMessagesManager()
      .sendCreateRequestMessage(
        {
          entityName: "Cell",
          properties: _convertPropertyValuesToArray(propertyValues),
          quantity,
        },
        uiData
      )
  }
}
