namespace AutoRest.Swagger
{
    public static class ComparisonMessages
    {
        public static MessageTemplate RemovedProperty = new MessageTemplate
        {
            Id = 1033,
            Code = nameof(RemovedProperty),
            Message = "The new version is missing a property found in the old version. Was '{0}' renamed or removed?"
        };

        public static MessageTemplate AddedRequiredProperty = new MessageTemplate
        {
            Id = 1034,
            Code = nameof(AddedRequiredProperty),
            Message = "The new version has new required property '{0}' that was not found in the old version."
        };

        public static MessageTemplate AddedReadOnlyPropertyInResponse = new MessageTemplate
        {
            Id = 1040,
            Code = nameof(AddedReadOnlyPropertyInResponse),
            Message =
                "The new version has a new read-only property '{0}' in response that was not found in the old version."
        };

        public static MessageTemplate AddedPropertyInResponse = new MessageTemplate
        {
            Id = 1041,
            Code = nameof(AddedPropertyInResponse),
            Message = "The new version has a new property '{0}' in response that was not found in the old version."
        };

        public static MessageTemplate RemovedDefinition = new MessageTemplate
        {
            Id = 1006,
            Code = nameof(RemovedDefinition),
            Message =
                "The new version is missing a definition that was found in the old version. Was '{0}' removed or renamed?"
        };

        public static MessageTemplate RemovedPath = new MessageTemplate
        {
            Id = 1005,
            Code = nameof(RemovedPath),
            Message =
                "The new version is missing a path that was found in the old version. Was path '{0}' removed or restructured?"
        };

        public static MessageTemplate AddedPath = new MessageTemplate
        {
            Id = 1038,
            Code = nameof(AddedPath),
            Message = "The new version is adding a path that was not found in the old version."
        };

        public static MessageTemplate RemovedOperation = new MessageTemplate
        {
            Id = 1035,
            Code = nameof(RemovedOperation),
            Message =
                "The new version is missing an operation that was found in the old version. Was operationId '{0}' removed or restructured?"
        };

        public static MessageTemplate ModifiedOperationId = new MessageTemplate
        {
            Id = 1008,
            Code = nameof(ModifiedOperationId),
            Message = "The operation id has been changed from '{0}' to '{1}'. This will impact generated code."
        };

        public static MessageTemplate AddedOperation = new MessageTemplate
        {
            Id = 1039,
            Code = nameof(AddedOperation),
            Message = "The new version is adding an operation that was not found in the old version."
        };

        public static MessageTemplate RemovedRequiredParameter = new MessageTemplate
        {
            Id = 1009,
            Code = nameof(RemovedRequiredParameter),
            Message = "The required parameter '{0}' was removed in the new version."
        };

        public static MessageTemplate AddingRequiredParameter = new MessageTemplate
        {
            Id = 1010,
            Code = nameof(AddingRequiredParameter),
            Message = "The required parameter '{0}' was added in the new version."
        };

        public static MessageTemplate RequiredStatusChange = new MessageTemplate
        {
            Id = 1025,
            Code = nameof(RequiredStatusChange),
            Message = "The 'required' status changed from the old version('{0}') to the new version('{1}')."
        };

        public static MessageTemplate TypeChanged = new MessageTemplate
        {
            Id = 1026,
            Code = nameof(TypeChanged),
            Message = "The new version has a different type '{0}' than the previous one '{1}'."
        };

        public static MessageTemplate RemovedEnumValue = new MessageTemplate
        {
            Id = 1019,
            Code = nameof(RemovedEnumValue),
            Message = "The new version is removing enum value(s) '{0}' from the old version."
        };

        public static MessageTemplate AddedEnumValue = new MessageTemplate
        {
            Id = 1020,
            Code = nameof(AddedEnumValue),
            Message = "The new version is adding enum value(s) '{0}' from the old version."
        };

        public static MessageTemplate ConstraintIsStronger = new MessageTemplate
        {
            Id = 1024,
            Code = nameof(ConstraintIsStronger),
            Message = "The new version has a more constraining '{0}' value than the previous one."
        };

        public static MessageTemplate ConstraintIsWeaker = new MessageTemplate
        {
            Id = 1037,
            Code = nameof(ConstraintIsWeaker),
            Message = "The new version has a less constraining '{0}' value than the previous one."
        };

        public static MessageTemplate ReadonlyPropertyChanged = new MessageTemplate
        {
            Id = 1029,
            Code = nameof(ReadonlyPropertyChanged),
            Message = "The read only property has changed from '{0}' to '{1}'."
        };

        public static MessageTemplate VersionsReversed = new MessageTemplate
        {
            Id = 1000,
            Code = nameof(VersionsReversed),
            Message = "The new version has a lower value than the old: {0} -> {1}"
        };

