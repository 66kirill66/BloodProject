import { IApiMsgError } from "./api.definitions";
export declare abstract class MessageBuilder {
    protected nextMsgId: number;
    buildErrorMessage(error: string): IApiMsgError;
    reset(): void;
}
