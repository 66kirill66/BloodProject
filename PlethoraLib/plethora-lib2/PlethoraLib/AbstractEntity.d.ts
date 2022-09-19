import { PropertyValuesDictionary } from ".";
import { IApiActionParameter, UiData } from "../API/api.definitions";
import { ParamsByNames } from "./types.definitions";
export declare abstract class AbstractEntity {
    readonly id: number;
    readonly name: string;
    private parentsNames;
    protected propertyValuesMap: Map<string, string | number | boolean>;
    constructor(name: string, id: number, propertyValues: PropertyValuesDictionary, parentsNames: string[]);
    abstract computeFunction(propertyName: string, functionParameters: ParamsByNames): number;
    protected abstract onPropertyUpdate(propertyName: string, newValue: any, oldValue: any, uiData: UiData): void;
    protected abstract onAction(actionName: string, actionParameters: ParamsByNames, uiData: UiData): void;
    protected abstract onInteraction(interactionName: string, reactorEntity: AbstractEntity, actionParameters: ParamsByNames, uiData: UiData): void;
    abstract onDelete(uiData: UiData): void;
    abstract onDestory(): void;
    abstract onSetHighlight(highlight: boolean): void;
    isA(entityName: string): boolean;
    click(): void;
    delete(uiData?: UiData): void;
    getPropertyValue(propertyName: string): string | number | boolean;
    setPropertyValue(propertyName: string, value: string | number | boolean, uiData: UiData, updateParent: boolean): void;
    applyAction(actionName: string, actionParameters: ParamsByNames, uiData: UiData, updateParent: boolean): void;
    applyInteraction(reactorId: number, interactionName: string, interactionParameters: ParamsByNames, uiData: UiData, updateParent: boolean): void;
    private isSimulationRunning;
    logToConsole(functionName: string, params: string): void;
    toString(): string;
}
export declare function _convertActionParamsToDict(actionParameters: IApiActionParameter[]): ParamsByNames;
export declare function _convertActionParamsToArray(paramsByNames: ParamsByNames): IApiActionParameter[];
