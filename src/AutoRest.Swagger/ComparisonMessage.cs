// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Globalization;
using AutoRest.Swagger.Logging;

namespace AutoRest.Swagger
{
    /// <summary>
    ///     Represents a single validation violation.
    /// </summary>
    public class ComparisonMessage
    {
        public ComparisonMessage(MessageTemplate template, FileObjectPath path, Category severity,
            params object[] formatArguments)
        {
            Severity = severity;
            Message = $"{string.Format(CultureInfo.CurrentCulture, template.Message, formatArguments)}";
            Path = path;
            Id = template.Id;
            Code = template.Code;
        }

        public Category Severity { get; }

        public string Message { get; }

        /// <summary>
        ///     The JSON document path to the element being validated.
        /// </summary>
        public FileObjectPath Path { get; }

        /// <summary>
        ///     The id of the validation message
        /// </summary>
        public int Id { get; }

        /// <summary>
        ///     The code of the validation message
        /// </summary>
        public string Code { get; }

        public override string ToString()
        {
            return $"code = {Code}, type = {Severity}, message = {Message}";
        }
    }
}