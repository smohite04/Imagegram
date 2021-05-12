using UserPostApi.Common.Exceptions;
using System.Net;

namespace UserPostApi.Common
{
    public static class Errors
    {
        public static BaseApplicationException MissingField(string value)
        {
            return new BadRequestException(ErrorCodes.MissingField, string.Format(ErrorMessages.MissingField, value), HttpStatusCode.BadRequest);
        }

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
        public static BaseApplicationException InternalServerError()
        {
            return new BaseApplicationException(ErrorCodes.InternalServerError,ErrorMessages.InternalServerError, HttpStatusCode.InternalServerError);
        }
    }
}
