import { AbstractEntity, PlethoraLib, UiData } from "plethora-lib";
import { GeneratedModel } from "./GeneratedClasses/GeneratedModel";
import { Blood } from "./UiClasses/Blood";
import { Insulin } from "./UiClasses/Insulin";
import { InsulinReceptor } from "./UiClasses/InsulinReceptor";
import { SignalMolecule } from "./UiClasses/SignalMolecule";
import { Channel } from "./UiClasses/Channel";
import { SignalMolecule2 } from "./UiClasses/SignalMolecule2";
import { Sugar } from "./UiClasses/Sugar";
import { SugarStorage } from "./UiClasses/SugarStorage";
import { Enzyme } from "./UiClasses/Enzyme";
import { SimulationState } from "plethora-lib/API/api.definitions";
import { Glucagon } from "./UiClasses/Glucagon";
import { DataTypeLocation } from "./GeneratedClasses/GeneratedDataTypes";
import { DataTypeState } from "./GeneratedClasses/GeneratedDataTypes";


export let globals: Record<string, any> = {};

// call when simulation is ready to start communicating with plethora
globals.init = function () {
  PlethoraLib.getInstance().requestInit(new GeneratedModel());
  console.log("Iframe Ready");
};

globals.createRequestSignalM = function (receptorId: number)
{
  const uiData = {
    receptorId : receptorId
  }
  SignalMolecule.createRequest({},1,uiData)
};

globals.createRequestNewSignalMTo = function (receptorId: number)
{
  const uiData = {
    receptorId : receptorId
  }
  SignalMolecule2.createRequest({},1,uiData)
};

globals.createRequestNewSugarStorage = function (storagePlaceCount: number)
{
  const uiData = {
    storagePlaceCount : storagePlaceCount
  }
  SugarStorage.createRequest({},1,uiData)
};



// call when an entity is clicked
globals.entityClick = function (entityId: number) {
  const entityInstance = PlethoraLib.getInstance()
    .getModel()
    .getEntity(entityId);
  entityInstance.click();
};


globals.setSugarLevel = function (bloodId: number,newLevel: number)  {
  const blood = window.PlethoraLib.getInstance()
    .getModel()
    .getEntity(bloodId);
  if (blood instanceof Blood) {
    console.log("object Blood found " + newLevel)
    blood.setSugarLevel(newLevel,this.id); } 
  else {
    console.error("object is not blood");
  }
};

globals.setInsulinLevel = function (bloodId: number,newLevel: number)  {
  const blood = window.PlethoraLib.getInstance()
    .getModel()
    .getEntity(bloodId);
  if (blood instanceof Blood) {
    console.log("object Blood found " + newLevel)
    blood.setInsulinLevel(newLevel,this.id);} 
  else 
  {
    console.error("object is not blood");
  }
};


globals.setGlucagonLevel = function (bloodId: number,newLevel: number)  {
  const blood = window.PlethoraLib.getInstance()
    .getModel()
    .getEntity(bloodId);
  if (blood instanceof Blood)
  {
    console.log("Object Blood found " + newLevel)
    blood.setGlucagonLevel(newLevel,this.id);  
  } 
  else 
  {
    console.error("Object is not blood");
  }
};

globals.applyMeetInsReceptor = function (insulinId : number, receptorId : number)
 {
  const insulin = window.PlethoraLib.getInstance().getModel().getEntity(insulinId)
  if (insulin instanceof Insulin)
  {
    insulin.applyMeet(receptorId)
  }  
};

globals.insulunMeetGlucReceptor = function (insulinId : number, receptorId : number)
 {
  const insulin = window.PlethoraLib.getInstance().getModel().getEntity(insulinId)
  if (insulin instanceof Insulin)
  {
    insulin.applyMeet(receptorId)
  }  
};

globals.insulunMeetChannal = function (insulinId : number, channelId : number)
 {  
  const channel = window.PlethoraLib.getInstance().getModel().getEntity(channelId)
  if (channel instanceof Channel)
  { 
    channel.applyMeet(insulinId)
  }  
};

globals.glucagonMeetInsReceptor = function (glucagonId : number, receptorId : number)
 {
  const glucagon = window.PlethoraLib.getInstance().getModel().getEntity(glucagonId)
  if (glucagon instanceof Glucagon)
  {
    glucagon.applyMeet(receptorId)
  }  
};

globals.glucagonMeetChannal = function (glucagonId : number, channelId : number)
 {  
  const channel = window.PlethoraLib.getInstance().getModel().getEntity(channelId)
  if (channel instanceof Channel)
  { 
    channel.applyMeet(glucagonId)
  }  
};