        public static MessageTemplate NoVersionChange = new MessageTemplate
        {
            Id = 1001,
            Code = nameof(NoVersionChange),
            Message = "The versions have not changed."
        };

        public static MessageTemplate ProtocolNoLongerSupported = new MessageTemplate
        {
            Id = 1002,
            Code = nameof(ProtocolNoLongerSupported),
            Message = "The new version does not support '{0}' as a protocol."
        };

        public static MessageTemplate RequestBodyFormatNoLongerSupported = new MessageTemplate
        {
            Id = 1003,
            Code = nameof(RequestBodyFormatNoLongerSupported),
            Message = "The new version does not support '{0}' as a request body format."
        };

        public static MessageTemplate ResponseBodyFormatNowSupported = new MessageTemplate
        {
            Id = 1004,
            Code = nameof(ResponseBodyFormatNowSupported),
            Message = "The old version did not support '{0}' as a response body format."
        };

        public static MessageTemplate RemovedClientParameter = new MessageTemplate
        {
            Id = 1007,
            Code = nameof(RemovedClientParameter),
            Message =
                "The new version is missing a client parameter that was found in the old version. Was '{0}' removed or renamed?"
        };

        public static MessageTemplate AddingResponseCode = new MessageTemplate
        {
            Id = 1011,
            Code = nameof(AddingResponseCode),
            Message = "The new version adds a response code '{0}'."
        };

        public static MessageTemplate RemovedResponseCode = new MessageTemplate
        {
            Id = 1012,
            Code = nameof(RemovedResponseCode),
            Message = "The new version removes the response code '{0}'"
        };

        public static MessageTemplate AddingHeader = new MessageTemplate
        {
            Id = 1013,
            Code = nameof(AddingHeader),
            Message = "The new version adds a required header '{0}'."
        };

        public static MessageTemplate RemovingHeader = new MessageTemplate
        {
            Id = 1014,
            Code = nameof(RemovingHeader),
            Message = "The new version removs a required header '{0}'."
        };

        public static MessageTemplate ParameterInHasChanged = new MessageTemplate
        {
            Id = 1015,
            Code = nameof(ParameterInHasChanged),
            Message = "How the parameter is passed has changed -- it used to be '{0}', now it is '{1}'."
        };

        public static MessageTemplate ConstantStatusHasChanged = new MessageTemplate
        {
            Id = 1016,
            Code = nameof(ConstantStatusHasChanged),
            Message = "The 'constant' status changed from the old version to the new."
        };

        public static MessageTemplate ReferenceRedirection = new MessageTemplate
        {
            Id = 1017,
            Code = nameof(ReferenceRedirection),
            Message = "The '$ref' property points to different models in the old and new versions."
        };

        public static MessageTemplate AddedAdditionalProperties = new MessageTemplate
        {
            Id = 1021,
            Code = nameof(AddedAdditionalProperties),
            Message = "The new version adds an 'additionalProperties' element."
        };

        public static MessageTemplate RemovedAdditionalProperties = new MessageTemplate
        {
            Id = 1022,
            Code = nameof(RemovedAdditionalProperties),
            Message = "The new version removes the 'additionalProperties' element."
        };

        public static MessageTemplate TypeFormatChanged = new MessageTemplate
        {
            Id = 1023,
            Code = nameof(TypeFormatChanged),
            Message = "The new version has a different format than the previous one."
        };

        public static MessageTemplate DefaultValueChanged = new MessageTemplate
        {
            Id = 1027,
            Code = nameof(DefaultValueChanged),
            Message = "The new version has a different default value than the previous one."
        };

        public static MessageTemplate ArrayCollectionFormatChanged = new MessageTemplate
        {
            Id = 1028,
            Code = nameof(ArrayCollectionFormatChanged),
            Message = "The new version has a different array collection format than the previous one."
        };

        public static MessageTemplate DifferentDiscriminator = new MessageTemplate
        {
            Id = 1030,
            Code = nameof(DifferentDiscriminator),
            Message = "The new version has a different discriminator than the previous one."
        };

        public static MessageTemplate DifferentExtends = new MessageTemplate
        {
            Id = 1031,
            Code = nameof(DifferentExtends),
            Message = "The new version has a different 'extends' property than the previous one."
        };

        public static MessageTemplate DifferentAllOf = new MessageTemplate
        {
            Id = 1032,
            Code = nameof(DifferentAllOf),
            Message = "The new version has a different 'allOf' property than the previous one."
        };

        public static MessageTemplate ConstraintChanged = new MessageTemplate
        {
            Id = 1036,
            Code = nameof(ConstraintChanged),
            Message = "The new version has a different '{0}' value than the previous one."
        };
    }
}