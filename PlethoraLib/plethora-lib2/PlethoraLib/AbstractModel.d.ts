import { PropertyValuesDictionary } from "./types.definitions";
import { IApiEntityGroupWithId, IApiProperty, UiData } from "../API/api.definitions";
import { AbstractEntity } from "./AbstractEntity";
import { ISimplifiedModel } from "./../Model/simplifiedModel.definitions";
export declare abstract class AbstractModel {
    private wasInit;
    private entities;
    private singletonsIds;
    abstract getSimplifiedModel(): ISimplifiedModel;
    init(entityGroups: IApiEntityGroupWithId[]): void;
    createUiEntites(entityGroup: IApiEntityGroupWithId, uiData: UiData): AbstractEntity[];
    abstract createUiEntity(entityName: string, entityId: number, propertyValues: PropertyValuesDictionary, uiData: UiData): AbstractEntity;
    abstract isSingleton(name: string): boolean;
    forEachEntity(callback: (entity: AbstractEntity) => void): void;
    getSingleton(name: string): AbstractEntity;
    getEntities(): AbstractEntity[];
    private setEntity;
    getEntity(entityId: number): AbstractEntity;
    deleteEntities(entityIds: number[], uiData?: UiData, updateParent?: boolean): void;
    deleteEntity(entityId: number, uiData?: UiData): void;
    reset(): void;
    toString(): string;
}
export declare function _convertPropertyValuesToArray(propertiesValues: PropertyValuesDictionary): IApiProperty[];
