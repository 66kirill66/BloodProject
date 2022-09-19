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
var MessageTransceiver = /** @class */ (function () {
    function MessageTransceiver(name, messageBuilder, messageHandler, target, isParent) {
        this.wasInit = false;
        this.nextMsgBlockId = 0;
        this.messageBlockListeners = new Map();
        this.messageListeners = new Map();
        this.name = name;
        this.target = target;
        this.isParent = isParent;
        this.messageBuilder = messageBuilder;
        this.messageHandler = messageHandler;
        this.sendAs = this.isParent ? "science-parent" : "science-child";
        this.listenTo = this.isParent ? "science-child" : "science-parent";
        this.bindListener();
    }
    MessageTransceiver.prototype.bindListener = function () {
        var _this = this;
        if (this.wasInit) {
            throw new Error("MessageTransceiver was already initialized");
        }
        this.wasInit = true;
        this.listener = function (event) { return __awaiter(_this, void 0, void 0, function () {
            var data, messages, error_1, errorText;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0:
                        data = event.data;
                        if (!(data.source && data.source === this.listenTo)) return [3 /*break*/, 4];
                        messages = data.payload;
                        this.logMessages("-- ".concat(this.name, " RECIEVED"), messages, data.blockId);
                        _a.label = 1;
                    case 1:
                        _a.trys.push([1, 3, , 4]);
                        this.checkBlockMessageListeners(data.respondingToBlockId);
                        this.checkMessageListeners(messages);
                        return [4 /*yield*/, this.messageHandler(messages, data.blockId)];
                    case 2:
                        _a.sent();
                        return [3 /*break*/, 4];
                    case 3:
                        error_1 = _a.sent();
                        console.error(error_1);
                        errorText = error_1 instanceof Error ? error_1.message : "unkown error";
                        this.sendMessage(this.messageBuilder.buildErrorMessage(errorText));
                        return [3 /*break*/, 4];
                    case 4: return [2 /*return*/];
                }
            });
        }); };
        window.addEventListener("message", this.listener, false);
    };
    MessageTransceiver.prototype.detach = function () {
        if (typeof this.listener !== "undefined") {
            // remove old listener
            console.log("remove listener");
            window.removeEventListener("message", this.listener, false);
        }
    };
    MessageTransceiver.prototype.addMessageBlockListener = function (blockId) {
        return __awaiter(this, void 0, void 0, function () {
            var _this = this;
            return __generator(this, function (_a) {
                return [2 /*return*/, new Promise(function (resolve) {
                        _this.messageBlockListeners.set(blockId, resolve);
                    })];
            });
        });
    };
    MessageTransceiver.prototype.checkBlockMessageListeners = function (respondingToBlockId) {
        if (respondingToBlockId !== null) {
            var messageBlockListener = this.messageBlockListeners.get(respondingToBlockId);
            if (typeof messageBlockListener === "function") {
                messageBlockListener();
            }
        }
    };
    MessageTransceiver.prototype.sendMessages = function (messages, respondingToBlockId, waitForBlockResponse) {
        return __awaiter(this, void 0, void 0, function () {
            var blockId, messageBlockPromise, messagesContainer;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0:
                        blockId = this.nextMsgBlockId++;
                        this.logMessages(">> ".concat(this.name, " SENT"), messages, blockId, respondingToBlockId);
                        messageBlockPromise = waitForBlockResponse
                            ? this.addMessageBlockListener(blockId)
                            : null;
                        messagesContainer = {
                            source: this.sendAs,
                            payload: messages,
                            blockId: blockId,
                            respondingToBlockId: respondingToBlockId,
                        };
                        this.target.postMessage(messagesContainer, "*");
                        return [4 /*yield*/, messageBlockPromise];
                    case 1:
                        _a.sent();
                        return [2 /*return*/];
                }
            });
        });
    };
    MessageTransceiver.prototype.sendMessage = function (message, respondingToBlockId) {
        if (respondingToBlockId === void 0) { respondingToBlockId = null; }
        this.sendMessages([message], respondingToBlockId, false);
    };
    MessageTransceiver.prototype.sendMessageAndWaitForResponse = function (message, respondingToBlockId) {
        if (respondingToBlockId === void 0) { respondingToBlockId = null; }
        return __awaiter(this, void 0, void 0, function () {
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, this.sendMessages([message], respondingToBlockId, true)];
                    case 1:
                        _a.sent();
                        return [2 /*return*/];
                }
            });
        });
    };
    MessageTransceiver.prototype.sendMessageWithListener = function (messageToSend, listenerType, listenerCallaback) {
        return __awaiter(this, void 0, void 0, function () {
            var listenerPromise;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0:
                        listenerPromise = this.addMessageListener(listenerType, listenerCallaback);
                        // send compute function message
                        this.sendMessage(messageToSend);
                        return [4 /*yield*/, listenerPromise];
                    case 1: 
                    // wait for result
                    return [2 /*return*/, _a.sent()];
                }
            });
        });
    };
    MessageTransceiver.prototype.addMessageListener = function (type, callback) {
        return __awaiter(this, void 0, void 0, function () {
            var _this = this;
            return __generator(this, function (_a) {
                return [2 /*return*/, new Promise(function (resolve) {
                        if (!_this.messageListeners.has(type)) {
                            // create new Set if it's the first listener of this type
                            _this.messageListeners.set(type, []);
                        }
                        _this.messageListeners.get(type).push({ callback: callback, resolve: resolve });
                    })];
            });
        });
    };
    MessageTransceiver.prototype.checkMessageListeners = function (messages) {
        // for each listener of the matching type,
        // check the callback and resolve the promise
        // if it returns true
        var e_1, _a, e_2, _b;
        try {
            for (var messages_1 = __values(messages), messages_1_1 = messages_1.next(); !messages_1_1.done; messages_1_1 = messages_1.next()) {
                var message = messages_1_1.value;
                var messageListeners = this.messageListeners.get(message.type);
                if (typeof messageListeners === "undefined") {
                    return;
                }
                try {
                    for (var messageListeners_1 = (e_2 = void 0, __values(messageListeners)), messageListeners_1_1 = messageListeners_1.next(); !messageListeners_1_1.done; messageListeners_1_1 = messageListeners_1.next()) {
                        var messageListener = messageListeners_1_1.value;
                        var shouldResolve = typeof messageListener.callback === "function"
                            ? messageListener.callback(message)
                            : true;
                        if (shouldResolve) {
                            messageListener.resolve(message);
                        }
                    }
                }
                catch (e_2_1) { e_2 = { error: e_2_1 }; }
                finally {
                    try {
                        if (messageListeners_1_1 && !messageListeners_1_1.done && (_b = messageListeners_1.return)) _b.call(messageListeners_1);
                    }
                    finally { if (e_2) throw e_2.error; }
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
    };
    MessageTransceiver.prototype.logMessages = function (prefix, messages, blockId, respondingToBlockId) {
        if (respondingToBlockId === void 0) { respondingToBlockId = null; }
        var css = this.isParent ? "color: green" : "color: red";
        var msgsIds = messages.map(function (msg) {
            var respondingToMsgId = msg.respondingToMsgId || null;
            return "".concat(msg.msgId).concat(respondingToMsgId === null ? "" : "\uD83E\uDC52".concat(respondingToMsgId), ":").concat(msg.type);
        });
        console.log("%c ".concat(prefix, " [").concat(blockId).concat(respondingToBlockId === null ? "" : " \uD83E\uDC52 ".concat(respondingToBlockId), " | (").concat(msgsIds.join(", "), ")]: %O"), css, messages);
    };
    return MessageTransceiver;
}());
export { MessageTransceiver };
