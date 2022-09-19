import { SimulationState } from "../API/api.definitions";
import { AbstractModel } from "./AbstractModel";
import { ChildMessagesManager } from "./ChildMessagesManager";
export declare class PlethoraLib {
    private static _instance?;
    private simulationState;
    private messagesManager;
    private _model?;
    private _onReset?;
    private _onSimulationStateChange?;
    private constructor();
    static getInstance(): PlethoraLib;
    getSimulationState(): SimulationState;
    setSimulationState(state: SimulationState): void;
    requestInit(model: AbstractModel): void;
    requestStart(): void;
    reset(): void;
    getModel(): AbstractModel;
    getMessagesManager(): ChildMessagesManager;
    onReset(handler: () => void): void;
    onSimulationStateChange(handler: (simulationState: SimulationState) => void): void;
}
