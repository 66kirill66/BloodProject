export declare type ApiMessage = IApiMsgModelRequest | IApiMsgModelResponse | IApiParentSimulationStateTrans | IApiChildSimulationStateTrans | IApiMsgEntityClick | IApiMsgSetEntityHighlight | IApiMsgInit | IApiMsgDone | IApiMsgProperty | IApiMsgAction | IApiMsgInteraction | IApiMsgCreate | IApiMsgCreateRequest | IApiMsgDelete | IApiMsgComputeFunction | IApiMsgFunctionResult | IApiMsgError;
export declare type SourceTypes = "science-parent" | "science-child";
export declare type SimulationState = "LOADING" | "UP" | "INIT" | "READY" | "RUNNING" | "PAUSED" | "RESET";
export declare type ParentSimulationStateTransition = "UP" | "READY" | "START" | "PAUSE" | "RESUME" | "RESET";
export declare type ChildSimulationStateTransition = "UP" | "START";
export interface IApiMessageContainer {
    source: SourceTypes;
    payload: ApiMessage[];
    blockId: number;
    respondingToBlockId: number | null;
}
interface IBaseApiMessage {
    msgId: number;
    type: string;
    uiData: UiData;
}
export declare type UiData = {
    [key: string]: any;
} | null;
export interface IApiMsgModelRequest extends IBaseApiMessage {
    type: "MODEL_REQUEST";
}
export interface IApiMsgModelResponse extends IBaseApiMessage {
    type: "MODEL_RESPONSE";
    modelJson: string;
    plethora_lib_version: string;
}
export interface IApiParentSimulationStateTrans extends IBaseApiMessage {
    type: "PARENT_SIMULATION_STATE_TRANS";
    stateTrans: ParentSimulationStateTransition;
}
export interface IApiChildSimulationStateTrans extends IBaseApiMessage {
    type: "CHILD_SIMULATION_STATE_TRANS";
    stateTrans: ChildSimulationStateTransition;
}
export interface IApiMsgEntityClick extends IBaseApiMessage {
    type: "ENTITY_CLICK";
    entityId: number;
}
export interface IApiMsgSetEntityHighlight extends IBaseApiMessage {
    type: "SET_ENTITY_HIGHLIGHT";
    entityId: number;
    highlight: boolean;
}
export interface IApiMsgInit extends IBaseApiMessage {
    type: "INIT";
    entityGroups: IApiEntityGroupWithId[];
}
export interface IApiEntityGroup {
    entityName: string;
    quantity: number;
    properties: IApiProperty[];
}
export interface IApiEntityGroupWithId extends IApiEntityGroup {
    startingId: number;
}
export interface IApiProperty {
    propertyName: string;
    value: number | string | boolean;
}
export interface IApiMsgDone extends IBaseApiMessage {
    type: "DONE";
    respondingToMsgId: number;
}
export interface IApiMsgProperty extends IBaseApiMessage {
    type: "PROPERTY";
    entityId: number;
    property: IApiProperty;
}
export interface IApiMsgAction extends IBaseApiMessage {
    type: "ACTION";
    entityId: number;
    action: IApiAction;
}
export interface IApiAction {
    actionName: string;
    actionParameters: IApiActionParameter[];
}
export interface IApiActionParameter {
    actionParameterName: string;
    value: number | string | boolean;
}
export interface IApiMsgInteraction extends IBaseApiMessage {
    type: "INTERACTION";
    activatorEntityId: number;
    reactorEntityId: number;
    interaction: IApiAction;
}
export interface IApiMsgCreate extends IBaseApiMessage {
    type: "CREATE";
    entityGroup: IApiEntityGroupWithId;
}
export interface IApiMsgCreateRequest extends IBaseApiMessage {
    type: "CREATE_REQUEST";
    entityGroup: IApiEntityGroup;
}
export interface IApiMsgDelete extends IBaseApiMessage {
    type: "DELETE";
    entityIds: number[];
}
export interface IApiMsgComputeFunction extends IBaseApiMessage {
    type: "COMPUTE_FUNCTION";
    entityId: number;
    propertyName: string;
    functionParameters: {
        [parameterName: string]: number | string | boolean;
    };
}
export interface IApiMsgFunctionResult extends IBaseApiMessage {
    type: "FUNCTION_RESULT";
    respondingToMsgId: number;
    result: number;
}
export interface IApiMsgError extends IBaseApiMessage {
    type: "ERROR";
    error: string;
}
export {};
