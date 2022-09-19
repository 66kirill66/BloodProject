import {
  UiData,
  AbstractEntity,
  PropertyValuesDictionary,
  AbstractModel,
  ISimplifiedModel,
  simplifyModel,
} from "plethora-lib"
import { Blood } from "../UiClasses/Blood"
import { InsulinReceptor } from "../UiClasses/InsulinReceptor"
import { SimulationManager } from "../UiClasses/SimulationManager"
import { Pancreas } from "../UiClasses/Pancreas"
import { Channel } from "../UiClasses/Channel"
import { SugarStorage } from "../UiClasses/SugarStorage"
import { CellMembrane } from "../UiClasses/CellMembrane"
import { SignalMolecule2 } from "../UiClasses/SignalMolecule2"
import { Sugar } from "../UiClasses/Sugar"
import { Cell } from "../UiClasses/Cell"
import { MuscleCells } from "../UiClasses/MuscleCells"
import { Enzyme } from "../UiClasses/Enzyme"
import { LiverCells } from "../UiClasses/LiverCells"
import { Insulin } from "../UiClasses/Insulin"
import { Glucagon } from "../UiClasses/Glucagon"
import { SignalMolecule } from "../UiClasses/SignalMolecule"
import { GlucagonReceptor } from "../UiClasses/GlucagonReceptor"
import { IntervalTimer } from "../UiClasses/IntervalTimer"

export enum Singletons {
  Blood = "Blood",
  SimulationManager = "Simulation Manager",
  Pancreas = "Pancreas",
  CellMembrane = "Cell Membrane",
  Sugar = "Sugar",
  MuscleCells = "Muscle Cells",
  LiverCells = "Liver Cells",
  Insulin = "Insulin",
  Glucagon = "Glucagon",
  IntervalTimer = "IntervalTimer",
}

export class GeneratedModel extends AbstractModel {
  private _simplifiedModel: ISimplifiedModel | null = null

  public createUiEntity(
    entityName: string,
    entityId: number,
    propertyValues: PropertyValuesDictionary,
    uiData: UiData
  ): AbstractEntity {
    let entity: AbstractEntity
    switch (entityName) {
      case "Blood":
        entity = new Blood(entityId, propertyValues, uiData)
        break

      case "Insulin Receptor":
        entity = new InsulinReceptor(entityId, propertyValues, uiData)
        break

      case "Simulation Manager":
        entity = new SimulationManager(entityId, propertyValues, uiData)
        break

      case "Pancreas":
        entity = new Pancreas(entityId, propertyValues, uiData)
        break

      case "Channel":
        entity = new Channel(entityId, propertyValues, uiData)
        break

      case "Sugar Storage":
        entity = new SugarStorage(entityId, propertyValues, uiData)
        break

      case "Cell Membrane":
        entity = new CellMembrane(entityId, propertyValues, uiData)
        break

      case "Signal Molecule 2":
        entity = new SignalMolecule2(entityId, propertyValues, uiData)
        break

      case "Sugar":
        entity = new Sugar(entityId, propertyValues, uiData)
        break

      case "Cell":
        entity = new Cell(entityId, propertyValues, uiData)
        break

      case "Muscle Cells":
        entity = new MuscleCells(entityId, propertyValues, uiData)
        break

      case "Enzyme":
        entity = new Enzyme(entityId, propertyValues, uiData)
        break

      case "Liver Cells":
        entity = new LiverCells(entityId, propertyValues, uiData)
        break

      case "Insulin":
        entity = new Insulin(entityId, propertyValues, uiData)
        break

      case "Glucagon":
        entity = new Glucagon(entityId, propertyValues, uiData)
        break

      case "Signal Molecule":
        entity = new SignalMolecule(entityId, propertyValues, uiData)
        break

      case "Glucagon Receptor":
        entity = new GlucagonReceptor(entityId, propertyValues, uiData)
        break

      case "IntervalTimer":
        entity = new IntervalTimer(entityId, propertyValues, uiData)
        break

      default:
        throw new Error("Error on createUiEntity(), unkown entity name: '" + entityName + "'")
    }
    return entity
  }

  public isSingleton(name: string): boolean {
    return [
      "Blood",
      "Simulation Manager",
      "Pancreas",
      "Cell Membrane",
      "Sugar",
      "Muscle Cells",
      "Liver Cells",
      "Insulin",
      "Glucagon",
      "IntervalTimer",
    ].includes(name)
  }

  public getSimplifiedModel(): ISimplifiedModel {
    if (this._simplifiedModel === null) {
      const mappedModel = JSON.parse(_getMappedModelJson())
      this._simplifiedModel = simplifyModel(mappedModel)
    }
    return this._simplifiedModel
  }
}

