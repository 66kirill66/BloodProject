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

export interface ISimulationManagerPropertiesValues {}

export abstract class GeneratedSimulationManager extends AbstractUiEntity {
  constructor(id: number, propertyValues: PropertyValuesDictionary) {
    super("Simulation Manager", id, propertyValues, [])
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
      case "Eat": {
        this.onEat(uiData)
        return
      }

      case "Inject Glucagon": {
        this.onInjectGlucagon(uiData)
        return
      }

      case "Inject Insulin": {
        this.onInjectInsulin(uiData)
        return
      }

      default:
        throw new Error("Unkown action " + actionName)
    }
  }

  public applyEat(uiData: UiData = null): void {
    this.applyAction("Eat", {}, uiData, true)
  }
  protected abstract onEat(uiData: UiData): void

  public applyInjectGlucagon(uiData: UiData = null): void {
    this.applyAction("Inject Glucagon", {}, uiData, true)
  }
  protected abstract onInjectGlucagon(uiData: UiData): void

  public applyInjectInsulin(uiData: UiData = null): void {
    this.applyAction("Inject Insulin", {}, uiData, true)
  }
  protected abstract onInjectInsulin(uiData: UiData): void

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
    propertyValues: Partial<ISimulationManagerPropertiesValues>,
    quantity: number,
    uiData: UiData = null
  ): void {
    PlethoraLib.getInstance()
      .getMessagesManager()
      .sendCreateRequestMessage(
        {
          entityName: "Simulation Manager",
          properties: _convertPropertyValuesToArray(propertyValues),
          quantity,
        },
        uiData
      )
  }
}
