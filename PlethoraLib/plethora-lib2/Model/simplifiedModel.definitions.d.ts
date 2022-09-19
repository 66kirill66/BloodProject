import { DataType } from "../utilities/enums";
import { INumberSettings, NameDictionary } from "./model.definitions";
export interface ISimplifiedModel {
    enumTypes: NameDictionary<ISimpEnumType>;
    interactions: NameDictionary<ISimpInteraction>;
    entities: NameDictionary<ISimpEntity>;
}
export interface ISimpEnumType {
    name: string;
    allowedValues: string[];
}
export interface ISimpHasDataType {
    dataType: DataType;
    enumTypeName?: string;
}
export interface ISimpProperty extends ISimpHasDataType {
    name: string;
    computed: boolean;
    settings?: INumberSettings;
}
export interface ISimpAction {
    name: string;
    actionParameters: NameDictionary<ISimpActionParameter>;
}
export interface ISimpActionParameter extends ISimpHasDataType {
    name: string;
}
export interface ISimpInteraction extends ISimpAction {
    isSymmetric: boolean;
    allowedActivatorsNames: string[];
    allowedReactorsNames: string[];
}
export interface ISimpEntity {
    name: string;
    ownProperties: NameDictionary<ISimpProperty>;
    ownActions: NameDictionary<ISimpAction>;
    allProperties: NameDictionary<ISimpProperty>;
    allActions: NameDictionary<ISimpAction>;
    isSingleton: boolean;
    maxInstances: number;
    parentsNames: string[];
}
