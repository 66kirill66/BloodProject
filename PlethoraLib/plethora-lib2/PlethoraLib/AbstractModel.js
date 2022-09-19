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
var AbstractModel = /** @class */ (function () {
    function AbstractModel() {
        this.wasInit = false;
        this.entities = new Map(); // all entities
        this.singletonsIds = new Map(); // map singleton name to id
    }
    AbstractModel.prototype.init = function (entityGroups) {
        var e_1, _a;
        if (this.wasInit) {
            throw new Error("Model was already initialized");
        }
        this.wasInit = true;
        try {
            for (var entityGroups_1 = __values(entityGroups), entityGroups_1_1 = entityGroups_1.next(); !entityGroups_1_1.done; entityGroups_1_1 = entityGroups_1.next()) {
                var entityGroup = entityGroups_1_1.value;
                this.createUiEntites(entityGroup, null);
            }
        }
        catch (e_1_1) { e_1 = { error: e_1_1 }; }
        finally {
            try {
                if (entityGroups_1_1 && !entityGroups_1_1.done && (_a = entityGroups_1.return)) _a.call(entityGroups_1);
            }
            finally { if (e_1) throw e_1.error; }
        }
    };
    AbstractModel.prototype.createUiEntites = function (entityGroup, uiData) {
        var createdEntities = [];
        var entityName = entityGroup.entityName, properties = entityGroup.properties, quantity = entityGroup.quantity, startingId = entityGroup.startingId;
        for (var id = startingId; id < startingId + quantity; id++) {
            var propertyValues = _convertPropertyValuesToDict(properties);
            var entity = this.createUiEntity(entityName, id, propertyValues, uiData);
            this.setEntity(id, entity);
            createdEntities.push(entity);
            if (this.isSingleton(entityName)) {
                this.singletonsIds.set(entityName, id);
            }
        }
        return createdEntities;
    };
    AbstractModel.prototype.forEachEntity = function (callback) {
        var e_2, _a;
        try {
            for (var _b = __values(this.entities.values()), _c = _b.next(); !_c.done; _c = _b.next()) {
                var entity = _c.value;
                callback(entity);
            }
        }
        catch (e_2_1) { e_2 = { error: e_2_1 }; }
        finally {
            try {
                if (_c && !_c.done && (_a = _b.return)) _a.call(_b);
            }
            finally { if (e_2) throw e_2.error; }
        }
    };
    AbstractModel.prototype.getSingleton = function (name) {
        var entityId = this.singletonsIds.get(name);
        if (typeof entityId === "undefined") {
            throw new Error("Singleton \"".concat(name, "\" does not exist"));
        }
        return this.getEntity(entityId);
    };
    AbstractModel.prototype.getEntities = function () {
        return Array.from(this.entities.values());
    };
    AbstractModel.prototype.setEntity = function (entityId, entity) {
        if (this.entities.has(entityId)) {
            throw new Error("Duplicate entity ids " + entityId);
        }
        this.entities.set(entityId, entity);
    };
    AbstractModel.prototype.getEntity = function (entityId) {
        var entity = this.entities.get(entityId);
        if (typeof entity === "undefined") {
            throw new Error("EntityId ".concat(entityId, " was not found"));
        }
        return entity;
    };
    AbstractModel.prototype.deleteEntities = function (entityIds, uiData, updateParent) {
        var e_3, _a;
        if (uiData === void 0) { uiData = null; }
        if (updateParent === void 0) { updateParent = true; }
        try {
            // delete entities
            for (var entityIds_1 = __values(entityIds), entityIds_1_1 = entityIds_1.next(); !entityIds_1_1.done; entityIds_1_1 = entityIds_1.next()) {
                var entityId = entityIds_1_1.value;
                var entity = this.entities.get(entityId);
                if (typeof entity === "undefined") {
                    console.error("Trying to delete entity [".concat(entityId, "] but it doesn't exist"));
                    continue;
                }
                this.entities.delete(entityId);
                var entityName = entity.name;
                if (this.isSingleton(entityName)) {
                    this.singletonsIds.delete(entityName);
                }
                entity.logToConsole("onDelete", ""); // log for testing
                entity.onDelete(uiData);
            }
        }
        catch (e_3_1) { e_3 = { error: e_3_1 }; }
        finally {
            try {
                if (entityIds_1_1 && !entityIds_1_1.done && (_a = entityIds_1.return)) _a.call(entityIds_1);
            }
            finally { if (e_3) throw e_3.error; }
        }
        // send message to parent
        if (updateParent) {
            PlethoraLib.getInstance().getMessagesManager().sendDeleteMessage(entityIds);
        }
    };
    AbstractModel.prototype.deleteEntity = function (entityId, uiData) {
        if (uiData === void 0) { uiData = null; }
        this.deleteEntities([entityId], uiData);
    };
    AbstractModel.prototype.reset = function () {
        this.entities.clear();
        this.singletonsIds.clear();
        this.wasInit = false;
    };
    AbstractModel.prototype.toString = function () {
        var e_4, _a;
        var res = "";
        try {
            for (var _b = __values(this.entities.values()), _c = _b.next(); !_c.done; _c = _b.next()) {
                var entity = _c.value;
                res += entity.toString() + "\n";
            }
        }
        catch (e_4_1) { e_4 = { error: e_4_1 }; }
        finally {
            try {
                if (_c && !_c.done && (_a = _b.return)) _a.call(_b);
            }
            finally { if (e_4) throw e_4.error; }
        }
        return res;
    };
    return AbstractModel;
}());
export { AbstractModel };
function _convertPropertyValuesToDict(properties) {
    var e_5, _a;
    var propertiesValues = {};
    try {
        for (var properties_1 = __values(properties), properties_1_1 = properties_1.next(); !properties_1_1.done; properties_1_1 = properties_1.next()) {
            var property = properties_1_1.value;
            propertiesValues[property.propertyName] = property.value;
        }
    }
    catch (e_5_1) { e_5 = { error: e_5_1 }; }
    finally {
        try {
            if (properties_1_1 && !properties_1_1.done && (_a = properties_1.return)) _a.call(properties_1);
        }
        finally { if (e_5) throw e_5.error; }
    }
    return propertiesValues;
}
export function _convertPropertyValuesToArray(propertiesValues) {
    var e_6, _a;
    var properties = [];
    try {
        for (var _b = __values(Object.entries(propertiesValues)), _c = _b.next(); !_c.done; _c = _b.next()) {
            var _d = __read(_c.value, 2), propertyName = _d[0], value = _d[1];
            properties.push({
                propertyName: propertyName,
                value: value,
            });
        }
    }
    catch (e_6_1) { e_6 = { error: e_6_1 }; }
    finally {
        try {
            if (_c && !_c.done && (_a = _b.return)) _a.call(_b);
        }
        finally { if (e_6) throw e_6.error; }
    }
    return properties;
}
