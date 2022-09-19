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

export interface ISugarPropertiesValues {}

export abstract class GeneratedSugar extends AbstractUiEntity {
  constructor(id: number, propertyValues: PropertyValuesDictionary) {
    super("Sugar", id, propertyValues, [])
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
      default:
        throw new Error("Unkown property " + propertyName)
    }
  }

  protected onAction(actionName: string, actionParameters: ParamsByNames, uiData: UiData): void {
    super.onAction(actionName, actionParameters, uiData)
    switch (actionName) {
      case "change location": {
        const { from, to } = actionParameters
        this.onChangeLocation(from, to, uiData)
        return
      }

      default:
        throw new Error("Unkown action " + actionName)
    }
  }

  public applyChangeLocation(from: DataTypeLocation, to: DataTypeLocation, uiData: UiData = null): void {
    this.applyAction("change location", { from, to }, uiData, true)
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
    propertyValues: Partial<ISugarPropertiesValues>,
    quantity: number,
    uiData: UiData = null
  ): void {
    PlethoraLib.getInstance()
      .getMessagesManager()
      .sendCreateRequestMessage(
        {
          entityName: "Sugar",
          properties: _convertPropertyValuesToArray(propertyValues),
          quantity,
        },
        uiData
      )
  }
}
