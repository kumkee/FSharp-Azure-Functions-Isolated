namespace My.Function

open Microsoft.Azure.Functions.Worker
open Microsoft.Extensions.Logging
open Microsoft.Azure.Functions.Worker.Http
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Http.Extensions
open System.Net

type Execute(logger: ILogger<Execute>, reqHttp: HttpRequest) =

    [<Function("Execute")>]
    member _.Run
        ([<HttpTrigger(AuthorizationLevel.Function, "get")>] req:
            HttpRequestData)
        =
        task {
            logger.LogInformation
                $"Hello at {System.DateTime.UtcNow} from an Azure function using F# on .NET 8."

            let response = req.CreateResponse(HttpStatusCode.OK)
            let url = reqHttp.GetDisplayUrl ()
            do! response.WriteStringAsync <| "Hello World " + url
            return response
        }