function _getMappedModelJson() {
  return `{"executionDelayMs":0,"enumTypes":{"gag_SshM2SKebz7uZ6uQo":{"id":"gag_SshM2SKebz7uZ6uQo","name":"State","allowedValues":{"Qc-YZBvvMZSH5X7kepuNB":"Active","ng-J_zV88uu89db6zu_m_":"Inactive"}},"sh0U-Art0W5qez9FGAIqW":{"id":"sh0U-Art0W5qez9FGAIqW","name":"Location","allowedValues":{"5EAvxDYaFzRcdwvEZutgV":"Cell Membrane","6KxgYnd6UZdRP3GPlp4tb":"Blood","JYwyJJsNF5by0xkVjvMdF":"Muscle Cells ","ior32hakLDAwizCRTuq4z":"Pancreas Cells","luJeiyl8pe2jWS0GYH9Rv":"Liver Cells","yl6p9d4Bpqr-63pDRNwqr":"Cell"}}},"interactions":{"8TGs5FI0zXRsOVKrz9iOz":{"id":"8TGs5FI0zXRsOVKrz9iOz","name":"Meet","actionParameters":{},"allowedActivatorsIds":["dOLYJBhHSEQphE0gHpNi9","cZ0-bJN2ixEA6Qdq6_qTL","IFXGd1Gze2HgqOiMOv_y7","wEojlj7_QnqkoHCKHEVOn","qAXELQ6qLWAKhOkZxamTN","EfSXYotxnkL9hMWJbeyBl","9xnQx6YBaJrAwlM9Kf5zp","V8_USa62iau4tlwEDbOIX","-PaTAQmPbLVM-vXhOLPZ8","OpP86QfwLFKs1l2X0ccRl"],"allowedReactorsIds":["dOLYJBhHSEQphE0gHpNi9","cZ0-bJN2ixEA6Qdq6_qTL","IFXGd1Gze2HgqOiMOv_y7","wEojlj7_QnqkoHCKHEVOn","qAXELQ6qLWAKhOkZxamTN","EfSXYotxnkL9hMWJbeyBl","9xnQx6YBaJrAwlM9Kf5zp","V8_USa62iau4tlwEDbOIX","-PaTAQmPbLVM-vXhOLPZ8","OpP86QfwLFKs1l2X0ccRl"],"isSymmetric":true},"I16Hx3npqhR1fJPNzrBj4":{"id":"I16Hx3npqhR1fJPNzrBj4","name":"Deconstruct","actionParameters":{},"allowedActivatorsIds":["IFXGd1Gze2HgqOiMOv_y7"],"allowedReactorsIds":["cZ0-bJN2ixEA6Qdq6_qTL"],"isSymmetric":false},"Q6GwlAdx_CO9cbJ2-4GFK":{"id":"Q6GwlAdx_CO9cbJ2-4GFK","name":"Go Through","actionParameters":{},"allowedActivatorsIds":["EfSXYotxnkL9hMWJbeyBl"],"allowedReactorsIds":["9xnQx6YBaJrAwlM9Kf5zp"],"isSymmetric":false}},"entities":{"_24kOnlxp_BPDJ_bgQtk6":{"id":"_24kOnlxp_BPDJ_bgQtk6","name":"Blood","properties":{"ekSQmWyrMx2H2hPgmdHI4":{"id":"ekSQmWyrMx2H2hPgmdHI4","name":"sugar level","computed":false,"dataType":"number","defaultValue":100,"settings":{"min":80,"max":140,"decimalPlaces":0,"units":"mg/dl"}},"Ex_JnDVJx2Jl6r_LAl4aA":{"id":"Ex_JnDVJx2Jl6r_LAl4aA","name":"insulin level","computed":false,"dataType":"number","defaultValue":25,"settings":{"min":0,"max":60,"decimalPlaces":0}},"WOB5hthroHh6Kx4FCRr3Y":{"id":"WOB5hthroHh6Kx4FCRr3Y","name":"glucagon level","computed":false,"dataType":"number","defaultValue":5,"settings":{"min":0,"max":10,"decimalPlaces":0}}},"actions":{},"parentPropertiesDefaultValues":{},"maxInstances":1,"parentsIds":[],"isSingleton":true},"-PaTAQmPbLVM-vXhOLPZ8":{"id":"-PaTAQmPbLVM-vXhOLPZ8","name":"Insulin Receptor","properties":{},"actions":{"l51KJzrJSdwjYmpuZHkgS":{"id":"l51KJzrJSdwjYmpuZHkgS","name":"releases signal molecule","actionParameters":{}}},"parentPropertiesDefaultValues":{},"maxInstances":20,"parentsIds":[],"isSingleton":false},"2yDv0OjCoMXoln9RD0rDf":{"id":"2yDv0OjCoMXoln9RD0rDf","name":"Simulation Manager","properties":{},"actions":{"qVeiiDnZy08F9Q5UiMQPy":{"id":"qVeiiDnZy08F9Q5UiMQPy","name":"Eat","actionParameters":{}},"WDThjedkWrJcKczvPglas":{"id":"WDThjedkWrJcKczvPglas","name":"Inject Glucagon","actionParameters":{}},"YyURPoQ1VWVnfTygnzTZZ":{"id":"YyURPoQ1VWVnfTygnzTZZ","name":"Inject Insulin","actionParameters":{}}},"parentPropertiesDefaultValues":{},"maxInstances":1,"parentsIds":[],"isSingleton":true},"5Yofvrvuns1i_iv5cfHfl":{"id":"5Yofvrvuns1i_iv5cfHfl","name":"Pancreas","properties":{},"actions":{},"parentPropertiesDefaultValues":{},"maxInstances":1,"parentsIds":[],"isSingleton":true},"9xnQx6YBaJrAwlM9Kf5zp":{"id":"9xnQx6YBaJrAwlM9Kf5zp","name":"Channel","properties":{"zGJ7ob9bJK9g8W7OkhcC3":{"id":"zGJ7ob9bJK9g8W7OkhcC3","name":"location","computed":false,"dataType":"enum","defaultValue":"Muscle Cells ","enumTypeId":"sh0U-Art0W5qez9FGAIqW"}},"actions":{"EKHGgUK7blY3kOiu4CNVc":{"id":"EKHGgUK7blY3kOiu4CNVc","name":"Change Location","actionParameters":{"0XtekWa9YmvBiYKnubP94":{"id":"0XtekWa9YmvBiYKnubP94","name":"from","dataType":"enum","enumTypeId":"sh0U-Art0W5qez9FGAIqW"},"L_B6nO-r7Izt_6GlrR3wi":{"id":"L_B6nO-r7Izt_6GlrR3wi","name":"to","dataType":"enum","enumTypeId":"sh0U-Art0W5qez9FGAIqW"}}}},"parentPropertiesDefaultValues":{},"maxInstances":20,"parentsIds":[],"isSingleton":false},"cZ0-bJN2ixEA6Qdq6_qTL":{"id":"cZ0-bJN2ixEA6Qdq6_qTL","name":"Sugar Storage","properties":{},"actions":{},"parentPropertiesDefaultValues":{},"maxInstances":20,"parentsIds":[],"isSingleton":false},"dcjx9Wz92Nas5oZdv5yCO":{"id":"dcjx9Wz92Nas5oZdv5yCO","name":"Cell Membrane","properties":{},"actions":{},"parentPropertiesDefaultValues":{},"maxInstances":1,"parentsIds":[],"isSingleton":true},"dOLYJBhHSEQphE0gHpNi9":{"id":"dOLYJBhHSEQphE0gHpNi9","name":"Signal Molecule 2","properties":{"j9oqXdC3FSVa2DwRJmc7u":{"id":"j9oqXdC3FSVa2DwRJmc7u","name":"AttachedToReceptor","computed":false,"dataType":"boolean","defaultValue":true}},"actions":{},"parentPropertiesDefaultValues":{},"maxInstances":20,"parentsIds":[],"isSingleton":false},"EfSXYotxnkL9hMWJbeyBl":{"id":"EfSXYotxnkL9hMWJbeyBl","name":"Sugar","properties":{},"actions":{"8nSR4xBk0yCV74DdddSGZ":{"id":"8nSR4xBk0yCV74DdddSGZ","name":"change location","actionParameters":{"d1aT1_VpniIac3BWpv3Pv":{"id":"d1aT1_VpniIac3BWpv3Pv","name":"from","dataType":"enum","enumTypeId":"sh0U-Art0W5qez9FGAIqW"},"uU-FjCJMz4z2ZChRJoQSA":{"id":"uU-FjCJMz4z2ZChRJoQSA","name":"to","dataType":"enum","enumTypeId":"sh0U-Art0W5qez9FGAIqW"}}}},"parentPropertiesDefaultValues":{},"maxInstances":1,"parentsIds":[],"isSingleton":true},"GFuCTHIDsHSiyA8wb2f3z":{"id":"GFuCTHIDsHSiyA8wb2f3z","name":"Cell","properties":{"zFWKxJXQtclSYvxLTSra7":{"id":"zFWKxJXQtclSYvxLTSra7","name":"sugar level","computed":false,"dataType":"number","defaultValue":0,"settings":{"min":0,"max":140,"decimalPlaces":0}}},"actions":{},"parentPropertiesDefaultValues":{},"maxInstances":1,"parentsIds":[],"isSingleton":false},"GQnmkSo6tXu-ue4ZFGGem":{"id":"GQnmkSo6tXu-ue4ZFGGem","name":"Muscle Cells","properties":{},"actions":{},"parentPropertiesDefaultValues":{"zFWKxJXQtclSYvxLTSra7":2},"maxInstances":1,"parentsIds":["GFuCTHIDsHSiyA8wb2f3z"],"isSingleton":true},"IFXGd1Gze2HgqOiMOv_y7":{"id":"IFXGd1Gze2HgqOiMOv_y7","name":"Enzyme","properties":{"5kZGP5NHaNiBibt6Ckucd":{"id":"5kZGP5NHaNiBibt6Ckucd","name":"State","computed":false,"dataType":"enum","defaultValue":"Inactive","enumTypeId":"gag_SshM2SKebz7uZ6uQo"}},"actions":{},"parentPropertiesDefaultValues":{},"maxInstances":20,"parentsIds":[],"isSingleton":false},"Omxm2Z9wj6VrDXaGPQFI1":{"id":"Omxm2Z9wj6VrDXaGPQFI1","name":"Liver Cells","properties":{},"actions":{},"parentPropertiesDefaultValues":{},"maxInstances":1,"parentsIds":["GFuCTHIDsHSiyA8wb2f3z"],"isSingleton":true},"OpP86QfwLFKs1l2X0ccRl":{"id":"OpP86QfwLFKs1l2X0ccRl","name":"Insulin","properties":{},"actions":{"aHMmKCvuZt6Ozxin7ARpP":{"id":"aHMmKCvuZt6Ozxin7ARpP","name":"change location","actionParameters":{"eyZNET9bPKrH53rUf3m6p":{"id":"eyZNET9bPKrH53rUf3m6p","name":"from","dataType":"enum","enumTypeId":"sh0U-Art0W5qez9FGAIqW"},"xMBnMa216Obs091VuV521":{"id":"xMBnMa216Obs091VuV521","name":"to","dataType":"enum","enumTypeId":"sh0U-Art0W5qez9FGAIqW"}}}},"parentPropertiesDefaultValues":{},"maxInstances":1,"parentsIds":[],"isSingleton":true},"qAXELQ6qLWAKhOkZxamTN":{"id":"qAXELQ6qLWAKhOkZxamTN","name":"Glucagon","properties":{},"actions":{"lqce3qpUJntyMfKmUQNb7":{"id":"lqce3qpUJntyMfKmUQNb7","name":"change location","actionParameters":{"hQmRqPX0V2fbbZJ6vOI8n":{"id":"hQmRqPX0V2fbbZJ6vOI8n","name":"from","dataType":"enum","enumTypeId":"sh0U-Art0W5qez9FGAIqW"},"stsrh_FqJVdkFznPxuH1X":{"id":"stsrh_FqJVdkFznPxuH1X","name":"to","dataType":"enum","enumTypeId":"sh0U-Art0W5qez9FGAIqW"}}}},"parentPropertiesDefaultValues":{},"maxInstances":1,"parentsIds":[],"isSingleton":true},"V8_USa62iau4tlwEDbOIX":{"id":"V8_USa62iau4tlwEDbOIX","name":"Signal Molecule","properties":{"qpo2w9e8I8NZREhlmmmkI":{"id":"qpo2w9e8I8NZREhlmmmkI","name":"AttachedToReceptor","computed":false,"dataType":"boolean","defaultValue":true}},"actions":{},"parentPropertiesDefaultValues":{},"maxInstances":20,"parentsIds":[],"isSingleton":false},"wEojlj7_QnqkoHCKHEVOn":{"id":"wEojlj7_QnqkoHCKHEVOn","name":"Glucagon Receptor","properties":{},"actions":{"cw4Xe2Vv7Y-XqDzM5dkXp":{"id":"cw4Xe2Vv7Y-XqDzM5dkXp","name":"releases signal molecule","actionParameters":{}}},"parentPropertiesDefaultValues":{},"maxInstances":20,"parentsIds":[],"isSingleton":false}}}`
}

declare global {
  var getMappedModelJson: () => string
}
globalThis.getMappedModelJson = _getMappedModelJson
