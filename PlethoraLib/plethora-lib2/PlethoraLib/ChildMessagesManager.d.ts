import { ChildSimulationStateTransition, SimulationState, IApiAction, IApiEntityGroup, IApiProperty, UiData } from "../API/api.definitions";
import { ParamsByNames } from "./types.definitions";
export declare type ComputedPropertyFunction = (params: ParamsByNames) => number;
export declare type SimulationStateSetter = (state: SimulationState) => void;
export declare class ChildMessagesManager {
    private messageTransceiver;
    private messageBuilder;
    constructor();
    sendClickMessage(entityId: number): void;
    sendSimulationStateTransMessage(stateTrans: ChildSimulationStateTransition): Promise<void>;
    sendCreateRequestMessage(requestEntityGroup: IApiEntityGroup, uiData: UiData): void;
    sendDeleteMessage(entityIds: number[]): void;
    sendPropertyMessage(entityId: number, property: IApiProperty, uiData?: UiData): void;
    sendActionMessage(entityId: number, action: IApiAction, uiData?: UiData): void;
    sendInterctionMessage(activatorEntityId: number, reactorEntityId: number, interaction: IApiAction, uiData?: UiData): void;
    private handleMessages;
    private handleMessage;
}
