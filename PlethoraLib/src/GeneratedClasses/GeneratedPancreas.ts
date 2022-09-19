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

export interface IPancreasPropertiesValues {}

export abstract class GeneratedPancreas extends AbstractUiEntity {
  constructor(id: number, propertyValues: PropertyValuesDictionary) {
    super("Pancreas", id, propertyValues, [])
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
    propertyValues: Partial<IPancreasPropertiesValues>,
    quantity: number,
    uiData: UiData = null
  ): void {
    PlethoraLib.getInstance()
      .getMessagesManager()
      .sendCreateRequestMessage(
        {
          entityName: "Pancreas",
          properties: _convertPropertyValuesToArray(propertyValues),
          quantity,
        },
        uiData
      )
  }
}
