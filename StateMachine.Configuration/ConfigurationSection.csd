<?xml version="1.0" encoding="utf-8"?>
<configurationSectionModel xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="d0ed9acb-0435-4532-afdd-b5115bc4d562" namespace="StateMachine.Configuration" xmlSchemaNamespace="https://github.com/Mongooz/StateMachine" xmlns="http://schemas.microsoft.com/dsltools/ConfigurationSectionDesigner">
  <typeDefinitions>
    <externalType name="String" namespace="System" />
    <externalType name="Boolean" namespace="System" />
    <externalType name="Int32" namespace="System" />
    <externalType name="Int64" namespace="System" />
    <externalType name="Single" namespace="System" />
    <externalType name="Double" namespace="System" />
    <externalType name="DateTime" namespace="System" />
    <externalType name="TimeSpan" namespace="System" />
  </typeDefinitions>
  <configurationElements>
    <configurationSection name="StateMachineSection" codeGenOptions="Singleton, XmlnsProperty" xmlSectionName="stateMachine">
      <attributeProperties>
        <attributeProperty name="DefaultStateId" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="defaultStateId" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
      <elementProperties>
        <elementProperty name="States" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="states" isReadOnly="false">
          <type>
            <configurationElementCollectionMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/StateCollection" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
    <configurationElementCollection name="StateCollection" xmlItemName="state" codeGenOptions="Indexer, AddMethod, RemoveMethod, GetItemMethods">
      <itemType>
        <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/StateElement" />
      </itemType>
    </configurationElementCollection>
    <configurationElementCollection name="TransitionCollection" xmlItemName="transition" codeGenOptions="Indexer, AddMethod, RemoveMethod, GetItemMethods">
      <itemType>
        <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/TransitionElement" />
      </itemType>
    </configurationElementCollection>
    <configurationElement name="StateElement">
      <attributeProperties>
        <attributeProperty name="StateId" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="stateId" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="StateName" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="stateName" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
      <elementProperties>
        <elementProperty name="Transitions" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="transitions" isReadOnly="false">
          <type>
            <configurationElementCollectionMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/TransitionCollection" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationElement>
    <configurationElement name="TransitionElement">
      <attributeProperties>
        <attributeProperty name="StateId" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="stateId" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
  </configurationElements>
  <propertyValidators>
    <validators />
  </propertyValidators>
</configurationSectionModel>