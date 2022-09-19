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

export interface IChannelPropertiesValues {
  location: DataTypeLocation
}

export abstract class GeneratedChannel extends AbstractUiEntity {
  constructor(id: number, propertyValues: PropertyValuesDictionary) {
    super("Channel", id, propertyValues, [])
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
      case "location": {
        this.onLocationUpdate(newValue, oldValue, uiData)
        return
      }

      default:
        throw new Error("Unkown property " + propertyName)
    }
  }

  public getLocation(): DataTypeLocation {
    return this.getPropertyValue("location") as DataTypeLocation
  }

  public setLocation(value: DataTypeLocation, uiData: UiData = null): void {
    this.setPropertyValue("location", value, uiData, true)
  }

  protected abstract onLocationUpdate(newValue: DataTypeLocation, oldValue: DataTypeLocation, uiData: UiData): void

  protected onAction(actionName: string, actionParameters: ParamsByNames, uiData: UiData): void {
    super.onAction(actionName, actionParameters, uiData)
    switch (actionName) {
      case "Change Location": {
        const { from, to } = actionParameters
        this.onChangeLocation(from, to, uiData)
        return
      }

      default:
        throw new Error("Unkown action " + actionName)
    }
  }

  public applyChangeLocation(from: DataTypeLocation, to: DataTypeLocation, uiData: UiData = null): void {
    this.applyAction("Change Location", { from, to }, uiData, true)
  }
  protected abstract onChangeLocation(from: DataTypeLocation, to: DataTypeLocation, uiData: UiData): void

  protected onInteraction(
    interactionName: string,
    reactorEntity: AbstractEntity,
    interactionParameters: ParamsByNames,
    uiData: UiData
  ): void {
    super.onInteraction(interactionName, reactorEntity, interactionParameters, uiData)
    switch (interactionName) {
      case "Meet": {
        this.onMeet(true, reactorEntity, uiData) // activator
        ;(reactorEntity as any).onMeet(false, this, uiData) // reactor
        return
      }

      case "Go Through": {
        this.onGoThrough(true, reactorEntity, uiData) // activator
        ;(reactorEntity as any).onGoThrough(false, this, uiData) // reactor
        return
      }

      default:
        throw new Error("Unkown interaction " + interactionName)
    }
  }

  public applyMeet(reactorId: number, uiData: UiData = null): void {
    this.applyInteraction(reactorId, "Meet", {}, uiData, true)
  }
  protected abstract onMeet(isActivator: boolean, otherEntity: AbstractEntity, uiData: UiData): void

  public applyGoThrough(reactorId: number, uiData: UiData = null): void {
    this.applyInteraction(reactorId, "Go Through", {}, uiData, true)
  }
  protected abstract onGoThrough(isActivator: boolean, otherEntity: AbstractEntity, uiData: UiData): void

  public static createRequest(
    propertyValues: Partial<IChannelPropertiesValues>,
    quantity: number,
    uiData: UiData = null
  ): void {
    PlethoraLib.getInstance()
      .getMessagesManager()
      .sendCreateRequestMessage(
        {
          entityName: "Channel",
          properties: _convertPropertyValuesToArray(propertyValues),
          quantity,
        },
        uiData
      )
  }
}
