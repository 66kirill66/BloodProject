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

export interface IIntervalTimerPropertiesValues {
  Ticks: number
}

export abstract class GeneratedIntervalTimer extends AbstractUiEntity {
  constructor(id: number, propertyValues: PropertyValuesDictionary) {
    super("IntervalTimer", id, propertyValues, [])
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
      case "Ticks": {
        this.onTicksUpdate(newValue, oldValue, uiData)
        return
      }

      default:
        throw new Error("Unkown property " + propertyName)
    }
  }

  public getTicks(): number {
    return this.getPropertyValue("Ticks") as number
  }

  public setTicks(value: number, uiData: UiData = null): void {
    this.setPropertyValue("Ticks", value, uiData, true)
  }

  protected abstract onTicksUpdate(newValue: number, oldValue: number, uiData: UiData): void

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
    propertyValues: Partial<IIntervalTimerPropertiesValues>,
    quantity: number,
    uiData: UiData = null
  ): void {
    PlethoraLib.getInstance()
      .getMessagesManager()
      .sendCreateRequestMessage(
        {
          entityName: "IntervalTimer",
          properties: _convertPropertyValuesToArray(propertyValues),
          quantity,
        },
        uiData
      )
  }
}
