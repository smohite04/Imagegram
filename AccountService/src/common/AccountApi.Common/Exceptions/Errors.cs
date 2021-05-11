using AccountApi.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace AccountApi.Common
{
    public static class Errors
    {
        public static BaseApplicationException InvalidHeader(string value)
        {
            return new BadRequestException(ErrorCodes.InvalidHeader, string.Format(ErrorMessages.InvalidHeader, value), HttpStatusCode.BadRequest);
        }

        public static BaseApplicationException MissingHeader(string value)
        {
            return new BadRequestException(ErrorCodes.MissingHeader, string.Format(ErrorMessages.MissingHeader, value), HttpStatusCode.BadRequest);
        }
        public static BaseApplicationException ValueDoesNotExist(string property, string value)
        {
            return new BadRequestException(ErrorCodes.ValueDoesNotExist, string.Format(ErrorMessages.ValueDoesNotExist, property,value), HttpStatusCode.NotFound);
        }
        public static BaseApplicationException ExpiredToken( string value)
        {
            return new BadRequestException(ErrorCodes.ExpiredToken, string.Format(ErrorMessages.ExpiredToken, value), HttpStatusCode.Unauthorized);
        }
        public static BaseApplicationException AccountCreationError()
        {
            return new BaseApplicationException(ErrorCodes.AccountCreationError, string.Format(ErrorMessages.AccountCreationError), HttpStatusCode.InternalServerError);
        }
    }
}
