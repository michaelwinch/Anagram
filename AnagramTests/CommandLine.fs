module AnagramTests.CommandLine
open NUnit.Framework

[<Test>]
let ``File path should be correctly parsed`` () =
    let filePath = @"C:\test"
    let actual = CommandLine.parse ["--filepath"; filePath]
    let expected : Result<CommandLine.Settings, unit> = Result.Ok { FilePath = filePath }
    Assert.AreEqual (expected, actual)

[<Test>]
let ``Error is thrown when file path is not provided`` () =
    let actual = CommandLine.parse []
    let expected : Result<CommandLine.Settings, unit> = Result.Error ()
    Assert.AreEqual (expected, actual)

[<Test>]
let ``Error is thrown when file path is empty`` () =
    let actual = CommandLine.parse ["--filePath"; ""]
    let expected : Result<CommandLine.Settings, unit> = Result.Error ()
    Assert.AreEqual (expected, actual)
