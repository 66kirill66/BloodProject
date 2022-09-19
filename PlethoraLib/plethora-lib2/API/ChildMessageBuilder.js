var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
import { PLETHORA_LIB_VERSION } from "../PlethoraLib/plethora-lib-version";
import { MessageBuilder } from "./MessageBuilder";
var ChildMessageBuilder = /** @class */ (function (_super) {
    __extends(ChildMessageBuilder, _super);
    function ChildMessageBuilder() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    ChildMessageBuilder.prototype.buildSimulationStateTransMessage = function (stateTrans) {
        return {
            msgId: this.nextMsgId++,
            type: "CHILD_SIMULATION_STATE_TRANS",
            stateTrans: stateTrans,
            uiData: null,
        };
    };
    ChildMessageBuilder.prototype.buildDoneMessage = function (respondingToMsgId) {
        return {
            msgId: this.nextMsgId++,
            type: "DONE",
            respondingToMsgId: respondingToMsgId,
            uiData: null,
        };
    };
    ChildMessageBuilder.prototype.buildEntityClickMessage = function (entityId) {
        return {
            msgId: this.nextMsgId++,
            type: "ENTITY_CLICK",
            entityId: entityId,
            uiData: null,
        };
    };
    ChildMessageBuilder.prototype.buildModelResponseMessage = function (modelJson) {
        return {
            msgId: this.nextMsgId++,
            type: "MODEL_RESPONSE",
            modelJson: modelJson,
            plethora_lib_version: PLETHORA_LIB_VERSION,
            uiData: null,
        };
    };
    ChildMessageBuilder.prototype.buildFunctionResultMessage = function (result, respondingToMsgId) {
        return {
            msgId: this.nextMsgId++,
            type: "FUNCTION_RESULT",
            respondingToMsgId: respondingToMsgId,
            result: result,
            uiData: null,
        };
    };
    ChildMessageBuilder.prototype.buildActionMessage = function (entityId, action, uiData) {
        if (uiData === void 0) { uiData = null; }
        return {
            msgId: this.nextMsgId++,
            type: "ACTION",
            entityId: entityId,
            action: action,
            uiData: uiData,
        };
    };
    ChildMessageBuilder.prototype.buildInteractionMessage = function (activatorEntityId, reactorEntityId, interaction, uiData) {
        if (uiData === void 0) { uiData = null; }
        return {
            msgId: this.nextMsgId++,
            type: "INTERACTION",
            activatorEntityId: activatorEntityId,
            reactorEntityId: reactorEntityId,
            interaction: interaction,
            uiData: uiData,
        };
    };
    ChildMessageBuilder.prototype.buildDeleteMessage = function (entityIds, uiData) {
        if (uiData === void 0) { uiData = null; }
        return {
            msgId: this.nextMsgId++,
            type: "DELETE",
            entityIds: entityIds,
            uiData: uiData,
        };
    };
    ChildMessageBuilder.prototype.buildPropertyMessage = function (entityId, property, uiData) {
        if (uiData === void 0) { uiData = null; }
        return {
            msgId: this.nextMsgId++,
            type: "PROPERTY",
            entityId: entityId,
            property: property,
            uiData: uiData,
        };
    };
    ChildMessageBuilder.prototype.buildCreateRequestMessage = function (requestEntityGroup, uiData) {
        if (uiData === void 0) { uiData = null; }
        return {
            msgId: this.nextMsgId++,
            type: "CREATE_REQUEST",
            entityGroup: requestEntityGroup,
            uiData: uiData,
        };
    };
    return ChildMessageBuilder;
}(MessageBuilder));
export { ChildMessageBuilder };
