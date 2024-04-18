using System.Net.Mime;
using System.Net;
using System.Transactions;
using System.Buffers;
using System.IO.Pipelines;
using System.Text;
using InmueblesCrud.Api.Middlewares.Model;
using InmueblesCrud.BusinessEntities.ViewModels;
using InmueblesCrud.BusinessEntities.Exceptions;

namespace InmueblesCrud.Api.Middlewares
{
    public static class RequestExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestException(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestExceptionMiddleware>();
        }
    }

    public class RequestExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        
        public RequestExceptionMiddleware(RequestDelegate next, ILogger<RequestExceptionMiddleware> logger)
        {
            _next = next;
            
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
                if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
                    throw new UnauthorizedAccessException();
            }
            catch (UnauthorizedAccessException noAuthorization)
            {
                await HandleExceptionAsync(context, noAuthorization, HttpStatusCode.Unauthorized, new ErrorDetail()
                {
                    Cabecera = new HeadErrorDetail(ErrorCode._4999, ErrorDescription._4999)
                });
            }
            catch (TransactionException transaction)
            {
                await HandleExceptionAsync(context, transaction, HttpStatusCode.InternalServerError, new ErrorDetail()
                {
                    Cabecera = new HeadErrorDetail(ErrorCode._5000, ErrorDescription._5000)
                });
            }
            catch (DataNotFoundException dataNotFoundException)
            {
                await HandleExceptionAsync(context, dataNotFoundException, HttpStatusCode.NotFound, new ErrorDetail()
                {
                    Cabecera = new HeadErrorDetail(ErrorCode._1001, dataNotFoundException.Message)
                });
            }

            catch (Exception ex)
            {
                 await HandleExceptionAsync(context, ex, HttpStatusCode.InternalServerError, new ErrorDetail()
                {
                    Cabecera = new HeadErrorDetail(ErrorCode._5000, ErrorDescription._5000)
                });
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex, HttpStatusCode statusCode, ErrorDetail response)
        {
            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(response.ToString());
        }

        private async Task<string> GetInfoFromRequest(HttpContext context)
        {
            var request = context.Request;
            string strInfoBody = string.Empty;
            bool infoBody = request.ContentLength > 0;
            if (infoBody)
            {
                request.Body.Position = 0;
                List<string> tmp = await GetListOfStringFromPipe(request.BodyReader);
                request.Body.Position = 0;

                strInfoBody = string.Concat("\r\nBody: ", string.Join("", tmp.ToArray()));
            }

            return string.Concat('[', request.Method, "]: ", request.Path, '/', request.QueryString, (infoBody ? strInfoBody : string.Empty));
        }

        private async Task<List<string>> GetListOfStringFromPipe(PipeReader reader)
        {
            List<string> results = new List<string>();

            while (true)
            {
                ReadResult readResult = await reader.ReadAsync();
                var buffer = readResult.Buffer;

                SequencePosition? position = null;

                do
                {
                    // Look for a EOL in the buffer
                    position = buffer.PositionOf((byte)'\n');

                    if (position != null)
                    {
                        var readOnlySequence = buffer.Slice(0, position.Value);
                        AddStringToList(results, in readOnlySequence);

                        // Skip the line + the \n character (basically position)
                        buffer = buffer.Slice(buffer.GetPosition(1, position.Value));
                    }
                }
                while (position != null);


                if (readResult.IsCompleted && buffer.Length > 0)
                {
                    AddStringToList(results, in buffer);
                }

                reader.AdvanceTo(buffer.Start, buffer.End);

                // At this point, buffer will be updated to point one byte after the last
                // \n character.
                if (readResult.IsCompleted)
                {
                    break;
                }
            }

            return results;
        }

        private static void AddStringToList(List<string> results, in ReadOnlySequence<byte> readOnlySequence)
        {
            // Separate method because Span/ReadOnlySpan cannot be used in async methods
            ReadOnlySpan<byte> span = readOnlySequence.IsSingleSegment ? readOnlySequence.First.Span : readOnlySequence.ToArray().AsSpan();
            results.Add(Encoding.UTF8.GetString(span));
        }
    }
}
