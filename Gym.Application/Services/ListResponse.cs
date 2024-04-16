using FluentValidation.Results;
using Gym.Application.Validations;

namespace Gym.Application.Services
{
    public class ListResponse
    {
        public bool IsSuccess { get; set; }
        public ICollection<ErrorValidation> Errors { get; set; }

        public static ListResponse<T> RequestError<T>(string message, ValidationResult validationResult)
        {
            return new ListResponse<T>
            {
                IsSuccess = false,
                Errors = validationResult.Errors.Select(x => new ErrorValidation(x.ErrorMessage)).ToList()
            };
        }

        public static ListResponse<T> Ok<T>(IList<T> data)
        {
            return new ListResponse<T>
            {
                Data = data,
                IsSuccess = true,
            };
        }
    }

    public class ListResponse<T> : ListResponse
    {
        public IList<T> Data { get; set; }
    }
}
