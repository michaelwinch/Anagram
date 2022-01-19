module CommandLine

open CommandLine

type ExitCode =
    | Success = 0
    | FailedParsingArguments = 1

type Settings =
    {
        [<CommandLine.Option(Required = true)>]
        FilePath: string
    }

let parse argv =
    match Parser.Default.ParseArguments<Settings> argv with
    | :? Parsed<Settings> as parsed -> Result.Ok parsed.Value
    | :? NotParsed<Settings>
    | _ -> Result.Error ()