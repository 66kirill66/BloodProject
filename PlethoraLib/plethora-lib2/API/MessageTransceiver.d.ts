import { ApiMessage, SourceTypes } from "./api.definitions";
import { MessageBuilder } from "./MessageBuilder";
export declare type MessageHandler = (messages: ApiMessage[], blockId: number) => void | Promise<void>;
declare type messageListenerCallback = (message: ApiMessage) => boolean;
export declare class MessageTransceiver {
    private wasInit;
    readonly name: string;
    readonly isParent: boolean;
    readonly sendAs: SourceTypes;
    readonly listenTo: SourceTypes;
    private target;
    private messageBuilder;
    private messageHandler;
    private nextMsgBlockId;
    private messageBlockListeners;
    private messageListeners;
    private listener?;
    constructor(name: string, messageBuilder: MessageBuilder, messageHandler: MessageHandler, target: Window, isParent: boolean);
    private bindListener;
    detach(): void;
    addMessageBlockListener(blockId: number): Promise<void>;
    private checkBlockMessageListeners;
    sendMessages(messages: ApiMessage[], respondingToBlockId: number | null, waitForBlockResponse: boolean): Promise<void>;
    sendMessage(message: ApiMessage, respondingToBlockId?: number | null): void;
    sendMessageAndWaitForResponse(message: ApiMessage, respondingToBlockId?: number | null): Promise<void>;
    sendMessageWithListener(messageToSend: ApiMessage, listenerType: ApiMessage["type"], listenerCallaback?: messageListenerCallback): Promise<ApiMessage>;
    addMessageListener(type: string, callback?: messageListenerCallback): Promise<ApiMessage>;
    private checkMessageListeners;
    private logMessages;
}
export {};
