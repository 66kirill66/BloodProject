import { PlethoraLib } from "plethora-lib";
import { bindEventHandlers } from "./eventHandlers";
import { globals } from "./globals";

import "./assets/index.css"
import { GeneratedModel } from "./GeneratedClasses/GeneratedModel"
require("jquery")

// expose variables to global scope
declare global {
    var gameInstance: {
      SendMessage: (
        objectName: string,
        methodName: string,
        value: string | number | boolean
      ) => void;
    };
  
    var PlethoraLib: any;
    var globals: any;
  }

globalThis.PlethoraLib = PlethoraLib;
globalThis.globals = globals;

bindEventHandlers();

