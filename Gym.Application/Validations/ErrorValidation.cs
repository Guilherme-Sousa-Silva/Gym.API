namespace Gym.Application.Validations
{
    public class ErrorValidation
    {
        public ErrorValidation(string field, string message)
        {
            Field = field;
            Message = message;
        }

        public string Field { get; set; }
        public string Message { get; set; }
    }
}
