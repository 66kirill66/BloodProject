var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (_) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
var __values = (this && this.__values) || function(o) {
    var s = typeof Symbol === "function" && Symbol.iterator, m = s && o[s], i = 0;
    if (m) return m.call(o);
    if (o && typeof o.length === "number") return {
        next: function () {
            if (o && i >= o.length) o = void 0;
            return { value: o && o[i++], done: !o };
        }
    };
    throw new TypeError(s ? "Object is not iterable." : "Symbol.iterator is not defined.");
};
import { ChildMessageBuilder } from "../API/ChildMessageBuilder";
import { MessageTransceiver } from "../API/MessageTransceiver";
import { _convertActionParamsToDict } from "./AbstractEntity";
import { PlethoraLib } from "./PlethoraLib";
var ChildMessagesManager = /** @class */ (function () {
    // used to set the simulation state without being publicly exposed
    function ChildMessagesManager() {
        var _this = this;
        this.messageBuilder = new ChildMessageBuilder();
        this.messageTransceiver = new MessageTransceiver("API CHILD", this.messageBuilder, function (messages, blockId) { return _this.handleMessages(messages, blockId); }, parent, false);
    }
    ChildMessagesManager.prototype.sendClickMessage = function (entityId) {
        var message = this.messageBuilder.buildEntityClickMessage(entityId);
        this.messageTransceiver.sendMessage(message);
    };
    ChildMessagesManager.prototype.sendSimulationStateTransMessage = function (stateTrans) {
        return __awaiter(this, void 0, void 0, function () {
            var message;
            return __generator(this, function (_a) {
                message = this.messageBuilder.buildSimulationStateTransMessage(stateTrans);
                this.messageTransceiver.sendMessage(message);
                return [2 /*return*/];
            });
        });
    };
    ChildMessagesManager.prototype.sendCreateRequestMessage = function (requestEntityGroup, uiData) {
        var message = this.messageBuilder.buildCreateRequestMessage(requestEntityGroup, uiData);
        this.messageTransceiver.sendMessage(message);
    };
    ChildMessagesManager.prototype.sendDeleteMessage = function (entityIds) {
        var message = this.messageBuilder.buildDeleteMessage(entityIds);
        this.messageTransceiver.sendMessage(message);
    };
    ChildMessagesManager.prototype.sendPropertyMessage = function (entityId, property, uiData) {
        if (uiData === void 0) { uiData = null; }
        var message = this.messageBuilder.buildPropertyMessage(entityId, property, uiData);
        this.messageTransceiver.sendMessage(message);
    };
    ChildMessagesManager.prototype.sendActionMessage = function (entityId, action, uiData) {
        if (uiData === void 0) { uiData = null; }
        var message = this.messageBuilder.buildActionMessage(entityId, action, uiData);
        this.messageTransceiver.sendMessage(message);
    };
    ChildMessagesManager.prototype.sendInterctionMessage = function (activatorEntityId, reactorEntityId, interaction, uiData) {
        if (uiData === void 0) { uiData = null; }
        var message = this.messageBuilder.buildInteractionMessage(activatorEntityId, reactorEntityId, interaction, uiData);
        this.messageTransceiver.sendMessage(message);
    };
    ChildMessagesManager.prototype.handleMessages = function (messages, blockId) {
        var e_1, _a;
        var responses = [];
        try {
            for (var messages_1 = __values(messages), messages_1_1 = messages_1.next(); !messages_1_1.done; messages_1_1 = messages_1.next()) {
                var message = messages_1_1.value;
                var response = this.handleMessage(message);
                if (response !== null) {
                    responses.push(response);
                }
            }
        }
        catch (e_1_1) { e_1 = { error: e_1_1 }; }
        finally {
            try {
                if (messages_1_1 && !messages_1_1.done && (_a = messages_1.return)) _a.call(messages_1);
            }
            finally { if (e_1) throw e_1.error; }
        }
        // ! IMPORTANT: send message even if responses is empty
        // because parent might wait for block response
        this.messageTransceiver.sendMessages(responses, blockId, false);
    };
    ChildMessagesManager.prototype.handleMessage = function (message) {
        switch (message.type) {
            case "MODEL_REQUEST":
                // getMappedModelJson() is global on the child environment
                var modelJson = window.getMappedModelJson();
                return this.messageBuilder.buildModelResponseMessage(modelJson);
            case "PARENT_SIMULATION_STATE_TRANS":
                switch (message.stateTrans) {
                    case "UP":
                        PlethoraLib.getInstance().setSimulationState("UP");
                        // respond to up message with another up message
                        return this.messageBuilder.buildSimulationStateTransMessage("UP");
                    case "START":
                        PlethoraLib.getInstance().setSimulationState("RUNNING");
                        return null;
                    case "READY":
                        PlethoraLib.getInstance().setSimulationState("READY");
                        return null;
                    case "PAUSE":
                        PlethoraLib.getInstance().setSimulationState("PAUSED");
                        return null;
                    case "RESUME":
                        PlethoraLib.getInstance().setSimulationState("RUNNING");
                        return null;
                    case "RESET":
                        PlethoraLib.getInstance().reset();
                        // after reset is finished the state is UP, send UP message to parent
                        return this.messageBuilder.buildSimulationStateTransMessage("UP");
                }
            case "INIT":
                PlethoraLib.getInstance().setSimulationState("INIT");
                PlethoraLib.getInstance().getModel().init(message.entityGroups);
                return null;
            case "COMPUTE_FUNCTION":
                var functionResult = PlethoraLib.getInstance()
                    .getModel()
                    .getEntity(message.entityId)
                    .computeFunction(message.propertyName, message.functionParameters);
                return this.messageBuilder.buildFunctionResultMessage(functionResult, message.msgId);
            case "SET_ENTITY_HIGHLIGHT":
                PlethoraLib.getInstance()
                    .getModel()
                    .getEntity(message.entityId)
                    .onSetHighlight(message.highlight);
                return null;
            case "ACTION":
                PlethoraLib.getInstance()
                    .getModel()
                    .getEntity(message.entityId)
                    .applyAction(message.action.actionName, _convertActionParamsToDict(message.action.actionParameters), message.uiData, false);
                return null;
            case "INTERACTION":
                PlethoraLib.getInstance()
                    .getModel()
                    .getEntity(message.activatorEntityId)
                    .applyInteraction(message.reactorEntityId, message.interaction.actionName, _convertActionParamsToDict(message.interaction.actionParameters), message.uiData, false);
                return null;
            case "CREATE":
                PlethoraLib.getInstance()
                    .getModel()
                    .createUiEntites(message.entityGroup, message.uiData);
                return this.messageBuilder.buildDoneMessage(message.msgId);
            case "DELETE":
                PlethoraLib.getInstance()
                    .getModel()
                    .deleteEntities(message.entityIds, message.uiData, false);
                return null;
            case "PROPERTY":
                PlethoraLib.getInstance()
                    .getModel()
                    .getEntity(message.entityId)
                    .setPropertyValue(message.property.propertyName, message.property.value, message.uiData, false);
                return null;
            case "ERROR":
                var errorText = "ERROR ON PARENT: " + message.error;
                console.log(errorText);
                alert(errorText);
                return null;
            default:
                throw new Error("Illigal incoming message type: " + message.type);
        }
    };
    return ChildMessagesManager;
}());
export { ChildMessagesManager };
