import { PlethoraLib } from "plethora-lib"
import { SimulationState } from "plethora-lib/API/api.definitions"

export function bindEventHandlers() {
  PlethoraLib.getInstance().onSimulationStateChange((state: SimulationState) => {
    console.log(`PlethoraLib.onSimulationStateChange(${state})`)
    if (state === "INIT") {
      // handle entrance to init process
    } else if (state === "READY") {
      // handle end of init
      // request start automatically after init:
      PlethoraLib.getInstance().requestStart()
    } else if (state === "PAUSED") {
      // handle pausing
    } else if (state === "RUNNING") {
      // handle starting & resuming
    } else if (state === "RESET") {
      // handle transition to RESET
      // this function is called *before* calling onDestory() on every entity,
      // and *before* calling onReset()
      // this function can be used to show a loading screen, etc.
      // important! don't use this function to handle removal of entities
      // use onReset() instead.
    }
  })

  PlethoraLib.getInstance().onReset(() => {

    gameInstance.SendMessage("Manager","ResetSimulation","")

    console.log("RESET")
    // this function will be called *after* calling onDestory() on every entity
    // the entities still exist in the model at this point and will be removed
    // only after this function finish executing
  })
  PlethoraLib.getInstance().onSetLanguage((langCode: string) => {
    // this function will be called on startup or whenever the website language is changed
    gameInstance.SendMessage("Manager","SetLanguage",langCode)
    console.log("OnSatLang",langCode);

    console.log(`PlethoraLib.onSetLanguage(langCode = '${langCode}')`)
  })

}
