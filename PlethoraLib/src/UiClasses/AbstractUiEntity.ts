import { AbstractEntity, PropertyValuesDictionary, ParamsByNames, UiData, PlethoraLib } from "plethora-lib" // GENERATED

export abstract class AbstractUiEntity extends AbstractEntity {
  constructor(name: string, id: number, propertyValues: PropertyValuesDictionary, parentsNames: string[]) {
    super(name, id, propertyValues, parentsNames)
  }

  public onDelete(uiData: UiData): void /* GENERATED */ {
    // YOUR CODE HERE
  }

  public onDestory(): void /* GENERATED */ {
    // YOUR CODE HERE
  }

  public onSetHighlight(highlight: boolean): void /* GENERATED */ {
    // YOUR CODE HERE
  }

  protected onPropertyUpdate(propertyName: string, newValue: any, oldValue: any, uiData: UiData): void /* GENERATED */ {
    // YOUR CODE HERE
  }

  protected onAction(actionName: string, actionParameters: ParamsByNames, uiData: UiData): void /* GENERATED */ {
    // YOUR CODE HERE
  }

  protected onInteraction(
    interactionName: string,
    reactorEntity: AbstractEntity,
    actionParameters: ParamsByNames,
    uiData: UiData
  ): void /* GENERATED */ {
    // YOUR CODE HERE
  }
}
