mergeInto(LibraryManager.library,
{
    callTNITfunction: function () 
  {
    globals.init();
  },

  //
   ClickFunc: function (bloodId)
  {
    globals.entityClick(bloodId);
  },

  //
   SetSugarLevelNew: function (sugarId,Value)
  {
    globals.setSugarLevel(sugarId,Value)
  },

  //
   SetInsulinLevelNew: function (insulinId,Value)
  {
    globals.setInsulinLevel(insulinId,Value)
  },

  //
   SetGlucagonLevelNew: function (glucagonId,Value)
  {
    globals.setGlucagonLevel(glucagonId,Value)
  },

  // 
   ApplyMeetInsReceptor: function (insulinId,receptorId)
  {
    globals.applyMeetInsReceptor(insulinId,receptorId)
  },
 
   // 
    InsulunMeetGlucReceptor: function (insulinId,receptorId)
  {
    globals.insulunMeetGlucReceptor(insulinId,receptorId)
  },

   // 
    GlucagonMeetInsReceptor: function (glucagonId,receptorId)
  {
    globals.glucagonMeetInsReceptor(glucagonId,receptorId)
  },

    // 
    GlucagonMeetChannal: function (glucagonId,channalId)
  {
    globals.glucagonMeetChannal(glucagonId,channalId)
  },

    // 
    InsulunMeetChannal: function (glucagonId,channalId)
  {
    globals.insulunMeetChannal(glucagonId,channalId)
  },

  //
   ApplyMeetGlucReceptor: function (glucagonId,receptorId)
  {
    globals.applyMeetGlucReceptor(glucagonId,receptorId)
  },

  //
   ApplyMeetChannel: function (signalId,channalId)
  {
    globals.applyMeetChannel(signalId,channalId)
  },

  //
  CreateRequestNewSignalM: function(receptorId)
  {  
    globals.createRequestSignalM(receptorId)
  },

  //
   CreateRequestNewSignalMTo: function(receptorId)
  {  
    globals.createRequestNewSignalMTo(receptorId)
  },

  //
   CreateRequestNewStorage: function(storagePlace)
  {  
    globals.createRequestNewSugarStorage(storagePlace)
  },

  //
   SugarMeetChannal: function (sugarId,channalId)
  {
    globals.sugarMeetChannal(sugarId,channalId)
  },

  //
   SugarMeetInsulinRec: function (sugarId,receptorId)
  {
    globals.sugarMeetInsulinRec(sugarId,receptorId)
  },

  //
   SugarMeetGlucagonRec: function (sugarId,receptorId)
  {
    globals.sugarMeetGlucagonRec(sugarId,receptorId)
  },

  //
   SetSignalLevel: function (signalId)
  {
    globals.setSignalLevel(signalId)
  },

  //
   SetEnzimeLevel: function (enzimelId)
  {
    globals.setEnzimeLevel(enzimelId)
  },

   //
   SetStorageLevel: function (storagelId)
  {
    globals.setSugarStorageLevel(storagelId)
  },

  //
   SetChannelLocation: function (value,channelId)
  {
    var text = Pointer_stringify(value)
    globals.setChannelLocation(text,channelId)
  },

  //
   SetSignalAttachedToReceptor: function (value) // ,channelId
  {
    globals.setSignalAttachedToReceptor(value) // ,channelId
  },

  //
   SetSignalToAttachedToReceptor: function (value) // ,channelId
  {
    globals.setSignalToAttachedToReceptor(value) // ,channelId
  },
  

  //
  EnzimeMeetStorage: function(enzimeId,storageId)
  {
    globals.enzimeMeetStorage(enzimeId,storageId)
  },

  //
  EnzimeMeetSignalTo: function(enzimeId,signalToId)
  {
    globals.enzimeMeetSignalTo(enzimeId,signalToId)
  },

  

});
