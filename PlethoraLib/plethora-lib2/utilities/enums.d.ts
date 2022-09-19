export declare enum LogicalOperator {
    And = "and",
    Or = "or"
}
export declare enum CompareSigns {
    Equal = "=",
    NotEqual = "\u2260",
    GreaterEqual = "\u2265",
    Greater = ">",
    LessEqual = "\u2264",
    Less = "<"
}
export declare enum DataType {
    Enum = "enum",
    Number = "number",
    Boolean = "boolean",
    String = "string"
}
export declare enum IndicatorType {
    Change = "change",
    Increase = "increase",
    Decrease = "decrease"
}
export declare enum PropertyEventType {
    Assign = "assign",
    Add = "add",
    Substract = "substract",
    Multiply = "multiply",
    Devide = "devide"
}
export declare type MathOperation = PropertyEventType.Add | PropertyEventType.Substract | PropertyEventType.Multiply | PropertyEventType.Devide;
export declare enum Multiplicity {
    SingleEntity = "singleEntity",
    Singleton = "singleton",
    AllOf = "allOf",
    SomeOf = "someOf"
}
