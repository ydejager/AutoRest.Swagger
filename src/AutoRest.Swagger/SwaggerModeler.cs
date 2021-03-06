﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace AutoRest.Swagger
{
    public class SwaggerModeler
    {
        /// <summary>
        ///     Copares two versions of the same service specification.
        /// </summary>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling")]
        public IEnumerable<ComparisonMessage> Compare(string swaggerPrevious, string swaggerNew,
            Settings settings = null)
        {
            var oldDefintion = SwaggerParser.Parse(swaggerPrevious);
            var newDefintion = SwaggerParser.Parse(swaggerNew);

            var context = new ComparisonContext(oldDefintion, newDefintion, settings);

            var comparisonMessages = newDefintion.Compare(context, oldDefintion);

            return comparisonMessages;
        }
    }
}