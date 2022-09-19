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
import { ChildMessagesManager } from "./ChildMessagesManager";
var PlethoraLib = /** @class */ (function () {
    function PlethoraLib() {
        this.simulationState = "LOADING";
        this.messagesManager = new ChildMessagesManager();
    }
    PlethoraLib.getInstance = function () {
        if (!PlethoraLib._instance) {
            PlethoraLib._instance = new PlethoraLib();
        }
        return PlethoraLib._instance;
    };
    PlethoraLib.prototype.getSimulationState = function () {
        return this.simulationState;
    };
    PlethoraLib.prototype.setSimulationState = function (state) {
        this.simulationState = state;
        if (typeof this._onSimulationStateChange === "function") {
            this._onSimulationStateChange(state);
        }
    };
    PlethoraLib.prototype.requestInit = function (model) {
        if (this.simulationState !== "LOADING") {
            throw new Error("requestInit() should be called on LOADING state only");
        }
        this._model = model;
        this.setSimulationState("UP");
        // send UP message to indicate that iframe is up and ready for init
        this.messagesManager.sendSimulationStateTransMessage("UP");
    };
    PlethoraLib.prototype.requestStart = function () {
        if (this.simulationState === "RUNNING") {
            // ignore if we are already running
            return;
        }
        else if (this.simulationState !== "READY") {
            throw new Error("requestStart() can't be called when the simulation state is ".concat(this.simulationState, "."));
        }
        this.messagesManager.sendSimulationStateTransMessage("START");
    };
    PlethoraLib.prototype.reset = function () {
        var e_1, _a;
        // should not be called by the UI directly!
        if (this.simulationState !== "RUNNING" && this.simulationState !== "PAUSED") {
            throw new Error("Simulation state should be RUNNING or PAUSED to call reset()");
        }
        this.setSimulationState("RESET");
        try {
            // call onDestroy on all entities
            for (var _b = __values(this.getModel().getEntities()), _c = _b.next(); !_c.done; _c = _b.next()) {
                var entity = _c.value;
                entity.onDestory();
            }
        }
        catch (e_1_1) { e_1 = { error: e_1_1 }; }
        finally {
            try {
                if (_c && !_c.done && (_a = _b.return)) _a.call(_b);
            }
            finally { if (e_1) throw e_1.error; }
        }
        // call onReset
        if (typeof this._onReset === "function") {
            this._onReset();
        }
        // reset the model
        this.getModel().reset();
        this.setSimulationState("UP");
    };
    PlethoraLib.prototype.getModel = function () {
        if (!this._model) {
            throw new Error("PlethoraLib was not initialized. Call PlethoraLib.getInstance().requestInit(model) first");
        }
        return this._model;
    };
    PlethoraLib.prototype.getMessagesManager = function () {
        return this.messagesManager;
    };
    PlethoraLib.prototype.onReset = function (handler) {
        this._onReset = handler;
    };
    PlethoraLib.prototype.onSimulationStateChange = function (handler) {
        this._onSimulationStateChange = handler;
    };
    return PlethoraLib;
}());
export { PlethoraLib };
