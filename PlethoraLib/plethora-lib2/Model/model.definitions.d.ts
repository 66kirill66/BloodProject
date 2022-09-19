import { DataType } from "../utilities/enums";
export declare type IdDictionary<T> = Record<string, T>;
export declare type NameDictionary<T> = Record<string, T>;
export interface IMappedModel {
    executionDelayMs: number;
    enumTypes: IdDictionary<IEnumType>;
    interactions: IdDictionary<IInteraction>;
    entities: IdDictionary<IEntity>;
}
export interface IEnumType {
    id: string;
    name: string;
    allowedValues: IdDictionary<string>;
}
interface IHasDataType {
    dataType: DataType;
    enumTypeId?: string;
}
interface IProperty extends IHasDataType {
    id: string;
    name: string;
    computed: boolean;
}
interface INormalProperty extends IProperty {
    computed: false;
    defaultValue: string | number | boolean;
}
export interface IEnumProperty extends INormalProperty {
    dataType: DataType.Enum;
    enumTypeId: string;
}
export interface IBooleanProperty extends INormalProperty {
    dataType: DataType.Boolean;
}
export interface IStringProperty extends INormalProperty {
    dataType: DataType.String;
}
export interface INumberProperty extends INormalProperty {
    dataType: DataType.Number;
    settings: INumberSettings;
}
export interface INumberSettings {
    min?: number;
    max?: number;
    units?: string;
    decimalPlaces?: number;
}
export interface IComputedProperty extends IProperty {
    computed: true;
    dataType: DataType.Number;
    parametersPropertiesIds: string[];
    singletonsParametersPropertiesIds: Array<{
        singletonId: string;
        propertyId: string;
    }>;
}
export declare type PropertyType = IEnumProperty | IStringProperty | IBooleanProperty | INumberProperty | IComputedProperty;
export interface IAction {
    id: string;
    name: string;
    actionParameters: IdDictionary<IActionParameter>;
}
export interface IActionParameter extends IHasDataType {
    id: string;
    name: string;
}
export interface IInteraction extends IAction {
    isSymmetric: boolean;
    allowedActivatorsIds: string[];
    allowedReactorsIds: string[];
}
export interface IEntity {
    id: string;
    name: string;
    properties: IdDictionary<PropertyType>;
    actions: IdDictionary<IAction>;
    isSingleton?: boolean;
    maxInstances?: number;
    parentPropertiesDefaultValues?: IdDictionary<string | number | boolean>;
    parentsIds?: string[];
    macroEntityId?: string | null;
}
export {};
