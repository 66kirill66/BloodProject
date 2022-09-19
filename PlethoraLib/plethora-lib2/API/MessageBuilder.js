var MessageBuilder = /** @class */ (function () {
    function MessageBuilder() {
        this.nextMsgId = 0;
    }
    MessageBuilder.prototype.buildErrorMessage = function (error) {
        return {
            msgId: this.nextMsgId++,
            type: "ERROR",
            error: error,
            uiData: null,
        };
    };
    MessageBuilder.prototype.reset = function () {
        this.nextMsgId = 0;
    };
    return MessageBuilder;
}());
export { MessageBuilder };
