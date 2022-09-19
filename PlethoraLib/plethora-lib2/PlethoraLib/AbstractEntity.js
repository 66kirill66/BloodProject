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
var __read = (this && this.__read) || function (o, n) {
    var m = typeof Symbol === "function" && o[Symbol.iterator];
    if (!m) return o;
    var i = m.call(o), r, ar = [], e;
    try {
        while ((n === void 0 || n-- > 0) && !(r = i.next()).done) ar.push(r.value);
    }
    catch (error) { e = { error: error }; }
    finally {
        try {
            if (r && !r.done && (m = i["return"])) m.call(i);
        }
        finally { if (e) throw e.error; }
    }
    return ar;
};
import { PlethoraLib } from "./PlethoraLib";
var AbstractEntity = /** @class */ (function () {
    function AbstractEntity(name, id, propertyValues, parentsNames) {
        var e_1, _a;
        this.propertyValuesMap = new Map();
        this.name = name;
        this.id = id;
        this.parentsNames = parentsNames;
        try {
            // init properties values
            for (var _b = __values(Object.entries(propertyValues)), _c = _b.next(); !_c.done; _c = _b.next()) {
                var _d = __read(_c.value, 2), propertyName = _d[0], value = _d[1];
                if (typeof value === "undefined") {
                    throw new Error("Value of property ".concat(propertyName, " is undefined"));
                }
                // TODO: validate that it's all of the props?
                this.propertyValuesMap.set(propertyName, value);
            }
        }
        catch (e_1_1) { e_1 = { error: e_1_1 }; }
        finally {
            try {
                if (_c && !_c.done && (_a = _b.return)) _a.call(_b);
            }
            finally { if (e_1) throw e_1.error; }
        }
        this.logToConsole("constructor", "");
    }
    AbstractEntity.prototype.isA = function (entityName) {
        return this.name === entityName || this.parentsNames.includes(entityName);
    };
    AbstractEntity.prototype.click = function () {
        PlethoraLib.getInstance().getMessagesManager().sendClickMessage(this.id);
    };
    AbstractEntity.prototype.delete = function (uiData) {
        if (uiData === void 0) { uiData = null; }
        PlethoraLib.getInstance().getModel().deleteEntity(this.id, uiData);
    };
    AbstractEntity.prototype.getPropertyValue = function (propertyName) {
        var value = this.propertyValuesMap.get(propertyName);
        if (typeof value === "undefined") {
            throw new Error("Property \"".concat(propertyName, "\" was not found"));
        }
        return value;
    };
    AbstractEntity.prototype.setPropertyValue = function (propertyName, value, uiData, updateParent) {
        if (!this.propertyValuesMap.has(propertyName)) {
            throw new Error("Property ".concat(propertyName, " was not found"));
        }
        var oldValue = this.getPropertyValue(propertyName);
        this.propertyValuesMap.set(propertyName, value);
        if (updateParent) {
            PlethoraLib.getInstance().getMessagesManager().sendPropertyMessage(this.id, {
                propertyName: propertyName,
                value: value,
            }, uiData);
        }
        // log to console
        this.logToConsole("setPropertyValue", "".concat(propertyName, ", ").concat(value));
        // call handler
        this.onPropertyUpdate(propertyName, value, oldValue, uiData);
    };
    AbstractEntity.prototype.applyAction = function (actionName, actionParameters, uiData, updateParent) {
        var actionParametersArr = _convertActionParamsToArray(actionParameters);
        if (updateParent && this.isSimulationRunning()) {
            PlethoraLib.getInstance().getMessagesManager().sendActionMessage(this.id, {
                actionName: actionName,
                actionParameters: actionParametersArr,
            }, uiData);
        }
        // log to console
        var paramsToLog = actionParametersArr.map(function (param) { return "".concat(param.actionParameterName, " = ").concat(param.value); });
        this.logToConsole("applyAction", "".concat(actionName, ", [").concat(paramsToLog.join(", "), "]"));
        // call handler              
        this.onAction(actionName, actionParameters, uiData);
    };
    AbstractEntity.prototype.applyInteraction = function (reactorId, interactionName, interactionParameters, uiData, updateParent) {
        var interactionParametersArr = _convertActionParamsToArray(interactionParameters);
        if (updateParent && this.isSimulationRunning()) {
            PlethoraLib.getInstance().getMessagesManager().sendInterctionMessage(this.id, reactorId, {
                actionName: interactionName,
                actionParameters: interactionParametersArr,
            }, uiData);
        }
        // log to console
        var paramsToLog = interactionParametersArr.map(function (param) { return "".concat(param.actionParameterName, " = ").concat(param.value); });
        this.logToConsole("applyInteraction", "".concat(reactorId, ", ").concat(interactionName, ", [").concat(paramsToLog.join(", "), "]"));
        // call handler
        var reactorEntity = PlethoraLib.getInstance().getModel().getEntity(reactorId);
        this.onInteraction(interactionName, reactorEntity, interactionParameters, uiData);
    };
    AbstractEntity.prototype.isSimulationRunning = function () {
        // used on action and interaction to skip sending them when we know
        // they will not be processed on the parent
        var simulationState = PlethoraLib.getInstance().getSimulationState();
        return simulationState === "RUNNING";
    };
    AbstractEntity.prototype.logToConsole = function (functionName, params) {
        var css = "color: orange";
        console.log("%c [".concat(this.id, "] ").concat(this.name, " ").concat(functionName, "(").concat(params, ")"), css);
    };
    AbstractEntity.prototype.toString = function () {
        var e_2, _a;
        var props = [];
        try {
            for (var _b = __values(this.propertyValuesMap.entries()), _c = _b.next(); !_c.done; _c = _b.next()) {
                var _d = __read(_c.value, 2), propertyName = _d[0], value = _d[1];
                props.push("".concat(propertyName, " = ").concat(value));
            }
        }
        catch (e_2_1) { e_2 = { error: e_2_1 }; }
        finally {
            try {
                if (_c && !_c.done && (_a = _b.return)) _a.call(_b);
            }
            finally { if (e_2) throw e_2.error; }
        }
        return "[".concat(this.id, "] (").concat(this.name, ": ").concat(props.join(", "), ")");
    };
    return AbstractEntity;
}());
export { AbstractEntity };
export function _convertActionParamsToDict(actionParameters) {
    var e_3, _a;
    var paramsByNames = {};
    try {
        for (var actionParameters_1 = __values(actionParameters), actionParameters_1_1 = actionParameters_1.next(); !actionParameters_1_1.done; actionParameters_1_1 = actionParameters_1.next()) {
            var param = actionParameters_1_1.value;
            paramsByNames[param.actionParameterName] = param.value;
        }
    }
    catch (e_3_1) { e_3 = { error: e_3_1 }; }
    finally {
        try {
            if (actionParameters_1_1 && !actionParameters_1_1.done && (_a = actionParameters_1.return)) _a.call(actionParameters_1);
        }
        finally { if (e_3) throw e_3.error; }
    }
    return paramsByNames;
}
export function _convertActionParamsToArray(paramsByNames) {
    var e_4, _a;
    var actionParameters = [];
    try {
        for (var _b = __values(Object.entries(paramsByNames)), _c = _b.next(); !_c.done; _c = _b.next()) {
            var _d = __read(_c.value, 2), actionParameterName = _d[0], value = _d[1];
            actionParameters.push({
                actionParameterName: actionParameterName,
                value: value,
            });
        }
    }
    catch (e_4_1) { e_4 = { error: e_4_1 }; }
    finally {
        try {
            if (_c && !_c.done && (_a = _b.return)) _a.call(_b);
        }
        finally { if (e_4) throw e_4.error; }
    }
    return actionParameters;
}
