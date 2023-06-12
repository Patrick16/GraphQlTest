using Common;
using HotChocolate;

public class CustomErrorFilter : IErrorFilter
{
    public IError OnError(IError error)
    {
        IErrorBuilder? errBuilder = null;
        errBuilder = error.Exception switch
        {
            BadRequestException exception => ErrorBuilder.FromError(error)
                                .SetMessage(exception.Message)
                                .SetCode(nameof(BadRequestException)),
            _ => ErrorBuilder.FromError(error)
                                .SetMessage(error.Message)
                                .SetCode(code: error?.Extensions?["code"]?.ToString())
        };
        return errBuilder
                    .RemoveException()
                    .ClearExtensions()
                    .ClearLocations()
                    .Build();
    }
}