globals.applyMeetGlucReceptor = function (glucagonId : number, receptorId : number)
 {
  const glucagon = window.PlethoraLib.getInstance().getModel().getEntity(glucagonId)
  if (glucagon instanceof Glucagon)
  {
    glucagon.applyMeet(receptorId)
  }  
};

globals.applyMeetChannel = function (signalId : number, channelId : number)
 {  
  const channel = window.PlethoraLib.getInstance().getModel().getEntity(channelId)
  if (channel instanceof Channel)
  { 
    channel.applyMeet(signalId)
  }  
};

// globals.signalMToApplyMeetChannel = function (signalId : number, channelId : number)
//  {  
//   const channel = window.PlethoraLib.getInstance().getModel().getEntity(channelId)
//   if (channel instanceof Channel)
//   { 
//     channel.applyMeet(signalId)
//   }  
// };

globals.sugarMeetChannal = function (sugarId : number, channalId : number)
 {
  const sugar = window.PlethoraLib.getInstance().getModel().getEntity(sugarId)
  if (sugar instanceof Sugar)
  { 
    sugar.applyMeet(channalId)
  }  
};
globals.sugarMeetInsulinRec = function (sugarId : number, receptorId : number)
 {
  const sugar = window.PlethoraLib.getInstance().getModel().getEntity(sugarId)
  if (sugar instanceof Sugar)
  { 
    sugar.applyMeet(receptorId)
  }  
};
globals.sugarMeetGlucagonRec = function (sugarId : number, receptorId : number)
 {
  const sugar = window.PlethoraLib.getInstance().getModel().getEntity(sugarId)
  if (sugar instanceof Sugar)
  { 
    sugar.applyMeet(receptorId)
  }  
};

globals.setSignalLevel = function (signalId: UiData)  {
  const signal = window.PlethoraLib.getInstance()
    .getModel()
    .getEntity(signalId);
  if (signal instanceof SignalMolecule){ 
    signal.delete(signalId)} 
    if (signal instanceof SignalMolecule2){
    signal.delete(signalId)} 
};

globals.setEnzimeLevel = function (enzimeId: UiData)  {
  const enzime = window.PlethoraLib.getInstance()
    .getModel()
    .getEntity(enzimeId);
  if (enzime instanceof Enzyme){ 
    enzime.delete(enzimeId)} 
    
};
globals.setSugarStorageLevel = function (storageId: UiData)  {
  const storage = window.PlethoraLib.getInstance()
    .getModel()
    .getEntity(storageId);
  if (storage instanceof SugarStorage){ 
    storage.delete(storageId)} 
    
};

globals.setChannelLocation = function (value: DataTypeLocation ,channalId: UiData)  { 
  
  const channel = window.PlethoraLib.getInstance()
    .getModel()
    .getEntity(channalId);
  if (channel instanceof Channel) {
      channel.setLocation(value);}  
};



globals.setSignalAttachedToReceptor = function (value: boolean )  { //,signalId: UiData
  console.log("setSignalAttachedToReceptorMolOne",value)
  const signal = window.PlethoraLib.getInstance()
    .getModel()
    .getEntity(value);
  if (signal instanceof SignalMolecule)
  {
    signal.setAttachedToReceptor(value)//,this.id   
  } 
};

globals.setSignalToAttachedToReceptor = function (value: boolean )  { //,signalId: UiData
  console.log("setSignalAttachedToReceptorMolTo",value)
  const signal = window.PlethoraLib.getInstance()
    .getModel()
    .getEntity(value);
  if (signal instanceof SignalMolecule2)
  {
    signal.setAttachedToReceptor(value)//,this.id    
  } 
};

globals.enzimeMeetStorage = function (enzimeId : number, storagelId : number)
 {
  console.log("----------------","enzimeMeetStorage")
  const enzime = window.PlethoraLib.getInstance().getModel().getEntity(enzimeId)
  if (enzime instanceof Enzyme)
  { 
    enzime.applyMeet(storagelId)
  }  
};
globals.enzimeMeetSignalTo = function (enzimeId : number, signalToId : number)
 {
  console.log("----------------","enzimeMeetSignalTo")
  const enzime = window.PlethoraLib.getInstance().getModel().getEntity(enzimeId)
  if (enzime instanceof Enzyme)
  { 
    enzime.applyMeet(signalToId)
  }  
};

// Use this file to create global functions of your own
// the 'globals' object will be available on the global scope of the program
// it can be later used on Unity jslib like: globals.exampleFunction()
globals.exampleFunction = function () {
  // YOUR CODE HERE
};
