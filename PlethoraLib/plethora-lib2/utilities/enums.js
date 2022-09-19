export var LogicalOperator;
(function (LogicalOperator) {
    LogicalOperator["And"] = "and";
    LogicalOperator["Or"] = "or";
})(LogicalOperator || (LogicalOperator = {}));
export var CompareSigns;
(function (CompareSigns) {
    CompareSigns["Equal"] = "=";
    CompareSigns["NotEqual"] = "\u2260";
    CompareSigns["GreaterEqual"] = "\u2265";
    CompareSigns["Greater"] = ">";
    CompareSigns["LessEqual"] = "\u2264";
    CompareSigns["Less"] = "<";
})(CompareSigns || (CompareSigns = {}));
export var DataType;
(function (DataType) {
    DataType["Enum"] = "enum";
    DataType["Number"] = "number";
    DataType["Boolean"] = "boolean";
    DataType["String"] = "string";
})(DataType || (DataType = {}));
export var IndicatorType;
(function (IndicatorType) {
    IndicatorType["Change"] = "change";
    IndicatorType["Increase"] = "increase";
    IndicatorType["Decrease"] = "decrease";
})(IndicatorType || (IndicatorType = {}));
export var PropertyEventType;
(function (PropertyEventType) {
    PropertyEventType["Assign"] = "assign";
    PropertyEventType["Add"] = "add";
    PropertyEventType["Substract"] = "substract";
    PropertyEventType["Multiply"] = "multiply";
    PropertyEventType["Devide"] = "devide";
})(PropertyEventType || (PropertyEventType = {}));
export var Multiplicity;
(function (Multiplicity) {
    Multiplicity["SingleEntity"] = "singleEntity";
    Multiplicity["Singleton"] = "singleton";
    Multiplicity["AllOf"] = "allOf";
    Multiplicity["SomeOf"] = "someOf";
})(Multiplicity || (Multiplicity = {}));
