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

export interface ISignalMoleculePropertiesValues {
  AttachedToReceptor: boolean
}

export abstract class GeneratedSignalMolecule extends AbstractUiEntity {
  constructor(id: number, propertyValues: PropertyValuesDictionary) {
    super("Signal Molecule", id, propertyValues, [])
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
      case "AttachedToReceptor": {
        this.onAttachedToReceptorUpdate(newValue, oldValue, uiData)
        return
      }

      default:
        throw new Error("Unkown property " + propertyName)
    }
  }

  public getAttachedToReceptor(): boolean {
    return this.getPropertyValue("AttachedToReceptor") as boolean
  }

  public setAttachedToReceptor(value: boolean, uiData: UiData = null): void {
    this.setPropertyValue("AttachedToReceptor", value, uiData, true)
  }

  protected abstract onAttachedToReceptorUpdate(newValue: boolean, oldValue: boolean, uiData: UiData): void

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
      case "Meet": {
        this.onMeet(true, reactorEntity, uiData) // activator
        ;(reactorEntity as any).onMeet(false, this, uiData) // reactor
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

  public static createRequest(
    propertyValues: Partial<ISignalMoleculePropertiesValues>,
    quantity: number,
    uiData: UiData = null
  ): void {
    PlethoraLib.getInstance()
      .getMessagesManager()
      .sendCreateRequestMessage(
        {
          entityName: "Signal Molecule",
          properties: _convertPropertyValuesToArray(propertyValues),
          quantity,
        },
        uiData
      )
  }
}
