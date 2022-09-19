import { IApiAction, IApiEntityGroup, IApiMsgAction, IApiMsgEntityClick, IApiMsgCreateRequest, IApiMsgDelete, IApiMsgDone, IApiMsgFunctionResult, IApiMsgInteraction, IApiMsgModelResponse, IApiMsgProperty, IApiProperty, UiData, ChildSimulationStateTransition, IApiChildSimulationStateTrans } from "./api.definitions";
import { MessageBuilder } from "./MessageBuilder";
export declare class ChildMessageBuilder extends MessageBuilder {
    buildSimulationStateTransMessage(stateTrans: ChildSimulationStateTransition): IApiChildSimulationStateTrans;
    buildDoneMessage(respondingToMsgId: number): IApiMsgDone;
    buildEntityClickMessage(entityId: number): IApiMsgEntityClick;
    buildModelResponseMessage(modelJson: string): IApiMsgModelResponse;
    buildFunctionResultMessage(result: number, respondingToMsgId: number): IApiMsgFunctionResult;
    buildActionMessage(entityId: number, action: IApiAction, uiData?: UiData): IApiMsgAction;
    buildInteractionMessage(activatorEntityId: number, reactorEntityId: number, interaction: IApiAction, uiData?: UiData): IApiMsgInteraction;
    buildDeleteMessage(entityIds: number[], uiData?: UiData): IApiMsgDelete;
    buildPropertyMessage(entityId: number, property: IApiProperty, uiData?: UiData): IApiMsgProperty;
    buildCreateRequestMessage(requestEntityGroup: IApiEntityGroup, uiData?: UiData): IApiMsgCreateRequest;
}
