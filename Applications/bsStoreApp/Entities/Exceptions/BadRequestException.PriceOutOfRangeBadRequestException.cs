namespace Entities.Exceptions
{
    public abstract partial class BadRequestException
    {
        public class PriceOutOfRangeBadRequestException : BadRequestException
        {
            public PriceOutOfRangeBadRequestException() : base("Max price should be less than 1000 and greater than 10.")
            {
            }
        }
    }
}
