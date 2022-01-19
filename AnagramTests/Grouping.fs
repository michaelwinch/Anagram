module AnagramTests.Grouping
open NUnit.Framework

[<Test>]
let ``Empty input should not error`` () =
    let actual = Program.groupAnagrams []
    let expected = List.empty<string list>
    Assert.AreEqual (expected, actual)

[<Test>]
let ``Non matching words should be in different groups`` () =
    let actual = Program.groupAnagrams ["qwe"; "asd"]
    let expected = [["qwe"]; ["asd"]]
    Assert.AreEqual (expected, actual)

[<Test>]
let ``Matching words should be in the same group`` () =
    let actual = Program.groupAnagrams ["qwe"; "ewq"]
    let expected = [["qwe"; "ewq"]]
    Assert.AreEqual (expected, actual)

[<Test>]
let ``Matching words should be correctly grouped when preceded by a non matching word`` () =
    let actual = Program.groupAnagrams ["asd"; "qwe"; "ewq"]
    let expected = [["asd"]; ["qwe"; "ewq"]]
    Assert.AreEqual (expected, actual)

[<Test>]
let ``Matching words should be correctly grouped when followed by a non matching word`` () =
    let actual = Program.groupAnagrams ["qwe"; "ewq"; "asd"]
    let expected = [["qwe"; "ewq"]; ["asd"]]
    Assert.AreEqual (expected, actual)

[<Test>]
let ``Matching words should be correctly grouped when separated by a non matching word`` () =
    let actual = Program.groupAnagrams ["qwe"; "asd"; "ewq"]
    let expected = [["qwe"; "ewq"]; ["asd"]]
    Assert.AreEqual (expected, actual)