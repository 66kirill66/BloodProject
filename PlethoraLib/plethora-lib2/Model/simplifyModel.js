var __assign = (this && this.__assign) || function () {
    __assign = Object.assign || function(t) {
        for (var s, i = 1, n = arguments.length; i < n; i++) {
            s = arguments[i];
            for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p))
                t[p] = s[p];
        }
        return t;
    };
    return __assign.apply(this, arguments);
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
import { DataType } from "../utilities/enums";
export function simplifyModel(mappedModel) {
    // the simplified model is indexed by names and has the basic information
    // to understand the model structure
    return {
        enumTypes: _simplifyEnumTypes(mappedModel),
        interactions: _simplifyInteractions(mappedModel),
        entities: _simplifyEntities(mappedModel),
    };
}
function _simplifyEnumTypes(mappedModel) {
    var e_1, _a;
    var simpEnumTypes = {};
    try {
        for (var _b = __values(Object.values(mappedModel.enumTypes)), _c = _b.next(); !_c.done; _c = _b.next()) {
            var enumType = _c.value;
            var name_1 = enumType.name, allowedValues = enumType.allowedValues;
            simpEnumTypes[name_1] = {
                name: name_1,
                allowedValues: Object.values(allowedValues),
            };
        }
    }
    catch (e_1_1) { e_1 = { error: e_1_1 }; }
    finally {
        try {
            if (_c && !_c.done && (_a = _b.return)) _a.call(_b);
        }
        finally { if (e_1) throw e_1.error; }
    }
    return simpEnumTypes;
}
function _simplifyInteractions(mappedModel) {
    var e_2, _a;
    var simpInteractions = {};
    try {
        for (var _b = __values(Object.values(mappedModel.interactions)), _c = _b.next(); !_c.done; _c = _b.next()) {
            var interaction = _c.value;
            var name_2 = interaction.name, actionParameters = interaction.actionParameters, isSymmetric = interaction.isSymmetric, allowedActivatorsIds = interaction.allowedActivatorsIds, allowedReactorsIds = interaction.allowedReactorsIds;
            simpInteractions[name_2] = {
                name: name_2,
                actionParameters: _simplifyActionParams(mappedModel, actionParameters),
                isSymmetric: isSymmetric,
                allowedActivatorsNames: allowedActivatorsIds.map(function (entityId) { return mappedModel.entities[entityId].name; }),
                allowedReactorsNames: allowedReactorsIds.map(function (entityId) { return mappedModel.entities[entityId].name; }),
            };
        }
    }
    catch (e_2_1) { e_2 = { error: e_2_1 }; }
    finally {
        try {
            if (_c && !_c.done && (_a = _b.return)) _a.call(_b);
        }
        finally { if (e_2) throw e_2.error; }
    }
    return simpInteractions;
}
function _simplifyEntities(mappedModel) {
    var e_3, _a, e_4, _b;
    var simpEntities = {};
    try {
        for (var _c = __values(Object.values(mappedModel.entities)), _d = _c.next(); !_d.done; _d = _c.next()) {
            var entity = _d.value;
            var name_3 = entity.name, properties = entity.properties, actions = entity.actions, isSingleton = entity.isSingleton, maxInstances = entity.maxInstances, parentsIds = entity.parentsIds;
            simpEntities[name_3] = {
                name: name_3,
                isSingleton: isSingleton || false,
                maxInstances: typeof maxInstances !== "undefined" ? maxInstances : -1,
                parentsNames: (parentsIds === null || parentsIds === void 0 ? void 0 : parentsIds.map(function (entityId) { return mappedModel.entities[entityId].name; })) || [],
                ownProperties: _simplifyProperties(mappedModel, properties),
                ownActions: _simplifyActions(mappedModel, actions),
                allProperties: {},
                allActions: {},
            };
        }
    }
    catch (e_3_1) { e_3 = { error: e_3_1 }; }
    finally {
        try {
            if (_d && !_d.done && (_a = _c.return)) _a.call(_c);
        }
        finally { if (e_3) throw e_3.error; }
    }
    try {
        // gather properties and actions up inheritance
        for (var _e = __values(Object.values(simpEntities)), _f = _e.next(); !_f.done; _f = _e.next()) {
            var simpEntity = _f.value;
            var _g = _getAllPropertiesActions(simpEntity.name, simpEntities), properties = _g.properties, actions = _g.actions;
            simpEntity.allProperties = properties;
            simpEntity.allActions = actions;
        }
    }
    catch (e_4_1) { e_4 = { error: e_4_1 }; }
    finally {
        try {
            if (_f && !_f.done && (_b = _e.return)) _b.call(_e);
        }
        finally { if (e_4) throw e_4.error; }
    }
    return simpEntities;
}
function _getAllPropertiesActions(entityName, simpEntities) {
    var e_5, _a;
    var simpEntity = simpEntities[entityName];
    var parentEntityNames = simpEntity.parentsNames || [];
    // run recursively on all parents
    var parentsPropertiesActions = parentEntityNames.map(function (parentName) {
        return _getAllPropertiesActions(parentName, simpEntities);
    });
    var properties = __assign({}, simpEntity.ownProperties); // clone dictionary
    var actions = __assign({}, simpEntity.ownActions); // clone dictionary
    try {
        for (var parentsPropertiesActions_1 = __values(parentsPropertiesActions), parentsPropertiesActions_1_1 = parentsPropertiesActions_1.next(); !parentsPropertiesActions_1_1.done; parentsPropertiesActions_1_1 = parentsPropertiesActions_1.next()) {
            var parentPropertyActions = parentsPropertiesActions_1_1.value;
            Object.assign(properties, parentPropertyActions.properties); // merge fields
            Object.assign(actions, parentPropertyActions.actions); // merge fields
        }
    }
    catch (e_5_1) { e_5 = { error: e_5_1 }; }
    finally {
        try {
            if (parentsPropertiesActions_1_1 && !parentsPropertiesActions_1_1.done && (_a = parentsPropertiesActions_1.return)) _a.call(parentsPropertiesActions_1);
        }
        finally { if (e_5) throw e_5.error; }
    }
    return {
        properties: properties,
        actions: actions,
    };
}
function _simplifyProperties(mappedModel, properties) {
    var e_6, _a;
    var simpProperties = {};
    try {
        for (var _b = __values(Object.values(properties)), _c = _b.next(); !_c.done; _c = _b.next()) {
            var property = _c.value;
            var propertyName = property.name, computed = property.computed, dataType = property.dataType, enumTypeId = property.enumTypeId;
            simpProperties[propertyName] = {
                name: propertyName,
                computed: computed,
                dataType: dataType,
                enumTypeName: enumTypeId ? mappedModel.enumTypes[enumTypeId].name : undefined,
                settings: property.dataType === DataType.Number && !property.computed
                    ? property.settings
                    : undefined,
            };
        }
    }
    catch (e_6_1) { e_6 = { error: e_6_1 }; }
    finally {
        try {
            if (_c && !_c.done && (_a = _b.return)) _a.call(_b);
        }
        finally { if (e_6) throw e_6.error; }
    }
    return simpProperties;
}
function _simplifyActions(mappedModel, actions) {
    var e_7, _a;
    var simpActions = {};
    try {
        for (var _b = __values(Object.values(actions)), _c = _b.next(); !_c.done; _c = _b.next()) {
            var action = _c.value;
            var name_4 = action.name, actionParameters = action.actionParameters;
            simpActions[name_4] = {
                name: name_4,
                actionParameters: _simplifyActionParams(mappedModel, actionParameters),
            };
        }
    }
    catch (e_7_1) { e_7 = { error: e_7_1 }; }
    finally {
        try {
            if (_c && !_c.done && (_a = _b.return)) _a.call(_b);
        }
        finally { if (e_7) throw e_7.error; }
    }
    return simpActions;
}
function _simplifyActionParams(mappedModel, actionParameters) {
    var e_8, _a;
    var simpActionParameters = {};
    try {
        for (var _b = __values(Object.values(actionParameters)), _c = _b.next(); !_c.done; _c = _b.next()) {
            var actionParameter = _c.value;
            var name_5 = actionParameter.name, dataType = actionParameter.dataType, enumTypeId = actionParameter.enumTypeId;
            simpActionParameters[name_5] = {
                name: name_5,
                dataType: dataType,
                enumTypeName: enumTypeId ? mappedModel.enumTypes[enumTypeId].name : undefined,
            };
        }
    }
    catch (e_8_1) { e_8 = { error: e_8_1 }; }
    finally {
        try {
            if (_c && !_c.done && (_a = _b.return)) _a.call(_b);
        }
        finally { if (e_8) throw e_8.error; }
    }
    return simpActionParameters;
}
