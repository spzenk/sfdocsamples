<?xml version="1.0" encoding="utf-8"?>
<Dsl dslVersion="1.0.0.0" Id="08a4f8ff-2867-414d-8c64-8b3e780b021d" Description="Description for pelsoft.FWK_Dsl.FWK_Dsl" Name="FWK_Dsl" DisplayName="Class Diagrams" Namespace="pelsoft.FWK_Dsl" ProductName="FWK_Dsl" CompanyName="pelsoft" PackageGuid="54776c82-4666-483e-a7bb-397b397f03c0" PackageNamespace="" xmlns="http://schemas.microsoft.com/VisualStudio/2005/DslTools/DslDefinitionModel">
  <Classes>
    <DomainClass Id="706ec50a-d4fe-4d0f-8c3c-10d2884d22ea" Description="" Name="Persona" DisplayName="Persona" InheritanceModifier="Abstract" Namespace="pelsoft.FWK_Dsl">
      <Properties>
        <DomainProperty Id="8d039379-2297-4036-839e-a50986a68cd1" Description="" Name="Name" DisplayName="Name" DefaultValue="" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="9123ba25-10ce-46a9-8552-ecf64946073a" Description="Description for pelsoft.FWK_Dsl.Persona.Domain Property1" Name="DomainProperty1" DisplayName="Domain Property1">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="250dd952-1ae4-4168-b88f-f8964a724b63" Description="Description for pelsoft.FWK_Dsl.Persona.Sexo" Name="Sexo" DisplayName="Sexo">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="8a674ed6-8e30-4571-bdda-c2b874618a6e" Description="" Name="ModelRoot" DisplayName="Model Root" Namespace="pelsoft.FWK_Dsl">
      <BaseClass>
        <DomainClassMoniker Name="Persona" />
      </BaseClass>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="Comment" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>ModelRootHasComments.Comments</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="ModelType" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>ModelRootHasTypes.Types</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="30fa867e-76f3-4723-881b-7282ff8e2816" Description="" Name="ModelClass" DisplayName="Model Class" Namespace="pelsoft.FWK_Dsl">
      <BaseClass>
        <DomainClassMoniker Name="ModelType" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="908a61fe-5cfa-4f8c-9c0e-6b901bb8f085" Description="" Name="Kind" DisplayName="Kind" DefaultValue="">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="d1d8d580-2528-4e7a-9040-c481ad3deee8" Description="" Name="IsAbstract" DisplayName="Is Abstract" DefaultValue="None">
          <Type>
            <DomainEnumerationMoniker Name="InheritanceModifier" />
          </Type>
        </DomainProperty>
      </Properties>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="ModelAttribute" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>ClassHasAttributes.Attributes</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="ClassOperation" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>ClassHasOperations.Operations</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="83694d4d-3704-4ccb-ad82-8fdb7bb233bc" Description="An attribute of a class." Name="ModelAttribute" DisplayName="Model Attribute" Namespace="pelsoft.FWK_Dsl">
      <BaseClass>
        <DomainClassMoniker Name="ClassModelElement" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="15ebfef4-2ad1-4149-98c6-a74874a4f2f2" Description="" Name="Type" DisplayName="Type" DefaultValue="">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="d988860f-603e-4735-a013-55b52fe9a420" Description="" Name="InitialValue" DisplayName="Initial Value" DefaultValue="">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="aec46897-6c9e-48ba-9ae9-74f3fc69dcb1" Description="" Name="Multiplicity" DisplayName="Multiplicity" DefaultValue="1">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="3ec3b4ae-56a2-4809-af0c-e13be31e63e7" Description="" Name="Comment" DisplayName="Comment" Namespace="pelsoft.FWK_Dsl">
      <Properties>
        <DomainProperty Id="33f9f791-8c50-48dc-a062-db1747fcffff" Description="" Name="Text" DisplayName="Text" DefaultValue="">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="7e4bbbc1-fdaa-4873-b5d8-943137410cca" Description="An Operation of a Class." Name="Operation" DisplayName="Operation" InheritanceModifier="Abstract" Namespace="pelsoft.FWK_Dsl">
      <Notes>Abstract base class of ClassOperation and InterfaceOperation.</Notes>
      <BaseClass>
        <DomainClassMoniker Name="ClassModelElement" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="2c292f88-6476-485d-b961-cd63c3c463a3" Description="" Name="Signature" DisplayName="Signature" DefaultValue="">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="bc08d1e2-b650-4974-b59f-3f73f9f58a3b" Description="" Name="Concurrency" DisplayName="Concurrency" DefaultValue="Sequential">
          <Type>
            <DomainEnumerationMoniker Name="OperationConcurrency" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="b40f919e-05ea-4918-a96f-d0a579ea007d" Description="" Name="Precondition" DisplayName="Precondition" DefaultValue="">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="2b7bc2f9-6e77-435a-b694-1d6da117bfd2" Description="" Name="Postcondition" DisplayName="Postcondition" DefaultValue="">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="c7c3a971-2812-4508-bf25-b6b50708d66b" Description="" Name="ClassOperation" DisplayName="Class Operation" Namespace="pelsoft.FWK_Dsl">
      <BaseClass>
        <DomainClassMoniker Name="Operation" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="d5be4ae1-d611-49e9-83e9-1279db697f18" Description="" Name="IsAbstract" DisplayName="Is Abstract" DefaultValue="False">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="41f946c3-46db-4a2c-a9b2-31088f8e0da7" Description="" Name="ModelInterface" DisplayName="Model Interface" Namespace="pelsoft.FWK_Dsl">
      <BaseClass>
        <DomainClassMoniker Name="ModelType" />
      </BaseClass>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="InterfaceOperation" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>InterfaceHasOperation.Operations</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="de5de78b-5020-45ab-b536-b759cb34ea57" Description="" Name="InterfaceOperation" DisplayName="Interface Operation" Namespace="pelsoft.FWK_Dsl">
      <BaseClass>
        <DomainClassMoniker Name="Operation" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="c13ddb39-609a-41a1-8090-9782b3238050" Description="" Name="MultipleAssociation" DisplayName="Multiple Association" Namespace="pelsoft.FWK_Dsl">
      <BaseClass>
        <DomainClassMoniker Name="ModelType" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="197ad9f2-ab32-44d5-ae8f-7c99aa604651" Description="" Name="ModelType" DisplayName="Model Type" InheritanceModifier="Abstract" Namespace="pelsoft.FWK_Dsl">
      <BaseClass>
        <DomainClassMoniker Name="ClassModelElement" />
      </BaseClass>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="Comment" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>CommentReferencesSubjects.Comments</DomainPath>
            <DomainPath>ModelRootHasTypes.ModelRoot/!ModelRoot/ModelRootHasComments.Comments</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="c62243d1-f9c6-499e-9580-163cf8726784" Description="Element with a Description" Name="ClassModelElement" DisplayName="Class Model Element" InheritanceModifier="Abstract" Namespace="pelsoft.FWK_Dsl">
      <Notes>Abstract base of all elements that have a Description property.</Notes>
      <BaseClass>
        <DomainClassMoniker Name="Persona" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="49eb230b-d987-4906-a73b-9c7ffc7e367e" Description="This is a Description." Name="Description" DisplayName="Description" DefaultValue="">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
  </Classes>
  <Relationships>
    <DomainRelationship Id="b28e302c-f25e-4b8f-8fc4-e28da6863270" Description="Associations between Classes." Name="Association" DisplayName="Association" InheritanceModifier="Abstract" Namespace="pelsoft.FWK_Dsl" AllowsDuplicates="true">
      <Notes>This is the abstract base relationship of the several kinds of association between Classes.
      It defines the Properties that are attached to each association.</Notes>
      <Properties>
        <DomainProperty Id="f0628c8e-dd1d-465f-b5d0-6208e383dad7" Description="" Name="SourceMultiplicity" DisplayName="Source Multiplicity" DefaultValue="ZeroMany">
          <Type>
            <DomainEnumerationMoniker Name="Multiplicity" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="34e03f66-5ad3-4807-a14c-b9a67b0cee01" Description="" Name="SourceRoleName" DisplayName="Source Role Name" DefaultValue="">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="279215dc-6eb3-4ab0-b28b-434c2de6ef6f" Description="" Name="TargetMultiplicity" DisplayName="Target Multiplicity" DefaultValue="ZeroMany">
          <Type>
            <DomainEnumerationMoniker Name="Multiplicity" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="8d47cb88-651c-4e1a-b996-a0606b53eba7" Description="" Name="TargetRoleName" DisplayName="Target Role Name" DefaultValue="">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
      <Source>
        <DomainRole Id="23f03bd0-b818-4d23-bf6d-39182bb3aca5" Description="" Name="Source" DisplayName="Source" PropertyName="Targets" PropertyDisplayName="Targets">
          <Notes>The Targets property on a ModelClass will include all the elements targeted by every kind of Association.</Notes>
          <RolePlayer>
            <DomainClassMoniker Name="ModelClass" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="e1a7c4d8-469d-461f-87c9-75d61e990b1f" Description="" Name="Target" DisplayName="Target" PropertyName="Sources" PropertyDisplayName="Sources">
          <Notes>The Sources property on a ModelClass will include all the elements sourced by every kind of Association.</Notes>
          <RolePlayer>
            <DomainClassMoniker Name="ModelClass" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="ba9f6786-443b-455c-a746-f23d6ad5edee" Description="" Name="UnidirectionalAssociation" DisplayName="Unidirectional Association" Namespace="pelsoft.FWK_Dsl" AllowsDuplicates="true">
      <BaseRelationship>
        <DomainRelationshipMoniker Name="Association" />
      </BaseRelationship>
      <Source>
        <DomainRole Id="7dbe6f11-838b-42ad-ae86-164fffd7b307" Description="" Name="UnidirectionalSource" DisplayName="Unidirectional Source" PropertyName="UnidirectionalTargets" PropertyDisplayName="Unidirectional Targets">
          <RolePlayer>
            <DomainClassMoniker Name="ModelClass" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="0a2d53cf-e464-4730-9e5f-740ed6b55882" Description="" Name="UnidirectionalTarget" DisplayName="Unidirectional Target" PropertyName="UnidirectionalSources" PropertyDisplayName="Unidirectional Sources">
          <RolePlayer>
            <DomainClassMoniker Name="ModelClass" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="2aa1b2ab-37e0-4652-b552-9d6fc1a13f94" Description="" Name="ClassHasAttributes" DisplayName="Class Has Attributes" Namespace="pelsoft.FWK_Dsl" IsEmbedding="true">
      <Source>
        <DomainRole Id="a97390da-a6de-40c0-9066-8c1d283745ed" Description="" Name="ModelClass" DisplayName="Model Class" PropertyName="Attributes" PropertyDisplayName="Attributes">
          <RolePlayer>
            <DomainClassMoniker Name="ModelClass" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="cedf6dbe-38f7-448b-a028-1f6857169f8c" Description="" Name="Attribute" DisplayName="Attribute" PropertyName="ModelClass" Multiplicity="ZeroOne" PropagatesDelete="true" PropertyDisplayName="Model Class">
          <RolePlayer>
            <DomainClassMoniker Name="ModelAttribute" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="3e7c675d-d213-49a2-a766-84e48ace358e" Description="" Name="ModelRootHasComments" DisplayName="Model Root Has Comments" Namespace="pelsoft.FWK_Dsl" IsEmbedding="true">
      <Source>
        <DomainRole Id="47d0b5f4-70e7-4ab3-a53f-78a3ab1a964f" Description="" Name="ModelRoot" DisplayName="Model Root" PropertyName="Comments" PropertyDisplayName="Comments">
          <RolePlayer>
            <DomainClassMoniker Name="ModelRoot" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="6301548d-682e-4895-b4c5-a5132929081a" Description="" Name="Comment" DisplayName="Comment" PropertyName="ModelRoot" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Model Root">
          <RolePlayer>
            <DomainClassMoniker Name="Comment" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="35888345-b8f7-495f-9ad2-33d31d5e1497" Description="" Name="ClassHasOperations" DisplayName="Class Has Operations" Namespace="pelsoft.FWK_Dsl" IsEmbedding="true">
      <Source>
        <DomainRole Id="3977d5fe-d07f-4d2c-8b12-1313abb8944a" Description="" Name="ModelClass" DisplayName="ModelClass" PropertyName="Operations" PropertyDisplayName="Operations">
          <RolePlayer>
            <DomainClassMoniker Name="ModelClass" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="f7dc7bbf-7a60-4034-bee1-464b341e7373" Description="" Name="Operation" DisplayName="Operation" PropertyName="ModelClass" Multiplicity="ZeroOne" PropagatesDelete="true" PropertyDisplayName="Model Class">
          <RolePlayer>
            <DomainClassMoniker Name="ClassOperation" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="22f5398b-99a5-4e54-801b-872f2e58c82b" Description="Inheritance between Classes." Name="Generalization" DisplayName="Generalization" Namespace="pelsoft.FWK_Dsl">
      <Properties>
        <DomainProperty Id="6aa0ebf8-89bf-4ccf-96b3-286d2bb70027" Description="" Name="Discriminator" DisplayName="Discriminator" DefaultValue="">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
      <Source>
        <DomainRole Id="6378f978-0b30-4255-a5e8-c98ac3833816" Description="" Name="Superclass" DisplayName="Superclass" PropertyName="Subclasses" PropertyDisplayName="Subclasses">
          <RolePlayer>
            <DomainClassMoniker Name="ModelClass" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="478a1f60-dd3d-4da6-86c5-5f35916840a8" Description="" Name="Subclass" DisplayName="Subclass" PropertyName="Superclass" Multiplicity="ZeroOne" PropertyDisplayName="Superclass">
          <RolePlayer>
            <DomainClassMoniker Name="ModelClass" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="36951235-dae2-4b69-b415-ac763323f6dd" Description="" Name="BidirectionalAssociation" DisplayName="Bidirectional Association" Namespace="pelsoft.FWK_Dsl" AllowsDuplicates="true">
      <BaseRelationship>
        <DomainRelationshipMoniker Name="Association" />
      </BaseRelationship>
      <Source>
        <DomainRole Id="a58477c3-c5bf-471b-bd5e-90eda61b8382" Description="" Name="BidirectionalSource" DisplayName="Bidirectional Source" PropertyName="BidirectionalTargets" PropertyDisplayName="Bidirectional Targets">
          <RolePlayer>
            <DomainClassMoniker Name="ModelClass" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="9d2f386f-5233-4da6-ad49-f2d450d31cdc" Description="" Name="BidirectionalTarget" DisplayName="Bidirectional Target" PropertyName="BidirectionalSources" PropertyDisplayName="Bidirectional Sources">
          <RolePlayer>
            <DomainClassMoniker Name="ModelClass" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="25603e73-20d1-4a23-85a5-5cb743aa1320" Description="" Name="InterfaceHasOperation" DisplayName="Interface Has Operation" Namespace="pelsoft.FWK_Dsl" IsEmbedding="true">
      <Source>
        <DomainRole Id="6e31c6f6-02ea-476d-9ac2-6ed40cd75c29" Description="" Name="Interface" DisplayName="Interface" PropertyName="Operations" PropertyDisplayName="Operations">
          <RolePlayer>
            <DomainClassMoniker Name="ModelInterface" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="83f5bcea-2e6f-410c-882d-dcd9fe0f09fb" Description="" Name="Operation" DisplayName="Operation" PropertyName="Interface" Multiplicity="ZeroOne" PropagatesDelete="true" PropertyDisplayName="Interface">
          <RolePlayer>
            <DomainClassMoniker Name="InterfaceOperation" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="18d62ae1-fedb-47e0-9b44-688cc0402e91" Description="Links a MultipleAssociation to one of the classes it associates." Name="MultipleAssociationRole" DisplayName="Multiple Association Role" Namespace="pelsoft.FWK_Dsl">
      <Properties>
        <DomainProperty Id="168d5922-b547-4670-878a-f29f7904ab49" Description="" Name="Multiplicity" DisplayName="Multiplicity" DefaultValue="ZeroMany">
          <Type>
            <DomainEnumerationMoniker Name="Multiplicity" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="9db0ed70-dcc9-4bbe-af4a-98251404d320" Description="" Name="RoleName" DisplayName="RoleName" DefaultValue="">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
      <Source>
        <DomainRole Id="c5c40174-9b88-4b5b-b782-d0738abe6c01" Description="" Name="MultipleAssociation" DisplayName="Multiple Association" PropertyName="Types" PropertyDisplayName="Types">
          <RolePlayer>
            <DomainClassMoniker Name="MultipleAssociation" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="1f24fd89-c1f6-43f1-a595-0f258dedc931" Description="" Name="Type" DisplayName="Type" PropertyName="MultipleAssociations" PropertyDisplayName="Multiple Associations">
          <RolePlayer>
            <DomainClassMoniker Name="ModelClass" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="b03c9983-4a2b-4a2c-b28e-521ebbeb5331" Description="Identifies a MultipleAssociation with a Class, so that it can have attributes." Name="AssociationClassRelationship" DisplayName="Association Class Relationship" Namespace="pelsoft.FWK_Dsl">
      <Source>
        <DomainRole Id="5fe75e95-a21f-48af-b484-c5bd2bdf1290" Description="" Name="MultipleAssociation" DisplayName="Multiple Association" PropertyName="AssociationClass" Multiplicity="ZeroOne" PropertyDisplayName="Association Class">
          <RolePlayer>
            <DomainClassMoniker Name="MultipleAssociation" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="36d28336-da05-4c38-b04b-6a3ac1bbc8ab" Description="" Name="AssociationClass" DisplayName="Association Class" PropertyName="MultipleAssociation" Multiplicity="ZeroOne" PropertyDisplayName="Multiple Association">
          <RolePlayer>
            <DomainClassMoniker Name="ModelClass" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="6b4ebb4f-e648-4c15-8ef5-45b4cae3c4a2" Description="" Name="Aggregation" DisplayName="Aggregation" Namespace="pelsoft.FWK_Dsl" AllowsDuplicates="true">
      <BaseRelationship>
        <DomainRelationshipMoniker Name="Association" />
      </BaseRelationship>
      <Source>
        <DomainRole Id="66e3094d-e8da-435d-9c24-ae122f99a972" Description="" Name="AggregationSource" DisplayName="Aggregation Source" PropertyName="AggregationTargets" PropertyDisplayName="Aggregation Targets">
          <RolePlayer>
            <DomainClassMoniker Name="ModelClass" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="85054303-8094-475c-b0aa-57cce2e5dc59" Description="" Name="AggregationTarget" DisplayName="Aggregation Target" PropertyName="AggregationSources" PropertyDisplayName="Aggregation Sources">
          <RolePlayer>
            <DomainClassMoniker Name="ModelClass" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="8ebfa993-a82e-4418-95e7-81ba96d995ff" Description="" Name="Composition" DisplayName="Composition" Namespace="pelsoft.FWK_Dsl" AllowsDuplicates="true">
      <BaseRelationship>
        <DomainRelationshipMoniker Name="Association" />
      </BaseRelationship>
      <Source>
        <DomainRole Id="bb684a1d-72d4-43a5-9db5-de8eb85566f8" Description="" Name="CompositionSource" DisplayName="Composition Source" PropertyName="CompositionTargets" PropertyDisplayName="Composition Targets">
          <RolePlayer>
            <DomainClassMoniker Name="ModelClass" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="25c446ef-650f-45bf-850e-9e3f556ced8c" Description="" Name="CompositionTarget" DisplayName="Composition Target" PropertyName="CompositionSources" PropertyDisplayName="Composition Sources">
          <RolePlayer>
            <DomainClassMoniker Name="ModelClass" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="5de6ae0e-621a-4140-b8ca-a1322f32119d" Description="" Name="ModelRootHasTypes" DisplayName="Model Root Has Types" Namespace="pelsoft.FWK_Dsl" IsEmbedding="true">
      <Source>
        <DomainRole Id="3dad422d-4aad-45ae-9006-9e59f29beabb" Description="" Name="ModelRoot" DisplayName="Model Root" PropertyName="Types" PropertyDisplayName="Types">
          <RolePlayer>
            <DomainClassMoniker Name="ModelRoot" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="5ee86da2-cbd5-49e6-a5e3-93063873579a" Description="" Name="Type" DisplayName="Type" PropertyName="ModelRoot" Multiplicity="ZeroOne" PropagatesDelete="true" PropertyDisplayName="">
          <RolePlayer>
            <DomainClassMoniker Name="ModelType" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="352569a6-cb99-46ce-9ee7-05cebad05232" Description="" Name="CommentReferencesSubjects" DisplayName="Comment References Subjects" Namespace="pelsoft.FWK_Dsl">
      <Source>
        <DomainRole Id="bd2e1a46-fa46-404a-8a9e-47bd26a2505b" Description="" Name="Comment" DisplayName="Comment" PropertyName="Subjects" PropertyDisplayName="Subjects">
          <RolePlayer>
            <DomainClassMoniker Name="Comment" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="3f557f44-1e48-4112-946f-9f7ab9d5fe30" Description="" Name="Subject" DisplayName="Subject" PropertyName="Comments" PropertyDisplayName="Comments">
          <RolePlayer>
            <DomainClassMoniker Name="ModelType" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="f6b1d589-2b69-4ae1-987b-4a9657d490a4" Description="" Name="Implementation" DisplayName="Implementation" Namespace="pelsoft.FWK_Dsl">
      <Source>
        <DomainRole Id="06d38e48-7a6f-4337-be8b-49d0dabd0ecc" Description="" Name="Implement" DisplayName="Implement" PropertyName="Implementors" PropertyDisplayName="Implementors">
          <RolePlayer>
            <DomainClassMoniker Name="ModelInterface" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="dd5dcd88-790c-41fe-ae8b-7597a999401c" Description="" Name="Implementor" DisplayName="Implementor" PropertyName="Implements" PropertyDisplayName="Implements">
          <RolePlayer>
            <DomainClassMoniker Name="ModelType" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
  </Relationships>
  <Types>
    <ExternalType Name="DateTime" Namespace="System" />
    <ExternalType Name="String" Namespace="System" />
    <ExternalType Name="Int16" Namespace="System" />
    <ExternalType Name="Int32" Namespace="System" />
    <ExternalType Name="Int64" Namespace="System" />
    <ExternalType Name="UInt16" Namespace="System" />
    <ExternalType Name="UInt32" Namespace="System" />
    <ExternalType Name="UInt64" Namespace="System" />
    <ExternalType Name="SByte" Namespace="System" />
    <ExternalType Name="Byte" Namespace="System" />
    <ExternalType Name="Double" Namespace="System" />
    <ExternalType Name="Single" Namespace="System" />
    <ExternalType Name="Guid" Namespace="System" />
    <ExternalType Name="Boolean" Namespace="System" />
    <ExternalType Name="Char" Namespace="System" />
    <DomainEnumeration Name="AccessModifier" Namespace="pelsoft.FWK_Dsl" Description="">
      <Literals>
        <EnumerationLiteral Description="" Name="Public" Value="0" />
        <EnumerationLiteral Description="" Name="Assembly" Value="1" />
        <EnumerationLiteral Description="" Name="Private" Value="2" />
        <EnumerationLiteral Description="" Name="Family" Value="3" />
        <EnumerationLiteral Description="" Name="FamilyOrAssembly" Value="4" />
        <EnumerationLiteral Description="" Name="FamilyAndAssembly" Value="5" />
      </Literals>
    </DomainEnumeration>
    <DomainEnumeration Name="TypeAccessModifier" Namespace="pelsoft.FWK_Dsl" Description="">
      <Literals>
        <EnumerationLiteral Description="" Name="Public" Value="0" />
        <EnumerationLiteral Description="" Name="Private" Value="1" />
      </Literals>
    </DomainEnumeration>
    <DomainEnumeration Name="InheritanceModifier" Namespace="pelsoft.FWK_Dsl" Description="">
      <Literals>
        <EnumerationLiteral Description="" Name="None" Value="0" />
        <EnumerationLiteral Description="" Name="Abstract" Value="1" />
        <EnumerationLiteral Description="" Name="Sealed" Value="2" />
      </Literals>
    </DomainEnumeration>
    <DomainEnumeration Name="Multiplicity" Namespace="pelsoft.FWK_Dsl" Description="">
      <Literals>
        <EnumerationLiteral Description="" Name="ZeroMany" Value="0" />
        <EnumerationLiteral Description="" Name="One" Value="1" />
        <EnumerationLiteral Description="" Name="ZeroOne" Value="2" />
        <EnumerationLiteral Description="" Name="OneMany" Value="3" />
      </Literals>
    </DomainEnumeration>
    <DomainEnumeration Name="OperationConcurrency" Namespace="pelsoft.FWK_Dsl" Description="">
      <Literals>
        <EnumerationLiteral Description="" Name="Sequential" Value="0" />
        <EnumerationLiteral Description="" Name="Guarded" Value="1" />
        <EnumerationLiteral Description="" Name="Concurrent" Value="2" />
      </Literals>
    </DomainEnumeration>
    <ExternalType Name="Color" Namespace="System.Drawing" />
    <ExternalType Name="DashStyle" Namespace="System.Drawing.Drawing2D" />
  </Types>
  <Shapes>
    <CompartmentShape Id="9b406fc8-fae1-499f-8842-dd193fe5f078" Description="" Name="ClassShape" DisplayName="Class Shape" Namespace="pelsoft.FWK_Dsl" FixedTooltipText="Class Shape" FillColor="211, 220, 239" InitialHeight="0.3" OutlineThickness="0.01" Geometry="RoundedRectangle">
      <ShapeHasDecorators Position="InnerTopCenter" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="Name" DisplayName="Name" DefaultText="Name" />
      </ShapeHasDecorators>
      <ShapeHasDecorators Position="InnerTopRight" HorizontalOffset="0" VerticalOffset="0">
        <ExpandCollapseDecorator Name="ExpandCollapse" DisplayName="Expand Collapse" />
      </ShapeHasDecorators>
      <Compartment TitleFillColor="235, 235, 235" Name="AttributesCompartment" Title="Attributes" />
      <Compartment TitleFillColor="235, 235, 235" Name="OperationsCompartment" Title="Operations" />
    </CompartmentShape>
    <CompartmentShape Id="8443b9ee-cd4a-439f-9b65-5ead23bdef4d" Description="" Name="InterfaceShape" DisplayName="Interface Shape" Namespace="pelsoft.FWK_Dsl" FixedTooltipText="Interface Shape" FillColor="LightGray" InitialHeight="0.5" OutlineThickness="0.01" Geometry="RoundedRectangle">
      <Notes>This shape only has one compartment, so by default it would not show the compartment header.
      But we want it to look uniform with the ClassShape, so we set IsSingleCompartmentHeaderVisible.</Notes>
      <ShapeHasDecorators Position="InnerTopCenter" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="Sterotype" DisplayName="Sterotype" DefaultText="&lt;&lt;Interface&gt;&gt;">
          <Notes>This decorator is fixed - not mapped to any property.</Notes>
        </TextDecorator>
      </ShapeHasDecorators>
      <ShapeHasDecorators Position="InnerTopCenter" HorizontalOffset="0" VerticalOffset="0.15">
        <TextDecorator Name="Name" DisplayName="Name" DefaultText="InterfaceShapeNameDecorator">
          <Notes>The VerticalOffset puts this decorator just below the stereotype, with normal font sizes.</Notes>
        </TextDecorator>
      </ShapeHasDecorators>
      <ShapeHasDecorators Position="InnerTopRight" HorizontalOffset="0" VerticalOffset="0">
        <ExpandCollapseDecorator Name="ExpandCollapse" DisplayName="Expand Collapse" />
      </ShapeHasDecorators>
      <Compartment TitleFillColor="235, 235, 235" Name="OperationsCompartment" Title="Operations" />
    </CompartmentShape>
    <GeometryShape Id="6217a91c-fb3d-48e4-820a-522728aa616c" Description="" Name="CommentBoxShape" DisplayName="Comment Box Shape" Namespace="pelsoft.FWK_Dsl" FixedTooltipText="Comment Box Shape" FillColor="255, 255, 204" OutlineColor="204, 204, 102" InitialHeight="0.3" OutlineThickness="0.01" FillGradientMode="None" Geometry="Rectangle">
      <ShapeHasDecorators Position="Center" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="Comment" DisplayName="Comment" DefaultText="BusinessRulesShapeNameDecorator" />
      </ShapeHasDecorators>
    </GeometryShape>
    <ImageShape Id="05047e3c-e8b1-429b-a91d-0f1757c74625" Description="" Name="MultipleAssociationShape" DisplayName="Multiple Association Shape" Namespace="pelsoft.FWK_Dsl" FixedTooltipText="Multiple Association Shape" InitialHeight="1" OutlineThickness="0.01" Image="Resources\Relation.emf" />
    <GeometryShape Id="87a423a5-778c-47d0-a27b-290475539252" Description="Description for pelsoft.FWK_Dsl.FiguraPersona" Name="FiguraPersona" DisplayName="Figura Persona" Namespace="pelsoft.FWK_Dsl" FixedTooltipText="Figura Persona" InitialHeight="1" Geometry="Ellipse">
      <ShapeHasDecorators Position="InnerTopLeft" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="Nombre" DisplayName="Nombre" DefaultText="Nombre" />
      </ShapeHasDecorators>
    </GeometryShape>
  </Shapes>
  <Connectors>
    <Connector Id="9e5a1df4-17a9-44aa-8604-ae199be084bd" Description="" Name="AssociationConnector" DisplayName="Association Connector" InheritanceModifier="Abstract" Namespace="pelsoft.FWK_Dsl" FixedTooltipText="Association Connector" Color="113, 111, 110" Thickness="0.01">
      <ConnectorHasDecorators Position="TargetBottom" OffsetFromShape="0" OffsetFromLine="0">
        <TextDecorator Name="TargetMultiplicity" DisplayName="Target Multiplicity" DefaultText="TargetMultiplicity" />
      </ConnectorHasDecorators>
      <ConnectorHasDecorators Position="SourceBottom" OffsetFromShape="0" OffsetFromLine="0">
        <TextDecorator Name="SourceMultiplicity" DisplayName="Source Multiplicity" DefaultText="SourceMultiplicity" />
      </ConnectorHasDecorators>
      <ConnectorHasDecorators Position="TargetTop" OffsetFromShape="0" OffsetFromLine="0">
        <TextDecorator Name="TargetRoleName" DisplayName="Target Role Name" DefaultText="TargetRoleName" />
      </ConnectorHasDecorators>
      <ConnectorHasDecorators Position="SourceTop" OffsetFromShape="0" OffsetFromLine="0">
        <TextDecorator Name="SourceRoleName" DisplayName="Source Role Name" DefaultText="SourceRoleName" />
      </ConnectorHasDecorators>
    </Connector>
    <Connector Id="19875b8e-03cd-4d28-ad71-0e37267ec4c1" Description="" Name="UnidirectionalConnector" DisplayName="Unidirectional Connector" Namespace="pelsoft.FWK_Dsl" FixedTooltipText="Unidirectional Connector" Color="113, 111, 110" TargetEndStyle="EmptyArrow" Thickness="0.01">
      <BaseConnector>
        <ConnectorMoniker Name="AssociationConnector" />
      </BaseConnector>
    </Connector>
    <Connector Id="88e9b7a6-8274-411c-ab9b-7b7529d7b646" Description="" Name="BidirectionalConnector" DisplayName="Bidirectional Connector" Namespace="pelsoft.FWK_Dsl" FixedTooltipText="" Color="113, 111, 110" Thickness="0.01">
      <BaseConnector>
        <ConnectorMoniker Name="AssociationConnector" />
      </BaseConnector>
    </Connector>
    <Connector Id="12e4f6d1-9746-40a3-aa5b-df9690584b08" Description="" Name="AggregationConnector" DisplayName="Aggregation Connector" Namespace="pelsoft.FWK_Dsl" FixedTooltipText="Aggregation Connector" Color="113, 111, 110" SourceEndStyle="EmptyDiamond" Thickness="0.01">
      <BaseConnector>
        <ConnectorMoniker Name="AssociationConnector" />
      </BaseConnector>
    </Connector>
    <Connector Id="0fb45c51-e962-43f4-a053-6d8984df036f" Description="" Name="CompositionConnector" DisplayName="Composition Connector" Namespace="pelsoft.FWK_Dsl" FixedTooltipText="Composition Connector" Color="113, 111, 110" SourceEndStyle="FilledDiamond" Thickness="0.01">
      <BaseConnector>
        <ConnectorMoniker Name="AssociationConnector" />
      </BaseConnector>
    </Connector>
    <Connector Id="3279633c-a027-479f-8652-f0b39317da0a" Description="" Name="MultipleAssociationRoleConnector" DisplayName="Multiple Association Role Connector" Namespace="pelsoft.FWK_Dsl" FixedTooltipText="Multiple Association Role Connector" Color="113, 111, 110" Thickness="0.01">
      <ConnectorHasDecorators Position="TargetBottom" OffsetFromShape="0" OffsetFromLine="0">
        <TextDecorator Name="TargetMultiplicity" DisplayName="Target Multiplicity" DefaultText="TargetMultiplicity" />
      </ConnectorHasDecorators>
      <ConnectorHasDecorators Position="TargetTop" OffsetFromShape="0" OffsetFromLine="0">
        <TextDecorator Name="TargetRoleName" DisplayName="Target Role Name" DefaultText="TargetRoleName" />
      </ConnectorHasDecorators>
    </Connector>
    <Connector Id="cefa0b07-4b0d-4b01-9d02-5ce52a41746f" Description="" Name="AssociationClassConnector" DisplayName="Association Class Connector" Namespace="pelsoft.FWK_Dsl" FixedTooltipText="Association Class Connector" Color="DarkGray" DashStyle="Dash" Thickness="0.01" />
    <Connector Id="b6ddd178-2eb6-4ac2-a320-afffca442169" Description="" Name="GeneralizationConnector" DisplayName="Generalization Connector" Namespace="pelsoft.FWK_Dsl" FixedTooltipText="Generalization Connector" Color="113, 111, 110" SourceEndStyle="HollowArrow" Thickness="0.01" ExposesColorAsProperty="true" ExposesDashStyleAsProperty="true">
      <Properties>
        <DomainProperty Id="436acab5-200e-48ee-b47a-392df67823b3" Description="Description for pelsoft.FWK_Dsl.GeneralizationConnector.Color" Name="Color" DisplayName="Color" Kind="CustomStorage">
          <Type>
            <ExternalTypeMoniker Name="/System.Drawing/Color" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="8b54c376-40cc-46ea-a244-32057cef5d84" Description="Description for pelsoft.FWK_Dsl.GeneralizationConnector.Dash Style" Name="DashStyle" DisplayName="Dash Style" Kind="CustomStorage">
          <Type>
            <ExternalTypeMoniker Name="/System.Drawing.Drawing2D/DashStyle" />
          </Type>
        </DomainProperty>
      </Properties>
    </Connector>
    <Connector Id="b7503693-baf5-400e-859d-d359c0c72937" Description="" Name="ImplementationConnector" DisplayName="Implementation Connector" Namespace="pelsoft.FWK_Dsl" FixedTooltipText="Implementation Connector" Color="113, 111, 110" DashStyle="Dash" SourceEndStyle="HollowArrow" Thickness="0.01" />
    <Connector Id="1e8754db-7bdf-476a-99d1-c557afcf07af" Description="" Name="CommentConnector" DisplayName="Comment Connector" Namespace="pelsoft.FWK_Dsl" FixedTooltipText="Comment Connector" Color="113, 111, 110" DashStyle="Dot" Thickness="0.01" RoutingStyle="Straight" />
  </Connectors>
  <XmlSerializationBehavior Name="FWK_DslSerializationBehavior" Namespace="pelsoft.FWK_Dsl">
    <ClassData>
      <XmlClassData TypeName="Persona" MonikerAttributeName="" MonikerElementName="personaMoniker" ElementName="persona" MonikerTypeName="PersonaMoniker">
        <DomainClassMoniker Name="Persona" />
        <ElementData>
          <XmlPropertyData XmlName="name" IsMonikerKey="true">
            <DomainPropertyMoniker Name="Persona/Name" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="domainProperty1">
            <DomainPropertyMoniker Name="Persona/DomainProperty1" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="sexo">
            <DomainPropertyMoniker Name="Persona/Sexo" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="Association" MonikerAttributeName="" SerializeId="true" MonikerElementName="associationMoniker" ElementName="association" MonikerTypeName="AssociationMoniker">
        <DomainRelationshipMoniker Name="Association" />
        <ElementData>
          <XmlPropertyData XmlName="sourceMultiplicity">
            <DomainPropertyMoniker Name="Association/SourceMultiplicity" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="sourceRoleName">
            <DomainPropertyMoniker Name="Association/SourceRoleName" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="targetMultiplicity">
            <DomainPropertyMoniker Name="Association/TargetMultiplicity" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="targetRoleName">
            <DomainPropertyMoniker Name="Association/TargetRoleName" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ClassHasAttributes" MonikerAttributeName="" MonikerElementName="classHasAttributesMoniker" ElementName="classHasAttributes" MonikerTypeName="ClassHasAttributesMoniker">
        <DomainRelationshipMoniker Name="ClassHasAttributes" />
      </XmlClassData>
      <XmlClassData TypeName="ModelRootHasComments" MonikerAttributeName="" MonikerElementName="modelRootHasCommentsMoniker" ElementName="modelRootHasComments" MonikerTypeName="ModelRootHasCommentsMoniker">
        <DomainRelationshipMoniker Name="ModelRootHasComments" />
      </XmlClassData>
      <XmlClassData TypeName="ClassHasOperations" MonikerAttributeName="" MonikerElementName="classHasOperationsMoniker" ElementName="classHasOperations" MonikerTypeName="ClassHasOperationsMoniker">
        <DomainRelationshipMoniker Name="ClassHasOperations" />
      </XmlClassData>
      <XmlClassData TypeName="Generalization" MonikerAttributeName="" MonikerElementName="generalizationMoniker" ElementName="generalization" MonikerTypeName="GeneralizationMoniker">
        <DomainRelationshipMoniker Name="Generalization" />
        <ElementData>
          <XmlPropertyData XmlName="discriminator">
            <DomainPropertyMoniker Name="Generalization/Discriminator" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="InterfaceHasOperation" MonikerAttributeName="" MonikerElementName="interfaceHasOperationMoniker" ElementName="interfaceHasOperation" MonikerTypeName="InterfaceHasOperationMoniker">
        <DomainRelationshipMoniker Name="InterfaceHasOperation" />
      </XmlClassData>
      <XmlClassData TypeName="MultipleAssociationRole" MonikerAttributeName="" MonikerElementName="multipleAssociationRoleMoniker" ElementName="multipleAssociationRole" MonikerTypeName="MultipleAssociationRoleMoniker">
        <DomainRelationshipMoniker Name="MultipleAssociationRole" />
        <ElementData>
          <XmlPropertyData XmlName="multiplicity">
            <DomainPropertyMoniker Name="MultipleAssociationRole/Multiplicity" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="roleName">
            <DomainPropertyMoniker Name="MultipleAssociationRole/RoleName" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="AssociationClassRelationship" MonikerAttributeName="" MonikerElementName="associationClassRelationshipMoniker" ElementName="associationClassRelationship" MonikerTypeName="AssociationClassRelationshipMoniker">
        <DomainRelationshipMoniker Name="AssociationClassRelationship" />
      </XmlClassData>
      <XmlClassData TypeName="ModelRootHasTypes" MonikerAttributeName="" MonikerElementName="modelRootHasTypesMoniker" ElementName="modelRootHasTypes" MonikerTypeName="ModelRootHasTypesMoniker">
        <DomainRelationshipMoniker Name="ModelRootHasTypes" />
      </XmlClassData>
      <XmlClassData TypeName="CommentReferencesSubjects" MonikerAttributeName="" MonikerElementName="commentReferencesSubjectsMoniker" ElementName="commentReferencesSubjects" MonikerTypeName="CommentReferencesSubjectsMoniker">
        <DomainRelationshipMoniker Name="CommentReferencesSubjects" />
      </XmlClassData>
      <XmlClassData TypeName="Implementation" MonikerAttributeName="" MonikerElementName="implementationMoniker" ElementName="implementation" MonikerTypeName="ImplementationMoniker">
        <DomainRelationshipMoniker Name="Implementation" />
      </XmlClassData>
      <XmlClassData TypeName="ModelRoot" MonikerAttributeName="" MonikerElementName="modelRootMoniker" ElementName="modelRoot" MonikerTypeName="ModelRootMoniker">
        <DomainClassMoniker Name="ModelRoot" />
        <ElementData>
          <XmlRelationshipData RoleElementName="comments">
            <DomainRelationshipMoniker Name="ModelRootHasComments" />
          </XmlRelationshipData>
          <XmlRelationshipData RoleElementName="types">
            <DomainRelationshipMoniker Name="ModelRootHasTypes" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ModelClass" MonikerAttributeName="" MonikerElementName="modelClassMoniker" ElementName="modelClass" MonikerTypeName="ModelClassMoniker">
        <DomainClassMoniker Name="ModelClass" />
        <ElementData>
          <XmlPropertyData XmlName="kind">
            <DomainPropertyMoniker Name="ModelClass/Kind" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isAbstract">
            <DomainPropertyMoniker Name="ModelClass/IsAbstract" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="unidirectionalTargets">
            <DomainRelationshipMoniker Name="UnidirectionalAssociation" />
          </XmlRelationshipData>
          <XmlRelationshipData RoleElementName="attributes">
            <DomainRelationshipMoniker Name="ClassHasAttributes" />
          </XmlRelationshipData>
          <XmlRelationshipData RoleElementName="operations">
            <DomainRelationshipMoniker Name="ClassHasOperations" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="subclasses">
            <DomainRelationshipMoniker Name="Generalization" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="bidirectionalTargets">
            <DomainRelationshipMoniker Name="BidirectionalAssociation" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="aggregationTargets">
            <DomainRelationshipMoniker Name="Aggregation" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="compositionTargets">
            <DomainRelationshipMoniker Name="Composition" />
          </XmlRelationshipData>
          <XmlRelationshipData RoleElementName="targets">
            <DomainRelationshipMoniker Name="Association" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ModelAttribute" MonikerAttributeName="" MonikerElementName="modelAttributeMoniker" ElementName="modelAttribute" MonikerTypeName="ModelAttributeMoniker">
        <DomainClassMoniker Name="ModelAttribute" />
        <ElementData>
          <XmlPropertyData XmlName="type">
            <DomainPropertyMoniker Name="ModelAttribute/Type" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="initialValue">
            <DomainPropertyMoniker Name="ModelAttribute/InitialValue" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="multiplicity">
            <DomainPropertyMoniker Name="ModelAttribute/Multiplicity" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="Comment" MonikerAttributeName="" SerializeId="true" MonikerElementName="commentMoniker" ElementName="comment" MonikerTypeName="CommentMoniker">
        <DomainClassMoniker Name="Comment" />
        <ElementData>
          <XmlPropertyData XmlName="text">
            <DomainPropertyMoniker Name="Comment/Text" />
          </XmlPropertyData>
          <XmlRelationshipData RoleElementName="subjects">
            <DomainRelationshipMoniker Name="CommentReferencesSubjects" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="Operation" MonikerAttributeName="" MonikerElementName="operationMoniker" ElementName="operation" MonikerTypeName="OperationMoniker">
        <DomainClassMoniker Name="Operation" />
        <ElementData>
          <XmlPropertyData XmlName="signature">
            <DomainPropertyMoniker Name="Operation/Signature" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="concurrency">
            <DomainPropertyMoniker Name="Operation/Concurrency" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="precondition">
            <DomainPropertyMoniker Name="Operation/Precondition" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="postcondition">
            <DomainPropertyMoniker Name="Operation/Postcondition" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ClassOperation" MonikerAttributeName="" MonikerElementName="classOperationMoniker" ElementName="classOperation" MonikerTypeName="ClassOperationMoniker">
        <DomainClassMoniker Name="ClassOperation" />
        <ElementData>
          <XmlPropertyData XmlName="isAbstract">
            <DomainPropertyMoniker Name="ClassOperation/IsAbstract" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ModelInterface" MonikerAttributeName="" MonikerElementName="modelInterfaceMoniker" ElementName="modelInterface" MonikerTypeName="ModelInterfaceMoniker">
        <DomainClassMoniker Name="ModelInterface" />
        <ElementData>
          <XmlRelationshipData RoleElementName="operations">
            <DomainRelationshipMoniker Name="InterfaceHasOperation" />
          </XmlRelationshipData>
          <XmlRelationshipData RoleElementName="implementors">
            <DomainRelationshipMoniker Name="Implementation" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="InterfaceOperation" MonikerAttributeName="" MonikerElementName="interfaceOperationMoniker" ElementName="interfaceOperation" MonikerTypeName="InterfaceOperationMoniker">
        <DomainClassMoniker Name="InterfaceOperation" />
      </XmlClassData>
      <XmlClassData TypeName="MultipleAssociation" MonikerAttributeName="" MonikerElementName="multipleAssociationMoniker" ElementName="multipleAssociation" MonikerTypeName="MultipleAssociationMoniker">
        <DomainClassMoniker Name="MultipleAssociation" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="types">
            <DomainRelationshipMoniker Name="MultipleAssociationRole" />
          </XmlRelationshipData>
          <XmlRelationshipData RoleElementName="associationClass">
            <DomainRelationshipMoniker Name="AssociationClassRelationship" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ModelType" MonikerAttributeName="" MonikerElementName="modelTypeMoniker" ElementName="modelType" MonikerTypeName="ModelTypeMoniker">
        <DomainClassMoniker Name="ModelType" />
      </XmlClassData>
      <XmlClassData TypeName="ClassModelElement" MonikerAttributeName="" MonikerElementName="classModelElementMoniker" ElementName="classModelElement" MonikerTypeName="ClassModelElementMoniker">
        <DomainClassMoniker Name="ClassModelElement" />
        <ElementData>
          <XmlPropertyData XmlName="description">
            <DomainPropertyMoniker Name="ClassModelElement/Description" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="UnidirectionalAssociation" MonikerAttributeName="" SerializeId="true" MonikerElementName="unidirectionalAssociationMoniker" ElementName="unidirectionalAssociation" MonikerTypeName="UnidirectionalAssociationMoniker">
        <DomainRelationshipMoniker Name="UnidirectionalAssociation" />
      </XmlClassData>
      <XmlClassData TypeName="BidirectionalAssociation" MonikerAttributeName="" SerializeId="true" MonikerElementName="bidirectionalAssociationMoniker" ElementName="bidirectionalAssociation" MonikerTypeName="BidirectionalAssociationMoniker">
        <DomainRelationshipMoniker Name="BidirectionalAssociation" />
      </XmlClassData>
      <XmlClassData TypeName="Aggregation" MonikerAttributeName="" SerializeId="true" MonikerElementName="aggregationMoniker" ElementName="aggregation" MonikerTypeName="AggregationMoniker">
        <DomainRelationshipMoniker Name="Aggregation" />
      </XmlClassData>
      <XmlClassData TypeName="Composition" MonikerAttributeName="" SerializeId="true" MonikerElementName="compositionMoniker" ElementName="composition" MonikerTypeName="CompositionMoniker">
        <DomainRelationshipMoniker Name="Composition" />
      </XmlClassData>
      <XmlClassData TypeName="ClassShape" MonikerAttributeName="" MonikerElementName="classShapeMoniker" ElementName="classShape" MonikerTypeName="ClassShapeMoniker">
        <CompartmentShapeMoniker Name="ClassShape" />
      </XmlClassData>
      <XmlClassData TypeName="InterfaceShape" MonikerAttributeName="" MonikerElementName="interfaceShapeMoniker" ElementName="interfaceShape" MonikerTypeName="InterfaceShapeMoniker">
        <CompartmentShapeMoniker Name="InterfaceShape" />
      </XmlClassData>
      <XmlClassData TypeName="CommentBoxShape" MonikerAttributeName="" MonikerElementName="commentBoxShapeMoniker" ElementName="commentBoxShape" MonikerTypeName="CommentBoxShapeMoniker">
        <GeometryShapeMoniker Name="CommentBoxShape" />
      </XmlClassData>
      <XmlClassData TypeName="MultipleAssociationShape" MonikerAttributeName="" MonikerElementName="multipleAssociationShapeMoniker" ElementName="multipleAssociationShape" MonikerTypeName="MultipleAssociationShapeMoniker">
        <ImageShapeMoniker Name="MultipleAssociationShape" />
      </XmlClassData>
      <XmlClassData TypeName="AssociationConnector" MonikerAttributeName="" MonikerElementName="associationConnectorMoniker" ElementName="associationConnector" MonikerTypeName="AssociationConnectorMoniker">
        <ConnectorMoniker Name="AssociationConnector" />
      </XmlClassData>
      <XmlClassData TypeName="UnidirectionalConnector" MonikerAttributeName="" MonikerElementName="unidirectionalConnectorMoniker" ElementName="unidirectionalConnector" MonikerTypeName="UnidirectionalConnectorMoniker">
        <ConnectorMoniker Name="UnidirectionalConnector" />
      </XmlClassData>
      <XmlClassData TypeName="BidirectionalConnector" MonikerAttributeName="" MonikerElementName="bidirectionalConnectorMoniker" ElementName="bidirectionalConnector" MonikerTypeName="BidirectionalConnectorMoniker">
        <ConnectorMoniker Name="BidirectionalConnector" />
      </XmlClassData>
      <XmlClassData TypeName="AggregationConnector" MonikerAttributeName="" MonikerElementName="aggregationConnectorMoniker" ElementName="aggregationConnector" MonikerTypeName="AggregationConnectorMoniker">
        <ConnectorMoniker Name="AggregationConnector" />
      </XmlClassData>
      <XmlClassData TypeName="CompositionConnector" MonikerAttributeName="" MonikerElementName="compositionConnectorMoniker" ElementName="compositionConnector" MonikerTypeName="CompositionConnectorMoniker">
        <ConnectorMoniker Name="CompositionConnector" />
      </XmlClassData>
      <XmlClassData TypeName="MultipleAssociationRoleConnector" MonikerAttributeName="" MonikerElementName="multipleAssociationRoleConnectorMoniker" ElementName="multipleAssociationRoleConnector" MonikerTypeName="MultipleAssociationRoleConnectorMoniker">
        <ConnectorMoniker Name="MultipleAssociationRoleConnector" />
      </XmlClassData>
      <XmlClassData TypeName="AssociationClassConnector" MonikerAttributeName="" MonikerElementName="associationClassConnectorMoniker" ElementName="associationClassConnector" MonikerTypeName="AssociationClassConnectorMoniker">
        <ConnectorMoniker Name="AssociationClassConnector" />
      </XmlClassData>
      <XmlClassData TypeName="GeneralizationConnector" MonikerAttributeName="" MonikerElementName="generalizationConnectorMoniker" ElementName="generalizationConnector" MonikerTypeName="GeneralizationConnectorMoniker">
        <ConnectorMoniker Name="GeneralizationConnector" />
        <ElementData>
          <XmlPropertyData XmlName="color">
            <DomainPropertyMoniker Name="GeneralizationConnector/Color" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="dashStyle">
            <DomainPropertyMoniker Name="GeneralizationConnector/DashStyle" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ImplementationConnector" MonikerAttributeName="" MonikerElementName="implementationConnectorMoniker" ElementName="implementationConnector" MonikerTypeName="ImplementationConnectorMoniker">
        <ConnectorMoniker Name="ImplementationConnector" />
      </XmlClassData>
      <XmlClassData TypeName="CommentConnector" MonikerAttributeName="" MonikerElementName="commentConnectorMoniker" ElementName="commentConnector" MonikerTypeName="CommentConnectorMoniker">
        <ConnectorMoniker Name="CommentConnector" />
      </XmlClassData>
      <XmlClassData TypeName="ClassDiagram" MonikerAttributeName="" MonikerElementName="classDiagramMoniker" ElementName="classDiagram" MonikerTypeName="ClassDiagramMoniker">
        <DiagramMoniker Name="ClassDiagram" />
      </XmlClassData>
      <XmlClassData TypeName="FiguraPersona" MonikerAttributeName="" MonikerElementName="figuraPersonaMoniker" ElementName="figuraPersona" MonikerTypeName="FiguraPersonaMoniker">
        <GeometryShapeMoniker Name="FiguraPersona" />
      </XmlClassData>
    </ClassData>
  </XmlSerializationBehavior>
  <ExplorerBehavior Name="FWK_DslExplorer" />
  <ConnectionBuilders>
    <ConnectionBuilder Name="UnidirectionalAssociationBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="UnidirectionalAssociation" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ModelClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ModelClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="BidirectionalAssociationBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="BidirectionalAssociation" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ModelClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ModelClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="AggregationBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="Aggregation" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ModelClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ModelClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="CompositionBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="Composition" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ModelClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ModelClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="GeneralizationBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="Generalization" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ModelClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ModelClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="Implementation" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ModelInterface" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ModelType" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="MultipleAssociationRoleBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="MultipleAssociationRole" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="MultipleAssociation" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ModelClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="AssociationClassRelationshipBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="AssociationClassRelationship" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="MultipleAssociation" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ModelClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="CommentReferencesSubjectsBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="CommentReferencesSubjects" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="Comment" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ModelClass" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="ModelInterface" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="MultipleAssociation" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
  </ConnectionBuilders>
  <Diagram Id="5f166212-2a9f-44b9-a829-293f032a6861" Description="" Name="ClassDiagram" DisplayName="Class Diagram" Namespace="pelsoft.FWK_Dsl">
    <Class>
      <DomainClassMoniker Name="ModelRoot" />
    </Class>
    <ShapeMaps>
      <CompartmentShapeMap>
        <DomainClassMoniker Name="ModelClass" />
        <ParentElementPath>
          <DomainPath>ModelRootHasTypes.ModelRoot/!ModelRoot</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="ClassShape/Name" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Persona/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <CompartmentShapeMoniker Name="ClassShape" />
        <CompartmentMap>
          <CompartmentMoniker Name="ClassShape/AttributesCompartment" />
          <ElementsDisplayed>
            <DomainPath>ClassHasAttributes.Attributes/!Attribute</DomainPath>
          </ElementsDisplayed>
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Persona/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </CompartmentMap>
        <CompartmentMap>
          <CompartmentMoniker Name="ClassShape/OperationsCompartment" />
          <ElementsDisplayed>
            <DomainPath>ClassHasOperations.Operations/!Operation</DomainPath>
          </ElementsDisplayed>
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Persona/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </CompartmentMap>
      </CompartmentShapeMap>
      <CompartmentShapeMap>
        <DomainClassMoniker Name="ModelInterface" />
        <ParentElementPath>
          <DomainPath>ModelRootHasTypes.ModelRoot/!ModelRoot</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="InterfaceShape/Name" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Persona/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <CompartmentShapeMoniker Name="InterfaceShape" />
        <CompartmentMap>
          <CompartmentMoniker Name="InterfaceShape/OperationsCompartment" />
          <ElementsDisplayed>
            <DomainPath>InterfaceHasOperation.Operations/!Operation</DomainPath>
          </ElementsDisplayed>
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Persona/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </CompartmentMap>
      </CompartmentShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="Comment" />
        <ParentElementPath>
          <DomainPath>ModelRootHasComments.ModelRoot/!ModelRoot</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="CommentBoxShape/Comment" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Comment/Text" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <GeometryShapeMoniker Name="CommentBoxShape" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="MultipleAssociation" />
        <ParentElementPath>
          <DomainPath>ModelRootHasTypes.ModelRoot/!ModelRoot</DomainPath>
        </ParentElementPath>
        <ImageShapeMoniker Name="MultipleAssociationShape" />
      </ShapeMap>
    </ShapeMaps>
    <ConnectorMaps>
      <ConnectorMap>
        <ConnectorMoniker Name="BidirectionalConnector" />
        <DomainRelationshipMoniker Name="BidirectionalAssociation" />
        <DecoratorMap>
          <TextDecoratorMoniker Name="AssociationConnector/SourceMultiplicity" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Association/SourceMultiplicity" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="AssociationConnector/TargetMultiplicity" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Association/TargetMultiplicity" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="AssociationConnector/SourceRoleName" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Association/SourceRoleName" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="AssociationConnector/TargetRoleName" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Association/TargetRoleName" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
      </ConnectorMap>
      <ConnectorMap>
        <ConnectorMoniker Name="UnidirectionalConnector" />
        <DomainRelationshipMoniker Name="UnidirectionalAssociation" />
        <DecoratorMap>
          <TextDecoratorMoniker Name="AssociationConnector/SourceMultiplicity" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Association/SourceMultiplicity" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="AssociationConnector/TargetMultiplicity" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Association/TargetMultiplicity" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="AssociationConnector/SourceRoleName" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Association/SourceRoleName" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="AssociationConnector/TargetRoleName" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Association/TargetRoleName" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
      </ConnectorMap>
      <ConnectorMap>
        <ConnectorMoniker Name="AggregationConnector" />
        <DomainRelationshipMoniker Name="Aggregation" />
        <DecoratorMap>
          <TextDecoratorMoniker Name="AssociationConnector/SourceMultiplicity" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Association/SourceMultiplicity" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="AssociationConnector/TargetMultiplicity" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Association/TargetMultiplicity" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="AssociationConnector/SourceRoleName" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Association/SourceRoleName" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="AssociationConnector/TargetRoleName" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Association/TargetRoleName" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
      </ConnectorMap>
      <ConnectorMap>
        <ConnectorMoniker Name="CompositionConnector" />
        <DomainRelationshipMoniker Name="Composition" />
        <DecoratorMap>
          <TextDecoratorMoniker Name="AssociationConnector/SourceMultiplicity" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Association/SourceMultiplicity" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="AssociationConnector/TargetMultiplicity" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Association/TargetMultiplicity" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="AssociationConnector/SourceRoleName" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Association/SourceRoleName" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="AssociationConnector/TargetRoleName" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Association/TargetRoleName" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
      </ConnectorMap>
      <ConnectorMap>
        <ConnectorMoniker Name="MultipleAssociationRoleConnector" />
        <DomainRelationshipMoniker Name="MultipleAssociationRole" />
        <DecoratorMap>
          <TextDecoratorMoniker Name="MultipleAssociationRoleConnector/TargetMultiplicity" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="MultipleAssociationRole/Multiplicity" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <DecoratorMap>
          <TextDecoratorMoniker Name="MultipleAssociationRoleConnector/TargetRoleName" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="MultipleAssociationRole/RoleName" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
      </ConnectorMap>
      <ConnectorMap>
        <ConnectorMoniker Name="AssociationClassConnector" />
        <DomainRelationshipMoniker Name="AssociationClassRelationship" />
      </ConnectorMap>
      <ConnectorMap>
        <ConnectorMoniker Name="CommentConnector" />
        <DomainRelationshipMoniker Name="CommentReferencesSubjects" />
      </ConnectorMap>
      <ConnectorMap>
        <ConnectorMoniker Name="GeneralizationConnector" />
        <DomainRelationshipMoniker Name="Generalization" />
      </ConnectorMap>
      <ConnectorMap>
        <ConnectorMoniker Name="ImplementationConnector" />
        <DomainRelationshipMoniker Name="Implementation" />
      </ConnectorMap>
    </ConnectorMaps>
  </Diagram>
  <Designer FileExtension="fwkdsl" EditorGuid="bed5263b-042e-49e2-8d4f-167124a5a860">
    <RootClass>
      <DomainClassMoniker Name="ModelRoot" />
    </RootClass>
    <XmlSerializationDefinition CustomPostLoad="false">
      <XmlSerializationBehaviorMoniker Name="FWK_DslSerializationBehavior" />
    </XmlSerializationDefinition>
    <ToolboxTab TabText="Class Diagrams">
      <ElementTool Name="ModelClass" ToolboxIcon="Resources\ClassTool.bmp" Caption="Class" Tooltip="Create a Class" HelpKeyword="ModelClassF1Keyword">
        <DomainClassMoniker Name="ModelClass" />
      </ElementTool>
      <ElementTool Name="Attribute" ToolboxIcon="resources\attributetool.bmp" Caption="Attribute" Tooltip="Create an Attribute on a Class" HelpKeyword="AttributeF1Keyword">
        <DomainClassMoniker Name="ModelAttribute" />
      </ElementTool>
      <ElementTool Name="ClassOperation" ToolboxIcon="resources\operationtool.bmp" Caption="Class Operation" Tooltip="Create an Operation on a Class" HelpKeyword="ClassOperationF1Keyword">
        <DomainClassMoniker Name="ClassOperation" />
      </ElementTool>
      <ElementTool Name="ModelInterface" ToolboxIcon="Resources\InterfaceTool.bmp" Caption="Interface" Tooltip="Create an Interface" HelpKeyword="ModelInterfaceF1Keyword">
        <DomainClassMoniker Name="ModelInterface" />
      </ElementTool>
      <ElementTool Name="InterfaceOperation" ToolboxIcon="resources\interfaceoperationtool.bmp" Caption="Interface Operation" Tooltip="Create an Operation on an Interface" HelpKeyword="InterfaceOperationF1Keyword">
        <DomainClassMoniker Name="InterfaceOperation" />
      </ElementTool>
      <ConnectionTool Name="UnidirectionalAssociation" ToolboxIcon="Resources\UnidirectionTool.bmp" Caption="Unidirectional Association" Tooltip="Create a Unidirectional link" HelpKeyword="ConnectUnidirectionalAssociationF1Keyword">
        <ConnectionBuilderMoniker Name="FWK_Dsl/UnidirectionalAssociationBuilder" />
      </ConnectionTool>
      <ConnectionTool Name="BidirectionalAssociation" ToolboxIcon="Resources\AssociationTool.bmp" Caption="Bidirectional Association" Tooltip="Create a Bidirectional link" HelpKeyword="ConnectBidirectionalAssociationF1Keyword">
        <ConnectionBuilderMoniker Name="FWK_Dsl/BidirectionalAssociationBuilder" />
      </ConnectionTool>
      <ConnectionTool Name="Aggregation" ToolboxIcon="Resources\AggregationTool.bmp" Caption="Aggregation" Tooltip="Create an Aggregation link" HelpKeyword="AggregationF1Keyword">
        <ConnectionBuilderMoniker Name="FWK_Dsl/AggregationBuilder" />
      </ConnectionTool>
      <ConnectionTool Name="Composition" ToolboxIcon="Resources\CompositeTool.bmp" Caption="Composition" Tooltip="Create a Composition link" HelpKeyword="CompositionF1Keyword">
        <ConnectionBuilderMoniker Name="FWK_Dsl/CompositionBuilder" />
      </ConnectionTool>
      <ConnectionTool Name="Generalization" ToolboxIcon="resources\generalizationtool.bmp" Caption="Inheritance" Tooltip="Create a Generalization or Implementation link" HelpKeyword="GeneralizationF1Keyword" ReversesDirection="true">
        <ConnectionBuilderMoniker Name="FWK_Dsl/GeneralizationBuilder" />
      </ConnectionTool>
      <ElementTool Name="MultipleAssociation" ToolboxIcon="resources\multipleassociationtool.bmp" Caption="Multiple Association" Tooltip="Create a Multiple Association element" HelpKeyword="MultipleAssociationF1Keyword">
        <DomainClassMoniker Name="MultipleAssociation" />
      </ElementTool>
      <ConnectionTool Name="MultipleAssociationRole" ToolboxIcon="Resources\AssociationLinkTool.bmp" Caption="Multiple Association Link" Tooltip="Create a Multiple Association link" HelpKeyword="MultipleAssociationRoleF1Keyword">
        <ConnectionBuilderMoniker Name="FWK_Dsl/MultipleAssociationRoleBuilder" />
      </ConnectionTool>
      <ConnectionTool Name="AssociationClassRelationship" ToolboxIcon="Resources\AssociationClassTool.bmp" Caption="Association Class" Tooltip="Identify a Multiple Association with a Class" HelpKeyword="AssociationClassRelationshipF1Keyword">
        <ConnectionBuilderMoniker Name="FWK_Dsl/AssociationClassRelationshipBuilder" />
      </ConnectionTool>
      <ElementTool Name="Comment" ToolboxIcon="resources\commenttool.bmp" Caption="Comment" Tooltip="Create a Comment" HelpKeyword="CommentF1Keyword">
        <DomainClassMoniker Name="Comment" />
      </ElementTool>
      <ConnectionTool Name="CommentsReferenceTypes" ToolboxIcon="resources\commentlinktool.bmp" Caption="Comment Link" Tooltip="Link a comment to an element" HelpKeyword="CommentsReferenceTypesF1Keyword">
        <ConnectionBuilderMoniker Name="FWK_Dsl/CommentReferencesSubjectsBuilder" />
      </ConnectionTool>
    </ToolboxTab>
    <Validation UsesMenu="false" UsesOpen="false" UsesSave="false" UsesLoad="false" />
    <DiagramMoniker Name="ClassDiagram" />
  </Designer>
  <Explorer ExplorerGuid="773b9a90-9caf-42e9-86f7-a13362a9ee1e" Title="">
    <ExplorerBehaviorMoniker Name="FWK_Dsl/FWK_DslExplorer" />
  </Explorer>
</Dsl>