open System
open System.IO

let groupAnagrams (words: string list) =
    words
    |> Seq.groupBy (Seq.sort >> String.Concat)
    |> Seq.map snd

let outputGroups = Seq.iter (String.concat "," >> printfn "%s\n")

let groupAnagramsAndOutput = groupAnagrams >> outputGroups

let run (filePath: string) =
    use reader = new StreamReader(filePath)
    let rec loop characterLength words =
        if reader.Peek() = -1 then
            groupAnagramsAndOutput words
        else
            let nextWord = reader.ReadLine()
            match characterLength with
            | None ->
                loop (String.length nextWord |> Some) [nextWord]
            | Some x when x = String.length nextWord ->
                loop characterLength (nextWord::words)
            | Some _ ->
                groupAnagramsAndOutput words
                loop (String.length nextWord |> Some) [nextWord]
    loop None []


[<EntryPoint>]
let main argv =
    match CommandLine.parse argv with
    | Result.Ok settings ->
        run settings.FilePath
        int CommandLine.ExitCode.Success
    | Result.Error _ ->
        int CommandLine.ExitCode.FailedParsingArguments