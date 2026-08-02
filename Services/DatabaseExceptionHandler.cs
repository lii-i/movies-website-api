// public class DatabaseExceptionHandler : IExceptionHandler{

//     public async ValueTask<bool> TryHandleAsync(
//         HttpContext httpContext, 
//         Exception exception, 
//         CancellationToken cancellationToken){

//         if(exception is not DbUpdateConcurrencyException ){
//             return false;
//         }

//         httpContext.StatusCode = StatusCodes.Status400BadRequest;
//             await httpContext.Response.WriteAsJsonAsync(new{
//                 Error = "Ошибка при сохранении в базу данных. Возможно, дубликат.",
//             }, cancellationToken);

//             return true;
//     }


// }