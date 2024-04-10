using FluentValidation.Results;
using Gym.Application.Validations;

namespace Gym.Application.Services
{
    public class ResultService
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public ICollection<ErrorValidation> Errors { get; set; }

        public static ResultService Ok(string message)
        {
            return new ResultService 
            { 
               IsSuccess = true,
               Message = message
            };
        }

        public static ResultService RequestError(string message, ValidationResult validationResult)
        {
            return new ResultService
            {
                IsSuccess = false,
                Message = message,
                Errors = validationResult.Errors.Select(x => new ErrorValidation(x.PropertyName, x.ErrorMessage)).ToList()
            };
        }

        public static ResultService<T> Ok<T>(T data, string message)
        {
            return new ResultService<T>
            {
                Data = data,
                IsSuccess = true,
                Message = message
            };
        }

        public static ResultService<T> RequestError<T>(string message, ValidationResult validationResult)
        {
            return new ResultService<T>
            {
                IsSuccess = false,
                Message = message,
                Errors = validationResult.Errors.Select(x => new ErrorValidation(x.PropertyName, x.ErrorMessage)).ToList()
            };
        }

        public static ResultService<T> Fail<T>(string message)
        {
            return new ResultService<T>
            {
                IsSuccess = false,
                Message = message,
            };
        }
    }

    public class ResultService<T> : ResultService
    {
        public T Data { get; set; }
    }
}
